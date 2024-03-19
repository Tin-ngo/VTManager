import Vue from "vue";
import "vue-toastification/dist/index.css";
import "vue2-datepicker/index.css";
// import "vue2-datepicker/locale/ja";
import "./bootstrap";
/* import the fontawesome core */
import "@/main.components";
import router from "@/router/router";
import "@/router/routerGuard";
import { library } from "@fortawesome/fontawesome-svg-core";
import { fab } from "@fortawesome/free-brands-svg-icons";
import { far } from "@fortawesome/free-regular-svg-icons";
import { fas } from "@fortawesome/free-solid-svg-icons";
import VueFormulate from '@braid/vue-formulate'
import "../css/vue-formulate.css";

import store from "@/store";
import Toast, { TYPE } from "vue-toastification";
import i18n from "./utils/i18n";

const filterBeforeCreate = (toast, toasts) => {
  if (toasts.filter((t) => t.type === toast.type).length !== 0) {
    return false;
  }
  return toast;
};
// Toast options
const options = {
  toastDefaults: {
    [TYPE.ERROR]: {
      timeout: 1000,
      closeButton: false,
      containerClassName: 'success-toast-container',
    },
    [TYPE.SUCCESS]: {
      timeout: 1000,
      containerClassName: 'success-toast-container',
    },
  },
  filterBeforeCreate: filterBeforeCreate,
};

Vue.use(Toast, options);
Vue.use(VueFormulate)

/* add icons to the library */
library.add(fas, far, fab);
Vue.config.productionTip = false;

new Vue({
  el: "#app",
  i18n,
  router,
  store,
});
