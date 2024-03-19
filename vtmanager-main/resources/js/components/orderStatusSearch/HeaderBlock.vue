<template>
  <div>
    <div class="container-fluid pt-2 content">
      <div class="card">
        <div class="card-body">
          <div class="form-row">
            <div class="form-group col-lg-1">
              <!-- 得意先 -->
              <label>{{ $t("order-status.label.form.customer") }}</label>
              <select class="form-control" v-model="customerCd">
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
              <!-- 出荷予定日 -->
              <label>{{
                $t("order-status.label.form.expected_shipping_date")
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
                <label for="" class="date-range-label">～</label>
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
            <div class="col-lg-8 d-flex justify-content-end align-items-center">
              <button class="btn btn-clear mr-2" @click="clear()">
                <font-awesome-icon :icon="['fas', 'share']" flip="horizontal" />
                &nbsp;{{ $t("button.clear") }}
              </button>
              <button class="btn btn-search" @click="search">
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
            <div class="form-row">
              <div class="form-group col-lg-1">
                <!-- ステータス -->
                <label>{{ $t("order-status.label.form.status") }} </label>
                <select class="form-control" v-model="statusCd">
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
              <div class="form-group col-lg-1">
                <!-- 出荷対象 -->
                <label
                  >{{ $t("order-status.label.form.shipping_target") }}
                </label>
                <select class="form-control" v-model="shipTarget">
                  <option value=""></option>
                  <option value="出荷対象_1">出荷対象_1</option>
                  <option value="出荷対象_2">出荷対象_2</option>
                  <option value="出荷対象_3">出荷対象_3</option>
                  <!-- <option
                  v-for="(item, idx) in listStatus"
                  :key="idx"
                  :value="item?.ステータスコード"
                >
                  {{ item?.ステータス名称 }}
                </option> -->
                </select>
              </div>
              <div class="form-group col-lg-3">
                <!-- 発注日 -->
                <label>{{ $t("order-status.label.form.order_date") }} </label>
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
                  <label for="" class="date-range-label">～</label>
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
                <!-- 納期 -->
                <label>{{ $t("order-status.label.form.deadline") }} </label>
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
                  <label for="" class="date-range-label">～</label>
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
            </div>

            <div class="form-row">
              <div class="form-group col-lg-2">
                <!-- 納入先名 -->
                <label
                  >{{ $t("order-status.label.form.delivery_name") }}
                </label>
                <input
                  type="text"
                  class="form-control"
                  v-model="nhsakiItemName"
                />
              </div>
              <div class="form-group col-lg-1">
                <!-- 商品コード -->
                <label>{{ $t("order-status.label.form.product_cd") }} </label>
                <input type="text" class="form-control" v-model="itemCd" />
              </div>
              <div class="form-group col-lg-2">
                <!-- 商品名 -->
                <label>{{ $t("order-status.label.form.product_name") }} </label>
                <input
                  type="text"
                  class="form-control"
                  v-model="nhsakiItemName"
                />
              </div>
              <div class="form-group col-lg-1">
                <!-- 発注番号 -->
                <label>{{ $t("order-status.label.form.order_number") }} </label>
                <input type="text" class="form-control" v-model="slipNum" />
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
import {
  getOrderStatus,
  getCustomerByID,
  getStatusByID,
} from "@/services/APIs/OMSService";
import moment from "moment";
import LoadingModalVue from "../modals/LoadingModal.vue";
import { DATE_FORMAT_BASIC } from "@/constants";
export default {
  components: {
    LoadingModalVue,
  },
  data() {
    return {
      isCollapsed: false,
      customerCd: null,
      shipStartDate: null,
      shipEndDate: null,
      orderStartDate: null,
      orderEndDate: null,
      deliveryStartDate: null,
      deliveryEndDate: null,
      statusCd: null,
      shipTarget: null,
      itemCd: null,
      nhsakiItemName: null,
      slipNum: null,
      listCustomer: [],
      listStatus: [],
      confirmTarget: null,
      isLoading: false,
    };
  },
  async mounted() {
    this.search();
  },
  async created() {
    [this.listCustomer, this.listStatus] = await Promise.all([
      getCustomerByID(this.params),
      getStatusByID(this.params),
    ]);
  },
  methods: {
    handleHiddenCondition() {
      this.isCollapsed = !this.isCollapsed;
      this.$emit("toggleCondition");
    },
    clear() {
      this.customerCd = null;
      this.shipStartDate = null;
      this.shipEndDate = null;
      this.orderStartDate = null;
      this.orderEndDate = null;
      this.deliveryStartDate = null;
      this.deliveryEndDate = null;
      this.statusCd = null;
      this.itemCd = null;
      this.nhsakiItemName = null;
      this.slipNum = null;
      this.shipTarget = null;
      this.search();
    },
    async search() {
      this.isLoading = true;
      const params = {};
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
      if (this.itemCd) {
        params.itemCd = this.itemCd;
      }
      if (this.nhsakiItemName) {
        params.nhsakiItemName = this.nhsakiItemName;
      }
      if (this.slipNum) {
        params.slipNum = this.slipNum;
      }
      const res = await getOrderStatus(params);
      this.isLoading = false;
      this.$emit("setListSlcOmsT1Order", res);
    },
  },
};
</script>

<style lang="scss">
.content {
  .mx-input {
    height: 38px;
  }
}
</style>
