<template>
  <div class="wrapper">
    <!-- Navbar -->
    <Navbar />
    <!-- /.navbar -->

    <!-- Main Sidebar Container -->
    <Sidebar />
    <!-- /.sidebar -->
    <div class="content-wrapper">
      <router-view />
    </div>
    <!-- Main Footer -->
    <footer class="main-footer">
      <!-- Default to the left -->
      Copyright © 2023 HRS All rights reserved.
    </footer>
  </div>
</template>

<script>
import Navbar from "@/components/layouts/Navbar.vue";
import Sidebar from "@/components/layouts/Sidebar.vue";
export default {
  components: {
    Navbar,
    Sidebar,
  },
};
</script>

<style lang="scss" scoped></style>
