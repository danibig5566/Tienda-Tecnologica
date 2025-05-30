<script>
import BodySobreNosotros from '../components/BodySobreNosotros.vue';
import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';


export default {
    name:'VistasobreNosotros',
    components:{
        Encabezado,BodySobreNosotros,PiePagina
    }
}
</script>
<template>
<Encabezado></Encabezado>
<BodySobreNosotros></BodySobreNosotros>
<PiePagina></PiePagina>
</template>
<style scoped>

</style>