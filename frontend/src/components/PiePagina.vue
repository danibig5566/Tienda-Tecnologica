<template>
  <footer class="footer">

    <div class="top-bar">
      <span>Conéctate con nosotros en las redes sociales:</span>
      <div class="social-icons">
        <a href="#"><i class="fab fa-facebook-f"></i></a>
        <a href="#"><i class="fab fa-twitter"></i></a>
        <a href="#"><i class="fab fa-google"></i></a>
        <a href="#"><i class="fab fa-instagram"></i></a>
        <a href="#"><i class="fab fa-linkedin-in"></i></a>
        <a href="#"><i class="fab fa-github"></i></a>
      </div>
    </div>


    <div class="footer-container">
      <div class="footer-section">
        <h3>💎 TIENDA TECNOLOGICA</h3>
        <p>
          ¡Explora las últimas tendencias en tecnología! Encuentra los gadgets más innovadores, computadoras de última
          generación y accesorios imprescindibles.
          ¡La tecnología del mañana, hoy! 🌟 <br>
          <span>#Innovación #Tecnología #Futuro</span>
        </p>
      </div>

      <div class="footer-section">
        <h3>PRODUCTOS</h3>
        <p><router-link to="/VistaConsolas">Consolas</router-link></p>
        <p><router-link to="/vistacelulares">Celulares</router-link></p>
        <p><router-link to="/VistaVideojuegos">Videojuegos</router-link></p>
        <p><router-link to="/VistaLaptos">Laptops</router-link></p>
        <p><router-link to="/VistaAccesorios">Accesorios</router-link></p>
      </div>

      <div class="footer-section">
        <h3>ENLACES UTILES</h3>
        <p><a href="#">PQR</a></p>
        <p><a href="#">Contactame</a></p>
        <p><a href="#">Sobre Nosotros</a></p>
      </div>

      <div class="footer-section">
        <h3>CONTACTO</h3>
        <p><i class="fas fa-home"></i> Santa Marta , Magdalena, Colombia</p>
        <p><i class="fas fa-envelope"></i> angeldanielgonzalezvillazon@gmail.com</p>
        <p><i class="fas fa-phone"></i> +57 316789323</p>
      </div>
    </div>

    <div class="footer-bottom">
      <p>&copy; 2025 Copyright: <strong>Tienda tecnologica</strong></p>
    </div>
  </footer>
</template>

<script>
export default {
  name: 'PiePagina',
}
</script>

<style scoped>
.footer {
  background-color: #000000;
  color: #ffffff;
  font-family: Arial, sans-serif;
}


.top-bar {
  background-color: #574747;
  display: flex;
  justify-content: space-between;
  padding: 10px 40px;
  font-size: 0.95em;

}

.social-icons a {
  margin-left: 15px;
  color: #ff0202;
  text-decoration: none;
  font-size: 1.1em;
}

.social-icons a:hover {
  color: rgb(30, 255, 0);
}


.footer-container {
  display: flex;
  justify-content: space-around;
  flex-wrap: wrap;
  padding: 3px 3px;
  background-color: #000000;
}

.footer-section {
  flex: 1;
  margin: 10px 20px;
  min-width: 200px;
}

.footer-section h3 {
  font-weight: bold;
  margin-bottom: 15px;
}

.footer-section a {
  text-decoration: none;
  color: #ffffff;
}

.footer-section a:hover {
  color: rgb(30, 255, 0);
}

.footer-bottom {
  background-color: #000000;
  text-align: center;
  padding: 15px 0;
  font-size: 0.9em;
}
</style>
