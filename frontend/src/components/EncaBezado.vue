<script>
export default {
  name: 'EncaBezado',
  data() {
    return {
      usuario: JSON.parse(localStorage.getItem('usuario') || 'null')
    };
  },
  computed: {
    esAdmin() {
      return this.usuario && (this.usuario.rol === 'admin' || this.usuario.rol === 'administrador');
    }
  },
  methods: {
    cerrarSesion() {
      localStorage.removeItem('usuario');
      this.usuario = null;
      this.$router.push({ name: 'VistaLogin' }); 
    }
  }
}
</script>

<template>
  <header class="header">
    <h2 class="logo">Gamer Store</h2>
    <nav class="menu">
      <ul class="nav-list">
        <li>
          <router-link to="/Inicio" title="Inicio">
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
          <router-link to="/VistaContactanos" title="contactanos">
            <i class="fas fa-envelope"></i>
          </router-link>
        </li>

        <li>
          <router-link to="/VistaPqr" title="Reclamos">
            <i class="fas fa-question-circle"></i>
          </router-link>
        </li>

        <li>
          <router-link to="/VistaCarrito" title="Carrito">
            <i class="fas fa-shopping-cart"></i>
          </router-link>
        </li>

        
        <li v-if="esAdmin">
          <router-link to="/AgregarProductos" title="Admin">  
            <i class="fas fa-user-cog"></i>
          </router-link>
        </li>

       
        <li v-if="usuario">
          <span style="color: #1abc9c; font-weight: bold;">
            👤 {{ usuario.nombre }}
          </span>
        </li>
        <li v-if="usuario">
          <button @click="cerrarSesion" class="logout-button">
            Cerrar sesión
          </button>
        </li>
      </ul>
    </nav>
  </header>
</template>

<style scoped>

header {
  background: rgba(17, 17, 17, 0.9);
  backdrop-filter: blur(8px);
  padding: 1rem 2rem;
  display: flex;
  justify-content: space-between;
  align-items: center;
  color: #fff;
  box-shadow: 0 8px 20px rgba(0, 0, 0, 0.4);
  position: sticky;
  top: 0;
  z-index: 1000;
  border-bottom: 1px solid rgba(255, 255, 255, 0.05);
}

.logo {
  font-size: 2rem;
  font-weight: 800;
  color: #1abc9c;
  letter-spacing: 1.5px;
  text-transform: uppercase;
  text-shadow: 1px 1px 3px rgba(0, 0, 0, 0.4);
}

.menu {
  display: flex;
  align-items: center;
}

.nav-list {
  list-style: none;
  display: flex;
  gap: 2rem;
  margin: 0;
  padding: 0;
  align-items: center;
}

.nav-list li {
  position: relative;
  display: flex;
  align-items: center;
}

.nav-list a {
  color: #ffffff;
  text-decoration: none;
  font-weight: 600;
  font-size: 1rem;
  padding: 0.5rem 0.75rem;
  border-radius: 6px;
  transition: all 0.3s ease;
}

.nav-list a:hover {
  background-color: rgba(26, 188, 156, 0.1);
  color: #1abc9c;
}

.nav-list i {
  font-size: 1.2rem;
  color: #ffffff;
  margin-left: 0.25rem;
  transition: color 0.3s ease;
}

.nav-list i:hover {
  color: #1abc9c;
}

.item {
  cursor: pointer;
}

.sub-item {
  position: absolute;
  top: 110%;
  left: 50%;
  transform: translateX(-50%);
  background-color: #1e1e1e;
  padding: 0.5rem 0;
  border-radius: 10px;
  opacity: 0;
  visibility: hidden;
  transition: all 0.4s ease;
  box-shadow: 0 6px 15px rgba(0, 0, 0, 0.3);
  min-width: 230px;
  z-index: 10;
}

.item:hover .sub-item {
  opacity: 1;
  visibility: visible;
  top: 120%;
}

.sub-item li {
  padding: 0.5rem 1rem;
  display: block;
}

.sub-item li a {
  font-size: 0.95rem;
  display: block;
  color: #ffffff;
  transition: all 0.3s ease;
}

.sub-item li a:hover {
  background-color: #2c3e50;
  color: #1abc9c;
  border-radius: 5px;
  padding-left: 10px;
}

.logout-button {
  background: linear-gradient(135deg, #e74c3c, #c0392b);
  color: white;
  border: none;
  padding: 8px 14px;
  border-radius: 6px;
  cursor: pointer;
  font-weight: bold;
  font-size: 0.9rem;
  transition: background 0.3s ease;
}

.logout-button:hover {
  background: linear-gradient(135deg, #c0392b, #96281b);
}

/* Responsive Design */
@media (max-width: 768px) {
  .nav-list {
    flex-direction: column;
    background: rgba(17, 17, 17, 0.95);
    position: absolute;
    top: 100%;
    right: 0;
    width: 250px;
    padding: 1rem;
    border-radius: 0 0 10px 10px;
    display: none;
  }

  .menu.active .nav-list {
    display: flex;
  }

  .nav-list li {
    width: 100%;
    justify-content: flex-start;
  }

  .sub-item {
    position: static;
    transform: none;
    opacity: 1;
    visibility: visible;
    box-shadow: none;
    padding: 0;
    background: transparent;
  }

  .sub-item li a {
    color: #fff;
  }
}
</style>
