<template>
   <Encabezado></Encabezado>
   <BodyAdmin></BodyAdmin>
     <BodysUsers></BodysUsers>
   <PiePagina></PiePagina>
  </template>
  
  <script>
import BodyAdmin from '../components/BodyAdmin.vue';
import BodysUsers from '../components/BodysUsers.vue';
import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';

export default {
  name:'AgregarProductos',
  components:{
Encabezado,PiePagina,BodyAdmin,BodysUsers
  }

}
 
  </script>
  <style scoped>
</style>
  