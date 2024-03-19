import http from "@/utils/http";

// định nghĩa URL
const listUrl = {

  area: {
    list: "admin/status/areas/"
  },
  table: {
    list: "admin/status/tables/",
    orders: "admin/status/table-orders/",
    update_status: "employee/update-status-table/"
  },
  order: {
    list: "admin/status/orders/",
    add: "employee/add-order",
    get: "employee/get-order",
    update: "employee/update-order",
    delete: "employee/delete-order",
    deletes: "employee/delete-orders",
    reduce_quantity: "employee/reduce-quantity",
    update_status: "employee/update-status-order/",
    update_status_orders: "employee/update-status-orders/",
    update_status_paid: "employee/update-status-paid/",
    switch_table: "employee/switch-table/"
  },
  employee: {
    list: "admin/status/employees/",
    check: "admin/status/employees-is-working/"
  },
  product_type: {
    list: "admin/status/product_type/"
  },
  product: {
    list: "admin/status/product/",
    update_status_product: "admin/status/product/update-status-product/"
  },
  bill: {
    add: "employee/add-bill"
  },
  // là các api lấy chung để tránh bị nhiều lần gọi
  common: {
    order: "common/orders/",
    employee_staff: "common/employee_staff",
    employee_order: "common/employee_order/",
  }
};

// ĐỊNH NGHĨA GỌi API

// common
const getCommonEmployeeStaff = async (params) => {
  try {
    const result = await http.get(listUrl.common.employee_staff, {params});
    return result?.data?.data;
  } catch (error) {
    console.log(error);
  }
};

const getCommonEmployeeOrder = async (ownerId) => {
  try {
    const result = await http.get(listUrl.common.employee_order + ownerId);
    return result?.data?.data;
  } catch (error) {
    console.log(error);
  }
};


// Web

// lấy tất cả khu vực
const getAreas = async (ownerId) => {
  try {
    const result = await http.get(
      listUrl.area.list + ownerId
    );
    return result?.data?.data?.areas;
  } catch (error) {
    console.log(error);
  }
};

// lấy tất cả bàn
const getTables = async (ownerId) => {
  try {
    const result = await http.get(
      listUrl.table.list + ownerId
    );
    return result?.data?.data?.tables;
  } catch (error) {
    console.log(error);
  }
};

// lấy tất cả table có join với order
const getTableOrders = async (ownerId) => {
  try {
    const result = await http.get(
      listUrl.table.orders + ownerId
    );
    return result?.data?.data?.tableOrders;
  } catch (error) {
    console.log(error);
  }
};

// lấy tất cả order
const getOrders = async (ownerId) => {
  try {
    const result = await http.get(
      listUrl.order.list + ownerId
    );
    return result?.data?.data?.orders;
  } catch (error) {
    console.log(error);
  }
};

// đổi bàn trong đơn hàng dựa vào orerId
const switchTable = async (params = {}) => {
    try {
      const result = await http.get(listUrl.order.switch_table, { params })
      return result?.data?.data?.result;
    } catch (error) {
      console.log(error);
    }
  }

// lấy tất cả order
const getCommonOrders = async (ownerId) => {
  try {
    const result = await http.get(
      listUrl.common.order + ownerId
    );
    return result?.data?.data;
  } catch (error) {
    console.log(error);
  }
};

// lấy tất cả nhân viên
const getEmployees = async (params = {}) => {
  try {
    const result = await http.get(listUrl.employee.list, { params })
    return result?.data?.data?.employees;
  } catch (error) {
    console.log(error);
  }
}

// kiểm tra nhân viên có đang trong thời gian làm việc không
const checkWorking = async (params = {}) => {
  try {
    const result = await http.get(listUrl.employee.check, { params });
    console.log('result?.data?.data?.result', result?.data?.data?.result);
    return result?.data?.data?.result;
  } catch (error) {
    console.log(error);
  }
}

