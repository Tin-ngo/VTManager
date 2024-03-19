<template>
  <section class="main-section">
    <div class="container-fluid pt-2">
      <div
        class="d-flex d-flex justify-content-center align-items-center text-danger"
        v-show="messageError != '' ? true : false"
      >
        <h6>{{ messageError }}</h6>
      </div>
      <div class="card">
        <div class="card-body" style="min-height: 713px">
          <div class="row">
            <label class="form-check-label col-lg-12">
              {{ this.label.customerCode }}
              <span class="badge badge-danger" style="margin-bottom: 5px"
                >必须</span
              >
            </label>
            <div class="col-lg-2">
              <input
                type="text"
                style="width: 80%"
                class="form-control border-custom"
                v-model="customerCode"
                :disabled="isUpdate"
                ref="customerCode"
              />
            </div>
          </div>
          <div class="row mg-top">
            <label class="form-check-label col-lg-12">
              {{ this.label.customerName }}
              <span class="badge badge-danger" style="margin-bottom: 5px"
                >必须</span
              >
            </label>
            <div class="col-lg-7">
              <input
                type="text"
                style="width: 95%"
                class="form-control border-custom"
                v-model="customerName"
                ref="customerName"
              />
            </div>
          </div>
          <div class="row mg-top">
            <label class="form-check-label col-lg-12">
              {{ this.label.creditLimit }}
            </label>
            <div class="col-lg-2">
              <input
                type="text"
                style="width: 50%"
                class="form-control border-custom"
                v-model="creditLimit"
                ref="creditLimit"
              />
            </div>
          </div>
          <div class="row mg-top">
            <label class="form-check-label col-lg-12">
              {{ this.label.paymentSite }}
            </label>
            <div class="col-lg-1">
              <input
                type="text"
                style="width: 40%"
                class="form-control border-custom"
                v-model="paymentSite"
                ref="paymentSite"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid card footer-item">
      <div class="card-footer">
        <div class="row">
          <div class="col-lg-6 text-nowrap">
            <button v-if="isUpdate" class="btn btn-create" @click="update()">
              <font-awesome-icon icon="fas fa-pencil-alt" />&nbsp;{{
                $t("button.update")
              }}
            </button>
            <button v-else class="btn btn-create" @click="create()">
              <font-awesome-icon icon="fas fa-pencil-alt" />&nbsp;{{
                $t("button.register")
              }}
            </button>
          </div>
          <div class="col-lg-6 text-right p-0">
            <button class="btn btn-back" @click="goBack()">
              <font-awesome-icon icon="fas fa-arrow-left" />
              {{ $t("button.back") }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { OmsCustomerMasterMaintenance } from "../../constants/router";
import { getCustomer, createCustomer, updateCustomer } from "@/services/APIs/MSTService";
import { RESPONSE_CODE, ROUTER } from "@/constants";
import { customerValidate, showMessage, convertToCamelCase } from "@/utils/helper"

export default {

  data() {
    return {
      isOpenedFromMenu: false,
      isUpdate: false,
      customerCode: null, // 得意先コード
      customerName: null, // 得意先名
      creditLimit: 0, // 与信額
      paymentSite: 0, // 入金サイト
      messageError: null,
      label : {
        customerCode : this.$t("customer-master-maintenance.label.form.customer_code"),
        customerName : this.$t("customer-master-maintenance.label.form.customer_name"),
        creditLimit : this.$t("customer-master-maintenance.label.form.credit_amount"),
        paymentSite : this.$t("customer-master-maintenance.label.form.payment_site"),
      }
    };
  },
  async mounted() {
    this.isOpenedFromMenu = this.$route.params.isOpenedFromMenu ? true : false;
    this.$store.dispatch("auth/setTitle", OmsCustomerMasterMaintenance);

    try {
      const customerCode = this.$route.query.customerCode
      if (customerCode) {
        this.isUpdate = true;
        this.getCustomer(customerCode);
      }
    } catch (error) {}
  },
  methods: {
    async getCustomer(customerCode) {
        const customer = await getCustomer(customerCode);
        
        this.customerCode = customer?.customer_code;
        this.customerName = customer?.customer_name;
        this.creditLimit = customer?.credit_limit ? customer?.credit_limit : 0;
        this.paymentSite = customer?.payment_site ? customer?.payment_site : 0;
    },
    async processRequest(apiFunction) {
      this.messageError = null;
      const params = {
        customer_code: this.customerCode,
        customer_name: this.customerName,
        credit_limit: this.creditLimit,
        payment_site: this.paymentSite,
      };

      try {
        const validatedParams = customerValidate(this, params);
        if(validatedParams) {
          showMessage(this, validatedParams);
          return;
        }

        const result = await apiFunction(params);
        if(result?.status_code === RESPONSE_CODE.OK) {
          this.$toast.success(this.$t(this.isUpdate ? "label.update_successfull" : "label.create_successfull"));
          return;
        }

        const messages = result?.message;
        for (const key in messages) {
          showMessage(this, {
            name: convertToCamelCase(key),
            message: messages[key]
          });
          break;
        }
        
      } catch (error) {
        this.$toast.error(error?.message);
      }
    },
    async create() {
      this.processRequest(createCustomer);
    },
    async update() {
      const customerCode = `${this.customerCode}`;
      this.processRequest(params => updateCustomer(customerCode, params));
    },
    goBack() {
      this.$router.push({
        name: ROUTER.MstCustomerMaster.name, 
        params: {'isOpenedFromMenu' : this.isOpenedFromMenu}
      });
    },
  },
};
</script>

<style>
.card-footer {
  background-color: #fff;
}

.btn-back {
  border: 1px solid #ddd;
  display: inline-block;
  font-weight: 400;
  color: #212529;
  text-align: center;
  vertical-align: middle;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
  background-color: transparent;
  padding: 0.25rem 1.75rem;
  font-size: 1rem;
  line-height: 1.5;
  border-radius: 0.25rem;
  transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out,
    border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}

.btn-back:hover {
  color: #212529;
  background-color: #e9ecef;
}

label {
  font-weight: bold;
  margin-bottom: 1px !important;
}

.mg-top {
  margin-top: 10px;
}

.height-body {
  height: 725px;
}
</style>
