<template>
  <div class="carrito-container">
    <h1 class="titulo">🛒 Carrito de Compras</h1>

    <div v-if="carrito.length > 0">
      <form class="formulario-carrito">
        <div v-for="item in carrito" :key="item.id" class="item-carrito">
          <img :src="item.imagenUrl" alt="producto" class="imagen-producto" />
          <div class="detalle-producto">
            <h2>{{ item.nombre }}</h2>
            <p>Precio: ${{ item.precio.toFixed(2) }}</p>
            <label>Cantidad:</label>
            <input
              type="number"
              min="1"
              v-model.number="item.cantidad"
              @change="guardarCarrito"
            />
          </div>
          <div class="subtotal">
            Subtotal: ${{ (item.precio * item.cantidad).toFixed(2) }}
          </div>
        </div>
      </form>

      <div class="acciones-carrito">
        <strong class="total">Total: ${{ total }}</strong>
        <div class="botones-carrito">
          <button @click="vaciarCarrito" class="btn btn-rojo">Vaciar carrito</button>
          <button @click="comprar" class="btn btn-verde">Comprar</button>
        </div>
      </div>
    </div>

    <div v-else class="carrito-vacio">
      <p>Tu carrito está vacío.</p>
    </div>

    <div v-if="showLoginModal" class="modal-overlay">
      <div class="modal">
        <h3>Iniciar Sesión</h3>
        <input v-model="nombreUsuario" placeholder="Nombre de usuario" />
        <input v-model="contrasena" type="password" placeholder="Contraseña" />
        <button @click="login">Iniciar sesión</button>
        <button @click="showLoginModal = false">Cancelar</button>
      </div>
    </div>

    <div v-if="mensajeCompra" class="modal-overlay">
      <div class="modal exito-compra">
        <div class="check-icon">✔️</div>
        <h3>¡Gracias por tu compra, {{ usuario.nombre }}!</h3>
        <p>Total pagado: ${{ total }}</p>
        <button @click="mensajeCompra = false">Cerrar</button>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'BodyCarrito',
  data() {
    return {
      carrito: JSON.parse(localStorage.getItem('carrito') || '[]'),
      showLoginModal: false,
      mensajeCompra: false,
      nombreUsuario: '',
      contrasena: '',
      usuario: JSON.parse(localStorage.getItem('usuario') || 'null')
    };
  },
  computed: {
    total() {
      return this.carrito
        .reduce((sum, item) => sum + item.precio * item.cantidad, 0)
        .toFixed(2);
    }
  },
  methods: {
    guardarCarrito() {
      localStorage.setItem('carrito', JSON.stringify(this.carrito));
    },
    vaciarCarrito() {
      localStorage.removeItem('carrito');
      this.carrito = [];
    },
    async comprar() {
      if (!this.usuario) {
        this.showLoginModal = true;
      } else {
        const resumenCompra = {
          usuario: this.usuario.nombre,
          productos: this.carrito.map(item => ({
            id: item.id,
            nombre: item.nombre,
            cantidad: item.cantidad,
            precio: item.precio,
            subtotal: (item.precio * item.cantidad).toFixed(2)
          })),
          total: this.total
        };
        console.log('🧾 Resumen de la compra:', resumenCompra);
        this.mensajeCompra = true;
        this.vaciarCarrito();
      }
    },
    async login() {
      if (this.usuario) {
        alert("Ya hay una sesión activa.");
        return;
      }

      try {
        const response = await axios.get('http://localhost:5041/api/usuarios');
        const usuarios = response.data;

        const usuarioEncontrado = usuarios.find(
          user =>
            user.nombre === this.nombreUsuario &&
            user.contraseña === this.contrasena
        );

        if (usuarioEncontrado) {
          localStorage.setItem('usuario', JSON.stringify(usuarioEncontrado));
          this.usuario = usuarioEncontrado;
          this.showLoginModal = false;
          this.comprar();
        } else {
          alert("Credenciales incorrectas.");
        }
      } catch (error) {
        console.error("Error al autenticar:", error);
        alert("Error al conectar con el servidor.");
      }
    },
    cerrarSesion() {
      localStorage.removeItem('usuario');
      this.usuario = null;
      alert("Sesión cerrada correctamente.");
    }
  }
};
</script>

