<template>
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
    <router-link :to="router?.MstOverview?.path" class="brand-link text-center">
      <span class="brand-text font-weight-light">{{ shopName }}</span>
    </router-link>
    <!-- Sidebar -->
    <div class="sidebar">
      <!-- Sidebar user panel (optional) -->
      <div class="user-panel mt-3 pb-3 mb-3 pt-3 d-flex">
        <div class="image">
          <div class="image">
            <img
              src="/images/User.jpg"
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
          <!-- TODO -->

          <li class="nav-item" @click="toggleSubMenu(1)">
            <router-link
              :to="router?.MstOverview?.path"
              class="nav-link menu-download"
              :class="getActive(1, router?.MstOverview?.path)"
            >
              <i class="fas fa-eye nav-icon"></i>
              <p>TỔNG QUAN</p>
            </router-link>
          </li>

          <!-- xem trạng thái nhân viên -->
          <li class="nav-item" @click="toggleSubMenu(2)">
            <router-link
              :to="router?.MstEmployee?.path"
              class="nav-link menu-download"
              :class="getActive(2, router?.MstEmployee?.path)"
            >
              <i class="fas fa-user nav-icon"></i>
              <p>Nhân viên</p>
            </router-link>
          </li>

          <!-- Xem trạng thái kho -->
          <li class="nav-item" @click="toggleSubMenu(3)">
            <router-link
              :to="router?.MstWarehouse?.path"  
              class="nav-link menu-download"
              :class="getActive(3, router?.MstWarehouse?.path)"
            >
              <i class="fas fa-warehouse nav-icon"></i>
              <p>Kho</p>
            </router-link>
          </li>

          <!-- Xem trạng thái các món ăn trong quán -->
          <li class="nav-item" @click="toggleSubMenu(4)">
            <router-link
              :to="'/menu'"  
              class="nav-link menu-download"
              :class="getActive(4, null)"
            >
              <i class="fas fa-warehouse nav-icon"></i>
              <p>Món ăn - menu</p>
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
