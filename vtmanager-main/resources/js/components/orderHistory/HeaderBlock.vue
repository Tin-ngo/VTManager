<template>
  <div class="container-fluid pt-2">
    <div class="card bg-condition">
      <div class="card-body">
        <div class="row form-group" style="margin-bottom: 0px">
          <div
            class="border px-2 bg-condition-icon rounded"
            @click="handleHiddenCondition"
          >
            <i
              :class="
                isCollapsed
                  ? 'fas fa-regular fa-minus'
                  : 'fas fa-regular fa-plus'
              "
              class="text-white"
            ></i>
          </div>
          <div class="col-lg-9 font-weight-bold">
            {{ $t("label.search_conditions") }}
          </div>
        </div>
        <div v-show="isCollapsed">
          <div class="form-row">
            <div class="form-group col-lg-3">
              <label class="form-check-label">{{
                $t("order-history.label.form.order_date")
              }}</label>
              <div class="date-picker-wrapper">
                <date-picker
                  format="YYYY/MM/DD"
                  id="datePicker1"
                  :clearable="false"
                  v-model="orderStartDate"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
                <label
                  for=""
                  class="date-range-label text-center"
                  style="margin-left: 4px; margin-right: 12px"
                  >～</label
                >
                <date-picker
                  format="YYYY/MM/DD"
                  id="datePicker2"
                  :clearable="false"
                  v-model="orderEndDate"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
              </div>
            </div>

            <div class="form-group col-lg-3">
              <label class="form-check-label">{{
                $t("order-history.label.form.deadline")
              }}</label>
              <div class="date-picker-wrapper">
                <date-picker
                  format="YYYY/MM/DD"
                  id="datePicker1"
                  :clearable="false"
                  v-model="deliveryStartDate"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
                <label
                  for=""
                  class="date-range-label"
                  style="margin-left: 4px; margin-right: 12px"
                  >～</label
                >
                <date-picker
                  format="YYYY/MM/DD"
                  id="datePicker2"
                  :clearable="false"
                  v-model="deliveryEndDate"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
              </div>
            </div>
            <div class="form-group col-lg-1">
              <label class="form-check-label">{{
                $t("order-history.label.form.status")
              }}</label>
              <select v-model="statusCd" class="form-control border-custom">
                <option value=""></option>
                <option
                  v-for="(item, index) in listStatus"
                  :value="item?.ステータスコード"
                  :key="index"
                >
                  {{ item.ステータス名称 }}
                </option>
              </select>
            </div>
          </div>

          <div class="form-row">
            <div class="form-group col-lg-3">
              <div class="row">
                <div class="col-md-8">
                  <label class="form-check-label">{{
                    $t("order-history.label.form.delivery_destination_name")
                  }}</label>
                </div>
                <div class="col-lg-10">
                  <input
                    type="text"
                    style="width: 96%"
                    class="form-control border-custom"
                    v-model="deliveryName"
                  />
                </div>
              </div>
            </div>
            <div class="form-group col-lg-1">
              <label class="form-check-label">{{
                $t("order-history.label.form.product_cd")
              }}</label>
              <input
                type="text"
                style="width: 78%"
                class="form-control border-custom"
                v-model="productCd"
              />
            </div>
            <div class="form-group col-lg-3">
              <label class="form-check-label">{{
                $t("order-history.label.form.product_name")
              }}</label>
              <input
                type="text"
                style="width: 75%"
                class="form-control border-custom"
                v-model="productName"
              />
            </div>
          </div>

          <div class="form-row">
            <div class="form-group col-lg-1">
              <label class="form-check-label">{{
                $t("order-history.label.form.customer")
              }}</label>
              <select class="form-control border-custom" v-model="customerCd">
                <option value=""></option>
                <option
                  v-for="(item, index) in listCustomer"
                  :value="item?.得意先コード"
                  :key="index"
                >
                  {{ item.得意先名称 }}
                </option>
              </select>
            </div>
            <div class="form-group col-lg-3">
              <label class="form-check-label">{{
                $t("order-history.label.form.ship_date")
              }}</label>
              <div class="date-picker-wrapper">
                <date-picker
                  format="YYYY/MM/DD"
                  id="datePicker1"
                  :clearable="false"
                  v-model="shipStartDate"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
                <label
                  for=""
                  class="date-range-label"
                  style="margin-left: 4px; margin-right: 12px"
                  >～</label
                >
                <date-picker
                  format="YYYY/MM/DD"
                  id="datePicker2"
                  :clearable="false"
                  v-model="shipEndDate"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
              </div>
            </div>
            <div class="form-group col-lg-1">
              <label class="form-check-label">{{
                $t("order-history.label.form.order_number")
              }}</label>
              <input
                type="text"
                class="form-control border-custom"
                v-model="orderNumber"
              />
            </div>
            <div class="col-lg-7 d-flex justify-content-end align-items-center">
              <button class="btn btn-clear mr-2" @click="clear()">
                <font-awesome-icon
                  :icon="['fas', 'share']"
                  flip="horizontal"
                />&nbsp;{{ $t("button.clear") }}
              </button>
              <button class="btn btn-search" @click="search">
                <font-awesome-icon icon="fas fa-search" />
                &nbsp; {{ $t("button.search") }}
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
    <LoadingModalVue v-show="isLoading" />
  </div>
