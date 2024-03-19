// Common
export const ComLogin = "Đăng nhập";
export const ComMain = "Màn hình chính";
// OMS
export const MstCustomerMaster = "Customer master";

const ROUTER_NAME = {
  // ================== Common ===================
  ComLogin: "Login",
  ComMain: "Main",

  MstCustomerMaster: "CustomerMaster"
}
const ROUTER = {
  // ================== Common ===================
  ComLogin: {
    path: "/login",
    name: "Login",
  },
  ComMain: {
    path: "/main",
    name: "Main",
  },
  
  OmsDataDownload: {
    path: "/data-download",
    name: "DataDownload",
  },
  MstCustomerMaster: {
    path: "/customer-master",
    name: "CustomerMaster",
  },
};

export { ROUTER, ROUTER_NAME };
