<script>
import Encabezado from '../components/Encabezado.vue';
import LoginUsers from '../components/LoginUsers.vue';
import PiePagina from '../components/PiePagina.vue';


export default {
    name: 'VistaUsers',
    components: {
        Encabezado, PiePagina, LoginUsers
    }
}
</script>
<template>
    <Encabezado></Encabezado>
    <LoginUsers></LoginUsers>
    <PiePagina></PiePagina>
</template>

<style></style>