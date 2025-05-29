<template>
  <div class="pqr-container">
    <h2>Formulario PQR</h2>
    <form @submit.prevent="submitPQR" class="pqr-form">
      <div class="form-group">
        <label for="tipo">Tipo de Solicitud:</label>
        <select id="tipo" v-model="pqrData.tipo" required>
          <option value="">Seleccionar</option>
          <option value="peticion">Petición</option>
          <option value="queja">Queja</option>
          <option value="reclamo">Reclamo</option>
        </select>
      </div>
      <div class="form-group">
        <label for="nombre">Nombre:</label>
        <input type="text" id="nombre" v-model="pqrData.nombre" required>
      </div>
      <div class="form-group">
        <label for="email">Correo Electrónico:</label>
        <input type="email" id="email" v-model="pqrData.email" required>
      </div>
      <div class="form-group">
        <label for="descripcion">Descripción:</label>
        <textarea id="descripcion" v-model="pqrData.descripcion" rows="5" required></textarea>
      </div>
      <button type="submit" :disabled="isSubmitting">
        <span v-if="isSubmitting">Enviando...</span>
        <span v-else>Enviar PQR</span>
      </button>
      <div v-if="submissionSuccess" class="success-message">
        ¡PQR Enviado!
      </div>
      <div v-if="submissionError" class="error-message">
        Hubo un error al enviar su solicitud. Por favor, intente de nuevo.
      </div>
    </form>
    <div v-if="isSubmitting" class="loading-overlay">
      <div class="loader"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'BodyPQRs',
  data() {
    return {
      pqrData: {
        tipo: '',
        nombre: '',
        email: '',
        descripcion: '',
      },
      submissionSuccess: false,
      submissionError: false,
      isSubmitting: false,
    };
  },
  methods: {
    async submitPQR() {
      this.isSubmitting = true;
      this.submissionSuccess = false;
      this.submissionError = false;
      try {
        console.log('Enviando PQR:', this.pqrData);
        await new Promise(resolve => setTimeout(resolve, 1500));
        this.submissionSuccess = true;
        this.pqrData = {
          tipo: '',
          nombre: '',
          email: '',
          descripcion: '',
        };
      } catch (error) {
        console.error('Error al enviar la PQR:', error);
        this.submissionError = true;
      } finally {
        this.isSubmitting = false;
      }
    },
  },
};
</script>

<style scoped>
.pqr-container {
  background-color: #f9f9f9;
  padding: 30px;
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  max-width: 600px;
  margin: 20px auto;
}

h2 {
  color: #333;
  text-align: center;
  margin-bottom: 25px;
}

.pqr-form {
  display: flex;
  flex-direction: column;
}

.form-group {
  margin-bottom: 20px;
}

label {
  display: block;
  margin-bottom: 8px;
  color: #555;
  font-weight: 600;
}

input[type="text"],
input[type="email"],
textarea,
select {
  padding: 12px;
  border: 1px solid #ddd;
  border-radius: 6px;
  box-sizing: border-box;
  font-size: 16px;
  margin-bottom: 10px;
  transition: border-color 0.3s ease;
}

input[type="text"]:focus,
input[type="email"]:focus,
textarea:focus,
select:focus {
  outline: none;
  border-color: #007bff;
  box-shadow: 0 0 6px rgba(0, 123, 255, 0.25);
}

textarea {
  min-height: 120px;
}

button {
  padding: 14px 20px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  font-size: 16px;
  transition: background-color 0.3s ease;
}

button:hover {
  background-color: #0056b3;
}

button:disabled {
  background-color: #ccc;
  cursor: not-allowed;
}

.success-message {
  color: #28a745;
  margin-top: 20px;
  text-align: center;
  font-weight: bold;
}

.error-message {
  color: #dc3545;
  margin-top: 20px;
  text-align: center;
  font-weight: bold;
}

.loading-overlay {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(255, 255, 255, 0.7);
  display: flex;
  justify-content: center;
  align-items: center;
  border-radius: 12px;
}

.loader {
  border: 6px solid #f3f3f3; 
  border-top: 6px solid #3498db; 
  border-radius: 50%;
  width: 50px;
  height: 50px;
  animation: spin 2s linear infinite;
}

@keyframes spin {
  0% { transform: rotate(0deg); }
  100% { transform: rotate(360deg); }
}
</style>