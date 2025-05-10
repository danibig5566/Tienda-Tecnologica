<template>
   
    <Encabezado > </Encabezado >
     <BodyAccesorios></BodyAccesorios>
       <PiePagina> </PiePagina >
      
</template>

<script>
import BodyAccesorios from '../components/BodyAccesorios.vue';
import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';
;

export default {
  name: 'VistaCelulares',
  components: {
    Encabezado,
    PiePagina,
    BodyAccesorios
  }
}
</script>

<style scoped>
</style>