<template>
  <div class="container-fluid pt-2">
    <div class="card">
      <div class="card-body">
        <label
          class="form-check-label col-lg-1"
          style="margin-bottom: 16px; margin-left: -6px"
          >{{ $t("order-inquiry.label.form.order_date") }}</label
        >
        <div class="row align-items-baseline">
          <div class="col-lg-3">
            <div class="date-picker-wrapper">
              <date-picker
                format="YYYY/MM/DD"
                id="orderStartDate"
                :clearable="false"
                v-model="orderStartDate"
              >
                <template v-slot:icon-calendar>
                  <font-awesome-icon icon="fas fa-calendar-alt" />
                </template>
              </date-picker>
              <label for="" class="date-range-label">～</label>
              <date-picker
                format="YYYY/MM/DD"
                id="orderEndDate"
                :clearable="false"
                v-model="orderEndDate"
              >
                <template v-slot:icon-calendar>
                  <font-awesome-icon icon="fas fa-calendar-alt" />
                </template>
              </date-picker>
            </div>
          </div>
          <div class="col-lg-9 text-right">
            <button
              class="btn btn-clear"
              @click="clearData()"
              style="margin-right: 20px"
            >
              <font-awesome-icon :icon="['fas', 'share']" flip="horizontal" />
              &nbsp;{{ $t("button.clear") }}
            </button>
            <button class="btn btn-search" @click="search()">
              <font-awesome-icon icon="fas fa-search" />
              &nbsp;{{ $t("button.search") }}
            </button>
          </div>
        </div>
      </div>
    </div>
    <div class="card">
      <div class="card-body">
        <div class="row form-group">
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
          <div class="row label-modifier">
            <div class="form-group col-lg-3">
              <label class="form-check-label">{{
                $t("order-inquiry.label.form.delivery_date")
              }}</label>
              <div class="date-picker-wrapper">
                <date-picker
                  format="YYYY/MM/DD"
                  id="deliveryStartDate"
                  :clearable="false"
                  v-model="deliveryStartDate"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
                <label for="" class="date-range-label">～</label>
                <date-picker
                  format="YYYY/MM/DD"
                  id="deliveryEndDate"
                  :clearable="false"
                  v-model="deliveryEndDate"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
              </div>
            </div>

            <div class="form-group col-lg-5">
              <label class="form-check-label col-lg-3">{{
                $t("order-inquiry.label.form.status")
              }}</label>
              <div class="col-lg-4">
                <select class="form-control input-border" id="status" v-model="status">
                  <option value=""></option>
                  <option
                    v-for="(item, index) in listStatus"
                    :value="item.ステータスコード"
                    :key="index"
                  >
                    {{ item.ステータス名称 }}
                  </option>
                </select>
              </div>
            </div>
          </div>
          <div
            class="row align-items-baseline form-group w-input label-modifier"
          >
            <div class="col-lg-3">
              <label for="" class="form-check-label col-lg-12"
                >{{ $t("order-inquiry.label.form.delivery_name") }}
              </label>
              <input
                type="text"
                class="form-control input-border col-lg-10"
                id="deliveryDestinationName"
                v-model="deliveryDestinationName"
              />
            </div>

            <div class="col-lg-2" style="margin-left: -50px">
              <label for="" class="form-check-label col-lg-10"
                >{{ $t("order-inquiry.label.form.commodity_cd") }}
              </label>
              <input
                type="text"
                id="productCd"
                class="form-control input-border col-lg-12"
                v-model="productCd"
              />
            </div>

            <div class="col-lg-2" style="margin-left: 10px">
              <label for="" class="form-check-label col-lg-10"
                >{{ $t("order-inquiry.label.form.commodity_nm") }}
              </label>
              <input
                type="text"
                class="form-control input-border col-lg-12"
                id="productName"
                v-model="productName"
              />
            </div>

            <div class="col-lg-3" style="margin-left: 15px">
              <label class="form-check-label col-lg-4">
                {{ $t("order-inquiry.label.form.entry_date") }}
              </label>
              <div class="row">
                <date-picker
                  format="YYYY/MM/DD"
                  id="registerDate"
                  :clearable="false"
                  v-model="registerDate"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>

                <input
                  type="time"
                  class="form-control col-lg-3 input-border"
                  id="registerTime"
                  v-model="registerTime"
                />
              </div>
            </div>
  
            <div class="col-lg-2" style="margin-left: -60px">
              <label
                class="form-check-label col-lg-5"
                style="margin-left: -15px"
                >{{ $t("order-inquiry.label.form.order_number") }}
              </label>
              <div class="row">
                <input
                  type="text"
                  id="orderNumber"
                  class="form-control col-lg-8 input-border"
                  v-model="orderNumber"
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <LoadingModalVue v-show="isLoading" />
  </div>
