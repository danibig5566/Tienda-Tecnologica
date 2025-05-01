<template>
  <div class="contenedor-cartas" id="listas-cartas">
    <div class="cartas" v-for="(producto, index) in productos" :key="index">
      <img :src="producto.imagen" :alt="producto.nombre">
      <div class="contenido-cartas">
        <h3>{{ producto.nombre }}</h3>
        <div class="precio">
          <p>{{ producto.precio }}</p>
        </div>
        <p class="descripcion">{{ producto.descripcion }}</p>
        <button
          class="agregar-carrito"
          @click="añadirAlCarrito(producto)"
        >
          Añadir al carrito
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'BodyCelulares',
  data() {
    return {
      productos: [
        {
          id: 1,
          nombre: 'Tecno Spark 20 Pro Plus',
          precio: '$999.990',
          imagen: new URL('../assets/img/celular-img1.jpg', import.meta.url).href,
          descripcion: 'Red: 2G, 3G, 4G. MPX Cámara Principal: 108 Mpx. Cámara Frontal: Sencilla. Peso: 205 gr. Núcleos: 8. Android 14. Batería: 5.000 mAh.'
        },
        {
          id: 2,
          nombre: 'Honor Magic 6 Lite',
          precio: '$1.998.000',
          imagen: new URL('../assets/img/celular-img2.jpg', import.meta.url).href,
          descripcion: 'Nanómetros: 4 nm. Cámara Principal: Triple. Cámara Frontal: Sencilla. Núcleos: 8. Batería: 5.800 mAh. Peso: 185 gr. MPX Frontal: 16 Mpx.'
        },
        {
          id: 3,
          nombre: 'iPhone 11',
          precio: '$1.999.000',
          imagen: new URL('../assets/img/celular-img3.jpg', import.meta.url).href,
          descripcion: 'MPX Principal: 12 Mpx. Red: 2G, 3G, 4G. Memoria: 128 GB. Peso: 194 gr. Batería: 3.110 mAh. iOS 16.'
        },
        {
          id: 4,
          nombre: 'Huawei Nova Y91',
          precio: '$899.900',
          imagen: new URL('../assets/img/celular-img4.jpg', import.meta.url).href,
          descripcion: 'Núcleos: 8. Tamaño: 171.6x79.9x8.9 mm. MPX Frontal: 8 Mpx. Batería: 7.000 mAh. Memoria: 256 GB. Cámara Principal: Doble.'
        }
      ],
      carrito: []
    

    };
  
  },
  methods: {
    limpiarPrecio(precioStr) {
  // Elimina símbolo $ y puntos, y convierte a número
  return parseFloat(precioStr.replace('$', '').replace(/\./g, '').replace(',', '.'));
},
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
      descripcion: producto.descripcion,
      precio: this.limpiarPrecio(producto.precio),
      cantidad: 1
    });
  }

  localStorage.setItem('carrito', JSON.stringify(carrito));
  alert('Producto añadido al carrito');
},

    }
  }

</script>
<style scoped>
.contenedor-cartas {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 20px;
  background-color: #5f5e54;
  padding: 30px;
}

.cartas {
  background-color: #ffffcc;
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0,0,0,0.2);
  width: 250px;
  overflow: hidden;
  transition: transform 0.3s ease;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.cartas:hover {
  transform: scale(1.03);
}

.cartas img {
  width: 100%;
  height: 200px;
  object-fit: contain;
  background-color: white;
  padding: 10px;
}

.contenido-cartas {
  padding: 16px;
  text-align: center;
}

.contenido-cartas h3 {
  font-size: 1.1rem;
  margin-bottom: 8px;
  color: #000;
}

.precio p {
  font-weight: bold;
  margin-bottom: 8px;
}

.descripcion {
  font-size: 0.9rem;
  color: #333;
  margin-bottom: 12px;
}

.agregar-carrito {
  background-color: #e53935;
  color: white;
  border: none;
  padding: 10px 16px;
  border-radius: 8px;
  cursor: pointer;
  font-weight: bold;
  transition: background-color 0.3s;
}

.agregar-carrito:hover {
  background-color: #c62828;
}
</style>


