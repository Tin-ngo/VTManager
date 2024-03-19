<template>
  <!-- Navbar -->
  <nav class="main-header navbar navbar-expand navbar-white navbar-light">
    <!-- Left navbar links -->
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" data-widget="pushmenu" href="#" role="button"
          ><i class="fas fa-bars"></i
        ></a>
      </li>
    </ul>

    <div class="font-weight-bold">
      {{ title }}
    </div>

    <!-- Right navbar links -->
    <ul class="navbar-nav ml-auto">
      <li class="nav-item">
        <button class="logout" @click="logout">
          <font-awesome-icon icon="fas fa-sign-out-alt fa-lg" />
        </button>
      </li>
    </ul>
  </nav>
  <!-- /.navbar -->
</template>
<script>
import { ROUTER } from "../../constants";
export default {
  data() {
    return {
      user: {},
    };
  },
  computed: {
    title() {
      return this.$store.state.auth.title;
    },
  },
  methods: {
    logout() {
      localStorage.clear();
      this.$router.push({ name: ROUTER.ComLogin.name });
    },
  },
};
</script>

<style lang="scss" scoped>
.logout {
  border: hidden;
  background-color: transparent;
}
</style>
