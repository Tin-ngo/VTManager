<template>
  <section class="main-section">
    <div class="container-fluid pt-2">
      <div class="card">
        <div class="card-body">
          <!-- 発注日 -->
          <label
            class="form-check-label col-lg-1"
            style="margin-bottom: 16px; margin-left: -6px"
          >
            {{ $t("order-inquiry.label.form.order_date") }}
          </label>

          <div class="row align-items-baseline">
            <!-- 発注日 -->
            <div class="col-lg-3">
              <div class="date-picker-wrapper">
                <date-picker
                  format="YYYY/MM/DD"
                  id="orderStartDate"
                  :clearable="false"
                  v-model="conditionSearch.orderStartDate"
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
                  v-model="conditionSearch.orderEndDate"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
              </div>
            </div>

            <!-- クリア && 検索 -->
            <div class="col-lg-9 text-right">
              <!-- クリア -->
              <button
                class="btn btn-clear"
                @click="handleClearButton()"
                style="margin-right: 20px"
              >
                <font-awesome-icon :icon="['fas', 'share']" flip="horizontal" />
                &nbsp;{{ $t("button.clear") }}
              </button>

              <!-- 検索 -->
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
              @click="toggleSearchForm"
            >
              <i
                :class="
                  isSearchFormOpen
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
          <div v-show="isSearchFormOpen">
            <div class="row label-modifier">
              <div class="form-group col-lg-3">
                <!-- 納期 -->
                <label class="form-check-label">{{
                  $t("order-inquiry.label.form.delivery_date")
                }}</label>
                <div class="date-picker-wrapper">
                  <date-picker
                    format="YYYY/MM/DD"
                    id="specifiedDeliveryStartDate"
                    :clearable="false"
                    v-model="conditionSearch.specifiedDeliveryStartDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>
                  <label for="" class="date-range-label">～</label>
                  <date-picker
                    format="YYYY/MM/DD"
                    id="specifiedDeliveryEndDate"
                    :clearable="false"
                    v-model="conditionSearch.specifiedDeliveryEndDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>
                </div>
              </div>

              <div class="form-group col-lg-5">
                <!-- ステータス -->
                <label class="form-check-label col-lg-3">{{
                  $t("order-inquiry.label.form.status")
                }}</label>
                <div class="col-lg-4">
                  <select
                    class="form-control input-border"
                    id="status"
                    v-model="conditionSearch.status"
                  >
                    <option value=""></option>
                    <option
                      v-for="(item, index) in status"
                      :value="item.statuscode"
                      :key="index"
                    >
                      {{ item.statusname }}
                    </option>
                  </select>
                </div>
              </div>
            </div>
            <div
              class="row align-items-baseline form-group w-input label-modifier"
            >
              <div class="col-lg-3">
                <!-- 納入先名 -->
                <label for="" class="form-check-label col-lg-12"
                  >{{ $t("order-inquiry.label.form.delivery_name") }}
                </label>
                <input
                  type="text"
                  class="form-control input-border col-lg-10"
                  id="deliveryDestinationName"
                  v-model="conditionSearch.deliveryDestinationName"
                />
              </div>

              <div class="col-lg-2" style="margin-left: -50px">
                <!-- 商品コード -->
                <label for="" class="form-check-label col-lg-10"
                  >{{ $t("order-inquiry.label.form.commodity_cd") }}
                </label>
                <input
                  type="text"
                  id="productCode"
                  class="form-control input-border col-lg-12"
                  v-model="conditionSearch.productCode"
                />
              </div>

              <div class="col-lg-2" style="margin-left: 10px">
                <!-- 商品名 -->
                <label for="" class="form-check-label col-lg-10"
                  >{{ $t("order-inquiry.label.form.commodity_nm") }}
                </label>
                <input
                  type="text"
                  class="form-control input-border col-lg-12"
                  id="productName"
                  v-model="conditionSearch.productName"
                />
              </div>

              <div class="col-lg-3" style="margin-left: 15px">
                <!-- 登録日時 -->
                <label class="form-check-label col-lg-4">
                  {{ $t("order-inquiry.label.form.entry_date") }}
                </label>
                <div class="row">
                  <date-picker
                    format="YYYY/MM/DD"
                    id="registeredDate"
                    :clearable="false"
                    v-model="conditionSearch.registeredDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>

                  <input
                    type="time"
                    class="form-control col-lg-3 input-border"
                    id="registeredTime"
                    v-model="conditionSearch.registeredTime"
                  />
                </div>
              </div>

              <div class="col-lg-2" style="margin-left: -60px">
                <!-- 発注番号 -->
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
                    v-model="conditionSearch.orderNumber"
                  />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <LoadingModal v-show="isLoading" />
    </div>
    <!-- <HeaderBlock
      @search="setSearchResult"
      ref="headerBlock"
      @toggleCondition="toggleCondition()"
    /> -->
    <!-- <ContentBlock :listData="searchResult" ref="ContentBlock" @reload="reload"/> -->

    <section>
      <div class="container-fluid">
        <div class="card bg-condition">
          <div class="card-body">
            <div :class="contentHeight" class="wrap-scroll">
              <div
                class="search-result pl-2 w-100 mg-0 item-scroll"
                style="border: 1px solid #ccc; line-height: 32px; height: 34px"
              >
                <label
                  style="margin-bottom: 0"
                  class="wrap-scroll-dispatch-title"
                  >{{ $t("label.search_results") }}</label
                >
              </div>
              <div
                class="text-center row-table header-row w-100 item-scroll wrap-scroll-dispatch-header"
              >
                <template v-for="(header, idx) in tableHeader">
                  <div
                    :key="idx"
                    v-if="idx == 0"
                    class="cell align-items-center header-color text-white header-btn bg-header"
                    :style="{
                      width: header.width,
                      background: '#ccc',
                      color: 'black',
                      'border-color': 'white',
                      'text-align': 'center',
                    }"
                  >
                    {{ header.name }}
                  </div>
                  <div
                    v-else
                    :class="[
                      'cell align-items-center header-color d-flex justify-content-center bg-header',
                      { 'header-color': idx !== 14 },
                    ]"
                    :key="idx"
                    :style="{
                      width: header.width,
                      background: '#ccc',
                      color: 'black',
                      'border-color': 'white',
                    }"
                  >
                    {{ header.name }}
                  </div>
                </template>
              </div>
              <template>
                <ContentItem
                  v-for="(item, idx) in enquiryOrders"
                  :item="item"
                  :key="idx"
                  class="w-100"
                  @reload="reload"
                />
              </template>
            </div>
          </div>
        </div>
      </div>
      <div class="container-fluid footer-item">
        <div class="card">
          <div class="row card-body">
            <div class="col-lg-3">
              <button class="btn btn-delete" @click="deleteAll">
                <font-awesome-icon icon="fas fa-pencil-alt" />
                {{ $t("button.cancel_all") }}
              </button>
            </div>
            <div class="col-lg-9 text-right">
              <button class="btn btn-back" @click="goBack()">
                <i class="fas fa-arrow-left"></i>
                {{ $t("button.back") }}
              </button>
            </div>
          </div>
        </div>
      </div>
    </section>
  </section>
