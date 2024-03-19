import Vue from "vue";
import VueRouter from "vue-router";
import { ROUTER } from "../constants";
import { xor } from "lodash";

Vue.use(VueRouter);
//=================== COM ===================
const DefaultLayout = () => import("@/components/layouts/Dashboard.vue");
const LoginComponent = () => import("@/views/auth/Login.vue");
const Main = () => import("@/views/common/Main.vue");

const CustomerMaster = () => import("@/views/oms_system/CustomerMaster.vue");

const {
  ComLogin,
  ComMain,
  MstCustomerMaster,
} = ROUTER;
export const routes = [
  {
    path: ComLogin?.path,
    name: ComLogin?.name,
    component: LoginComponent,
    meta: {
      middleware: "guest",
      title: "SL-CLOUD | Login",
    },
  },
  {
    path: "/",
    component: DefaultLayout,
    redirect: ComMain.path,
    meta: {
      middleware: "auth",
      title: "SL-CLOUD",
    },
    children: [
      //=================== COM ===================
      
      {
        path: ComMain.path,
        name: ComMain.name,
        component: Main,
        meta: {
          title: "SL-CLOUD",
        },
      },

       //=================== WMS ===================
       
      {
        path: MstCustomerMaster.path,
        name: MstCustomerMaster.name,
        component: CustomerMaster,
        meta: {
          title: "SL-CLOUD",
          
        },
        params : {
          isOpenedFromMenu : false
        }
      },
    ],
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