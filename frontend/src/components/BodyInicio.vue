<script>
export default {
  name: 'BodyInicio',
  data() {
    return {
      currentSlide: 0,
      productos: [
        {
          id: 1,
          nombre: 'Sony Playstation 4',
          precio: 1219000,
          imagen: new URL('../assets/img/play-img1.jpg', import.meta.url).href,
          descripcion: 'Procesador especial de chip único CPU: x86-64 AMD "Jaguar", 8 núcleos GPU: 1.84 TFLOPS, motor gráfico basado en AMD Radeon'
        },
        {
          id: 2,
          nombre: 'Playstation 2',
          precio: 800000,
          imagen: new URL('../assets/img/play-img3.jpg', import.meta.url).href
        },
        {
          id: 3,
          nombre: "Assassin's Creed: Valhalla",
          precio: 213900,
          imagen: new URL('../assets/img/D_NQ_NP_662308-MCO44219443194_122020-O.webp', import.meta.url).href
        },
        {
          id: 4,
          nombre: 'Impresora multifuncional Epson',
          precio: 1070000,
          imagen: new URL('../assets/img/impresora.jpg', import.meta.url).href
        },
        {
          id: 5,
          nombre: 'Tecno Spark 20 Pro Plus',
          precio: 999990,
          imagen: new URL('../assets/img/celular-img1.jpg', import.meta.url).href
        },
        {
          id: 6,
          nombre: 'iPhone 11',
          precio: 1900000,
          imagen: new URL('../assets/img/celular-img4.jpg', import.meta.url).href
        },
        {
          id: 7,
          nombre: 'Lenovo Ideapad',
          precio: 604211,
          imagen: new URL('../assets/img/lapto-img1.jpg', import.meta.url).href
        },
        {
          id: 8,
          nombre: 'Computador HG01251 Intel Core i5',
          precio: 1980000,
          imagen: new URL('../assets/img/computadores-img3.jpg', import.meta.url).href
        }
      ],
      marcas: [
        { src: new URL('../assets/img/icons8-samsung-90.png', import.meta.url).href, alt: 'Samsung' },
        { src: new URL('../assets/img/icons8-apple-logo-90.png', import.meta.url).href, alt: 'Apple' },
        { src: new URL('../assets/img/icons8-asus-90.png', import.meta.url).href, alt: 'Asus' },
        { src: new URL('../assets/img/icons8-xbox-90.png', import.meta.url).href, alt: 'Xbox' },
        { src: new URL('../assets/img/icons8-microsoft-90.png', import.meta.url).href, alt: 'Microsoft' },
        { src: new URL('../assets/img/icons8-nintendo-switch-80.png', import.meta.url).href, alt: 'Nintendo' },
        { src: new URL('../assets/img/5375-playstation_102558 (1).png', import.meta.url).href, alt: 'PlayStation' },
        { src: new URL('../assets/img/icons8-epson-80.png', import.meta.url).href, alt: 'Epson' },
        { src: new URL('../assets/img/icons8-hp-80.png', import.meta.url).href, alt: 'HP' }
      ],
      slides: [
        { src: new URL('../assets/img/IMG1.png', import.meta.url).href, alt: 'img1' },
        { src: new URL('../assets/img/IMG2.jpg', import.meta.url).href, alt: 'img2' },
        { src: new URL('../assets/img/IMG3.png', import.meta.url).href, alt: 'img3' }
      ]
    };
  },
  mounted() {
    this.startAutoSlide();
  },
  beforeUnmount() {
    this.stopAutoSlide();
  },
  methods: {
    añadirAlCarrito(producto) {
      let carrito = JSON.parse(localStorage.getItem('carrito') || '[]');
      const existente = carrito.find(p => p.id === producto.id);

      if (existente) {
        existente.cantidad += 1;
      } else {
        carrito.push({
          id: producto.id,
          nombre: producto.nombre,
          imagenUrl: producto.imagen,
          precio: producto.precio,
          descripcion: producto.descripcion,
          cantidad: 1
        });
      }

      localStorage.setItem('carrito', JSON.stringify(carrito));
      alert(`"${producto.nombre}" fue añadido al carrito.`);
    },
    nextSlide() {
      this.currentSlide = (this.currentSlide + 1) % this.slides.length;
    },
    prevSlide() {
      this.currentSlide = (this.currentSlide - 1 + this.slides.length) % this.slides.length;
    },
    startAutoSlide() {
      this.autoplayInterval = setInterval(() => {
        this.nextSlide();
      }, 5000);
    },
    stopAutoSlide() {
      clearInterval(this.autoplayInterval);
    },
    formatPrecio(precio) {
      return precio.toLocaleString('es-CO');
    }
  }
};
</script>

