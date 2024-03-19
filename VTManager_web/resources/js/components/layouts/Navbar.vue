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
      <li class="nav-item text-center" title="Manage">
        <div class="hover-show">
          <font-awesome-icon icon="fas fa-user fa-lg" />
          <ul class="ul-user" style="display: none;">
            <li @click="redirectSer">
              Nhân viên phục vụ
            </li>
            <li @click="redirectChef">
              Nhân viên bếp
            </li>
          </ul>
      </div>
      </li>
      <li class="nav-item" title="Manage">
        <button class="button-top">
          <font-awesome-icon icon="fas fa-cogs fa-lg" />
        </button>
      </li>
      <li class="nav-item">
        <button class="button-top" @click="logout" title="Logout">
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
    redirectSer(){
      this.$router.push("/employee/staff");
    },
    redirectChef(){
      this.$router.push("/employee/chef");
    }
  },
};
</script>

<style lang="scss" scoped>
.button-top {
  border: hidden;
  background-color: transparent;
}

.nav-item{
  padding: 0 6px;
  font-size: 20px;
}

.hover-show{
  position: relative;
}
.hover-show:hover ul.ul-user{
  position: absolute;
  top: 38px;
  right: -10px;
  text-align: right;
  display: block !important;
  background-color: #fff;
  list-style: none;
  padding: 0 6px;
  box-shadow: 0px 2px 8px -4px #000;
}

ul.ul-user{
  padding: 8px !important;
}

ul.ul-user li{
  width: 160px;
  font-size: 16px;
  margin-bottom: 2px;
  border-bottom: 1px solid #ccc;
}

ul.ul-user li:hover{
  background-color: #ccc;
  cursor: pointer;
}

ul.ul-user:before{
  content: "";
  border-style: solid;
  border-width: 16px 16px;
  border-color: transparent transparent #fff transparent;
  position: absolute;
  right: 2px;
  top: -26px;
}
</style>
