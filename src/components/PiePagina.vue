<script>
export default{
name:'PiePagina',
}
</script>

<template>
  <footer class="footer">
    <div class="footer-container">
      <div class="footer-section">
        <h3>Conéctate con nosotros en las redes sociales:</h3>
        <div class="social-links">
          <a href="#" target="_blank">Facebook</a>
          <a href="#" target="_blank">Twitter</a>
          <a href="#" target="_blank">Instagram</a>
          <a href="#" target="_blank">LinkedIn</a>
        </div>
      </div>

      <div class="footer-section">
        <h3>Tienda Tecnológica</h3>
        <p>¡Explora las últimas tendencias en tecnología! Encuentra los gadgets más innovadores, computadoras de última generación y accesorios imprescindibles. ¡La tecnología del mañana, hoy! 🌟</p>
        <p>#Innovación #Tecnología #Futuro</p>
      </div>

      <div class="footer-section">
        <h3>Productos</h3>
        <ul>
          <p>
              <a href="impresoras.html" class="text-reset">Impresoras</a>
            </p>
            <p>
              <a href="video_juegos.html" class="text-reset">Video Juegos</a>
            </p>
            <p>
              <a href="consolasAccesorios.html" class="text-reset">Consolas</a>
            </p>
            <p>
              <a href="celulares.html" class="text-reset">Celulares</a>
            </p>
            <p>
              <a href="computadores.html" class="text-reset">Computadores</a>
            </p>
            <p>
              <a href="laptos.html" class="text-reset">Laptos</a>
            </p>
        </ul>
      </div>

      <div class="footer-section">
        <h3>Enlaces útiles</h3>
        <ul>
          <li><a href="#">PQR</a></li>
          <li><a href="#">Contáctame</a></li>
          <li><a href="#">Sobre Nosotros</a></li>
        </ul>
      </div>

      <div class="footer-section">
        <h3>Contacto</h3>
        <p>Santa Marta, Magdalena, Colombia</p>
        <p>angeldanielgonzalezvillazon@gmail.com</p>
        <p>+57 3192281342</p>
      </div>
    </div>

    <div class="footer-bottom">
      <p>&copy; 2025 Copyright: Tienda Tecnológica</p>
    </div>
  </footer>
</template>
<style scoped>
.footer {
  background-color: #2c3e50;
  color: #fff;
  padding: 40px 0;
  font-family: Arial, sans-serif;
}

.footer-container {
  display: flex;
  justify-content: space-between;
  flex-wrap: wrap;
}

.footer-section {
  width: 20%;
  margin-bottom: 20px;
}

.footer-section h3 {
  font-size: 1.2em;
  margin-bottom: 10px;
}

.footer-section p {
  font-size: 0.9em;
 
}

.social-links a {
  margin-right: 5px;
  color: #fff;
  text-decoration: none;
}

.social-links a:hover {
  color: #3498db;
}

ul {
  padding-left: 0;
}

ul li {
  list-style: none;
  margin: 5px 0;
}

ul li a {
  color: #fff;
  text-decoration: none;
}

ul li a:hover {
  color: #3498db;
}

.footer-bottom {
  text-align: center;
  margin-top: 20px;
}

@media (max-width: 768px) {
  .footer-container {
    flex-direction: column;
    align-items: center;
  }

  .footer-section {
    width: 100%;
    text-align: center;
  }
}
</style>
