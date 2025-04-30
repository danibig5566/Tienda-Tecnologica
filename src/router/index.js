import { createRouter, createWebHistory } from 'vue-router'
import InicioPage from '../views/InicioPage.vue'
import VistaCelulares from '../views/VistaCelulares.vue'



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

 
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router

