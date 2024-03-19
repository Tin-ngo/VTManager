import http from "@/utils/http";

const listUrl = {
  orderRegistration: {
    upload: "/oms/order-registration/upload",
    captureDropdown: "/oms/order-registration/capture-dropdown",
    createOrder: "/oms/order-registration/create",
    getFlagOverride: "/oms/order-registration/flag-override",
    deleteOldT1Order: "/oms/order-registration/order",
  },
  orderStatus: {
    list: "/oms/order-status-search/",
    update: "/oms/order-status-search/update",
    getDropDownTaxCodeOrder: "/oms/order-status-search/dropdown-taxCode",
  },
  orderHistoryInquiry: {
    list: "/oms/order-history-inquiry/",
  },
  orderInquiry: {
    list: "/api/oms/order-inquiry/",
    currencySymbol: "/oms/order-inquiry/currency-symbol/",
    orderDate: "/oms/order-inquiry/orderdate",
    delete: "/oms/order-inquiry/",
  },
  orderCorrection: {
    list: "/oms/order-correction/",
  },
  common: {
    getCustomer: "/oms/order-status-search/customers",
    getAllStatus: "/oms/order-status-search/",
    getStatus: "/oms/order-status-search/status",
    getMstStatus: 'mst/status',
    getProducts: "/oms/product-master/",
    getProduct: "/oms/product-master-manternance/get-product",
  },
};

//===============1_OMS01001_発注登録
const uploadFile = async (params = {}) => {
  try {
    // const result = await http.post("/oms/order-registration/upload", params);
    const result = await http.post(listUrl.orderRegistration.upload, params);
    return result?.data;
  } catch (error) {
    console.log(error);
  }
};

const getCaptureDefinitionDropdown = async () => {
  try {
    const result = await http.get(
      listUrl.orderRegistration.captureDropdown,
      {}
    );
    return result?.data?.data?.captures;
  } catch (error) {
    console.log(error);
  }
};

const getInfoFlagAndOverrideOrder = async (params) => {
  try {
    const result = await http.get(listUrl.orderRegistration.getFlagOverride, {
      params,
    });
    return result?.data?.data?.info;
  } catch (error) {
    console.log(error);
  }
};

const deleteOldT1Order = async (data) => {
  try {
    const result = await http.delete(
      listUrl.orderRegistration.deleteOldT1Order,
      { data }
    );
    return result?.data?.data?.successOrNot;
  } catch (error) {
    console.log(error);
  }
};

const createOrder = async (params = {}) => {
  try {
    const result = await http.post(
      listUrl.orderRegistration.createOrder,
      params
    );
    return result?.data;
  } catch (error) {
    console.log(error);
  }
};

//==============2_OMS02001_受注状況検索

const updateSlcOmsT1Order = async (params = {}) => {
  try {
    const result = await http.post(listUrl.orderStatus.update, params);
    return result?.data?.data;
  } catch (error) {
    console.log(error);
  }
};

const getDropDownTaxCodeOrder = async (params = {}) => {
  try {
    const result = await http.get(
      listUrl.orderStatus.getDropDownTaxCodeOrder,
      params
    );
    return result?.data?.data.list;
  } catch (error) {
    console.log(error);
  }
};

const getOrderStatus = async (params = {}) => {
  try {
    const result = await http.get(listUrl.orderStatus.list, {
      params,
    });
    return result?.data?.data?.orderStatus;
  } catch (error) {
    console.log(error);
  }
};
//==================3_OMS03001_発注履歴照会
const getOrderHistory = async (params) => {
  try {
    const result = await http.get(listUrl.orderHistoryInquiry.list, {
      params,
    });
    return result?.data?.data?.listSlcOmsT1Order;
  } catch (error) {
    console.log(error);
  }
};

//===================6_OMS06001_発注照会
const getOrderDate = async (system_code) => {
  try {
    const result = await http.post(
      listUrl.orderInquiry.orderDate, {system_code}
    );
    return result?.data?.data;
  } catch (error) {
    console.log(error);
  }
};

const getOrderInquiry = async (params = {}) => {
  try {
    const result = await axios.get(listUrl.orderInquiry.list, {
      params,
    });
    return result?.data?.data;
  } catch (error) {
    console.log(error);
  }
};



const deleteOrder = async (number) => {
  try {
    const result = await http.delete(listUrl.orderInquiry.delete + number);
    return result;
  } catch (error) {
    console.log(error);
  }
};

const deleteOrders = async (params = {}) => {
  try {
    const result = await http.delete(listUrl.orderInquiry.delete, { params });
    return result;
  } catch (error) {
    console.log(error);
  }
};

//======================7_OMS07001_発注訂正
const getOrderCorrection = async ({ params }) => {
  try {
    const result = await http.get(listUrl.orderCorrection.list, { params });
    return result?.data?.data?.response;
  } catch (error) {
    console.log(error);
  }
};

//=====================COMMON
const getCustomerByID = async () => {
  try {
    const result = await http.get(listUrl.common.getCustomer);
    return result?.data?.data?.customers;
  } catch (error) {
    console.log(error);
  }
};

const getMstStatus = async () => {
  try {
    const result = await http.get(listUrl.common.getMstStatus);
    return result?.data?.data?.status;
  } catch (error) {
    console.log(error);
  }
};

const getAllStatus = async () => {
  try {
    const result = await http.get(listUrl.common.getAllStatus, {});
    return result?.data?.data?.status;
  } catch (error) {
    console.log(error);
  }
};

const getCurrencySymbol = async (systemCode) => {
  try {
    const result = await http.get(
      listUrl.orderInquiry.currencySymbol + systemCode
    );
    return result?.data?.data.symbol[0]["通貨記号"];
  } catch (error) {
    console.log(error);
  }
};

const getStatusByID = async () => {
  try {
    const result = await http.get(listUrl.common.getStatus, {});
    return result?.data?.data?.status;
  } catch (error) {
    console.log(error);
  }
};

const getListSlcMst04ProductBySearchHandle = async (params = {}) => {
  try {
    const result = await http.get(listUrl.common.getProducts, {
      params,
    });
    return result?.data?.data?.products;
  } catch (error) {
    console.log(error);
  }
};
export const getProduct = async (params = {}) => {
  try {
    const result = await http.get(listUrl.common.getProduct, {
      params,
    });
    console.log(result?.data.data.product);
    return result?.data.data.product;
  } catch (error) {
    console.log(error);
  }
};

export {
  //===============1_OMS01001_発注登録===============
  getCaptureDefinitionDropdown,
  getInfoFlagAndOverrideOrder,
  createOrder,
  uploadFile,

  //==============2_OMS02001_受注状況検索===============
  updateSlcOmsT1Order,
  getOrderStatus,

  //==================3_OMS03001_発注履歴照会===============
  getOrderHistory,

  //===================6_OMS06001_発注照会===============
  getOrderInquiry,
  getOrderDate,
  deleteOrder,
  deleteOrders,

  //======================7_OMS07001_発注訂正===============
  getOrderCorrection,

  //=====================COMMON===============
  getCustomerByID,
  getStatusByID,
  getListSlcMst04ProductBySearchHandle,
  getAllStatus,
  deleteOldT1Order,
  getDropDownTaxCodeOrder,
  getCurrencySymbol,
  getMstStatus
};
