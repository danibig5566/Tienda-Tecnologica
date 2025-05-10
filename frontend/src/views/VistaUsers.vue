<script>
import BodysUsers from '../components/BodysUsers.vue';
import Encabezado from '../components/Encabezado.vue';
import PiePagina from '../components/PiePagina.vue';

export default {
    name: 'VistaUsers',
    components: {
        Encabezado, PiePagina, BodysUsers
    }
}
</script>
<template>
    <Encabezado></Encabezado>
    <BodysUsers></BodysUsers>
    <PiePagina></PiePagina>
</template>

<style></style>