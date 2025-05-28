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
footer {
  background: linear-gradient(to right, #000000, #111111);
  color: #ffffff;
  font-family: 'Poppins', sans-serif;
  box-shadow: 0 -6px 20px rgba(0, 0, 0, 0.6);
  backdrop-filter: blur(4px);
  margin-top: 40px;
}


.top-bar {
  background-color: rgba(87, 71, 71, 0.9);
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 12px 40px;
  font-size: 0.95em;
  border-bottom: 1px solid rgba(255, 255, 255, 0.05);
}

.social-icons a {
  margin-left: 20px;
  color: #ff4d4d;
  text-decoration: none;
  font-size: 1.2em;
  transition: transform 0.3s ease, color 0.3s ease;
}

.social-icons a:hover {
  color: #1abc9c;
  transform: scale(1.2);
}


.footer-container {
  display: flex;
  justify-content: space-evenly;
  flex-wrap: wrap;
  padding: 30px 20px;
  background-color: transparent;
  border-top: 1px solid rgba(255, 255, 255, 0.05);
}

.footer-section {
  flex: 1;
  margin: 15px 30px;
  min-width: 220px;
}

.footer-section h3 {
  font-weight: 700;
  margin-bottom: 18px;
  color: #1abc9c;
  font-size: 1.2rem;
  border-bottom: 1px solid #1abc9c;
  padding-bottom: 6px;
}

.footer-section a {
  display: block;
  text-decoration: none;
  color: #dddddd;
  font-size: 0.95rem;
  margin-bottom: 10px;
  transition: color 0.3s ease, padding-left 0.2s ease;
}

.footer-section a:hover {
  color: #1abc9c;
  padding-left: 8px;
}


.footer-bottom {
  background-color: #0a0a0a;
  text-align: center;
  padding: 18px 0;
  font-size: 0.9em;
  border-top: 1px solid rgba(255, 255, 255, 0.08);
  color: #aaaaaa;
}


@media (max-width: 768px) {
  .top-bar {
    flex-direction: column;
    text-align: center;
    gap: 8px;
  }

  .footer-container {
    flex-direction: column;
    align-items: center;
    padding: 30px 15px;
  }

  .footer-section {
    margin: 20px 0;
    text-align: center;
  }

  .social-icons {
    justify-content: center;
  }
}

</style>
