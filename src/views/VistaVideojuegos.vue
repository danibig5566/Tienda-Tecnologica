<script>
import BodyVideojuegos from '../components/BodyVideojuegos.vue';
import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';
export default{
name:'VistaVideojuegos',
components:{
    Encabezado,PiePagina,BodyVideojuegos
}
}
</script>

<template>
    <Encabezado></Encabezado>
    <BodyVideojuegos></BodyVideojuegos>
    <PiePagina></PiePagina>

</template>

<style scoped>

</style>