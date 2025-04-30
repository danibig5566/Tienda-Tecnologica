<script>
export default {
  name: 'EncaBezado',
  data() {
    return {
      showCart: false,
      carrito: [
        // Puedes comenzar con datos de ejemplo para probar
        // { id: 1, nombre: 'Celular X', precio: 299.99, cantidad: 1, imagen: 'ruta.jpg' }
      ]
    }
  },
  computed: {
    totalCarrito() {
      return this.carrito.reduce((total, item) => total + item.precio * item.cantidad, 0).toFixed(2)
    }
  },
  methods: {
    toggleCart() {
      this.showCart = !this.showCart
    },
    vaciarCarrito() {
      this.carrito = []
    }
  }
}
</script>

<template>
  <header class="header">
    <h2>Tienda tecnológica</h2>
    <nav class="menu">
      <ul>
        <li><router-link to="/">Inicio</router-link></li>
        <li class="item">
          Productos
          <ul class="sub-item">
            <li><router-link to="/consolas">Consolas y Accesorios</router-link></li>
            <li><router-link to="/vistacelulares">Celulares</router-link></li>
            <li><router-link to="/computadores">Computadores</router-link></li>
            <li><router-link to="/videojuegos">Video Juegos</router-link></li>
            <li><router-link to="/laptops">Laptops</router-link></li>
            <li><router-link to="/impresoras">Impresoras y Proyectores</router-link></li>
          </ul>
        </li>
        <li><router-link to="/contacto">Contacto</router-link></li>
        <li><router-link to="/pqr">PQR</router-link></li>

        <!-- 🔽 Aquí el nuevo li del carrito -->
        <li>
          <router-link to="/carrito" class="cart-link">
            <i class="fa-solid fa-cart-shopping"></i> Mi Carrito
          </router-link>
        </li>
      </ul>
    </nav>
  </header>
</template>


<style scoped>
.header {
  background-color: #3f6597;
  padding: 1rem 2rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
  color: #000000;
  box-shadow: 0 4px 6px rgba(0,0,0,0.1);
}

.header h2 {
  font-size: 1.8rem;
  font-weight: bold;
  letter-spacing: 1px;
}

.menu {
  display: flex;
  align-items: center;
}

.menu ul {
  list-style: none;
  display: flex;
  gap: 2rem;
  margin: 0;
  padding: 0;
  margin-left: auto; 
}

.menu ul li {
  position: relative;
  padding: 15px 0;
}

.menu ul li a, .menu ul li router-link {
  color: #000000;
  text-decoration: none;
  font-weight: 500;
  font-size: 1rem;
  transition: color 0.3s ease;
}

.menu ul li a:hover, .menu ul li router-link:hover {
  color: #1abc9c;
}


.item {
  position: relative;
  cursor: pointer;
}

.sub-item {
  position: absolute;
  top: 100%; 
  left: 50%; 
  transform: translateX(-50%); 
  background: #ffffff;
  padding: 0.5rem 0;
  border-radius: 0.5rem;
  box-shadow: 0 4px 8px rgba(0,0,0,0.15);
  z-index: 100;
  min-width: 220px;
  opacity: 0;
  visibility: hidden;
  transition: opacity 0.3s ease, visibility 0.3s ease;
}

.item:hover .sub-item {
  opacity: 1;
  visibility: visible;
}

.sub-item li {
  padding: 0.5rem 1rem;
  white-space: nowrap;
}

.sub-item li a {
  color: #000000;
  font-size: 0.95rem;
  display: block;
  padding: 5px 0;
}

.sub-item li a:hover {
  color: #1abc9c;
}


.cart-icon {
  position: relative;
}

#carrito {
  cursor: pointer;
  font-size: 1.5rem;
  position: relative;
}

.fa-cart-shopping {
  font-size: 2rem;
  color: #000;
}

.buy-card {
  position: absolute;
  right: 0;
  top: 100%;
  width: 500px;
  background-color: white;
  border-radius: 8px;
  box-shadow: 0 4px 12px rgba(0,0,0,0.1);
  padding: 15px;
  z-index: 1000;
}

.cart-table {
  width: 100%;
  border-collapse: collapse;
}

.cart-table th {
  text-align: left;
  padding: 10px;
  border-bottom: 1px solid #eee;
}

.lista_de_productos {
  max-height: 200px;
  overflow-y: auto;
}

.total-carrito {
  margin: 15px 0;
  text-align: right;
  font-weight: bold;
  font-size: 1.1rem;
}

.vaciar-btn {
  display: block;
  width: 100%;
  padding: 12px;
  background-color: #f5f5f5;
  border: none;
  border-radius: 50px;
  cursor: pointer;
  font-weight: bold;
  margin-bottom: 10px;
  transition: background-color 0.3s;
}

.vaciar-btn:hover {
  background-color: #e0e0e0;
}

.ver-carrito-btn {
  display: block;
  width: 40%;
  margin: 0 auto;
  padding: 10px;
  background-color: #ffe699;
  border: none;
  border-radius: 50px;
  cursor: pointer;
  font-weight: bold;
  transition: background-color 0.3s;
}

.ver-carrito-btn:hover {
  background-color: #7ebfcf;
}
</style>