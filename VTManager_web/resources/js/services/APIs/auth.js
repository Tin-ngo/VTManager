import axios from "axios";
import http from "../../utils/http";

const authService = {
  login: async (params) =>
    axios.post("/api/auth/login",
      params,
    ),
  loginEmployee: async (params) =>
    axios.post("/api/auth/login-employee",
      params,
    )
};

export default authService;
