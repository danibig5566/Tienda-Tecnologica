<template>
   <Encabezado></Encabezado>
   <BodyAdmin></BodyAdmin>
   <PiePagina></PiePagina>
  </template>
  
  <script>
import BodyAdmin from '../components/BodyAdmin.vue';
import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';

export default {
  name:'AgregarProductos',
  components:{
Encabezado,PiePagina,BodyAdmin
  }

}
 
  </script>
  <style scoped>
</style>
  