<script>
import BodyConsolas from '../components/BodyConsolas.vue';
import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';
export default{
name:'VistaConsolas',
components:{
    Encabezado,PiePagina,BodyConsolas
}
}
</script>

<template>
<Encabezado></Encabezado>
<BodyConsolas></BodyConsolas>
<PiePagina></PiePagina>

</template>

<style scoped>

</style>