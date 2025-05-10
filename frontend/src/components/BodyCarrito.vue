<template>
  <div class="carrito-container">
    <h1 class="titulo">🛒 Carrito de Compras</h1>

    <div v-if="carrito.length > 0">
      <form class="formulario-carrito">
        <div
          v-for="item in carrito"
          :key="item.id"
          class="item-carrito"
        >
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
  </div>
</template>

<script>
export default {
  name: 'BodyCarrito',
  data() {
    return {
      carrito: JSON.parse(localStorage.getItem('carrito') || '[]'),
    };
  },
  computed: {
    total() {
      return this.carrito.reduce((sum, item) => sum + item.precio * item.cantidad, 0).toFixed(2);
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
    comprar() {
      alert('¡Gracias por tu compra!');
      this.vaciarCarrito();
    }
  }
};
</script>

<style scoped>
.carrito-container {
  max-width: 800px;
  margin: 30px auto;
  padding: 25px;
  background-color: #fff;
  border-radius: 10px;
  box-shadow: 0 8px 16px rgba(0,0,0,0.1);
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}

.titulo {
  text-align: center;
  font-size: 2rem;
  margin-bottom: 25px;
  color: #333;
}

.formulario-carrito {
  border-top: 1px solid #e0e0e0;
}

.item-carrito {
  display: flex;
  align-items: flex-start;
  gap: 20px;
  border-bottom: 1px solid #eee;
  padding: 20px 0;
}

.imagen-producto {
  width: 80px;
  height: 80px;
  object-fit: cover;
  border-radius: 8px;
  border: 1px solid #ddd;
  background-color: #f9f9f9;
}

.detalle-producto {
  flex: 1;
}

.detalle-producto h2 {
  font-size: 1.1rem;
  margin-bottom: 5px;
  color: #222;
}

.detalle-producto p {
  font-size: 0.95rem;
  color: #666;
  margin-bottom: 6px;
}

.detalle-producto input[type='number'] {
  width: 60px;
  padding: 6px;
  border: 1px solid #ccc;
  border-radius: 5px;
  font-size: 0.9rem;
}

.subtotal {
  min-width: 150px;
  text-align: right;
  padding-top: 8px;
  font-weight: 600;
  color: #444;
}

.acciones-carrito {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-top: 25px;
}

.total {
  font-size: 1.3rem;
  color: #000;
}

.botones-carrito {
  display: flex;
  gap: 10px;
}

.btn {
  padding: 10px 18px;
  font-size: 1rem;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  color: #fff;
  transition: background-color 0.3s ease;
}

.btn-rojo {
  background-color: #e53935;
}

.btn-rojo:hover {
  background-color: #c62828;
}

.btn-verde {
  background-color: #43a047;
}

.btn-verde:hover {
  background-color: #388e3c;
}

.carrito-vacio {
  text-align: center;
  color: #888;
  font-size: 1.1rem;
  padding: 40px 0;
}
</style>