<style scoped>
.carrito-container {
  max-width: 900px;
  margin: 40px auto;
  padding: 30px;
  background-color: #ffffff;
  border-radius: 12px;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
  font-family: 'Segoe UI', sans-serif;
}

.titulo {
  text-align: center;
  font-size: 2.2rem;
  margin-bottom: 30px;
  color: #2c3e50;
}

.usuario-sesion {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 20px;
  background-color: #ecf0f1;
  padding: 12px 20px;
  border-radius: 10px;
  color: #2c3e50;
  font-size: 1rem;
}

.btn-logout {
  background-color: #e74c3c;
  color: white;
  border: none;
  padding: 8px 16px;
  border-radius: 6px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.btn-logout:hover {
  background-color: #c0392b;
}

.formulario-carrito {
  border-top: 1px solid #e0e0e0;
}

.item-carrito {
  display: flex;
  gap: 20px;
  align-items: flex-start;
  padding: 20px 0;
  border-bottom: 1px solid #f1f1f1;
}

.imagen-producto {
  width: 100px;
  height: 100px;
  object-fit: cover;
  border-radius: 10px;
  border: 1px solid #ddd;
  background-color: #f8f9fa;
}

.detalle-producto {
  flex: 1;
}

.detalle-producto h2 {
  font-size: 1.1rem;
  margin-bottom: 6px;
  color: #2c3e50;
}

.detalle-producto p {
  margin-bottom: 6px;
  color: #555;
}

.detalle-producto label {
  display: block;
  font-size: 0.9rem;
  color: #666;
  margin-bottom: 4px;
}

.detalle-producto input[type='number'] {
  width: 60px;
  padding: 5px;
  border: 1px solid #ccc;
  border-radius: 6px;
  font-size: 0.9rem;
}

.subtotal {
  font-weight: 600;
  font-size: 1rem;
  color: #2c3e50;
  min-width: 160px;
  text-align: right;
  padding-top: 10px;
}

.acciones-carrito {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-top: 30px;
  border-top: 1px solid #e0e0e0;
  padding-top: 20px;
}

.total {
  font-size: 1.4rem;
  color: #27ae60;
}

.botones-carrito {
  display: flex;
  gap: 12px;
}

.btn {
  padding: 10px 20px;
  font-size: 1rem;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  color: #fff;
  transition: background-color 0.3s ease;
}

.btn-rojo {
  background-color: #e74c3c;
}

.btn-rojo:hover {
  background-color: #c0392b;
}

.btn-verde {
  background-color: #2ecc71;
}

.btn-verde:hover {
  background-color: #27ae60;
}

.carrito-vacio {
  text-align: center;
  padding: 50px 0;
  font-size: 1.2rem;
  color: #888;
}

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.modal {
  background-color: white;
  padding: 30px;
  border-radius: 12px;
  width: 320px;
  box-shadow: 0 8px 25px rgba(0, 0, 0, 0.2);
  display: flex;
  flex-direction: column;
  gap: 15px;
}

.modal h3 {
  margin: 0;
  font-size: 1.4rem;
  color: #2c3e50;
}

.modal input {
  padding: 10px;
  font-size: 1rem;
  border: 1px solid #ccc;
  border-radius: 8px;
}

.modal button {
  padding: 10px;
  font-size: 1rem;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.modal button:first-of-type {
  background-color: #3498db;
  color: white;
}

.modal button:first-of-type:hover {
  background-color: #2980b9;
}

.modal button:last-of-type {
  background-color: #bdc3c7;
  color: white;
}

.modal button:last-of-type:hover {
  background-color: #95a5a6;
}

.exito-compra {
  text-align: center;
  padding: 40px;
  max-width: 400px;
}

.check-icon {
  font-size: 3rem;
  color: #2ecc71;
  margin-bottom: 10px;
}

.exito-compra h3 {
  color: #2c3e50;
  font-size: 1.5rem;
  margin-bottom: 10px;
}

.exito-compra p {
  font-size: 1.1rem;
  margin-bottom: 20px;
  color: #555;
}
</style>
