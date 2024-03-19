import axios from "axios";
import http from "../../utils/http";

const authService = {
  login: (params) =>
    axios.post("/api/auth/login",
      params,
    ),
  information: (params) =>
    http.get("/auth/information", params)
};

export default authService;
