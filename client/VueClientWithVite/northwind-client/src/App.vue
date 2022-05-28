<script setup>
import AppSideBar from "./components/AppSideBar.vue";
</script>

<template>
  <div class="row">
    <div style="width:280px">
      <AppSideBar />
    </div>
    <div class="col">
      <div class="container">
        <RouterView />
      </div>
    </div>
  </div>
</template>
<style>
</style>

