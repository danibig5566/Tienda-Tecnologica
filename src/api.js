import axios from 'axios';


const api = axios.create({
  baseURL: 'http://localhost:5041/api' 
});

export default {
  GetProductosPorCategoria(categoriaId) {
    return api.get(`/Products/categoria/${categoriaId}`);
  },
  
  getProductos() {
    return api.get('/Products');
  },

  getProducto(id) {
    return api.get(`/Products/${id}`);
  },

  crearProducto(producto) {
    return api.post('/Products', producto);
  },

  actualizarProducto(id, producto) {
    return api.put(`/Products/${id}`, producto);
  },

  eliminarProducto(id) {
    return api.delete(`/Products/${id}`);
  }
};
