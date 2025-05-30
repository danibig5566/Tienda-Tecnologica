<template> 
  <div>
    <div class="container">
      <div v-for="(productos, categoriaNombre) in productosPorCategoria" :key="categoriaNombre">
        <h2 class="categoria-titulo">{{ categoriaNombre }}</h2>
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
    </div>

    <div class="icon-carousel-wrapper">
      <div class="icon-carousel" ref="carousel">
        <div 
          v-for="(icon, index) in iconos" 
          :key="index" 
          class="icon-item"
        >
          <img :src="icon" alt="icon" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'BodyInicio',
  data() {
    return {
      productosPorCategoria: {},
      iconos: [
        '/icons8-apple-logo-90.png',
        '/icons8-asus-90.png',
        '/icons8-epson-80.png',
        '/icons8-hp-50.png',
        '/icons8-microsoft-90.png',
        '/icons8-nintendo-switch-80.png',
        '/icons8-samsung-90.png',
        '/icons8-xbox-90.png'
      ],
      slideInterval: null,
    };
  },
  async mounted() {
    await this.cargarProductosAgrupados();
    this.iniciarCarrusel();
  },
  beforeDestroy() {
    clearInterval(this.slideInterval);
  },
  methods: {
    async cargarProductosAgrupados() {
      try {
        const [productosRes, categoriasRes] = await Promise.all([
          axios.get('http://localhost:5041/api/Products'),
          axios.get('http://localhost:5041/api/Categoria')
        ]);

        const productos = productosRes.data;
        const categorias = categoriasRes.data;

        const agrupados = {};

        categorias.forEach(categoria => {
          const productosFiltrados = productos.filter(p => p.categoriasId === categoria.id);
          const productosAleatorios = this.obtenerProductosAleatorios(productosFiltrados, 5);
          if (productosAleatorios.length > 0) {
            agrupados[categoria.nombre] = productosAleatorios;
          }
        });

        this.productosPorCategoria = agrupados;

      } catch (error) {
        console.error('Error al cargar productos o categorías:', error);
      }
    },
    obtenerProductosAleatorios(array, cantidad) {
      const mezclado = array.sort(() => 0.5 - Math.random());
      return mezclado.slice(0, cantidad);
    },
    accionProducto(producto) {
      const carrito = JSON.parse(localStorage.getItem('carrito')) || [];
      carrito.push(producto);
      localStorage.setItem('carrito', JSON.stringify(carrito));
      alert(`${producto.nombre} agregado al carrito.`);
    },
    iniciarCarrusel() {
      const carousel = this.$refs.carousel;
      const totalItems = this.iconos.length;
      let currentIndex = 0;

      this.slideInterval = setInterval(() => {
        currentIndex++;
        if (currentIndex >= totalItems) currentIndex = 0;
        carousel.style.transform = `translateX(-${currentIndex * 110}px)`;
      }, 2500);
    }
  }
};
</script>

<style scoped>
.container {
  padding: 20px;
}
.categoria-titulo {
  font-size: 1.6rem;
  margin-top: 40px;
  margin-bottom: 20px;
  color: #333;
}
.grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
  gap: 20px;
}
.card {
  background: #ffffff;
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
  background: #ffffff;
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
.icon-carousel-wrapper {
  overflow: hidden;
  width: 580px;
  margin: 40px auto 0;
}
.icon-carousel {
  display: flex;
  transition: transform 0.5s ease;
}
.icon-item {
  flex: 0 0 100px;
  margin: 0 5px;
  display: flex;
  justify-content: center;
  align-items: center;
}
.icon-item img {
  width: 60px;
  height: 60px;
  object-fit: contain;
  user-select: none;
}
</style>