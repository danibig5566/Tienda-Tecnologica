import { createRouter, createWebHistory } from 'vue-router'
import InicioPage from '../views/InicioPage.vue'
import VistaCelulares from '../views/VistaCelulares.vue'
import VistaCarrito from '../views/VistaCarrito.vue'
import AgregarProductos from '../views/AgregarProductos.vue'
import VistaLaptos from '../views/VistaLaptos.vue'
import VistaConsolas from '../views/VistaConsolas.vue'
import VistaVideojuegos from '../views/VistaVideojuegos.vue'
import VistaAccesorios from '../views/VistaAccesorios.vue'
import VistaUsers from '../views/VistaUsers.vue'
import VistaLogin from '../views/VistaLogin.vue'

const routes = [
  {
    path: '/',
    name: 'VistaLogin',
    component: VistaLogin
  },
  {
    path: '/Inicio',
    name: 'Inicio',
    component: InicioPage
  },
  {
    path:'/vistacelulares',
    name:'VistaCelulares',
    component:VistaCelulares
  },
  {
    path:'/VistaCarrito',
    name:'VistaCarrito',
    component:VistaCarrito
  },
  {
    path:'/VistaLaptos',
    name:'VistaLaptos',
    component:VistaLaptos
  },
  {
    path:'/AgregarProductos',
    name:'AgregarProductos',
    component:AgregarProductos
  },
  {
    path:'/VistaConsolas',
     name:'VistaConsolas',
     component:VistaConsolas
  },
  {
    path:'/VistaVideojuegos',
    name:'VistaVideojuegos',
    component:VistaVideojuegos
  },
  {
    path:'/VistaAccesorios',
    name:'VistaAccesorios',
    component:VistaAccesorios
  },
  {
    path:'/VistaUsers',
    name:'VistaUsers',
    component:VistaUsers

  },
  

 
]




const router = createRouter({
  history: createWebHistory(),
  routes
})

router.beforeEach((to, from, next) => {
  const usuario = JSON.parse(localStorage.getItem('usuario'));
  const rutasPublicas = ['VistaLogin'];

  if (!usuario && !rutasPublicas.includes(to.name)) {
    next({ name: 'VistaLogin' }); 
  } else {
    next();
  }
});


export default router

