<script>
import BodyLaptos from '../components/BodyLaptos.vue';
import EncaBezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';
export default {
    name: 'VistaLaptos',
    components: {
        EncaBezado, PiePagina, BodyLaptos
    }
}
</script>

<template>
    <EncaBezado></EncaBezado>
    <BodyLaptos></BodyLaptos>
    <PiePagina></PiePagina>

</template>

<style scoped></style>