import router from "@/router/router";
import http from "@/utils/http";
import i18n from "../utils/i18n";

export default {
  namespaced: true,
  state: {
    authenticated: false,
    user: {},
    title: null,
  },
  getters: {
    authenticated(state) {
      return state.authenticated;
    },
    user(state) {
      return state.user;
    },
  },
  mutations: {
    SET_AUTHENTICATED(state, payload) {
      state.authenticated = payload;
    },
    SET_USER(state, payload) {
      state.user = payload;
    },
    SET_LANG(state, payload) {
      i18n.locale = payload
    },
    SET_TITLE(state, payload) {
      state.title = payload
    }
  },
  actions: {
    login({ commit }) {
      return http
        .get("/user")
        .then((response) => {
          commit("SET_USER", response);
          commit("SET_AUTHENTICATED", true);
        })
        .catch((error) => {
          commit("SET_USER", {});
          commit("SET_AUTHENTICATED", false);
        });
    },
    logout({ commit }) {
      commit("SET_USER", {});
      commit("SET_AUTHENTICATED", false);
    },
    setLang({ commit }, payload) {
      commit('SET_LANG', payload)
      localStorage.setItem("appLanguage", payload)
    },
    setTitle({ commit }, payload) {
      commit('SET_TITLE', payload)
    }
  },
};
