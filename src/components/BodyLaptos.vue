<script>
import axios from 'axios';
export default {
  name: 'BodyLaptos',
  data() {
    return {
      productos: [],
    };
  },
  mounted() {
    this.cargarProductosPorCategoria(1);
  },
  methods: {
    async cargarProductosPorCategoria(idCategoria) {
      try {
        const res = await axios.get('http://localhost:5041/api/Products');
        const todosLosProductos = res.data;
        this.productos = todosLosProductos.filter(p => p.categoriasId === idCategoria);
      } catch (error) {
        console.error("Error al cargar productos:", error);
      }
    },
    accionProducto(producto) {
      console.log('Producto seleccionado:', producto);
      const carrito = JSON.parse(localStorage.getItem('carrito')) || [];
      carrito.push(producto);
      localStorage.setItem('carrito', JSON.stringify(carrito));
      alert(`${producto.nombre} agregado al carrito.`);
    }
  }
}
</script>
<template>
  <div class="container">
    <div class="grid">
      <div class="card" v-for="producto in productos" :key="producto.id">
        <img :src="producto.imagenUrl" :alt="producto.nombre" />
        <div class="card-body">
          <h2 class="card-title">{{ producto.nombre }}</h2>
          <p class="card-description">{{ producto.descripcion }}</p>
          <p class="card-price">$ {{ producto.precio.toLocaleString() }}</p>
          <span class="card-category">{{ producto.categorias?.nombre || 'Sin categoría' }}</span>
          <button class="card-button" @click="accionProducto(producto)">
            Agregar al carrito
          </button>
        </div>
      </div>
    </div>
  </div>

</template>
<style scoped>
.container {
  padding: 20px;
}

.grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
  gap: 20px;
}

.card {
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
  overflow: hidden;
  display: flex;
  flex-direction: column;
}

.card img {
  width: 100%;
  height: 180px;
  object-fit: cover;
}

.card-body {
  padding: 15px;
}

.card-title {
  font-size: 1.2rem;
  margin-bottom: 10px;
}

.card-description {
  font-size: 0.9rem;
  color: #555;
  margin-bottom: 10px;
}

.card-price {
  font-weight: bold;
  margin-bottom: 10px;
}

.card-category {
  display: inline-block;
  background: #e0e0e0;
  border-radius: 5px;
  padding: 3px 8px;
  font-size: 0.8rem;
  margin-bottom: 10px;
}

.card-button {
  padding: 10px;
  border: none;
  background: #28a745;
  color: white;
  border-radius: 5px;
  cursor: pointer;
}

.card-button:hover {
  background: #218838;
}
</style>