<template>
    <div class="max-w-4xl mx-auto p-6 bg-white shadow-md rounded-md">
      <h1 class="text-3xl font-semibold mb-6 text-center">🛒 Carrito de Compras</h1>
  
      <div v-if="carrito.length > 0">
        <form class="space-y-4">
          <div
            v-for="item in carrito"
            :key="item.id"
            class="flex items-center border-b pb-4 mb-4"
          >
            <img :src="item.imagenUrl" alt="producto" class="w-20 h-20 object-cover rounded mr-4" />
            <div class="flex-1">
              <h2 class="text-lg font-medium">{{ item.nombre }}</h2>
              <p class="text-gray-600 mb-1">Precio: ${{ item.precio.toFixed(2) }}</p>
  
              <label class="block text-sm text-gray-500">Cantidad:</label>
              <input
                type="number"
                min="1"
                v-model.number="item.cantidad"
                @change="guardarCarrito"
                class="mt-1 w-24 p-1 border rounded"
              />
            </div>
            <div class="text-right font-semibold">
              Subtotal: ${{ (item.precio * item.cantidad).toFixed(2) }}
            </div>
          </div>
        </form>
  
        <div class="flex justify-between items-center mt-6">
          <strong class="text-xl">Total: ${{ total }}</strong>
          <div class="flex gap-2">
            <button
              @click="vaciarCarrito"
              class="bg-red-600 text-white px-4 py-2 rounded hover:bg-red-700"
            >
              Vaciar carrito
            </button>
            <button
              @click="comprar"
              class="bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700"
            >
              Comprar
            </button>
          </div>
        </div>
      </div>
  
      <div v-else class="text-center text-gray-500">
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
input[type='number']::-webkit-inner-spin-button {
  opacity: 1;
}

img {
  background-color: #f4f4f4;
  border: 1px solid #ddd;
  padding: 4px;
}

form {
  border-top: 1px solid #e5e7eb;
}

.flex.items-center {
  align-items: flex-start;
  gap: 1rem;
}

input[type='number'] {
  width: 60px;
  text-align: center;
  border: 1px solid #ccc;
  font-size: 0.9rem;
}

.text-right {
  min-width: 120px;
  text-align: right;
  padding-top: 0.5rem;
  font-size: 0.95rem;
  color: #1a1a1a;
}

h2 {
  font-size: 1.1rem;
  margin-bottom: 0.2rem;
  color: #1f2937;
}

.text-gray-600 {
  font-size: 0.95rem;
}

button {
  transition: background-color 0.2s ease-in-out;
}
</style>


  
  