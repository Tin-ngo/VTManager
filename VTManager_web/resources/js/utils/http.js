import axios from "axios";
import { API_PREFIX, API_URL, RESPONSE_CODE } from "../constants";
import { getToken } from "@/utils/storage";

const http = axios.create({
  baseURL: `/${API_PREFIX}`, // do not use baseUrl here, because source is running with the same baseUri as the server, just prefix '/api'
  timeout: 5000,
  // withCredentials: true
});

http.interceptors.request.use(
  async (config) => {
    const token = await getToken();
    if (token) {
      config.headers["Authorization"] = `Bearer ${token}`;
    }

    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

http.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response) {
      if (`${API_URL}/` === error.response.config.baseURL) {
        // APIのエラー結果を入れる前に、残っているエラー情報を削除する
        Vue.prototype.$error.reset();
        // 失敗時のレスポンス情報をstore(localstorage)に保存
        Vue.prototype.$error.code = error.response.status;
        Vue.prototype.$error.url = `[${error.response.config.method}] ${error.response.config.url}`;
        Vue.prototype.$error.data = error.response.data;
      }

      const statuscode = error.response.status;
      if (
        statuscode == RESPONSE_CODE.UNAUTHORIZED &&
        error.response.config.url != "/session-time-out"
      ) {
        router.push("/session-time-out");
      }

      return {
        ...error.response,
        isError: true,
      };
    } else {
      return false;
    }
  }
);

export default http;
