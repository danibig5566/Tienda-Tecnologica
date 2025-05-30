<template>
  <div class="login-wrapper">
    <div class="login-container">
      <h2>🔐 Bienvenido a Gamer Store</h2>

      <div class="login-form">
        <input 
          v-model="correo" 
          type="email"
          placeholder="Correo electrónico" 
          :disabled="cargando"
        />
        <input 
          v-model="contrasena" 
          type="password" 
          placeholder="Contraseña" 
          :disabled="cargando"
          @keyup.enter="login"
        />

        <button 
          @click="login" 
          :disabled="cargando || !formularioValido"
          class="btn-principal"
        >
          <span v-if="cargando">⏳ Verificando...</span>
          <span v-else">Iniciar sesión</span>
        </button>
        
    
        
        <button 
          class="btn-registro" 
          @click="mostrarModalRegistro = true"
          :disabled="cargando"
        >
          Crear cuenta
        </button>

        <div v-if="mensaje" :class="['mensaje', tipoMensaje]">
          {{ mensaje }}
        </div>
      </div>
    </div>

    
    <div v-if="mostrarModalRegistro" class="modal-overlay" @click.self="cerrarModal">
      <div class="modal">
        <div class="modal-header">
          <h3>Crear nueva cuenta</h3>
          <button class="btn-cerrar" @click="cerrarModal">✕</button>
        </div>
        <LoginUsers @cerrar="cerrarModal" @registro-exitoso="manejarRegistroExitoso" />
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import LoginUsers from '../components/LoginUsers.vue'; 

export default {
  name: 'VistaLogin',
  components: { LoginUsers },
  data() {
    return {
      correo: '',
      contrasena: '',
      mensaje: '',
      tipoMensaje: '',
      mostrarModalRegistro: false,
      cargando: false
    };
  },
  computed: {
    formularioValido() {
      return this.correo.trim() !== '' && 
             this.contrasena.trim() !== '' && 
             this.esEmailValido(this.correo);
    }
  },
  methods: {
    esEmailValido(email) {
      const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
      return regex.test(email);
    },

    async login() {
      if (!this.formularioValido) {
        this.mostrarMensaje('Por favor completa todos los campos correctamente', 'error');
        return;
      }

      this.cargando = true;
      this.mostrarMensaje('Verificando credenciales...', 'info');

      try {
        const response = await axios.post('http://localhost:5041/api/usuarios/login', {
          correo: this.correo.trim(),
          contraseña: this.contrasena
        });

        const usuario = response.data;

        
        this.guardarUsuario(usuario);

        this.mostrarMensaje('✅ Inicio de sesión exitoso', 'success');

        setTimeout(() => {
          
          if (usuario.rol === 'admin' || usuario.rol === 'administrador') {
            this.$router.push('/Inicio');
          } else {
            this.$router.push('/Inicio');
          }
        }, 1500);

      } catch (error) {
        console.error('Error en login:', error);
        
        if (error.response) {
          switch (error.response.status) {
            case 401:
              this.mostrarMensaje('❌ Credenciales incorrectas', 'error');
              break;
            case 404:
              this.mostrarMensaje('❌ Usuario no encontrado', 'error');
              break;
            case 500:
              this.mostrarMensaje('⚠️ Error interno del servidor', 'error');
              break;
            default:
              this.mostrarMensaje('⚠️ Error inesperado', 'error');
          }
        } else if (error.request) {
          this.mostrarMensaje('⚠️ No se pudo conectar con el servidor', 'error');
        } else {
          this.mostrarMensaje('⚠️ Error al procesar la solicitud', 'error');
        }
      } finally {
        this.cargando = false;
      }
    },

    continuarSinSesion() {
    
      const usuarioInvitado = {
        id: null,
        nombre: 'Invitado',
        correo: null,
        rol: 'invitado'
      };
      this.guardarUsuario(usuarioInvitado);
      this.$router.push('/Inicio');
    },

    guardarUsuario(usuario) {
      
      if (this.$store) {
        this.$store.commit('setUsuario', usuario);
      }
      
     
      localStorage.setItem('usuario', JSON.stringify(usuario));
      
      
      this.$root.$emit('usuario-cambio', usuario);
    },

    cerrarModal() {
      this.mostrarModalRegistro = false;
    },

    manejarRegistroExitoso() {
      this.mostrarModalRegistro = false;
      this.mostrarMensaje('✅ Cuenta creada exitosamente. Puedes iniciar sesión ahora.', 'success');
    },

    mostrarMensaje(texto, tipo) {
      this.mensaje = texto;
      this.tipoMensaje = tipo;
      
      
      setTimeout(() => {
        this.mensaje = '';
        this.tipoMensaje = '';
      }, 5000);
    },

    limpiarFormulario() {
      this.correo = '';
      this.contrasena = '';
      this.mensaje = '';
      this.tipoMensaje = '';
    }
  },

  mounted() {
   
    const usuarioGuardado = localStorage.getItem('usuario');
    if (usuarioGuardado) {
      try {
        const usuario = JSON.parse(usuarioGuardado);
       
        if (this.$store) {
          this.$store.commit('setUsuario', usuario);
        }
        
       
        if (usuario.rol === 'admin' || usuario.rol === 'administrador') {
          this.$router.push('/Inicio');
        } else {
          this.$router.push('/Inicio');
        }
      } catch (error) {
        console.error('Error al parsear usuario guardado:', error);
        localStorage.removeItem('usuario');
      }
    }
  }
};
</script>