<template>
  <div>
    <main>
      <!-- Carrusel simplificado -->
      <div class="carrusel">
        <div class="carousel-container">
          <!-- Imágenes del carrusel -->
          <div class="carousel-slides">
            <div v-for="(slide, index) in slides" :key="index"
              :class="['carousel-slide', { active: index === currentSlide }]">
              <img :src="slide.src" :alt="slide.alt" />
            </div>
          </div>

          <!-- Overlay con texto y botón -->
          <div class="fotos-overlay">
            <div class="overlay-text">¡Disponible Ahora!</div>
            <button class="buy-button">Comprar Ahora</button>
          </div>

          <!-- Botones de navegación -->
          <button class="carousel-control prev-btn" @click="prevSlide">
            &#10094;
          </button>
          <button class="carousel-control next-btn" @click="nextSlide">
            &#10095;
          </button>

          <!-- Indicadores -->
          <div class="carousel-indicators">
            <button v-for="(slide, index) in slides" :key="'ind-' + index"
              :class="['indicator', { active: index === currentSlide }]" @click="currentSlide = index"></button>
          </div>
        </div>
      </div>

      <!-- Productos destacados -->
      <section class="Productos_destacados">
        <h2>___________Productos Destacados____________</h2>
        <div class="contenedor" id="lista-productos">
          <div class="producto_des" v-for="producto in productos" :key="producto.id">
            <img :src="producto.imagen" :alt="producto.nombre" />
            <div class="info">
              <h3>{{ producto.nombre }}</h3>
              <div class="descripcion">
                <p>{{ producto.descripcion }}</p>
              </div>
              <div class="precio">
                <p>{{ formatPrecio(producto.precio) }}</p>
              </div>
              <button class="agregar-carrito" @click="añadirAlCarrito(producto)">Agregar al carrito</button>
            </div>
          </div>
        </div>
      </section>

      <!-- Marcas -->
      <div class="contenedor-marca">

        <div class="marca-track">
          <div class="marca" v-for="marca in marcas" :key="marca.alt">
            <img :src="marca.src" :alt="marca.alt" />
          </div>
        </div>
      </div>
    </main>
  </div>
</template>



<style scoped>
.carrusel {
  max-width: 100%;
  position: relative;
  overflow: hidden;
  margin-bottom: 2rem;
}

.carousel-container {
  position: relative;
  height: 500px;
}

.carousel-slides {
  width: 100%;
  height: 100%;
  position: relative;
}

.carousel-slide {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  opacity: 0;
  transition: opacity 0.5s ease;
  display: none;
}

.carousel-slide.active {
  opacity: 1;
  display: block;
}

.carousel-slide img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}


.carousel-control {
  position: absolute;
  top: 50%;
  transform: translateY(-50%);
  background-color: rgba(0, 0, 0, 0.5);
  color: white;
  border: none;
  width: 40px;
  height: 40px;
  border-radius: 50%;
  font-size: 18px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  z-index: 10;
}

.prev-btn {
  left: 10px;
}

.next-btn {
  right: 10px;
}

.carousel-indicators {
  position: absolute;
  bottom: 20px;
  left: 50%;
  transform: translateX(-50%);
  display: flex;
  gap: 8px;
  z-index: 10;
}

.indicator {
  width: 12px;
  height: 12px;
  border-radius: 50%;
  background-color: rgba(255, 255, 255, 0.5);
  border: none;
  cursor: pointer;
}

.indicator.active {
  background-color: white;
}


.fotos-overlay {
  position: absolute;
  top: 50%;
  left: 10%;
  transform: translateY(-50%);
  color: white;
  z-index: 10;
  text-shadow: 2px 2px 5px rgba(0, 0, 0, 0.7);
}

.overlay-text {
  font-size: 2.5rem;
  font-weight: bold;
  margin-bottom: 1rem;
}

.buy-button {
  padding: 10px 20px;
  background-color: #007bff;
  border: none;
  color: white;
  font-size: 1rem;
  border-radius: 5px;
  cursor: pointer;
}


.Productos_destacados {
  padding: 3rem 1rem;
  background-color: #ffffff;
  text-align: center;
}

.Productos_destacados h2 {
  font-size: 2rem;
  margin-bottom: 1rem;
}

.Productos_destacados p {
  font-size: 1rem;
  margin-bottom: 2rem;
}

.contenedor {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 1.5rem;
}

.producto_des {
  background-color: #b9b4b4;
  border-radius: 10px;
  width: 250px;
  padding: 1rem;
  text-align: center;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
  transition: transform 0.2s;
}

.producto_des:hover {
  transform: translateY(-5px);
}

.producto_des img {
  width: 100%;
  height: 200px;
  object-fit: contain;
}

.info h3 {
  margin: 1rem 0 0.5rem;
  font-size: 1.2rem;
  height: 2.5em;
  overflow: hidden;
}

.precio p {
  font-size: 1.1rem;
  font-weight: bold;
  color: #333;
  margin: 0.5rem 0;
}

.agregar-carrito {
  margin-top: 1rem;
  background-color: #007bff;
  color: white;
  border: none;
  padding: 10px;
  width: 100%;
  border-radius: 5px;
  cursor: pointer;
}

.agregar-carrito:hover {
  background-color: #0056b3;
}


.contenedor-marca {
  padding: 3rem 1rem;
  background-color: #ffffff;
  text-align: center;
}

.contenedor-marca h2 {
  font-size: 1.5rem;
  margin-bottom: 2rem;
}

.marca-track {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-wrap: wrap;
  gap: 2rem;
}

.marca img {
  width: 80px;
  height: auto;
  transition: transform 0.3s;
}

.marca img:hover {
  transform: scale(1.1);
}


@media (max-width: 768px) {
  .carousel-container {
    height: 300px;
  }

  .overlay-text {
    font-size: 1.8rem;
  }
}

@media (max-width: 480px) {
  .carousel-container {
    height: 200px;
  }

  .overlay-text {
    font-size: 1.5rem;
  }

  .fotos-overlay {
    left: 5%;
  }
}
</style>