</template>

<script>
import moment from "moment";
import { getListOrderInquiry, getAllStatus, getOrderDateInitial } from "@/services/APIs/OMSService";
import LoadingModalVue from "../modals/LoadingModal.vue";

export default {
  components: {
    LoadingModalVue,
  },
  data() {
    return {
      listOrderinquiry: [],
      listStatus: [],
      isCollapsed: false,
      orderStartDate: null,
      orderEndDate: null,
      deliveryStartDate: null,
      deliveryEndDate: null,
      status: null,
      deliveryDestinationName: null,
      productCd: null,
      productName: null,
      registerDate: null,
      productName: null,
      registerTime: null,
      orderNumber: null,
      isLoading: false,
      searchResults: [],
    };
  },
  async created() {
    [this.listStatus, this.listOrderinquiry] = await Promise.all([
      getAllStatus(),
      getListOrderInquiry(),
    ]);
    
    this.getstartValueSearch();
    this.search();

    const orderInitial = await getOrderDateInitial("OMS")
    if(orderInitial){
      this.orderStartDate = moment(orderInitial?.oldestDate[0]?.受注日, 'YYYYMMDD').toDate();
      this.orderEndDate = moment(orderInitial?.orderDateEnd[0]?.業務日付, 'YYYYMMDD').toDate();
    }
  },
  methods: {
    handleHiddenCondition() {
      this.isCollapsed = !this.isCollapsed;
      this.$emit("toggleCondition");
    },

    storeValueSearch(){
      if(this.orderStartDate){
        localStorage.setItem("orderInquiry_orderStartDate", moment(this.orderStartDate).format("YYYYMMDD"));
      }
      if(this.orderEndDate){
        localStorage.setItem("orderInquiry_orderEndDate", moment(this.orderEndDate).format("YYYYMMDD"));
      }
      if(this.deliveryStartDate){
        localStorage.setItem("orderInquiry_deliveryStartDate", moment(this.deliveryStartDate).format("YYYYMMDD"));
      }
      if(this.deliveryEndDate){
        localStorage.setItem("orderInquiry_deliveryEndDate", moment(this.deliveryEndDate).format("YYYYMMDD"));
      }
      if(this.status){
        localStorage.setItem("orderInquiry_status",  this.status);
      }
      if(this.deliveryDestinationName){
        localStorage.setItem("orderInquiry_deliveryDestinationName",  this.deliveryDestinationName);
      }
      if(this.productCd){
        localStorage.setItem("orderInquiry_productCd",  this.productCd);
      }
      if(this.productName){
        localStorage.setItem("orderInquiry_productName",  this.productName);
      }
      if(this.registerDate){
        localStorage.setItem("orderInquiry_registerDate", moment(this.registerDate).format("YYYYMMDD") );
      }
      if(this.registerTime){
        localStorage.setItem("orderInquiry_registerTime",  this.registerTime);
      }
      if(this.orderNumber){
        localStorage.setItem("orderInquiry_orderNumber",  this.orderNumber);
      }
    },

    getstartValueSearch(){
      if(localStorage.getItem('orderInquiry_registerDate') && localStorage.getItem('orderInquiry_registerDate') !== "Invalid date" && localStorage.getItem('orderInquiry_registerDate') !== "null"){
        this.registerDate = moment(localStorage.getItem('orderInquiry_registerDate'), 'YYYYMMDD').toDate(); 
      }
      if(localStorage.getItem('orderInquiry_orderStartDate') && localStorage.getItem('orderInquiry_orderStartDate') !== "Invalid date" && localStorage.getItem('orderInquiry_orderStartDate') !== "null"){
        this.orderStartDate = moment(localStorage.getItem('orderInquiry_orderStartDate'), 'YYYYMMDD').toDate();
      }
      if(localStorage.getItem('orderInquiry_orderEndDate') && localStorage.getItem('orderInquiry_orderEndDate') !== "Invalid date" && localStorage.getItem('orderInquiry_orderEndDate') !== "null"){
        this.orderEndDate = moment(localStorage.getItem('orderInquiry_orderEndDate'), 'YYYYMMDD').toDate();
      }
      if(localStorage.getItem('orderInquiry_deliveryStartDate') && localStorage.getItem('orderInquiry_deliveryStartDate') !== "Invalid date" && localStorage.getItem('orderInquiry_deliveryStartDate') !== "null"){
        this.deliveryStartDate = moment(localStorage.getItem('orderInquiry_deliveryStartDate'), 'YYYYMMDD').toDate();
      }
      if(localStorage.getItem('orderInquiry_deliveryEndDate') && localStorage.getItem('orderInquiry_deliveryEndDate') !== "Invalid date" && localStorage.getItem('orderInquiry_deliveryEndDate') !== "null"){
        this.deliveryEndDate = moment(localStorage.getItem('orderInquiry_deliveryEndDate'), 'YYYYMMDD').toDate();
      }
      if(localStorage.getItem('orderInquiry_status')){
        this.status = localStorage.getItem('orderInquiry_status')
      }
      if(localStorage.getItem('orderInquiry_deliveryDestinationName')){
        this.deliveryDestinationName = localStorage.getItem('orderInquiry_deliveryDestinationName')
      }
      if(localStorage.getItem('orderInquiry_productCd')){
        this.productCd = localStorage.getItem('orderInquiry_productCd')
      }
      if(localStorage.getItem('orderInquiry_productName')){
        this.productName = localStorage.getItem('orderInquiry_productName')
      }
      if(localStorage.getItem('orderInquiry_registerTime')){
        this.registerTime = localStorage.getItem('orderInquiry_registerTime')
      }
      if(localStorage.getItem('orderInquiry_orderNumber')){
        this.orderNumber = localStorage.getItem('orderInquiry_orderNumber')
      }
    },


    async search() {
      this.storeValueSearch();
      this.isLoading = true;
      const params = {};
      if (this.customerCd) {
        params.customerCd = this.customerCd;
      }
      if (this.status) {
        params.statusCd = this.status;
      }
      if (this.orderStartDate) {
        params.orderStartDate = moment(this.orderStartDate).format("YYYYMMDD");
      }
      if (this.orderEndDate) {
        params.orderEndDate = moment(this.orderEndDate).format("YYYYMMDD");
      }
      if (this.deliveryStartDate) {
        params.delivery_start_date = moment(this.deliveryStartDate).format(
          "YYYYMMDD"
        );
      }
      if (this.deliveryEndDate) {
        params.delivery_end_date = moment(this.deliveryEndDate).format(
          "YYYYMMDD"
        );
      }
      if (this.productCd) {
        params.productCd = this.productCd;
      }

      if (this.productName) {
        params.productName = this.productName;
      }

      if (this.orderNumber) {
        params.orderNumber = this.orderNumber;
      }

      if (this.registerDate) {
        params.registerDate = moment(this.registerDate).format("YYYYMMDD");
      }
      if (this.registerTime) {
        params.registerTime = this.registerTime?.replace(":", "").toLowerCase();
      }
      if (this.deliveryDestinationName) {
        params.deliveryDestinationName = this.deliveryDestinationName;
      }

      const res = await getListOrderInquiry(params);
      const orders = Object.keys(res).map((item) => {
        return res[item];
      });

      // (11)
      for (let index = 0; index < orders.length; index++) {
        orders[index].countDenpyono = orders[index].length;
      }

      // (12)
      for (let index = 0; index < orders.length; index++) {
        let sum = 0;
        for (let index2 = 0; index2 < orders[index].length; index2++) {
          sum += parseInt(orders[index][index2]["irisu"]);   //入数
        }
        orders[index].count_ship_num1 = sum;
      }

      // (14)
      for (let index = 0; index < orders.length; index++) {
        let sum = 0;
        const order = orders[index];
        for (let key = 0; key < order.length; key++) {
          sum += parseInt(orders[index][key]["sell_price"]);  //売単価
        }
        if (isNaN(sum)) {
          sum = 0;
        }
        orders[index].sum_price = sum;
      }
      this.isLoading = false;
      this.$emit("search", orders);
    },

    clearData() {
      this.orderStartDate = "";
      this.orderEndDate = "";
      this.deliveryStartDate = "";
      this.deliveryEndDate = "";
      this.status = "";
      this.deliveryDestinationName = "";
      this.productCd = "";
      this.registerDate = "";
      this.productName = "";
      this.registerTime = "";
      this.orderNumber = "";
      this.search();
    },
  },
};
</script>

<style>
.bg-condition-icon {
  background-color: #5b9bd5;
}

.datepicker-gap {
  margin-left: 100px;
}

.date-picker-wrapper {
  display: flex;
  align-items: center;
}

.date-picker-wrapper .date-range-label {
  margin: 0 8px;
  padding-right: 20px;
}

.input-border {
  border: 1px solid #ccc;
}

.btn-default {
  border: 1px solid #ccc;
}
</style>

<style>
.mx-input-wrapper {
  width: 90%;
}

.mx-input {
  border: 1px solid #ccc;
}

.label-modifier label {
  margin-left: -4px;
  margin-bottom: 8px;
}

label {
  font-weight: bold;
}
</style>
