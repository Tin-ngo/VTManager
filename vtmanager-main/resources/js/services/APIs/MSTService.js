import http from "@/utils/http";
import { convertObjectToSnakeCase } from "@/utils/helper"
const listUrl = {
  product: {
    list: "/mst/product/",
    listCustomerProduct: "/mst/product/",
    deleteCustomerProduct: "/mst/product/delete-customerproduct/",
    deleteProduct: "/mst/product/",
    deleteProducts: "/mst/product/delete-products",
    createProduct: "/mst/product/",
    updateProduct: "/mst/product/",
    listCombinedProduct: "/mst/product/sub/combined-products/",
  },

  deliveryDestinationMaintenance: {
    list: "/mst/delivery-destination-maintenance/",
    create: "/mst/delivery-destination-maintenance/",
    update: "/mst/delivery-destination-maintenance/",
    delete: "/mst/delivery-destination-maintenance/",
  },
  customer: {
    list: "/mst/customer/",
    delete: "/mst/customer/delete",
    register: "/mst/customer/",
    update: "/mst/customer/",
  },
};

const getProducts = async (params = {}) => {
  try {
    const result = await http.get(
      listUrl.product.list,
      //productAPI + URL,
      {
        params,
      }
    );
    console.log("result", result);
    return result?.data?.data?.products;
  } catch (error) {
    return error;
  }
};

const getCombinedDataProducts = async (params = {}) => {
  try {
    const result = await http.get(listUrl.product.listCombinedProduct, {
      params,
    });
    console.log("result", result);
    return result?.data?.data?.products;
  } catch (error) {
    return error;
  }
};

const getProductsAndCustomerProducts = async (productCode) => {
  try {
    const result = await http.get(
      listUrl.product.listCustomerProduct + productCode
    );
    console.log(result?.data.data.product);
    return result?.data.data.product;
  } catch (error) {
    console.log(error);
  }
};

const createProduct = async (params = {}) => {
  try {
    const result = await http.post(listUrl.product.createProduct, params);
    return result?.data;
  } catch (error) {
    console.log("error", error);
  }
};

const deleteProduct = async (id) => {
  try {
    const result = await http.delete(listUrl.product.deleteProduct + id);
    return result;
  } catch (error) {
    console.log(error);
  }
};

const deleteProducts = async (params = {}) => {
  try {
    const result = await http.post(listUrl.product.deleteProducts, params);
    return result;
  } catch (error) {
    console.log(error);
  }
};

const updateProduct = async (id, params = {}) => {
  try {
    const result = await http.put(listUrl.product.updateProduct + id, params);
    return result?.data;
  } catch (error) {
    console.log(error);
  }
};

const deleteCustomerProducts = async (params = {}) => {
  try {
    const result = await http.post(
      listUrl.product.deleteCustomerProduct,
      params
    );
    return result;
  } catch (error) {
    console.log(error);
  }
};
//==============MST02101_納品先マスタメンテナンス
const getDeliveries = async (params = {}) => {
  try {
    const result = await http.get(listUrl.deliveryDestinationMaintenance.list, {
      params,
    });
    return result?.data?.data?.deliveries;
  } catch (error) {
    console.log(error);
  }
};

const create = async (bodies = {}) => {
  try {
    const result = await http.post(
      listUrl.deliveryDestinationMaintenance.create,
      bodies
    );
    console.log(result?.data);
    return result?.data;
  } catch (error) {
    console.log(error);
  }
};

const update = async (code, bodies = {}) => {
  try {
    const result = await http.put(
      listUrl.deliveryDestinationMaintenance.update + code,
      bodies
    );
    return result?.data;
  } catch (error) {
    console.log(error);
  }
};

const deleteDelivery = async (code = {}) => {
  try {
    const result = await http.delete(
      listUrl.deliveryDestinationMaintenance.delete + code
    );
    return result?.data;
  } catch (error) {
    console.log(error);
  }
};

//MST03101_得意先マスタ
//MST03101_得意先マスタメンテナンス
const getCustomers = async (params = {}) => {
  try {
    params = convertObjectToSnakeCase(params);
    const result = await http.get(listUrl.customer.list, {
      params
    });
    return result?.data?.data;
  } catch (error) {
    return error;
  }
};

const getCustomer = async (customerCode) => {
  try {
    const result = await http.get(listUrl.customer.list + customerCode);

    return result?.data?.data?.customer;
  } catch (error) {
    return error;
  }
};

const createCustomer = async (params = {}) => {
  try {
    const result = await http.post(listUrl.customer.register, params);
    return result?.data;
  } catch (error) {
    console.log(error);
  }
};

const updateCustomer = async (customerCode, params = {}) => {
  try {
    const result = await http.put(listUrl.customer.update + customerCode, params);
    return result?.data;
  } catch (error) {
    console.log(error);
  }
};

const deleteCustomer = async (customerCodes) => {
  try {
    const result = await http.post(listUrl.customer.delete, {
      customerCodes,
    });
    return result?.data;
  } catch (error) {
    return error;
  }
};

export {
  //==============MST01001_商品マスタ
  getProducts,
  createProduct,
  deleteProduct,
  deleteProducts,
  updateProduct,
  getProductsAndCustomerProducts,
  deleteCustomerProducts,
  getCombinedDataProducts,
  //==============MST02101_納品先マスタメンテナンス
  getDeliveries,
  create,
  update,
  deleteDelivery,
  //MST03101_得意先マスタ
  //MST03101_得意先マスタメンテナンス
  getCustomers,
  getCustomer,
  createCustomer,
  updateCustomer,
  deleteCustomer,
};
