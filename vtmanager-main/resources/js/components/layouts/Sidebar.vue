<template>
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
    <router-link :to="router?.ComMain?.path" class="brand-link text-center">
      <span class="brand-text font-weight-light">{{ shopName }}</span>
    </router-link>
    <!-- Sidebar -->
    <div class="sidebar">
      <!-- Sidebar user panel (optional) -->
      <div class="user-panel mt-3 pb-3 mb-3 pt-3 d-flex">
        <div class="image">
          <div class="image">
            <img
              src="images/User.jpg"
              class="img-circle elevation-2"
              alt="User Image"
            />
          </div>
        </div>
        <div class="info">
          <a href="#" class="d-block">{{ userName }}</a>
        </div>
      </div>

      <nav class="mt-2">
        <ul
          class="nav nav-pills nav-sidebar flex-column"
          data-widget="treeview"
          role="menu"
          data-accordion="false"
        >
          <!-- OMS -->
          <li
            class="nav-item nav-item-parent-1"
            :class="navItemParent1"
            @click="toggleMenu(1)"
          >
            <a href="#" class="nav-link">
              <i class="nav-icon fas fa-home"></i>
              <p>
                OMS MENU
                <i class="right fas fa-angle-left"></i>
              </p>
            </a>
            <ul class="nav nav-treeview">
              <li class="nav-item" @click="toggleSubMenu(7)">
                <router-link
                  :to="{ name: router?.MstCustomerMaster.name, params: { isOpenedFromMenu: true } }"
                  class="nav-link"
                  :class="getActive(7, router?.MstCustomerMaster?.path)"
                >
                  <i class="far fa-circle nav-icon"></i>
                  <p>{{ $t("menu.customer_master") }}</p>
                </router-link>
              </li>
              
            </ul>
          </li>

          <!-- TODO -->
          
          <li class="nav-item" @click="toggleSubMenu(12)">
            <router-link
              :to="router?.OmsDataDownload?.path"
              class="nav-link menu-download"
              :class="getActive(12, router?.OmsDataDownload?.path)"
            >
              <i class="fas fa-download nav-icon"></i>
              <p>DOWNLOAD</p>
            </router-link>
          </li>
        </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside>
</template>

<script>
import { ROUTER } from "../../constants";
export default {
  data() {
    return {
      router: ROUTER,
      userName: null,
      shopName: null,
      navItemParent1: "menu-open",
      navItemParent2: "",
      navItemParent3: "",
      selectedMenu: null,
    };
  },
  mounted() {
    console.log('Lấy tên người dùng ở đây - đổi tên column trong table sẽ đổi được ở đây ', this.$store?.state?.auth?.user?.data);
    this.userName = this.$store?.state?.auth?.user?.data.adminName;
    this.shopName = this.$store?.state?.auth?.user?.data.shopName;
  },
  methods: {
    toggleMenu(option) {
      switch (option) {
        case 1:
          this.navItemParent1 = "menu-open";
          this.navItemParent2 = "";
          this.navItemParent3 = "";

          break;
        case 2:
          this.navItemParent1 = "";
          this.navItemParent2 = "menu-open";
          this.navItemParent3 = "";
          break;
        case 3:
          this.navItemParent1 = "";
          this.navItemParent2 = "";
          this.navItemParent3 = "menu-open";
          break;
        default:
          break;
      }
    },
    toggleSubMenu(option) {
      this.selectedMenu = option;
    },
    getActive(option, routePath) {
      if (this.$route.path === routePath) {
        this.selectedMenu = option;
        return "active";
      }
      return "";
    },
  },
};
</script>

<style scoped>
.menu-download.active {
  background-color: #fff !important;
  color: black !important;
}
</style>
