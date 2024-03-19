// ======================== name tittle =========================
// Common
export const ComLogin = "Đăng nhập";
//
export const MstOverview = "Tổng quan";
export const MstEmployee = "Nhân viên";
export const MstWarehouse = "Kho";
//user
export const UserEmployee = "Nhân viên";

const ROUTER_NAME = {
  // ================== Common ===================
  ComLogin: "Login",
  MstOverview: "Overview",
  MstEmployee: "Employee",
  MstWarehouse: "MstWarehouse",
  //user
  
}
const ROUTER = {
  // ================== Common ===================
  ComLogin: {
    path: "/login",
    name: "Login",
  },
 // Status Admin
  // MstOverview: {
  //   path: "/overview",
  //   name: "Overview",
  // },
  // MstEmployee: {
  //   path: "/status-employee",
  //   name: "Employee",
  // },
  // MstWarehouse: {
  //   path: "/status-warehouse",
  //   name: "Warehouse",
  // },
  //user
  UserEmployeeHome: {
    path: "/employee",
    name: "EmployeeHome",
  },
  UserEmployeeStaff: {
    path: "/employee/staff",
    name: "EmployeeStaff",
  },
  UserEmployeeChef: {
    path: "/employee/chef",
    name: "EmployeeChef",
  },
  UserOrder: {
    path: "/employee/order",
    name: "Order",
  },

};

export { ROUTER, ROUTER_NAME };
