<script>
import Encabezado from '../components/Encabezado.vue';
import BodyPQRs from '../components/BodyPQRs.vue';
import PiePagina from '../components/PiePagina.vue';
export default{
name:'VistaPqr',
components:{
    Encabezado,BodyPQRs,PiePagina
}
}
</script>

<template>
<Encabezado></Encabezado>
<BodyPQRs></BodyPQRs>
<PiePagina></PiePagina>
</template>

<style scoped>

</style>