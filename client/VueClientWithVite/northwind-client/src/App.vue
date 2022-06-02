<script setup>
import AppSideBar from "./components/AppSideBar.vue";
import AppNavBar from "./AppNavBar.vue";
</script>

<template>
  <div class="row">
    <div style="width:280px">
      <AppSideBar />
    </div>
    <div class="col">
      <AppNavBar />
      <div class="container">
        <RouterView />
      </div>
    </div>
  </div>
</template>
<style>
</style>

