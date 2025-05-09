<script>

export default {
  name: 'EncaBezado',
};
</script>

<template>
  <header class="header">
    <h2 class="logo">Gamer Store</h2>
    <nav class="menu">
      <ul class="nav-list">
  <li>
    <router-link to="/" title="Inicio">
      <i class="fas fa-house"></i>
    </router-link>
  </li>
  <li class="item">
    <i class="fa-sharp fa-solid fa-bars" style="margin-right: 5px;"></i> 
    <ul class="sub-item">
      <li><router-link to="/VistaConsolas">Consolas</router-link></li>
      <li><router-link to="/vistacelulares">Celulares</router-link></li>
      <li><router-link to="/VistaVideojuegos">Videojuegos</router-link></li>
      <li><router-link to="/VistaLaptos">Laptops</router-link></li>
      <li><router-link to="/VistaAccesorios">Accesorios</router-link></li>
    </ul>
  </li>
  <li>
    <router-link to="/contacto" title="Contactenos">
      <i class="fas fa-envelope"></i>
    </router-link>
  </li>
  <li>
    <router-link to="/pqr" title="Reclamos">
      <i class="fas fa-question-circle"></i>
    </router-link>
  </li>
  <li>
    <router-link to="/VistaCarrito" title="Carrito">
      <i class="fas fa-shopping-cart"></i>
    </router-link>
  </li>
  <li>
    <router-link to="/AgregarProductos" title="Admin">
      <i class="fas fa-user-cog"></i>
    </router-link>
  </li>
</ul>

    </nav>
  </header>
</template>

<style scoped>


.header {
  background-color: #111;
  padding: 1rem 2rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
  color: #fff;
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.25);
  position: sticky;
  top: 0;
  z-index: 100;
}

.logo {
  font-size: 2rem;
  font-weight: 700;
  color: #1abc9c;
  letter-spacing: 1px;
}

.menu {
  display: flex;
}

.nav-list {
  list-style: none;
  display: flex;
  gap: 2rem;
  align-items: center;
}

.nav-list li {
  position: relative;
}

.nav-list a {
  color: #fff;
  text-decoration: none;
  font-weight: 500;
  font-size: 1rem;
  transition: color 0.3s ease;
}

.nav-list a:hover {
  color: #1abc9c;
}

.nav-list i {
  font-size: 1.2rem;
  color: #ffffff;
  transition: color 0.3s ease;
}

.nav-list i:hover {
  color: #1abc9c;
}

.item {
  cursor: context-menu;
}

.sub-item {
  position: absolute;
  top: 100%;
  transform: translateX(-50%);
  background-color: #ffffff;
  padding: 0.13rem 20;
  border-radius: 8px;
  
  opacity: 0;
  visibility: hidden;
  transition: opacity 0.3s ease, visibility 0.3s ease;
  min-width: 230px;
}

.item:hover .sub-item {
  opacity: 6  ;
  visibility: visible;
}

.sub-item li {
  padding: 0.5rem 5rem;
  display:table-caption;
}

.sub-item li a {
  font-size: 0.9rem;
  display: block;
  color: #000000;
  transition: color 0.3s ease;
}

.sub-item li a:hover {
  color: #1abc9c;
}
</style>