</template>

<script>
import { DATE_FORMAT_BASIC } from "@/constants";
import {
  getOrderHistory,
  getCustomerByID,
  getStatusByID,
} from "../../services/APIs/OMSService";
import LoadingModalVue from "../modals/LoadingModal.vue";
import moment from 'moment';

export default {
  components: {
    LoadingModalVue,
  },
  data() {
    return {
      isCollapsed: false,
      orderStartDate: null,
      orderEndDate: null,
      deliveryStartDate: null,
      deliveryEndDate: null,
      statusCd: null,
      deliveryName: null,
      productCd: null,
      productName: null,
      customerCd: null,
      shipStartDate: null,
      shipEndDate: null,
      orderNumber: null,
      isLoading: false,
      listStatus: [],
      listCustomer: [],
    };
  },
  async mounted() {
    await this.search();
  },
  async created() {
    [this.listStatus, this.listCustomer] = await Promise.all([
      getStatusByID(),
      getCustomerByID(),
    ]);
  },
  methods: {
    handleHiddenCondition() {
      this.isCollapsed = !this.isCollapsed;
      this.$emit("toggleCondition");
    },
    clear() {
      this.orderStartDate = null;
      this.orderEndDate = null;
      this.deliveryStartDate = null;
      this.deliveryEndDate = null;
      this.statusCd = null;
      this.deliveryName = null;
      this.productCd = null;
      this.productName = null;
      this.customerCd = null;
      this.shipStartDate = null;
      this.shipEndDate = null;
      this.orderNumber = null;
      this.search();
    },

    async search() {
      this.isLoading = true;
      const params = {};
      if (this.orderStartDate) {
        params.orderStartDate = moment(this.orderStartDate).format(
          DATE_FORMAT_BASIC
        );
      }
      if (this.orderEndDate) {
        params.orderEndDate = moment(this.orderEndDate).format(
          DATE_FORMAT_BASIC
        );
      }
      if (this.deliveryStartDate) {
        params.deliveryStartDate = moment(this.deliveryStartDate).format(
          DATE_FORMAT_BASIC
        );
      }
      if (this.deliveryEndDate) {
        params.deliveryEndDate = moment(this.deliveryEndDate).format(
          DATE_FORMAT_BASIC
        );
      }
      if (this.statusCd) {
        params.statusCd = this.statusCd;
      }
      if (this.deliveryName) {
        params.deliveryName = this.deliveryName;
      }
      if (this.productCd) {
        params.productCd = this.productCd;
      }
      if (this.productName) {
        params.productName = this.productName;
      }
      if (this.customerCd) {
        params.customerCd = this.customerCd;
      }
      if (this.shipStartDate) {
        params.shipStartDate = moment(this.shipStartDate).format(
          DATE_FORMAT_BASIC
        );
      }
      if (this.shipEndDate) {
        params.shipEndDate = moment(this.shipEndDate).format(DATE_FORMAT_BASIC);
      }
      if (this.orderNumber) {
        params.orderNumber = this.orderNumber;
      }
      const res = await getOrderHistory(params);
      const listOrder = Object.keys(res).map((item) => {
        return res[item];
      });

      for (let index = 0; index < listOrder.length; index++) {
        listOrder[index].countDenpyono = listOrder[index].length;
      }

      for (let index = 0; index < listOrder.length; index++) {
        let sum = 0;
        for (let index2 = 0; index2 < listOrder[index].length; index2++) {
          const irisu = listOrder[index][index2]["irisu"] ?? 0;
          sum += parseInt(irisu);
        }
        listOrder[index].count_ship_num1 = sum;
      }
      this.isLoading = false;
      this.$emit("setListSlcOmsT1Order", listOrder);
    },
  },
};
</script>

<style>
.mx-input-wrapper {
  width: 90%;
}

label {
  font-weight: bold;
}

.text-bold {
  font-weight: bold;
}
</style>
