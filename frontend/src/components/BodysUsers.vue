<template>
  <div class="form-container">
    <h2 class="form-title">Registrar Usuario</h2>

    <form @submit.prevent="guardarUsuario" class="form">
      <div class="form-group">
        <label for="nombre">Nombre</label>
        <input v-model="usuario.nombre" type="text" id="nombre" placeholder="Nombre" required />
      </div>

      <div class="form-group">
        <label for="correo">Correo electrónico</label>
        <input v-model="usuario.correo" type="email" id="correo" placeholder="correo" required />
      </div>

      <div class="form-group">
        <label for="telefono">Teléfono</label>
        <input v-model="usuario.telefono" type="text" id="telefono" placeholder="telefono" required />
      </div>

      <div class="form-group">
        <label for="direccion">Dirección</label>
        <input v-model="usuario.direccion" type="text" id="direccion" placeholder="direccion" required />
      </div>
       <div class="form-group">
        <label for="contraseña">Contraseña</label>
        <input v-model="usuario.contraseña" type="text" id="contraseña" placeholder="contraseña" required />
      </div>

      <button type="submit" class="btn-submit">Guardar Usuario</button>
    </form>

    <div v-if="usuarios.length" class="users-list">
      <h3 class="users-title">Usuarios Registrados</h3>
      <ul>
        <li v-for="u in usuarios" :key="u.id" class="user-item">
          <div>
            <strong>{{ u.nombre }}</strong> - {{ u.correo }}<br />
            <span class="details">{{ u.telefono }} | {{ u.direccion }} | {{ u.contraseña  }}</span>
          </div>
          <div class="actions">
            <button @click="editarUsuario(u)" class="btn-edit">Editar</button>
            <button @click="eliminarUsuario(u.id)" class="btn-delete">Eliminar</button>
          </div>
        </li>
      </ul>
    </div>
  </div>
</template>


<script>
import axios from 'axios'

export default {
  name :'BodyUsers',
  data() {
    return {
      usuarios: [],
      usuario: {
        id: null,
        nombre: '',
        correo: '',
        telefono: '',
        direccion: '',
        contraseña: ''
      }
    }
  },
  methods: {
    async cargarUsuarios() {
      try {
        const res = await axios.get('http://localhost:5041/api/usuarios') 
        this.usuarios = res.data
      } catch (error) {
        console.error('Error al obtener usuarios:', error)
      }
    },
    async guardarUsuario() {
      try {
        if (this.usuario.id) {
          
          await axios.put(`http://localhost:5041/api/usuarios/${this.usuario.id}`, this.usuario)
        } else {
          await axios.post('http://localhost:5041/api/usuarios', {
            nombre: this.usuario.nombre,
            correo: this.usuario.correo,
            telefono: this.usuario.telefono,
            direccion: this.usuario.direccion,
            contraseña: this.usuario.contraseña
          })
        }
         alert('✅ usuario creado');
        this.usuario = { id: null, nombre: '', correo: '', telefono: '', direccion: '',contraseña:'' }
        this.cargarUsuarios()
      } catch (error) {
        alert('error al registrar verifique los campos correctamente');
        console.error('Error al guardar usuario:', error)
      }
    },
    editarUsuario(usuario) {
     
      this.usuario = { ...usuario }
     
    },
    async eliminarUsuario(id) {
      try {
        await axios.delete(`http://localhost:5041/api/usuarios/${id}`)
         alert('🗑️ usuario eliminado.');
        this.cargarUsuarios()
      } catch (error) {
        console.error('Error al eliminar usuario:', error)
      }
    }
  },
  mounted() {
    this.cargarUsuarios()
  }
}
</script>

<style scoped>
.form-container {
  max-width: 600px;
  margin: 3rem auto;
  padding: 2rem;
  background: #ffffff;
  border-radius: 16px;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.08);
  font-family: 'Segoe UI', sans-serif;
}

.form-title {
  text-align: center;
  font-size: 2rem;
  color: #333;
  margin-bottom: 1.5rem;
}

.form {
  display: grid;
  gap: 1rem;
}

.form-group {
  display: flex;
  flex-direction: column;
}

.form-group label {
  margin-bottom: 0.5rem;
  font-weight: 600;
  color: #555;
}

.form-group input {
  padding: 0.75rem;
  border: 1px solid #ccc;
  border-radius: 8px;
  font-size: 1rem;
  transition: border-color 0.3s;
}

.form-group input:focus {
  border-color: #007bff;
  outline: none;
}

.btn-submit {
  padding: 0.9rem;
  background-color: #007bff;
  color: white;
  font-weight: 600;
  border: none;
  border-radius: 10px;
  cursor: pointer;
  transition: background-color 0.3s;
}

.btn-submit:hover {
  background-color: #0056b3;
}

.users-list {
  margin-top: 2rem;
}

.users-title {
  font-size: 1.5rem;
  margin-bottom: 1rem;
  color: #222;
}

.user-item {
  padding: 1rem;
  border-bottom: 1px solid #eee;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.details {
  font-size: 0.875rem;
  color: #777;
}

.actions {
  display: flex;
  gap: 0.5rem;
}

.btn-edit,
.btn-delete {
  padding: 0.5rem 1rem;
  font-size: 0.875rem;
  border-radius: 6px;
  border: none;
  cursor: pointer;
  transition: background 0.3s;
}

.btn-edit {
  background-color: #f0ad4e;
  color: white;
}

.btn-edit:hover {
  background-color: #ec971f;
}

.btn-delete {
  background-color: #d9534f;
  color: white;
}

.btn-delete:hover {
  background-color: #c9302c;
}
</style>
