<template>
  <div class="admin-wrapper">
    <div class="admin-header" @click="toggleAdminPanel">
      <h2>Control y registro de productos</h2>
      <span class="toggle-icon">{{ panelVisible ? '▼' : '►' }}</span>
    </div>
    
    <div class="admin-content" v-if="panelVisible">
      <div class="admin-panel">
        <div class="form-container">
          <h2>{{ producto.id ? 'Actualizar Producto' : 'Registro y control de Productos' }}</h2>
          <form @submit.prevent="producto.id ? actualizarProducto() : agregarProducto()">
            <div class="form-group">
              <label>Nombre:</label>
              <input v-model="producto.Nombre" required />
            </div>
            <div class="form-group">
              <label>Descripción:</label>
              <textarea v-model="producto.Descripcion" required></textarea>
            </div>
            <div class="form-group">
              <label>Precio:</label>
              <input v-model.number="producto.Precio" type="number" min="0" required />
            </div>
            <div class="form-group">
              <label>Cantidad:</label>
              <input v-model.number="producto.Cantidad" type="number" min="0" required />
            </div>

            <div class="form-group">
              <label>URL Imagen:</label>
              <input v-model="producto.ImagenUrl" required />
            </div>
            <div class="form-group">
              <label>Categoría:</label>
              <select v-model.number="producto.CategoriasId" required>
                <option disabled value="">Seleccione una categoría</option>
                <option v-for="cat in categorias" :key="cat.id" :value="cat.id">
                  {{ cat.nombre }}
                </option>
              </select>
            </div>
            <div class="button-group">
              <button type="submit">{{ producto.id ? 'Actualizar' : 'Agregar' }}</button>
              <button type="button" v-if="producto.id" @click="cancelarEdicion">Cancelar</button>
            </div>
          </form>
        </div>


        <div class="productos-seccion">
          <div class="productos-header" @click="toggleProductosVisibles">
            <h3>Productos registrados</h3>
            <span class="toggle-icon">{{ productosVisibles ? '▼' : '►' }}</span>
          </div>

          <div class="productos-container" v-if="productos.length && productosVisibles">
            <div class="producto-card" v-for="prod in productos" :key="prod.id">
              <img :src="prod.imagenUrl" alt="Imagen" />
              <div class="producto-info">
                <h4>{{ prod.nombre }}</h4>
                <p><strong>Precio:</strong> ${{ prod.precio }}</p>
                <p><strong>Descripción:</strong> {{ prod.descripcion }}</p>
                <p><strong>Categoría:</strong> {{ prod.categorias?.nombre }}</p>
                <div class="acciones">
                  <button class="editar" @click="cargarParaEditar(prod)">Editar</button>
                  <button class="eliminar" @click="eliminarProducto(prod.id)">Eliminar</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'BodyAdmin',
  data() {
    return {
      panelVisible: false,
      producto: {
        Nombre: '',
        Descripcion: '',
        Precio: 0,
        Cantidad: 0,
        ImagenUrl: '',
        CategoriasId: null
      },
      productos: [],
      categorias: [],
      productosVisibles: true
    };
  },
  created() {
    this.cargarProductos();
    this.cargarCategorias();
  },
  methods: {
    toggleAdminPanel() {
      this.panelVisible = !this.panelVisible;
    },
    async cargarProductos() {
      const res = await axios.get('http://localhost:5041/api/products');
      this.productos = res.data;
    },
    async cargarCategorias() {
      const res = await axios.get('http://localhost:5041/api/Categoria');
      this.categorias = res.data;
    },
    async agregarProducto() {
      const nuevoProducto = { ...this.producto };
      delete nuevoProducto.id;
      try {
        await axios.post('http://localhost:5041/api/products', nuevoProducto);
        alert('✅ Producto agregado exitosamente.');
        this.resetFormulario();
        this.cargarProductos();
        this.productosVisibles = true;
      } catch (error) {
        alert('error al agregar producto verifique los campos correctamente');
        console.error('error al agregar producto', error)
      }
    },
    async actualizarProducto() {
      try {
        await axios.put(`http://localhost:5041/api/products/${this.producto.id}`, this.producto);
        alert('✅ Producto actualizado exitosamente.');
        this.resetFormulario();
        this.cargarProductos();
      } catch (error) {
        console.error('error al actualizar el producto', error)
      }
    },
    async eliminarProducto(id) {
      if (confirm("¿Estás seguro de eliminar este producto?")) {
        try {
          await axios.delete(`http://localhost:5041/api/products/${id}`);
          alert('🗑️ Producto eliminado exitosamente.');
          this.cargarProductos();
        } catch (error) {
          console.error('error al elimnar el producto', error)
        }
      }
    },
    cargarParaEditar(prod) {
      this.producto = { ...prod };
    },
    cancelarEdicion() {
      this.resetFormulario();
    },
    resetFormulario() {
      this.producto = {
        id: null,
        Nombre: '',
        Descripcion: '',
        Precio: 0,
        Cantidad: 0,
        ImagenUrl: '',
        CategoriasId: null
      };
    },
    toggleProductosVisibles() {
      this.productosVisibles = !this.productosVisibles;
    }
  }
};
</script>

