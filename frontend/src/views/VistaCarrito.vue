<script>
import BodyCarrito from '../components/BodyCarrito.vue';
import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';
export default{
    name:'VistaCarrito',
    components:{
       Encabezado,PiePagina,BodyCarrito
    }
}
</script>
<template>
<Encabezado></Encabezado>
<BodyCarrito></BodyCarrito>
<PiePagina></PiePagina>



</template>

<style scoped>

</style>