<style scoped>
.login-wrapper {
  min-height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background-image: url('../assets/img/imagenfondologin.jpg');
  background-size: cover;
  background-repeat: no-repeat;
  background-position: center;
  position: relative;
}

.login-wrapper::before {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.4);
  z-index: 1;
}

.login-container {
  background: rgba(30, 30, 47, 0.95);
  padding: 2.5rem 2rem;
  border-radius: 20px;
  box-shadow: 0 15px 35px rgba(0, 0, 0, 0.4);
  text-align: center;
  width: 100%;
  max-width: 420px;
  color: #fff;
  position: relative;
  z-index: 2;
  backdrop-filter: blur(10px);
}

.login-container h2 {
  margin-bottom: 2rem;
  font-size: 1.8rem;
  color: #1abc9c;
  font-weight: 600;
}

.login-form input {
  width: 100%;
  margin-bottom: 1.2rem;
  padding: 0.8rem 1rem;
  border-radius: 10px;
  border: 2px solid #444;
  background: #2a2a3d;
  color: #fff;
  font-size: 1rem;
  transition: all 0.3s ease;
  box-sizing: border-box;
}

.login-form input:focus {
  outline: none;
  border-color: #1abc9c;
  box-shadow: 0 0 10px rgba(26, 188, 156, 0.3);
  background: #323248;
}

.login-form input:disabled {
  opacity: 0.6;
  cursor: not-allowed;
}

.login-form button {
  width: 100%;
  padding: 0.8rem;
  margin-bottom: 0.8rem;
  border-radius: 10px;
  border: none;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: all 0.3s ease;
  position: relative;
  overflow: hidden;
}

.btn-principal {
  background: linear-gradient(135deg, #1abc9c, #16a085);
  color: white;
}

.btn-principal:hover:not(:disabled) {
  background: linear-gradient(135deg, #16a085, #1abc9c);
  transform: translateY(-2px);
  box-shadow: 0 5px 15px rgba(26, 188, 156, 0.4);
}

.btn-secundario {
  background: linear-gradient(135deg, #3498db, #2980b9);
  color: white;
}

.btn-secundario:hover:not(:disabled) {
  background: linear-gradient(135deg, #2980b9, #3498db);
  transform: translateY(-2px);
  box-shadow: 0 5px 15px rgba(52, 152, 219, 0.4);
}

.btn-registro {
  background: linear-gradient(135deg, #9b59b6, #8e44ad);
  color: white;
}

.btn-registro:hover:not(:disabled) {
  background: linear-gradient(135deg, #8e44ad, #9b59b6);
  transform: translateY(-2px);
  box-shadow: 0 5px 15px rgba(155, 89, 182, 0.4);
}

.login-form button:disabled {
  opacity: 0.6;
  cursor: not-allowed;
  transform: none;
  box-shadow: none;
}

.mensaje {
  margin-top: 1.2rem;
  padding: 0.8rem;
  border-radius: 8px;
  font-weight: 500;
  font-size: 0.9rem;
  animation: slideIn 0.3s ease;
}

@keyframes slideIn {
  from {
    opacity: 0;
    transform: translateY(-10px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}

.success {
  background: linear-gradient(135deg, #2ecc71, #27ae60);
  color: #fff;
  border-left: 4px solid #27ae60;
}

.error {
  background: linear-gradient(135deg, #e74c3c, #c0392b);
  color: #fff;
  border-left: 4px solid #c0392b;
}

.info {
  background: linear-gradient(135deg, #f1c40f, #f39c12);
  color: #2c3e50;
  border-left: 4px solid #f39c12;
}

.modal-overlay {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: rgba(0, 0, 0, 0.75);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 3000;
  backdrop-filter: blur(5px);
}

.modal {
  background: white;
  border-radius: 20px;
  max-width: 650px;
  width: 90%;
  max-height: 90vh;
  overflow-y: auto;
  box-shadow: 0 25px 60px rgba(0, 0, 0, 0.4);
  animation: modalSlideIn 0.3s ease;
}

@keyframes modalSlideIn {
  from {
    opacity: 0;
    transform: scale(0.9) translateY(-20px);
  }
  to {
    opacity: 1;
    transform: scale(1) translateY(0);
  }
}

.modal-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1.5rem 2rem 1rem;
  border-bottom: 1px solid #eee;
}

.modal-header h3 {
  margin: 0;
  color: #2c3e50;
  font-size: 1.4rem;
}

.btn-cerrar {
  background: none;
  border: none;
  font-size: 1.5rem;
  cursor: pointer;
  color: #7f8c8d;
  padding: 0.5rem;
  border-radius: 50%;
  transition: all 0.3s ease;
}

.btn-cerrar:hover {
  background: #ecf0f1;
  color: #e74c3c;
}

/* Responsive */
@media (max-width: 480px) {
  .login-container {
    margin: 1rem;
    padding: 2rem 1.5rem;
  }
  
  .modal {
    width: 95%;
    margin: 1rem;
  }
  
  .modal-header {
    padding: 1rem 1.5rem 0.5rem;
  }
}
</style>