<style scoped>
.admin-wrapper {
  max-width: 900px;
  margin: 3rem auto;
    background: #ffffff;
  border-radius: 16px;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.08);
  font-family: 'Segoe UI', sans-serif;
  overflow: hidden;
}

.admin-header {
   display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1.5rem 2rem;
  background-color: #007bff;
  color: white;
  cursor: pointer;
  transition: background-color 0.3s;
}

.admin-header:hover {
  background-color: #152a43;
}

.admin-header h2 {
  margin: 0;
  font-size: 1.8rem;
  font-weight: 600;
}

.toggle-icon {
  font-size: 20px;
  font-weight: bold;
}

.admin-content {
  margin-top: 10px;
  border-radius: 0 0 10px 10px;
  overflow: hidden;
  animation: slideDown 0.3s ease-out;
}

@keyframes slideDown {
  from {
    opacity: 0;
    transform: translateY(-20px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

.admin-panel {
  padding: 20px;
}

.form-container {
  background: #36567a;
  padding: 20px;
  border-radius: 10px;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
  margin-bottom: 30px;
}

.form-group {
  margin-bottom: 15px;
}

.form-group label {
  display: block;
  font-weight: bold;
  margin-bottom: 5px;
  color: white;
}

input,
textarea,
select {
  width: 100%;
  padding: 8px 12px;
  border-radius: 6px;
  border: 1px solid #ccc;
  font-size: 14px;
}

textarea {
  resize: vertical;
  height: 80px;
}

.button-group {
  display: flex;
  gap: 10px;
  margin-top: 10px;
}

button {
  padding: 10px 16px;
  border: none;
  border-radius: 6px;
  font-weight: bold;
  cursor: pointer;
  background-color: #007BFF;
  color: white;
  transition: background-color 0.3s;
}

button:hover {
  background-color: #0056b3;
}

button[type="button"] {
  background-color: #6c757d;
}

button[type="button"]:hover {
  background-color: #495057;
}

.productos-seccion {
  margin-top: 40px;
  background-color: #36567a;
  border-radius: 10px;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
  overflow: hidden;
}

.productos-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 15px 20px;
  cursor: pointer;
  background-color: #36567a;
  transition: background-color 0.2s;
}

.productos-header:hover {
  background-color: #2a4565;
}

.productos-header h3 {
  margin: 0;
  color: white;
}

.toggle-icon {
  font-size: 18px;
  color: white;
}

.productos-container {
  padding: 20px;
  background-color: #8896a7;
  border-top: 1px solid #5b7799;
}

.producto-card {
  display: flex;
  gap: 15px;
  background-color: #9aa7b5;
  padding: 15px;
  border-radius: 10px;
  margin-bottom: 20px;
  box-shadow: 0 1px 5px rgba(0, 0, 0, 0.1);
}

.producto-card:last-child {
  margin-bottom: 0;
}

.producto-card img {
  width: 300px;
  height: auto;
  border-radius: 6px;
  object-fit: cover;
}

.producto-info {
  flex: 1;
}

.acciones {
  margin-top: 10px;
  display: flex;
  gap: 10px;
}

.editar {
  background-color: #28a745;
}

.editar:hover {
  background-color: #218838;
}

.eliminar {
  background-color: #dc3545;
}

.eliminar:hover {
  background-color: #c82333;
}

.form-container h2 {
  color: white;
  margin-top: 0;
  margin-bottom: 20px;
  padding-bottom: 10px;
  border-bottom: 1px solid #4a6d94;
}
</style>