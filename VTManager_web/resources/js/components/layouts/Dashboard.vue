<template>
  <div class="wrapper">
    <!-- admin -->
    <div>  <!-- v-show="isUserLogin != null ? false : true"-->
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
        Copyright © 2023 TIN-VKU All rights reserved.
      </footer>
    </div>
  </div>
</template>

<script>
import Navbar from "@/components/layouts/Navbar.vue";
import Sidebar from "@/components/layouts/Sidebar.vue";
export default {
  data(){
    return {
    }
  },
  created() {
    
  },
  components: {
    Navbar,
    Sidebar,
  },
};
</script>

<style lang="scss" scoped></style>
