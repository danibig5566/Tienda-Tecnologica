import { createRouter, createWebHistory } from 'vue-router'
import InicioPage from '../views/InicioPage.vue'
import VistaCelulares from '../views/VistaCelulares.vue'
import VistaCarrito from '../views/VistaCarrito.vue'
import AgregarProductos from '../views/AgregarProductos.vue'
import VistaLaptos from '../views/VistaLaptos.vue'
import VistaConsolas from '../views/VistaConsolas.vue'
import VistaVideojuegos from '../views/VistaVideojuegos.vue'
import VistaAccesorios from '../views/VistaAccesorios.vue'
import VistaLogin from '../views/VistaLogin.vue'
import VistaContactanos from '../views/VistaContactanos.vue'
import VistaPqr from '../views/VistaPqr.vue'
import VistasobreNosotros from '../views/VistasobreNosotros.vue'

const routes = [
  { path: '/', name: 'VistaLogin', component: VistaLogin },
  { path: '/Inicio', name: 'Inicio', component: InicioPage },
  { path: '/vistacelulares', name: 'VistaCelulares', component: VistaCelulares },
  { path: '/VistaCarrito', name: 'VistaCarrito', component: VistaCarrito },
  { path: '/VistaLaptos', name: 'VistaLaptos', component: VistaLaptos },
  { path: '/AgregarProductos', name: 'AgregarProductos', component: AgregarProductos, meta: { requiereAdmin: true } },
  { path: '/VistaConsolas', name: 'VistaConsolas', component: VistaConsolas },
  { path: '/VistaVideojuegos', name: 'VistaVideojuegos', component: VistaVideojuegos },
  { path: '/VistaAccesorios', name: 'VistaAccesorios', component: VistaAccesorios },
  {path: '/VistaContactanos',name: 'VistaContactanos', component: VistaContactanos},
  {path:'/VistaPqr',name: 'VistaPqr',component: VistaPqr},
  {path:'/VistasobreNosotros',name:'VistaSobreNosotros',component:VistasobreNosotros},
  
]

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
});

router.beforeEach((to, from, next) => {
  const usuario = JSON.parse(localStorage.getItem('usuario'));
  const rutasPublicas = ['VistaLogin'];

  if (!usuario && !rutasPublicas.includes(to.name)) {
    return next({ name: 'VistaLogin' });
  }

  if (to.meta.requiereAdmin) {
    if (!usuario || (usuario.rol !== 'admin' && usuario.rol !== 'administrador')) {
      return next({ name: 'Inicio' });
    }
  }

  next();
});

export default router;


