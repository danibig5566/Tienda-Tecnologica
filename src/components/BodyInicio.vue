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
          imagen: '../assets/img/play-img1.jpg'
        },
        {
          id: 2,
          nombre: 'Playstation 2',
          precio: 800000,
          imagen: '../assets/img/play-img3.jpg'
        },
        {
          id: 3,
          nombre: "Assassin's Creed: Valhalla",
          precio: 213900,
          imagen: '../assets/img/D_NQ_NP_662308-MCO44219443194_122020-O.webp'
        },
        {
          id: 4,
          nombre: 'Impresora multifuncional Epson',
          precio: 1070000,
          imagen: '../assets/img/impresora.jpg'
        },
        {
          id: 5,
          nombre: 'Tecno Spark 20 Pro Plus',
          precio: 999990,
          imagen: '../assets/img/celular-img1.jpg'
        },
        {
          id: 6,
          nombre: 'iPhone 11',
          precio: 1900000,
          imagen: '../assets/img/celular-img3.jpg'
        },
        {
          id: 7,
          nombre: 'Lenovo Ideapad',
          precio: 604211,
          imagen: '../assets/img/lapto-img1.jpg'
        },
        {
          id: 8,
          nombre: 'Computador HG01251 Intel Core i5',
          precio: 1980000,
          imagen: '../assets/img/computadores-img3.jpg'
        }
      ],
      marcas: [
        { src: '../assets/img/icons8-samsung-90.png', alt: 'Samsung' },
        { src: '../assets/img/icons8-apple-logo-90.png', alt: 'Apple' },
        { src: '../assets/img/icons8-asus-90.png', alt: 'Asus' },
        { src: '../assets/img/icons8-xbox-90.png', alt: 'Xbox' },
        { src: '../assets/img/pngwing.com (4).png', alt: 'PlayStation' },
        { src: '../assets/img/icons8-microsoft-90.png', alt: 'Microsoft' },
        { src: '../assets/img/icons8-nintendo-switch-80.png', alt: 'Nintendo' },
        { src: '../assets/img/5375-playstation_102558 (1).png', alt: 'PlayStation 2' },
        { src: '../assets/img/icons8-epson-80.png', alt: 'Epson' },
        { src: '../assets/img/icons8-hp-80.png', alt: 'HP' }
      ],
      slides: [
        { src: '../assets/img/IMG1.png', alt: 'img1' },
        { src: '../assets/img/IMG2.jpg', alt: 'img2' },
        { src: '../assets/img/IMG3.png', alt: 'img3' }
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
    agregarAlCarrito(producto) {
      console.log('Agregado al carrito:', producto);
      this.$emit('agregar-al-carrito', producto);
    },
    
    // Métodos de carrusel simplificados y corregidos
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
    
    // Método para formatear precios
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
          <div 
            v-for="(slide, index) in slides" 
            :key="index"
            :class="['carousel-slide', { active: index === currentSlide }]"
          >
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
          <button 
            v-for="(slide, index) in slides" 
            :key="'ind-'+index"
            :class="['indicator', { active: index === currentSlide }]"
            @click="currentSlide = index"
          ></button>
        </div>
      </div>
    </div>

    <!-- Productos destacados -->
    <section class="Productos_destacados">
      <h2>Productos Destacados</h2>
      <p>Obtenga productos originales de la mejor calidad y al mejor precio</p>
      <div class="contenedor" id="lista-productos">
        <div class="producto_des" v-for="producto in productos" :key="producto.id">
          <img :src="producto.imagen" :alt="producto.nombre" />
          <div class="info">
            <h3>{{ producto.nombre }}</h3>
            <div class="precio">
              <p>{{ formatPrecio(producto.precio) }}</p>
            </div>
            <button class="agregar-carrito" @click="agregarAlCarrito(producto)">agregar al carrito</button>
          </div>
        </div>
      </div>
    </section>
    
    <!-- Marcas -->
    <div class="contenedor-marca">
      <h2>MARCAS QUE COMERCIALIZAMOS</h2>
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

/* Indicadores */
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
  background-color: #fcb66a;
  border-radius: 10px;
  width: 250px;
  padding: 1rem;
  text-align: center;
  box-shadow: 0 0 10px rgba(0,0,0,0.1);
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

/* Estilos para marcas - manteniendo los nombres originales */
.contenedor-marca {
  padding: 3rem 1rem;
  background-color: #f0bf5c;
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

/* Responsive */
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