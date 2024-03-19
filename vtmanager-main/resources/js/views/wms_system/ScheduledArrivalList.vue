<template>
    <section class="main-section">
      <div class="container-fluid pt-2">
        <div class="card">
          <div class="card-body">
            
          </div>
        </div>
      </div>
      <div class="container-fluid footer-item">
        <div class="card">
          <div class="card-body">
            
            

          </div>
        </div>
      </div>
    </section>
  </template>
  
  <script>
  import { TmsVehicleMaintenance } from "../../constants/router";
  
  export default {
    data() {
      return {
      };
    },
    mounted() {
      this.$store.dispatch("auth/setTitle", "入荷予定一覧");
    },
  
    methods: {
      goBack() {
        this.$router.push({ path: "/main" });
      },
    },
  };
  </script>
  