</template>

<script>
// import HeaderBlock from "@/components/orderInquiry/HeaderBlock.vue";
// import ContentBlock from "@/components/orderInquiry/ContentBlock.vue";
import { SEARCH_STATE, ROUTER, ROUTER_NAME, RESPONSE_CODE } from "@/constants";
import LoadingModal from "@/components/modals/LoadingModal.vue";
import ContentItem from "@/components/orderInquiry/ContentItem.vue";
import {
  getOrderInquiry,
  getMstStatus,
  getOrderDate,
  deleteOrders,
} from "@/services/APIs/OMSService";
import {
  checkBlank,
  handleConditionSearch,
  handleBackButton,
  setIsOpenedFromMenu,
  handlePageReload,
} from "@/utils/helper";
import moment from "moment";

export default {
  components: {
    // HeaderBlock,
    // ContentBlock,
    LoadingModal,
    ContentItem,
  },
  async created() {
    const status = await getMstStatus();
    if (status) this.status = status;
  },
  async mounted() {
    this.$store.dispatch("auth/setTitle", this.$t("order-inquiry.label.title"));

    const constionSearch = localStorage.getItem(this.screenName);
    if (!checkBlank(constionSearch)) {
      this.conditionSearch = JSON.parse(constionSearch);
      const {
        orderStartDate,
        orderEndDate,
        specifiedDeliveryStartDate,
        specifiedDeliveryEndDate,
        registeredDate,
      } = this.conditionSearch;

      if (orderStartDate) {
        this.conditionSearch.orderStartDate = moment(
          orderStartDate,
          "YYYY/MM/DD"
        ).toDate();
      }

      if (orderEndDate) {
        this.conditionSearch.orderEndDate = moment(
          orderEndDate,
          "YYYY/MM/DD"
        ).toDate();
      }
      if (specifiedDeliveryStartDate) {
        this.conditionSearch.specifiedDeliveryStartDate = moment(
          specifiedDeliveryStartDate,
          "YYYY/MM/DD"
        ).toDate();
      }
      if (specifiedDeliveryEndDate) {
        this.conditionSearch.specifiedDeliveryEndDate = moment(
          specifiedDeliveryEndDate,
          "YYYY/MM/DD"
        ).toDate();
      }
      if (registeredDate) {
        this.conditionSearch.registeredDate = moment(
          registeredDate,
          "YYYY/MM/DD"
        ).toDate();
      }
    } else {
      const orderDate = await getOrderDate("OMS");
      if (orderDate) {
        this.conditionSearch.orderStartDate = moment(
          orderDate?.orderStartDate,
          "YYYY/MM/DD"
        ).toDate();
        this.conditionSearch.orderEndDate = moment(
          orderDate?.orderEndDate,
          "YYYY/MM/DD"
        ).toDate();
      }
    }
    this.search();
  },
  computed: {
    tableHeader() {
      return {
        0: {
          width: "3%",
          name: "", // 削除
        },
        1: {
          width: "6%",
          name: this.$t("label.cancel"),
        },
        2: {
          width: "3%",
          name: this.$t("label.edit"),
        },
        3: {
          width: "6%",
          name: this.$t("order-inquiry.label.table.headers.status"),
        },
        4: {
          width: "6%",
          name: this.$t("order-inquiry.label.table.headers.order_number"),
        },
        5: {
          width: "6%",
          name: this.$t("order-inquiry.label.table.headers.slip_number"),
        },
        6: {
          width: "8%",
          name: this.$t("order-inquiry.label.table.headers.order_date"),
        },
        7: {
          width: "8%",
          name: this.$t("order-inquiry.label.table.headers.delivery_date"),
        },
        8: {
          width: "8%",
          name: this.$t("order-inquiry.label.table.headers.delivery_code"),
        },
        9: {
          width: "11%",
          name: this.$t("order-inquiry.label.table.headers.shipping_name"),
        },
        10: {
          width: "10%",
          name: this.$t(
            "order-inquiry.label.table.headers.delivery_to_address"
          ),
        },
        11: {
          width: "4%",
          name: this.$t("order-inquiry.label.table.headers.number_items"),
        },
        12: {
          width: "5%",
          name: this.$t("order-inquiry.label.table.headers.total_quantity"),
        },
        13: {
          width: "6%",
          name: this.$t("order-inquiry.label.table.headers.ship_date"),
        },
        14: {
          width: "7%",
          name: this.$t("order-inquiry.label.table.headers.purchase_total"),
        },
        15: {
          width: "10%",
          name: this.$t("order-inquiry.label.table.headers.entry_date"),
        },
      };
    },
  },
  data() {
    return {
      screenName: ROUTER_NAME.OmsOrderInquiry,
      isSearchFormOpen: false,
      // ステータス
      status: [],
      conditionSearch: {
        // 発注日
        orderStartDate: null,
        orderEndDate: null,
        // 納期
        specifiedDeliveryStartDate: null,
        specifiedDeliveryEndDate: null,
        // ステータス
        status: null,
        // 納入先名
        deliveryDestinationName: null,
        // 商品コード
        productCode: null,
        // 商品名
        productName: null,
        // 登録日時
        registeredDate: null,
        registeredTime: null,
        // 発注番号
        orderNumber: null,
      },
      enquiryOrders: [],

      searchResult: [],
      listOrderinquiry: [],

      isLoading: false,
      searchResults: [],

      isShowDetail: false,
      contentHeight: "scroll-max-height",
    };
  },

  methods: {
    moment,
    toggleSearchForm() {
      this.isSearchFormOpen = !this.isSearchFormOpen;
      this.handleHeightContent();
    },
    handleHeightContent() {
      this.contentHeight =
        this.contentHeight == "scroll-max-height"
          ? "scroll-min-height"
          : "scroll-max-height";
    },
    async search() {
      this.isLoading = true;
      handleConditionSearch(this, SEARCH_STATE.ADD_CONDITION);
      const params = { ...this.conditionSearch };
      const {
        orderStartDate,
        orderEndDate,
        specifiedDeliveryStartDate,
        specifiedDeliveryEndDate,
        registeredDate,
        registeredTime,
      } = params;

      if (orderStartDate)
        params.orderStartDate = moment(orderStartDate).format("YYYYMMDD");
      if (orderEndDate)
        params.orderEndDate = moment(orderEndDate).format("YYYYMMDD");
      if (specifiedDeliveryStartDate)
        params.specifiedDeliveryStartDate = moment(
          specifiedDeliveryStartDate
        ).format("YYYYMMDD");
      if (specifiedDeliveryEndDate)
        params.specifiedDeliveryEndDate = moment(
          specifiedDeliveryEndDate
        ).format("YYYYMMDD");
      if (registeredDate)
        params.registeredDate = moment(registeredDate).format("YYYYMMDD");
      if (registeredTime)
        params.registeredTime = registeredTime?.replace(":", "");
      try {
        let result = await getOrderInquiry(params);
        console.log({ res: result });
        this.isLoading = false;

        // const orders = Object.keys(result).map((item) => {
        //   return result[item];
        // });

        // // (11)
        // for (let index = 0; index < orders.length; index++) {
        //   orders[index].countDenpyono = orders[index].length;
        // }

        // // (12)
        // for (let index = 0; index < orders.length; index++) {
        //   let sum = 0;
        //   for (let index2 = 0; index2 < orders[index].length; index2++) {
        //     sum += parseInt(orders[index][index2]["irisu"]); //入数
        //   }
        //   orders[index].count_ship_num1 = sum;
        // }

        // // (14)
        // for (let index = 0; index < orders.length; index++) {
        //   let sum = 0;
        //   const order = orders[index];
        //   for (let key = 0; key < order.length; key++) {
        //     sum += parseInt(orders[index][key]["sell_price"]); //売単価
        //   }
        //   if (isNaN(sum)) {
        //     sum = 0;
        //   }
        //   orders[index].sum_price = sum;
        // }
        // console.log(orders);
        this.enquiryOrders = result;
      } catch (e) {
        console.log(e);
        this.isLoading = false;
      }
    },
    handleClearButton() {
      this.conditionSearch = {
        // 発注日
        orderStartDate: null,
        orderEndDate: null,
        // 納期
        specifiedDeliveryStartDate: null,
        specifiedDeliveryEndDate: null,
        // ステータス
        status: null,
        // 納入先名
        deliveryDestinationName: null,
        // 商品コード
        productCode: null,
        // 商品名
        productName: null,
        // 登録日時
        registeredDate: null,
        registeredTime: null,
        // 発注番号
        orderNumber: null,
      };
      this.search();
    },
    goBack() {
      handleBackButton(this);
    },
    reload() {
      this.$refs.headerBlock.search();
    },
    async deleteAll() {
      const numDelete = [];
      for (let index = 0; index < this.enquiryOrders.length; index++) {
        numDelete.push(this.enquiryOrders[index][0]["denpyono"]);
      }
      const result = await deleteOrders(numDelete);
      if (typeof result !== "undefined") {
        this.$toast.success("正常に削除されました");
        this.search();
        this.$emit("reload");
      } else {
        this.$toast.error("削除に失敗しました");
      }
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

.table {
  background-color: #fff;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  overflow: hidden;
  width: 80%;
}

.row-table {
  display: flex;
  border-bottom: 1px solid #ccc;
  border: 1px solid #ccc;
  border-right: 0;
}

.cell {
  border-right: 1px solid gray;
}

.header-color {
  background-color: #2f75b5;
}

.header-btn {
  display: grid;
}

.mg-0 {
  margin: 0;
}
.mg-0 label {
  margin: 0;
}

.scroll-min-height {
  max-height: 285px;
  overflow-y: auto;
}

.scroll-max-height {
  max-height: 460px;
  overflow-y: auto;
}
</style>
