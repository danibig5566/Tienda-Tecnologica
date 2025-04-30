import { createRouter, createWebHistory } from 'vue-router'
import InicioPage from '../views/InicioPage.vue'
import VistaCelulares from '../views/VistaCelulares.vue'
import VistaCarrito from '../views/VistaCarrito.vue'



const routes = [
  {
    path: '/',
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

 
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router

