import { ROOT_STATE } from "./state";

export const ROOT_MUTATIONS = {
  SET_LOADING: "SET_LOADING",
  REMOVE_LOADING: "REMOVE_LOADING",
};

export const mutations = {
  [ROOT_MUTATIONS.SET_LOADING](state, actionName) {
    if (!state[ROOT_STATE.LOADINGS].includes(actionName))
      state[ROOT_STATE.LOADINGS].push(actionName);
  },
  [ROOT_MUTATIONS.REMOVE_LOADING](state, actionName) {
    state[ROOT_STATE.LOADINGS] = state[ROOT_STATE.LOADINGS].filter(
      (loading) => loading !== actionName
    );
  },
};
