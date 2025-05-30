<template>
  <div class="sobre-nosotros">
    <h1 class="titulo">Sobre Nosotros</h1>

    <!-- Tarjeta del CEO -->
    <div class="tarjeta">
      <div class="icono">👤</div>
      <div class="contenido">
        <h2 class="nombre">CEO: Ángel Daniel</h2>
        <p class="descripcion">
          Líder visionario, comprometido con la innovación, la excelencia y el crecimiento sostenible.
        </p>
      </div>
    </div>

   
    <h2 class="seccion-colab">Colaboradores</h2>
    <div class="contenedor-colab">
      <div class="tarjeta">
        <div class="icono">👤</div>
        <div class="contenido">
          <h3 class="nombre">Andrés</h3>
          <p class="descripcion">Colaborador </p>
          
        </div>
      </div>

      <div class="tarjeta">
        <div class="icono">👤</div>
        <div class="contenido">
          <h3 class="nombre">Diita</h3>
          <p class="descripcion">Colaborador </p>
          
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'BodySobreNosotros',
};
</script>

<style scoped>
.sobre-nosotros {
  max-width: 1000px;
  margin: 40px auto;
  padding: 20px;
  font-family: Arial, sans-serif;
  color: #333;
}

.titulo {
  text-align: center;
  font-size: 32px;
  margin-bottom: 30px;
}

.seccion-colab {
  margin-top: 40px;
  font-size: 24px;
  text-align: center;
  color: #222;
}

.tarjeta {
  display: flex;
  align-items: center;
  background: #fff;
  border-radius: 12px;
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
  margin-bottom: 30px;
  padding: 20px;
  gap: 20px;
}

.icono {
  font-size: 60px;
  color: #4CAF50;
  min-width: 80px;
  text-align: center;
}

.contenido {
  flex: 1;
}

.nombre {
  margin: 0;
  font-size: 20px;
  font-weight: bold;
  color: #2c3e50;
}

.descripcion {
  margin: 10px 0;
  font-size: 15px;
  color: #555;
}

.subtitulo {
  font-size: 16px;
  margin-top: 15px;
  font-weight: bold;
}

.lista {
  padding-left: 20px;
  margin-top: 8px;
}

.lista li {
  margin-bottom: 6px;
}

.boton {
  margin-top: 10px;
  background-color: #4CAF50;
  border: none;
  padding: 8px 16px;
  color: white;
  font-size: 14px;
  border-radius: 6px;
  cursor: pointer;
}

.boton:hover {
  background-color: #43a047;
}

.contenedor-colab {
  display: flex;
  flex-wrap: wrap;
  gap: 20px;
  justify-content: center;
}
</style>


