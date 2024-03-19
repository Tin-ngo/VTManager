import Vue from "vue";
import VueRouter from "vue-router";
import { ROUTER } from "../constants";

Vue.use(VueRouter);
//=================== COM ===================
const LoginComponent = () => import("@/views/auth/Login.vue");

// const DefaultLayout = () => import("@/components/layouts/Dashboard.vue");
// const Overview = () => import("@/views/status_admin/Overview.vue");
// const Employee = () => import("@/views/status_admin/Employee.vue");
// const Warehouse = () => import("@/views/status_admin/Warehouse.vue");

//user
const userEmployeeHome = () => import("@/views/user/EmployeeHome.vue");
const userEmployeeStaff = () => import("@/views/user/EmployeeStaff.vue");
const userEmployeeChef = () => import("@/views/user/EmployeeChef.vue");
const userOrder = () => import("@/views/user/EmployeeOrder.vue");
  
const {
  ComLogin,
  // MstOverview,
  // MstEmployee,
  // MstWarehouse,
  // employee
  UserEmployeeHome,
  UserEmployeeStaff,
  UserEmployeeChef,
  UserOrder
} = ROUTER;

export const routes = [

  // sẽ chạy qua routerGuard.js để kiểm tra các điều kiện rồi mới tới đây
  // khi admin chưa login thì sẽ luôn qua trang login của admin
  // khi admin đã login thì mới vào được path '/employees' để vào trang nhân viên này
 
  {
    path: ComLogin?.path,
    name: ComLogin?.name,
    component: LoginComponent,
    meta: {
      middleware: "guest",
      title: "VT-MANAGER | Login",
    },
  },
  // {
  //   path: "/",
  //   component: DefaultLayout,
  //   redirect: MstOverview.path,  //là để khi mà vào / thì sẽ mặc định chuyển sang path của overview
  //   meta: {
  //     middleware: "auth",
  //     title: "VT-MANAGER",
  //   },
  //   children: [
  //     //=================== COM ===================
  //     {
  //       path: MstOverview.path,
  //       name: MstOverview.name,
  //       component: Overview,
  //       meta: {
  //         title: "VT-MANAGER",
  //       },
  //     },
  //     {
  //       path: MstEmployee.path,
  //       name: MstEmployee.name,
  //       component: Employee,
  //       meta: {
  //         title: "VT-MANAGER",
  //       },
  //     },
  //     {
  //       path: MstWarehouse.path,
  //       name: MstWarehouse.name,
  //       component: Warehouse,
  //       meta: {
  //         title: "VT-MANAGER",
  //       },
  //     },
  //   ],
  // },

  // Khi admin đã đăng nhập thì mới vào được các path dưới đây
  // employee
  {
    path: UserEmployeeHome.path,
    name: UserEmployeeHome.name,
    component: userEmployeeHome,
    meta: {
      middleware: "auth",
      title: "VT-MANAGER | Home",
    },
  },
  {
    path: UserEmployeeStaff.path,
    name: UserEmployeeStaff.name,
    component: userEmployeeStaff,
    meta: {
      middleware: "auth",
      title: "VT-MANAGER | Employee",
    }
  },
  {
    path: UserEmployeeChef.path,
    name: UserEmployeeChef.name,
    component: userEmployeeChef,
    meta: {
      middleware: "auth",
      title: "VT-MANAGER | Employee",
    }
  },
  {
    path: UserOrder.path,
    name: UserOrder.name,
    component: userOrder,
    meta: {
      middleware: "auth",
      title: "VT-MANAGER | Order",
    },
  },
];

const rootRoutes = new VueRouter({
  mode: "history",
  base: import.meta.env.VITE_BASE_URL,
  routes,
  strict: true,
});

rootRoutes.beforeResolve((to, from, next) => {
  if(from?.name !== null) {
    localStorage.setItem('previousPath', from?.path);
  }
  next();
});
export default rootRoutes;