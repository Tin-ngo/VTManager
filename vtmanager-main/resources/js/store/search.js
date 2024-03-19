import { isEmpty, merge } from "lodash";

export default {
  namespaced: true,
  state: {
    searchQuery: {},
  },
  mutations: {
    setSearchQuery(state, object) {
      if(isEmpty(Object.values(object)?.[0])) {
        state.searchQuery[Object.keys(object)] = {}
      } else {
        state.searchQuery = merge(state.searchQuery, object)
      }
    },
  },
  actions: {
    updateSearchQuery({ commit }, object) {
      commit("setSearchQuery", object);
    },
  },
  getters: {
    searchQuery(state) {
      return state.searchQuery;
    },
  },
};
