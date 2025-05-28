<template>
  <div class="form-container">
    <!-- ALERTA DINÁMICA -->
    <div v-if="mostrarMensaje" :class="['alerta', tipoMensaje]">
      <span v-if="tipoMensaje === 'loading'" class="spinner-alert"></span>
      {{ mensaje }}
    </div>

    <h2 class="form-title">Rellene los campos para registrarse</h2>

    <form @submit.prevent="guardarUsuario" class="form">
      <div class="form-group">
        <label for="nombre">Nombre</label>
        <input v-model="usuario.nombre" type="text" id="nombre" placeholder="Nombre" required />
      </div>

      <div class="form-group">
        <label for="correo">Correo electrónico</label>
        <input v-model="usuario.correo" type="email" id="correo" placeholder="Correo" required />
      </div>

      <div class="form-group">
        <label for="telefono">Teléfono</label>
        <input v-model="usuario.telefono" type="text" id="telefono" placeholder="Teléfono" required />
      </div>

      <div class="form-group">
        <label for="direccion">Dirección</label>
        <input v-model="usuario.direccion" type="text" id="direccion" placeholder="Dirección" required />
      </div>

      <div class="form-group">
        <label for="contraseña">Contraseña</label>
        <input v-model="usuario.contraseña" type="password" id="contraseña" placeholder="Contraseña" required />
      </div>

      <button type="submit" class="btn-submit" :disabled="cargando">
        <span v-if="cargando" class="spinner"></span>
        <span v-else>Registrar</span>
      </button>
    </form>
  </div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'LoginUsers',
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
      cargando: false,
      mensaje: '',
      tipoMensaje: '',
      mostrarMensaje: false
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

    mostrarAlerta(texto, tipo) {
      this.mensaje = texto;
      this.tipoMensaje = tipo;
      this.mostrarMensaje = true;
      if (tipo !== 'loading') {
        setTimeout(() => {
          this.mostrarMensaje = false;
        }, 3000);
      }
    },

    async guardarUsuario() {
      this.cargando = true;
      this.mostrarAlerta('Registrando usuario...', 'loading');
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
        this.mostrarAlerta('✅ Registro exitoso', 'success');
        this.usuario = { id: null, nombre: '', correo: '', telefono: '', direccion: '', contraseña: '' }
        this.cargarUsuarios()
      } catch (error) {
        this.mostrarAlerta('❌ Error al registrar. Verifique los campos.', 'error');
        console.error('Error al guardar usuario:', error)
      } finally {
        this.cargando = false;
      }
    },

    editarUsuario(usuario) {
      this.usuario = { ...usuario }
    },

    async eliminarUsuario(id) {
      try {
        await axios.delete(`http://localhost:5041/api/usuarios/${id}`)
        this.mostrarAlerta('🗑️ Usuario eliminado.', 'success');
        this.cargarUsuarios()
      } catch (error) {
        this.mostrarAlerta('❌ Error al eliminar usuario.', 'error');
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
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 8px;
}

.btn-submit:disabled {
  background-color: #99caff;
  cursor: not-allowed;
}

.btn-submit:hover:not(:disabled) {
  background-color: #0056b3;
}

.spinner {
  width: 18px;
  height: 18px;
  border: 3px solid #fff;
  border-top: 3px solid #007bff;
  border-radius: 50%;
  animation: spin 1s linear infinite;
  display: inline-block;
  vertical-align: middle;
}

.spinner-alert {
  display: inline-block;
  width: 16px;
  height: 16px;
  border: 2px solid #004085;
  border-top: 2px solid transparent;
  border-radius: 50%;
  margin-right: 10px;
  animation: spin 1s linear infinite;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}

.alerta {
  padding: 1rem;
  border-radius: 10px;
  text-align: center;
  margin-bottom: 1rem;
  font-weight: bold;
  animation: fadein 0.5s ease-in-out;
}

.success {
  background-color: #d4edda;
  color: #155724;
}

.error {
  background-color: #f8d7da;
  color: #721c24;
}

.loading {
  background-color: #cce5ff;
  color: #004085;
}

@keyframes fadein {
  from { opacity: 0; transform: translateY(-10px); }
  to { opacity: 1; transform: translateY(0); }
}
</style>
