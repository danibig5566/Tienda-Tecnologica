<script>
import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';
import BodyInicio from '../components/BodyInicio.vue';
export default {
  name: 'InicioPage',
  components:{
    Encabezado,PiePagina,BodyInicio
  }
}
</script>
<template>
<Encabezado></Encabezado>
<BodyInicio></BodyInicio>
<PiePagina></PiePagina>
</template>
<style scoped>
</style>