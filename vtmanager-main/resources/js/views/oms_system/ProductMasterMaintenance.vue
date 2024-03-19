<template>
  <section class="main-section">
    <div class="container-fluid pt-2">
      <div class="d-flex align-items-center justify-content-center">
        <h6 class="text-danger">{{ messageError }}</h6>
      </div>
      <div class="card">
        <div class="card-body">
          <div class="form-group">
            <div>
              <label for="itemCode" class="d-flex align-items-center"
                >{{ $t("product-master-maintenance.label.product_cd") }}
                <span class="badge badge-danger" style="margin-bottom: 5px">
                  必须
                </span>
              </label>
            </div>
            <div>
              <!-- maxlength="30" -->
              <input
                v-if="isUpdateScreen"
                type="text"
                id="itemCode"
                class="form-control col-md-2"
                value="xxxxxxxxx1xxxxxxxxx2 "
                v-model="productCode"
                ref="productCode"
                readonly
              />
              <!-- maxlength="30" -->
              <input
                v-else
                type="text"
                id="itemCode"
                class="form-control col-md-2"
                v-model="productCode"
                ref="productCode"
                value="xxxxxxxxx1xxxxxxxxx2"
              />
            </div>
          </div>
          <div class="form-group">
            <div>
              <label for="itemName" class="d-flex align-items-center"
                >{{ $t("product-master-maintenance.label.product_name") }}
                <span class="badge badge-danger" style="margin-bottom: 5px">
                  必须
                </span>
              </label>
            </div>
            <div>
              <!-- maxlength="140" -->
              <input
                v-if="isUpdateScreen"
                type="text"
                id="itemName"
                class="form-control col-md-4"
                ref="productName"
                v-model="productName"
              />
              <!--maxlength="140" -->
              <input
                v-else
                type="text"
                id="itemName"
                class="form-control col-md-4"
                ref="productName"
                v-model="productName"
              />
            </div>
          </div>
          <div class="form-group row pl-0 col-md-6">
            <div class="col-md-3 pl-0">
              <div class="col-md-10">
                <label for="qtyOfCase" class="d-flex align-items-center"
                  >{{ $t("product-master-maintenance.label.quantity") }}
                  <span class="badge badge-danger" style="margin-bottom: 5px">
                    必须
                  </span>
                </label>
                <input
                  type="text"
                  id="qtyOfCase"
                  class="form-control text-right"
                  maxlength="10"
                  ref="quantity"
                  v-model="quantity"
                />
              </div>
            </div>
            <div class="col-md-3 pl-2">
              <label for="capacity" class="d-flex align-items-center">{{
                $t("product-master-maintenance.label.capacity")
              }}</label>
              <div class="row align-items-center">
                <input
                  type="text"
                  id="capacity"
                  ref="volumn"
                  class="form-control col-md-8 text-right"
                  v-model="capacity"
                />
                ㎥
              </div>
            </div>
            <div class="col-md-3 pl-2">
              <label for="weight" class="d-flex align-items-center">{{
                $t("product-master-maintenance.label.weight")
              }}</label>
              <div class="row align-items-center">
                <input
                  type="text"
                  id="weight"
                  class="form-control col-md-8 text-right"
                  v-model="weight"
                />
                kg
              </div>
            </div>
          </div>
          <div class="form-group">
            <div><label for="gtinCode">GTN</label></div>
            <div>
              <!-- maxlength="20" -->
              <input
                type="text"
                id="gtinCode"
                class="form-control col-md-2"
                v-model="gtn"
                ref="gtn"
              />
            </div>
          </div>
          <div class="form-group">
            <div>
              <label class="d-flex align-items-center">{{
                $t("product-master-maintenance.label.tax_rate")
              }}</label>
            </div>
            <div class="form-check-inline">
              <label class="form-check-label mr-5"
                ><input
                  type="radio"
                  class="form-check-input"
                  name="tax-style"
                  v-model="isTax"
                  :value="false"
                />{{ $t("product-master-maintenance.label.no_tax") }}</label
              >
              <label class="form-check-label mr-3"
                ><input
                  type="radio"
                  class="form-check-input"
                  name="tax-style"
                  v-model="isTax"
                  ref="tax"
                  :value="true"
                  checked
                />{{ $t("product-master-maintenance.label.taxation") }}</label
              >
              <div class="row ml-3 align-items-center">
                <input
                  type="text"
                  id="taxRate"
                  ref="tax"
                  class="form-control col-md-5 mr-2 text-right"
                  v-model="tax"
                  :disabled="isTax == true ? false : true"
                />%
              </div>
            </div>
          </div>
          <div class="row col-md-7 mb-1 align-items-center">
            <label class="mb-0">{{
              $t("product-master-maintenance.label.table_header.title")
            }}</label>
          </div>
          <div class="row col-md-7">
            <div class="container-fluid px-0">
              <table id="registration-table" class="table text-nowrap">
                <thead class="text-center bg-header">
                  <tr>
                    <th class="th1"></th>
                    <th class="th2">
                      {{
                        $t("product-master-maintenance.label.table_header.1")
                      }}
                    </th>
                    <th class="th3">
                      {{
                        $t("product-master-maintenance.label.table_header.2")
                      }}
                    </th>
                    <th class="th4">
                      {{
                        $t("product-master-maintenance.label.table_header.3")
                      }}
                    </th>
                    <th class="th5">
                      {{
                        $t("product-master-maintenance.label.table_header.4")
                      }}
                    </th>
                  </tr>
                </thead>
                <tbody>
                  <tr
                    class="row-hover"
                    v-for="(item, index) in products"
                    :key="index"
                  >
                    <td class="td1 text-center">
                      <button
                        id="btn-delete"
                        class="btn btn-sm"
                        @click="removeNewRow(index, item.customerCode)"
                      >
                        <i class="fa fa-trash"></i>
                      </button>
                    </td>
                    <td class="td2 pl-2">
                      <input
                        type="text"
                        id="customerItemCode"
                        class="form-control td-input pl-2"
                        maxlength="50"
                        v-model="item.customercode"
                        disabled
                      />
                    </td>
                    <td class="td4 pl-2">
                      <input
                        type="text"
                        id="customerItemCode"
                        class="form-control td-input pl-2"
                        maxlength="50"
                        v-model="item.customername"
                        disabled
                      />
                    </td>
                    <td class="td5">
                      <input
                        type="text"
                        id="customerItemCode"
                        class="form-control td-input pl-2"
                        maxlength="50"
                        v-model="item.productcustomercode"
                      />
                    </td>
                    <td class="td6 text-right">
                      <input
                        type="text"
                        id="price1"
                        class="form-control td-input pr-2 text-right"
                        v-model="item.cost1"
                      />
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid footer-item">
      <div class="card bg-condition">
        <div class="card-body">
          <div class="row">
            <button
              v-if="isUpdateScreen"
              class="btn btn-register"
              @click="updateProduct"
              :disabled="
                this.$store.state.auth.user.data.ユーザー種別 == 1
                  ? true
                  : false
              "
            >
              <font-awesome-icon icon="fas fa-pencil-alt" />&nbsp;{{
                $t("button.update")
              }}
            </button>
            <button v-else class="btn btn-register" @click="registerNew">
              <font-awesome-icon icon="fas fa-pencil-alt" />&nbsp;{{
                $t("button.register")
              }}
            </button>
            <button class="btn btn-back ml-auto" @click="goBack()">
              <font-awesome-icon icon="fas fa-arrow-left" />
              &nbsp;{{ $t("button.back") }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>
<script>
import {
  getProductsAndCustomerProducts,
  deleteCustomerProducts,
  createProduct,
  updateProduct,
  getCombinedDataProducts,
} from "@/services/APIs/MSTService.js";
import { getCustomerByID } from "@/services/APIs/OMSService";

export default {
  data() {
    return {
      isUpdateScreen: false,
      product: null,

      productCode: null,
      productName: null,
      quantity: 1,
      capacity: 0,
      weight: 0,
      gtn: null,
      isTax: false,
      tax: null,

      listUserProduct: [],
      productPrice: null,
      productCdCustomer: null,

      messageError: null,
      products: [],
    };
  },
  async mounted() {
    this.$store.dispatch(
      "auth/setTitle",
      this.$t("product-master-maintenance.label.title")
    );

    if (this.$store.state.auth.user.data.ユーザー種別 == 1) {
      var inputs = document.querySelectorAll("input");
      for (var i = 0; i < inputs.length; i++) {
        inputs[i].disabled = true;
      }
    }
  },
  watch: {
    isTax: function (newVal, oldVal) {
      // console.log("isTax", this.isTax);
    },
    capacity: function (newVal, oldVal) {
      if (newVal == "") {
        this.capacity = 0;
      }
    },
    weight: function (newVal, oldVal) {
      if (newVal == "") {
        this.weight = 0;
      }
    },
  },
  async created() {
    this.productCode = this.$route.query.productCode;
    if (this.productCode) {
      await this.getProductFromId(this.productCode);
      this.isUpdateScreen = true;

      this.productName = this.product?.item_name;
      this.quantity = this.product?.qty_of_case;
      this.capacity = this.product?.capacity;
      this.weight = this.product?.weight;
      (this.gtn = this.product?.gtin_code), (this.tax = ""); // QA 73
    } else {
      this.products = await getCombinedDataProducts();
    }
  },
  methods: {
    async getProductFromId(productCode) {
      const productFull = await getProductsAndCustomerProducts(productCode);
      this.product = productFull;
      const customerProducts = productFull?.customerProduct;
      for (let index = 0; index < customerProducts.length; index++) {
        const params = {
          customerCode: customerProducts[index]["customerCode"],
          productcode: this.productCode,
          productCustomerCode: customerProducts[index]["customerProductcode"],
          customerName: customerProducts[index]["customer"]?.customerName,
          cost1: customerProducts[index]["cost1"],
        };
        this.products.push(params);
        console.log(this.products);
      }
    },

    goBack() {
      this.$router.push("/commodity-master");
    },

    checkRequire() {
      if (!this.productCode) {
        this.$toast.error("商品コード" + "が未入力です");
        this.$refs.productCode.focus();
        return false;
      }
      if (!this.productName) {
        this.$toast.error("商品名" + "が未入力です");
        this.$refs.productName.focus();
        return false;
      }
      if (!this.quantity) {
        this.$toast.error("入数" + "が未入力です");
        this.$refs.quantity.focus();
        return false;
      }
      if (this.listUserProduct.length > 0) {
        for (let index = 0; index < this.listUserProduct.length; index++) {
          if (!this.listUserProduct[index].productCustomerCode) {
            this.$toast.error(
              "受注データが存在するため発注商品コードを削除できません"
            );
            return false;
          }
        }
      }
      return true;
    },

    async getCustomer() {
      const params = {};
      params.customerCd = 90;
      const a = await getCustomerByID(params);
    },
    async registerNew() {
      var keyValueToAdd = { productcode: this.productCode, };
      for (var i = 0; i < this.products.length; i++) {
        this.products[i] = { ...this.products[i], ...keyValueToAdd };
      }
      const data = {
        productCode: this.productCode,
        productName: this.productName,
        quantityPerPack: this.quantity,
        volume: this.capacity,
        weight: this.weight,
        GTIN: this.gtn,
        taxRate: this.tax,
        customerProducts: this.products,
      };
      try {
        const result = await createProduct(data);
        if (!result?.errors) {
          this.$toast.success(this.$t("label.regis_successfull"));
          this.messageError = "";
        } else {
          if (typeof result?.errors?.productCode != "undefined") {
            this.messageError = result?.errors?.productCode[0];
            this.$refs.productCode.focus();
            return;
          }
          if (typeof result?.errors?.productName != "undefined") {
            this.messageError = result?.errors?.productName[0];
            this.$refs.productName.focus();
            return;
          }
          if (typeof result?.errors?.quantityPerPack != "undefined") {
            this.messageError = result?.errors?.quantityPerPack[0];
            this.$refs.quantity.focus();
            return;
          }
          if (typeof result?.errors?.volume != "undefined") {
            this.messageError = result?.errors?.volume[0];
            this.$refs.volumn.focus();
            return;
          }
          if (typeof result?.errors?.weight != "undefined") {
            this.messageError = result?.errors?.weight[0];
            this.$refs.weight.focus();
            return;
          }
          if (typeof result?.errors?.GTIN != "undefined") {
            this.messageError = result?.errors?.GTIN[0];
            this.$refs.gtn.focus();
            return;
          }
          if (typeof result?.errors?.taxRate != "undefined") {
            this.messageError = result?.errors?.taxRate[0];
            this.$refs.tax.focus();
            return;
          }
          // if (
          //   typeof result?.errors["customerProducts.0.cost1"] != "undefined"
          // ) {
          //   this.messageError = result?.errors?.["customerProducts.0.cost1"][0];
          //   return;
          // }
          // if (
          //   typeof result?.errors["customerProducts.0.productCustomerCode"] !=
          //   "undefined"
          // ) {
          //   this.messageError =
          //     result?.errors?.["customerProducts.0.productCustomerCode"][0];
          //   return;
          // }
        }
      } catch (errors) {
        console.log("Catch");
      }
    },

    async removeNewRow(index, customerCode) {
      if (!this.isUpdateScreen) {
        this.products.splice(index, 1);
      } else {
        this.products.splice(index, 1);
        const data = {
          productCode: this.productCode,
          customerCode: customerCode,
        };
        try {
          const result = await deleteCustomerProducts(data);
          if (result) {
            this.$toast.success("アップロード成功");
          } else {
            this.$toast.error("アップロードエラー");
          }
        } catch (error) {
          this.$toast.error(error?.message);
        }
      }
    },

    async updateProduct() {
      const data = {
        productCode: this.productCode,
        productName: this.productName,
        quantityPerPack: this.quantity,
        volume: this.capacity,
        weight: this.weight,
        GTIN: this.gtn,
        taxRate: this.tax,
        customerProducts: this.products,
      };
      try {
        const result = await updateProduct(this.productCode, data);
        // console.log("result", result);
        if (!result?.errors) {
          this.$toast.success(this.$t("label.update_successfull"));
          this.messageError = "";
        } else {
          if (typeof result?.errors?.productCode != "undefined") {
            this.messageError = result?.errors?.productCode[0];
            this.$refs.productCode.focus();
            return;
          }
          if (typeof result?.errors?.productName != "undefined") {
            this.messageError = result?.errors?.productName[0];
            this.$refs.productName.focus();
            return;
          }
          if (typeof result?.errors?.quantityPerPack != "undefined") {
            this.messageError = result?.errors?.quantityPerPack[0];
            this.$refs.quantity.focus();
            return;
          }
          if (typeof result?.errors?.volume != "undefined") {
            this.messageError = result?.errors?.volume[0];
            this.$refs.volumn.focus();
            return;
          }
          if (typeof result?.errors?.weight != "undefined") {
            this.messageError = result?.errors?.weight[0];
            this.$refs.weight.focus();
            return;
          }
          if (typeof result?.errors?.GTIN != "undefined") {
            this.messageError = result?.errors?.GTIN[0];
            this.$refs.gtn.focus();
            return;
          }
          if (typeof result?.errors?.taxRate != "undefined") {
            this.messageError = result?.errors?.taxRate[0];
            this.$refs.tax.focus();
            return;
          }
          if (
            typeof result?.errors["customerProducts.0.cost1"] != "undefined"
          ) {
            this.messageError = result?.errors?.["customerProducts.0.cost1"][0];
            return;
          }
          if (
            typeof result?.errors["customerProducts.0.productCustomerCode"] !=
            "undefined"
          ) {
            this.messageError =
              result?.errors?.["customerProducts.0.productCustomerCode"][0];
            return;
          }
        }
      } catch (error) {
        this.$toast.error(error?.message);
      }
    },
  },
};
</script>

<style>
#registration-table thead tr th {
  border: 1px solid #ccc;
}

#registration-table tbody tr td {
  border: 1px solid #ccc;
  padding-top: 0px;
  padding-bottom: 0px;
  vertical-align: middle;
}

.td1 {
  width: 5%;
}

.td2 {
  width: 10%;
}

.td3 {
  width: 5%;
}

.td4 {
  width: 30%;
}

.td5 {
  width: 30%;
}

.td6 {
  width: 20%;
}

.td-input {
  width: 100% !important;
  height: 100% !important;
  border: none;
  padding-left: 2px;
  padding-right: 2px;
}

.td5,
.td6 {
  padding: 0px !important;
  margin: 0px !important;
}

.row-hover:hover {
  background-color: #fff2cc !important;
}

.row-hover:hover input {
  background-color: #fff2cc !important;
}

.pt-2 {
  padding-bottom: 1px !important;
}
</style>