// lấy tất cả loại sản phẩm
const getProductTypes = async (ownerId) => {
  try {
    const result = await http.get(listUrl.product_type.list + ownerId);
    return result?.data?.data?.product_type;
  } catch (error) {
    console.log(error);
  }
}

// lấy tất cả sản phẩm
const getProducts = async (ownerId) => {
  try {
    const result = await http.get(listUrl.product.list + ownerId);
    return result?.data?.data?.products;
  } catch (error) {
    console.log(error);
  }
}


const updateStatusProduct = async (params = {}) => {
  try {
    const result = await http.get(listUrl.product.update_status_product, {params});
    return result?.data?.data;
  } catch (error) {
    console.log(error);
  }
}

// EMPLOYEE

//thêm order
const addOrder = async (params = {}) => {
  try {
    const result = await http.get(listUrl.order.add, { params } );
    return result?.data?.data?.result;
  } catch (error) {
    console.log(error);
  }
}

//lấy order
const getOrder = async (params = {}) => {
  try {
    const result = await http.get(listUrl.order.get, { params } );
    return result?.data?.data?.orders;
  } catch (error) {
    console.log(error);
  }
}
//cập nhật order
const updateOrder = async (params = {}) => {
  try {
    const result = await http.get(listUrl.order.update, { params } );
    return result;
  } catch (error) {
    console.log(error);
  }
}

//xóa order
const deleteOrder = async (params = {}) => {
  try {
    const result = await http.get(listUrl.order.delete, { params } );
    return result?.data?.data?.result;
  } catch (error) {
    console.log(error);
  }
}
// xóa nhiều order
const deleteOrders = async (params = {}) => {
  try {
    const result = await http.get(listUrl.order.deletes, { params } );
    return result?.data?.data?.result;
  } catch (error) {
    console.log(error);
  }
}

const reduceQuantity = async (params = {}) => {
  try {
    const result = await http.get(listUrl.order.reduce_quantity, { params } );
    return result;
  } catch (error) {
    console.log(error);
  }
}

// cập nhật trạng thái bàn - 0 bàn trống, 1 có khách 
const updateStatusTable = async (params = {}) => {
  try {
    const result = await http.get(listUrl.table.update_status, {params});
    return result;
  } catch (error) {
    console.log(error);
  }
}

// cập nhật trạng thái order - 0 đã đặt bàn, 1 đã nấu xong đồ ăn
const updateStatusOrder = async (params = {}) => {
  try {
    const result = await http.get(listUrl.order.update_status, {params});
    return result?.data?.data?.result;
  } catch (error) {
    console.log(error);
  }
}

// cập nhật tất cả trạng thái order dựa vào tableId orderId - 0 đã đặt bàn, 1 đã nấu xong đồ ăn
const updateStatusOrders = async (params = {}) => {
  try {
    const result = await http.get(listUrl.order.update_status_orders, {params});
    return result?.data?.data?.results;
  } catch (error) {
    console.log(error);
  }
}

// cập nhật trạng thái order - 0 đã đặt bàn, 1 đã nấu xong đồ ăn
const updateStatusPaid = async (params = {}) => {
  try {
    const result = await http.get(listUrl.order.update_status_paid, {params});
    return result?.data?.data?.result;
  } catch (error) {
    console.log(error);
  }
}

// thêm hóa đơn
const addBill = async (params = {}) => {
  try {
    const result = await http.get(listUrl.bill.add, {params});
    return result?.data?.data?.result;
  } catch (error) {
    console.log(error);
  }
}




// export
export {
  // admin - web
  getAreas,
  getTables,
  getTableOrders,
  getOrders,
  switchTable,
  getEmployees,
  checkWorking,

  getProductTypes,
  getProducts,
  updateStatusProduct,
  addOrder,
  getOrder,
  updateOrder,
  deleteOrder,
  deleteOrders,
  reduceQuantity,
  updateStatusTable,
  updateStatusOrder,
  updateStatusOrders,
  updateStatusPaid,
  addBill,

  getCommonOrders,

  getCommonEmployeeStaff,   // để tối ưu hóa
  getCommonEmployeeOrder
};
