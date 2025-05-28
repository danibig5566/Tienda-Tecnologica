<template>
  <div class="login-wrapper">
    <div class="login-container">
      <h2>🔐 Bienvenido a Gamer Store</h2>

      <div class="login-form">
        <input v-model="nombreUsuario" placeholder="Nombre de usuario" />
        <input v-model="contrasena" type="password" placeholder="Contraseña" />

        <button @click="login">Iniciar sesión</button>
        <button class="btn-secundario" @click="continuarSinSesion">ingresar como invitado</button>
        

        <div v-if="mensaje" :class="['mensaje', tipoMensaje]">
          {{ mensaje }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'VistaLogin',
  data() {
    return {
      nombreUsuario: '',
      contrasena: '',
      mensaje: '',
      tipoMensaje: ''
    };
  },
  methods: {
    async login() {
      this.mensaje = 'Verificando credenciales...';
      this.tipoMensaje = 'info';

      try {
        const response = await axios.get('http://localhost:5041/api/usuarios');
        const usuarios = response.data;

        const usuarioEncontrado = usuarios.find(user =>
          user.nombre === this.nombreUsuario &&
          user.contraseña === this.contrasena
        );

        if (usuarioEncontrado) {
          localStorage.setItem('usuario', JSON.stringify(usuarioEncontrado));
          this.mensaje = '✅ Inicio de sesión exitoso';
          this.tipoMensaje = 'success';

          setTimeout(() => {
            this.$router.push('/Inicio');
          }, 1500);
        } else {
          this.mensaje = '❌ Credenciales incorrectas';
          this.tipoMensaje = 'error';
        }
      } catch (error) {
        console.error("Error al autenticar:", error);
        this.mensaje = '⚠️ Error al conectar con el servidor';
        this.tipoMensaje = 'error';
      }
    },
    continuarSinSesion() {
      localStorage.setItem('usuario', JSON.stringify({ invitado: true }));
      this.$router.push('/Inicio');
    },
    registroUsuario() {
      this.$router.push('/VistaUsers');
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
}

.login-container {
  background: rgba(30, 30, 47, 0.8); 
  padding: 2.5rem 2rem;
  border-radius: 15px;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.3);
  text-align: center;
  width: 100%;
  max-width: 400px;
  color: #fff;
}

.login-container h2 {
  margin-bottom: 2rem;
  font-size: 1.8rem;
  color: #1abc9c;
}

.login-form input {
  width: 100%;
  margin-bottom: 1rem;
  padding: 0.7rem;
  border-radius: 8px;
  border: 1px solid #444;
  background: #2a2a3d;
  color: #fff;
  font-size: 1rem;
}

.login-form input:focus {
  outline: none;
  border-color: #1abc9c;
  box-shadow: 0 0 5px #1abc9c;
}

.login-form button {
  width: 100%;
  padding: 0.75rem;
  margin-top: 0.5rem;
  border-radius: 8px;
  border: none;
  background-color: #1abc9c;
  color: white;
  font-size: 1rem;
  font-weight: bold;
  cursor: pointer;
  transition: background 0.3s ease;
}

.login-form .btn-secundario {
  background-color: #3498db;
}

.login-form .btn-registro {
  background-color: #9b59b6;
}

.login-form button:hover {
  opacity: 0.9;
}

.mensaje {
  margin-top: 1rem;
  padding: 0.6rem;
  border-radius: 6px;
  font-weight: bold;
  font-size: 0.9rem;
}

.success {
  background-color: #2ecc71;
  color: #fff;
}

.error {
  background-color: #e74c3c;
  color: #fff;
}

.info {
  background-color: #f1c40f;
  color: #333;
}
</style>