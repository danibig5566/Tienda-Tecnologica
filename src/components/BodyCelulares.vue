<template>
    <div class="carousel-container">
      <button class="nav-button left" @click="prevImage">‹</button>
  
      <div class="carousel-image">
        <img :src="imagenes[currentIndex]" alt="Producto" />
      </div>
  
      <button class="nav-button right" @click="nextImage">›</button>
    </div>
  </template>
  
  <script>
  export default {
    name: 'BodyCelulares',  
    data() {
      return {
        imagenes: [
          new URL('../assets/img/celular-img1.jpg', import.meta.url).href,
          new URL('../assets/img/celular-img2.jpg', import.meta.url).href,
          new URL('../assets/img/celular-img3.jpg', import.meta.url).href,
          new URL('../assets/img/celular-img4.jpg', import.meta.url).href
        ],
        currentIndex: 0
      }
    },
    methods: {
      nextImage() {
        this.currentIndex = (this.currentIndex + 1) % this.imagenes.length;
      },
      prevImage() {
        this.currentIndex = (this.currentIndex - 1 + this.imagenes.length) % this.imagenes.length;
      }
    }
  }
  </script>
  
  <style scoped>
  .carousel-container {
    position: relative;
    width: 300px;
    height: 400px;
    margin: auto;
    overflow: hidden;
    background-color: #f5f5f5;
    border-radius: 12px;
    box-shadow: 0 4px 8px rgba(0,0,0,0.2);
  }
  
  .carousel-image img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    border-radius: 12px;
  }
  
  .nav-button {
    position: absolute;
    top: 50%;
    transform: translateY(-50%);
    background-color: #ff4444;
    color: white;
    border: none;
    border-radius: 50%;
    width: 36px;
    height: 36px;
    font-size: 24px;
    cursor: pointer;
    z-index: 10;
  }
  
  .nav-button.left {
    left: 10px;
  }
  
  .nav-button.right {
    right: 10px;
  }
  
  .nav-button:hover {
    background-color: #ff2222;
  }
  </style>
  
  