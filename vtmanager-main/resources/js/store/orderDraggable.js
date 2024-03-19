import { merge } from 'lodash'
export default {
  namespaced: true,
  state: {
    dispatchSettingOrder: {},
  },
  mutations: {
    SET_DISPATCH_SETTING_ORDER(state, object) {
      state.dispatchSettingOrder = merge(state.dispatchSettingOrder, object)
    },
  },
  actions: {
    updateOrderDispatchSetting({ commit }, object) {
      commit("SET_DISPATCH_SETTING_ORDER", object);
    },
  },
  getters: {
    dispatchSettingOrder(state) {
      return state.dispatchSettingOrder;
    },
  },
};
