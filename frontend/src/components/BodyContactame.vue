<template>
  <div class="contact-container animate-fade-in">
    <div class="info-section">
      <h2>Contáctanos</h2>
      <p><i class="fas fa-user animate-icon"></i>CEO Angel gonzalez</p>
      <p><i class="fas fa-envelope animate-icon"></i> angeldanielgonzalezvillazon@gmail.com</p>
      <p><i class="fas fa-phone animate-icon"></i> 3166201155</p>
    </div>

    <div class="form-section">
      <h3>Envíame un mensaje</h3>
      <form @submit.prevent="enviarMensaje">
        <input v-model="nombre" type="text" placeholder="Tu nombre" required />
        <input v-model="correo" type="email" placeholder="Tu correo" required />
        <textarea v-model="mensaje" placeholder="Escribe tu mensaje..." required></textarea>
        <button type="submit" class="btn-send">
          <span v-if="!enviando">Enviar</span>
          <span v-else class="spinner"></span>
        </button>
      </form>
    </div>

   
    <div v-if="modalVisible" class="modal-backdrop">
      <div class="modal-success">
        <i class="fas fa-check-circle"></i>
        <p>¡Mensaje enviado con éxito!</p>
        <button @click="modalVisible = false">Cerrar</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'BodyContactame',
  data() {
    return {
      nombre: '',
      correo: '',
      mensaje: '',
      enviando: false,
      modalVisible: false
    }
  },
  methods: {
    enviarMensaje() {
      this.enviando = true;

     
      setTimeout(() => {
        this.enviando = false;
        this.modalVisible = true;
        this.nombre = '';
        this.correo = '';
        this.mensaje = '';
      }, 2000);
    }
  }
}
</script>

<style scoped>
.contact-container {
  display: flex;
  flex-direction: column;
  gap: 2rem;
  max-width: 760px;
  margin: 3rem auto;
  padding: 2.5rem;
  background: #f9f9f9;
  border-radius: 20px;
  box-shadow: 0 8px 24px rgba(0, 0, 0, 0.06);
  font-family: 'Inter', 'Segoe UI', sans-serif;
  color: #1f1f1f;
  animation: fadeIn 0.6s ease;
}

.info-section {
  text-align: center;
}

.info-section h2 {
  font-size: 2.2rem;
  font-weight: 600;
  color: #1f4e79;
  margin-bottom: 1rem;
}

.info-section p {
  font-size: 1.05rem;
  color: #4a4a4a;
  margin: 0.3rem 0;
  line-height: 1.6;
}

.info-section i {
  margin-right: 8px;
  color: #1f4e79;
}

.form-section {
  border-top: 1px solid #ddd;
  padding-top: 1.8rem;
}

.form-section h3 {
  font-size: 1.5rem;
  font-weight: 500;
  color: #2e2e2e;
  margin-bottom: 1.2rem;
}

form {
  display: flex;
  flex-direction: column;
  gap: 1.2rem;
}

input,
textarea {
  padding: 0.85rem 1rem;
  border: 1px solid #cfd8dc;
  border-radius: 12px;
  font-size: 1rem;
  background-color: #ffffff;
  transition: all 0.3s ease;
}

input:focus,
textarea:focus {
  border-color: #1f4e79;
  box-shadow: 0 0 0 3px rgba(31, 78, 121, 0.15);
  outline: none;
}

textarea {
  resize: vertical;
  min-height: 120px;
}

.btn-send {
  display: inline-flex;
  justify-content: center;
  align-items: center;
  padding: 0.9rem;
  background-color: #0d47a1;
  color: white;
  border: none;
  border-radius: 12px;
  font-size: 1rem;
  font-weight: 600;
  cursor: pointer;
  transition: background-color 0.3s ease, transform 0.2s ease;
  min-height: 48px;
}

.btn-send:hover {
  background-color: #093170;
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(9, 49, 112, 0.3);
}

.spinner {
  width: 24px;
  height: 24px;
  border: 3px solid #fff;
  border-top: 3px solid #093170;
  border-radius: 50%;
  animation: spin 1s linear infinite;
}

@keyframes spin {
  to {
    transform: rotate(360deg);
  }
}

.modal-backdrop {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.4);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 999;
}

.modal-success {
  background-color: #fff;
  padding: 2rem;
  border-radius: 16px;
  box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
  text-align: center;
  animation: fadeIn 0.5s ease;
}

.modal-success i {
  font-size: 3rem;
  color: #28a745;
  margin-bottom: 1rem;
}

.modal-success p {
  font-size: 1.2rem;
  margin-bottom: 1rem;
}

.modal-success button {
  padding: 0.6rem 1.2rem;
  background-color: #0d47a1;
  color: white;
  border: none;
  border-radius: 10px;
  font-weight: bold;
  cursor: pointer;
  transition: background 0.3s ease;
}

.modal-success button:hover {
  background-color: #093170;
}

@keyframes fadeIn {
  from {
    opacity: 0;
    transform: translateY(15px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}
</style>

