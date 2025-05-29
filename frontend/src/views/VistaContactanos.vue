<script>
import BodyContactame from '../components/BodyContactame.vue';
import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';

export default{
name:'VistaContactanos',
components:{
    Encabezado,PiePagina,BodyContactame
}
}
</script>

<template>
<Encabezado></Encabezado>
<BodyContactame></BodyContactame>
<PiePagina></PiePagina>

</template>

<style scoped>

</style>