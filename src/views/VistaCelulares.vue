<template>
   
      <Encabezado > </Encabezado >
       <BodyCelulares></BodyCelulares>
         <PiePagina> </PiePagina >
        
  </template>
  
  <script>
  import BodyCelulares from '../components/BodyCelulares.vue';
  import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';
;
  
  export default {
    name: 'VistaCelulares',
    components: {
      Encabezado,
      PiePagina,
      BodyCelulares
    }
  }
  </script>
  
  <style scoped>
  </style>
  