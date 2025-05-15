<template>
  <div class="main-container">

    <div class="main-header" @click="toggleMainContent">
      <h2 class="main-title">Control y registro de Usuario</h2>
      <span class="toggle-icon">{{ mainContentVisible ? '▼' : '►' }}</span>
    </div>


    <div v-if="mainContentVisible" class="content-wrapper">
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
          <input v-model="usuario.contraseña" type="password" id="contraseña" placeholder="contraseña" required />
        </div>

        <button type="submit" class="btn-submit">Guardar Usuario</button>
      </form>


      <div class="usuarios-seccion">
        <div class="usuarios-header" @click.stop="toggleUsuariosVisibles">
          <h3>Usuarios Registrados</h3>
          <span class="toggle-icon">{{ usuariosVisibles ? '▼' : '►' }}</span>
        </div>

        <div v-if="usuariosVisibles && usuarios.length" class="users-list">
          <ul>
            <li v-for="u in usuarios" :key="u.id" class="user-item">
              <div>
                <strong>{{ u.nombre }}</strong>
                <span class="details">
                  <p><strong>Telefono:</strong>{{ u.telefono }}</p>
                  <p><strong>Direccion:</strong> {{ u.direccion }}</p>
                  <p><strong>Correo:</strong>{{ u.correo }}</p>
                </span>
              </div>
              <div class="actions">
                <button @click.stop="editarUsuario(u)" class="btn-edit">Editar</button>
                <button @click.stop="eliminarUsuario(u.id)" class="btn-delete">Eliminar</button>
              </div>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'BodyUsers',
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
      },
      mainContentVisible: true,
      usuariosVisibles: false
    }
  },
  methods: {
    toggleMainContent() {
      this.mainContentVisible = !this.mainContentVisible
    },
    toggleUsuariosVisibles(event) {

      event.stopPropagation()
      this.usuariosVisibles = !this.usuariosVisibles
    },
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
          alert('✅ Usuario actualizado');
        } else {
          await axios.post('http://localhost:5041/api/usuarios', {
            nombre: this.usuario.nombre,
            correo: this.usuario.correo,
            telefono: this.usuario.telefono,
            direccion: this.usuario.direccion,
            contraseña: this.usuario.contraseña
          })
          alert('✅ Usuario creado');
        }
        this.usuario = { id: null, nombre: '', correo: '', telefono: '', direccion: '', contraseña: '' }
        this.cargarUsuarios()
      } catch (error) {
        alert('Error al registrar, verifique los campos correctamente');
        console.error('Error al guardar usuario:', error)
      }
    },
    editarUsuario(usuario) {

      this.usuario = { ...usuario }

      if (!this.usuariosVisibles) {
        this.usuariosVisibles = true;
      }
    },
    async eliminarUsuario(id) {
      try {
        await axios.delete(`http://localhost:5041/api/usuarios/${id}`)
        alert('🗑️ Usuario eliminado.');
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
.main-container {
  max-width: 900px;
  margin: 3rem auto;
  background: #ffffff;
  border-radius: 16px;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.08);
  font-family: 'Segoe UI', sans-serif;
  overflow: hidden;
}

.main-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1.5rem 2rem;
  background-color: #007bff;
  color: white;
  cursor: pointer;
  transition: background-color 0.3s;
}

.main-header:hover {
  background-color: #162e49;
}

.main-title {
  margin: 0;
  font-size: 1.8rem;
  font-weight: 600;
}

.content-wrapper {
  padding: 2rem;
  transition: all 0.3s ease-in-out;
}

.form {
  display: grid;
  gap: 1rem;
  margin-bottom: 2rem;
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


.usuarios-seccion {
  margin-top: 2rem;
  border: 1px solid #eee;
  border-radius: 8px;
  overflow: hidden;
}

.usuarios-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem;
  background-color: #f8f9fa;
  cursor: pointer;
  transition: background-color 0.2s;
}

.usuarios-header:hover {
  background-color: #e9ecef;
}

.usuarios-header h3 {
  margin: 0;
  font-size: 1.25rem;
  color: #333;
}

.toggle-icon {
  font-size: 1.2rem;
  color: white;
  transition: transform 0.2s;
}

.usuarios-header .toggle-icon {
  color: #555;
}

.users-list {
  max-height: 500px;
  overflow-y: auto;
  transition: max-height 0.3s ease-in-out;
}

.users-list ul {
  list-style: none;
  padding: 0;
  margin: 0;
}

.user-item {
  padding: 1rem;
  border-bottom: 1px solid #eee;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.user-item:last-child {
  border-bottom: none;
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