import { ROOT_MUTATIONS, mutations } from "./mutations";
import { state } from "./state";
// import modules from "./modules";
import Vue from "vue";
import Vuex from "vuex";
import createPersistedState from "vuex-persistedstate";
import auth from "./auth";
import search from "./search";
import orderDraggable from "./orderDraggable";

Vue.use(Vuex);
const store = new Vuex.Store({
  plugins: [createPersistedState()],
  state,
  mutations,
  modules: {
    auth,
    search,
    orderDraggable
  },
});

// export * from "./modules";

export { ROOT_MUTATIONS };

export default store;
