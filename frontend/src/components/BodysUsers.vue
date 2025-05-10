<template>
  <div class="formulario-usuario">
    <h2>Registro de Usuario</h2>
    <form @submit.prevent="registrarUsuario">
      <input v-model="usuario.nombre" placeholder="Nombre" required />
      <input v-model="usuario.correo" placeholder="Correo" type="email" required />
      <input v-model="usuario.telefono" placeholder="Teléfono" required />
      <input v-model="usuario.direccion" placeholder="Dirección" required />
      <button type="submit">Confirmar compra</button>
    </form>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'BodyUsers',
  props: ['carrito'],
  data() {
    return {
      usuario: {
        nombre: '',
        correo: '',
        telefono: '',
        direccion: ''
      }
    };
  },
  methods: {
    async registrarUsuario() {
      try {
      
        const resUsuario = await axios.post('http://localhost:5041/api/Usuarios', this.usuario);
        const usuarioId = resUsuario.data.id;

       
        for (const prod of this.carrito) {
          const compra = {
            usuarioId: usuarioId,
            productoId: prod.id,
            cantidad: prod.cantidad,
            fechaCompra: new Date().toISOString()
          };

          await axios.post('http://localhost:5041/api/Compras', compra);
        }

        alert('Compra registrada con éxito');
        this.$emit('compraExitosa');
      } catch (error) {
        console.error(error);
        alert('Ocurrió un error al registrar la compra');
      }
    }
  }
};
</script>


<style scoped>
input {
  display: block;
  margin: 8px 0;
  padding: 6px;
}
</style>
