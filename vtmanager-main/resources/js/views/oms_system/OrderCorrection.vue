<template>
  <div>
    <section class="content-order">
      <div class="container-fluid pt-2">
        <div class="card">
          <div class="card-body">
            <div class="form-row form-group">
              <div class="form-group col-lg-2">
                <!-- 受注No -->
                <label class="">{{
                  $t("order-correction.label.form.slip_number")
                }}</label>
                <input
                  type="text"
                  class="form-control input-item"
                  v-model="slipNumber"
                />
              </div>
              <div class="form-group col-lg-1">
                <!-- 発注日 -->
                <label class="">{{
                  $t("order-correction.label.form.order_date")
                }}</label>
                <input
                  type="text"
                  class="form-control input-item"
                  v-model="orderDate"
                />
              </div>
            </div>

            <div class="form-row form-group">
              <div class="form-group col-lg-2">
                <label class="d-flex align-items-center">
                  <!-- 発注番号 -->
                  {{ $t("order-correction.label.form.order_number") }}
                  <span class="badge badge-danger" style="margin-bottom: 5px">
                    必须</span
                  >
                </label>
                <input type="text" class="form-control" v-model="orderNumber" />
              </div>
              <div class="form-group col-lg-2">
                <label class="d-flex align-items-center">
                  <!-- 発注予定日 -->
                  {{ $t("order-correction.label.form.expected_order_date") }}
                  <span class="badge badge-danger" style="margin-bottom: 5px">
                    必须</span
                  >
                </label>
                <div class="date-picker-wrapper">
                  <date-picker
                    format="YYYY/MM/DD"
                    id="datePicker1"
                    :clearable="false"
                    v-model="shipDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>
                </div>
              </div>
              <div class="form-group col-lg-2">
                <!-- 納期 -->
                <label class="d-flex align-items-center">
                  {{ $t("order-correction.label.form.deadline") }}
                  <span class="badge badge-danger" style="margin-bottom: 5px">
                    必须</span
                  >
                </label>
                <div class="date-picker-wrapper">
                  <date-picker
                    format="YYYY/MM/DD"
                    id="datePicker1"
                    :clearable="false"
                    v-model="deliveryDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>
                </div>
              </div>
            </div>

            <div class="form-row form-group">
              <div class="form-group col-lg-2">
                <!-- 納入先 -->
                <label class="d-flex align-items-center">
                  {{ $t("order-correction.label.form.delivery_destination") }}
                  <span class="badge badge-danger" style="margin-bottom: 5px">
                    必须
                  </span>
                </label>
                <div class="d-flex">
                  <input type="text" class="form-control" v-model="nhsakiCd" />
                  <button class="btn btn-default ml-2">
                    <font-awesome-icon icon="fas fa-search" />
                  </button>
                </div>
              </div>
              <div class="col-lg-4 d-flex align-items-center mt-3">
                <input type="text" class="form-control" v-model="nhsakiName" />
              </div>
              <div class="col-lg-5 d-flex align-items-center mt-3">
                <input type="text" class="form-control" v-model="nhsakiAd" />
              </div>
            </div>

            <div class="w-100 scroll-table content-table">
              <table class="w-100">
                <thead class="bg-header-table wrap-scroll-title">
                  <tr class="text-center bg-header">
                    <template v-for="(header, idx) in tableHeader">
                      <td :key="idx">
                        {{ header }}
                      </td>
                    </template>
                  </tr>
                </thead>
                <tbody>
                  <tr
                    v-for="(item, idx) in listOrderCorrection"
                    :key="idx"
                    class="bg-hover"
                  >
                    <td class="text-center">{{ item?.meisai_no }}</td>
                    <td class="text-center">{{ item?.status_name }}</td>
                    <td style="width: 15%">
                      <div class="row ml-0" style="width: 100%">
                        <div style="width: 70%">
                          <input
                            type="text"
                            class="form-control ml-1 change-color-input"
                            v-model="item.item_cd"
                          />
                        </div>
                        <div style="width: 25%">
                          <button
                            class="btn btn-default w-100 ml-2"
                            @click="transferScreenToDeliveryDestination()"
                          >
                            <font-awesome-icon icon="fas fa-search" />
                          </button>
                        </div>
                      </div>
                    </td>
                    <td style="width: 10%">{{ item?.item_name }}</td>
                    <td style="width: 10%">
                      <input
                        style="width: 95%"
                        type="text"
                        class="form-control ml-1 change-color-input"
                        v-model="item.lot_no"
                      />
                    </td>
                    <td style="width: 12%" class="calendar-color-custom">
                      <date-picker
                        style="width: 95%"
                        format="YYYY/MM/DD"
                        class="ml-1"
                        :clearable="false"
                        v-model="item.symlmt"
                      >
                        <template v-slot:icon-calendar>
                          <font-awesome-icon icon="fas fa-calendar-alt" />
                        </template>
                      </date-picker>
                    </td>
                    <td style="width: 5%">
                      <input
                        style="width: 90%"
                        type="text"
                        class="form-control ml-1 change-color-input"
                        v-model="item.order_num1"
                      />
                    </td>
                    <td class="text-right">{{ item?.irisu }}</td>
                    <td class="text-right">{{ item?.ship_num1 }}</td>
                    <td class="text-right">{{ item?.sell_amount }}</td>
                    <td class="text-nowrap">
                      <button
                        style="width: 85%"
                        class="m-1 border-0 bg-transparent"
                      >
                        <font-awesome-icon icon="fas fa-trash" />
                      </button>
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>

        <div class="card">
          <div class="card-body">
            <div class="row align-items-baseline">
              <div class="col-lg-1">
                <label for="" class="d-flex align-items-center"
                  >{{ $t("order-correction.label.form.corrector_name") }}
                  <span class="badge badge-danger" style="margin-bottom: 5px">
                    必须</span
                  ></label
                >
              </div>
              <div class="col-lg-2">
                <input type="text" class="form-control" />
              </div>
              <div class="col-lg-2">
                <button class="btn btn-register">
                  <font-awesome-icon icon="fas fa-pencil-alt" />
                  {{ $t("button.correction") }}
                </button>
              </div>
              <div class="col-lg-7 text-right">
                <button class="btn btn-back" @click="goBack()">
                  <font-awesome-icon icon="fas fa-arrow-left" />
                  {{ $t("button.back") }}
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import { getOrderCorrection } from "@/services/APIs/OMSService";
import moment from "moment";
import { DATE_FORMAT_SLASH } from "@/constants";
export default {
  data() {
    return {
      slipNumber: null,
      orderNo: null,
      orderDate: null,
      orderNumber: null,
      deliveryDestinationName: null,
      denpyono: null,
      shipDate: null,
      deliveryDate: null,
      nhsakiCd: null,
      nhsakiName: null,
      nhsakiAd: null,
      listOrderCorrection: [],
    };
  },
  computed: {
    formattedDates() {
      return this.listOrderCorrection.map((item) => {
        const dateStr = item?.symlmt.toString();
        const year = dateStr.substr(0, 4);
        const month = dateStr.substr(4, 2);
        const day = dateStr.substr(6, 2);
        return new Date(`${year}-${month}-${day}`);
      });
    },
    tableHeader() {
      return {
        0: this.$t("order-correction.label.table.headers.no"),
        1: this.$t("order-correction.label.table.headers.status"),
        2: this.$t("order-correction.label.table.headers.commodity_cd"),
        3: this.$t("order-correction.label.table.headers.commodity_nm"),
        4: this.$t("order-correction.label.table.headers.lot_no"),
        5: this.$t("order-correction.label.table.headers.expriration_date"),
        6: this.$t("order-correction.label.table.headers.order_qty"),
        7: this.$t("order-correction.label.table.headers.qty_per_carton"),
        8: this.$t("order-correction.label.table.headers.expected_arrival"),
        9: this.$t("order-correction.label.table.headers.purchase_amount"),
        10: "",
      };
    },
  },
  async mounted() {
    const dataOrder = this.$route.query.dataOrder;
    console.log({ dataOrder: dataOrder });
    if (this.$route.query.dataOrder.denpyono) {
      this.slipNumber = this.$route.query.dataOrder.denpyono;
    }
    if (this.$route.query.dataOrder.order_date) {
      this.orderDate = moment(this.$route.query.dataOrder.order_date).format(
        DATE_FORMAT_SLASH
      );
    }
    if (this.$route.query.dataOrder.order_no) {
      this.orderNumber = this.$route.query.dataOrder.order_no;
    }
    if (this.$route.query.dataOrder.ship_date) {
      this.shipDate = this.formatDate(this.$route.query.dataOrder.ship_date);
    }
    if (this.$route.query.dataOrder.delivery_date) {
      this.deliveryDate = this.formatDate(
        this.$route.query.dataOrder.delivery_date
      );
    }
    if (this.$route.query.dataOrder.nhsaki_cd) {
      this.nhsakiCd = this.$route.query.dataOrder.nhsaki_cd;
    }
    if (
      this.$route.query.dataOrder.nhsaki_name1 &&
      this.$route.query.dataOrder.nhsaki_name2
    ) {
      this.nhsakiName =
        this.$route.query.dataOrder.nhsaki_name1 +
        " " +
        this.$route.query.dataOrder.nhsaki_name2;
    }
    if (
      this.$route.query.dataOrder.nhsaki_ad1 &&
      this.$route.query.dataOrder.nhsaki_ad2
    ) {
      this.nhsakiAd =
        this.$route.query.dataOrder.nhsaki_ad1 +
        " " +
        this.$route.query.dataOrder.nhsaki_ad2;
    }
    await this.getOrderCorrection();
    this.$store.dispatch(
      "auth/setTitle",
      this.$t("order-correction.label.title")
    );
  },
  methods: {
    moment,
    async getOrderCorrection() {
      const params = {};
      if (this.orderNo) {
        params.order_no = this.orderNo;
      }
      if (this.orderDate) {
        params.order_date = this.orderDate;
      }
      if (this.denpyono) {
        params.denpyono = this.denpyono;
      }
      if (this.shipDate) {
        params.ship_date = this.shipDate;
      }
      if (this.deliveryDate) {
        params.delivery_date = this.deliveryDate;
      }
      if (this.nhsakiCD) {
        params.nhsaki_cd = this.nhsakiCD;
      }
      if (this.nhsakiName1) {
        params.nhsaki_name1 = this.nhsakiName1;
      }
      if (this.nhsakiName2) {
        params.nhsaki_name2 = this.nhsakiName2;
      }
      if (this.nhsakiAd1) {
        params.nhsaki_ad1 = this.nhsakiAd1;
      }
      if (this.nhsakiAd2) {
        params.nhsaki_ad2 = this.nhsakiAd2;
      }
      this.listOrderCorrection = await getOrderCorrection(params);
    },
    formatDate(date) {
      return moment(date, DATE_FORMAT_SLASH).toDate();
    },
    goBack() {
      this.$router.push("/main");
    },

    transferScreenToDeliveryDestination() {
      this.$router.push("/delivery-destination");
    },
  },
};
</script>
<style scoped lang="scss">
.content-order {
  table,
  th,
  td {
    border: 1px solid #ccc !important;
    border-collapse: collapse;
  }

  .bg-header-table {
    background-color: #d9d9d9;
    color: #000;
    font-weight: 700;
  }

  .change-color-input {
    background-color: #fff2cc;
  }

  button {
    border: 1px solid #ccc;
  }

  .input-item {
    border: 0;
    border-bottom: 1px solid #000;
    border-radius: 0;
  }

  .scroll-table {
    overflow-y: auto;
    height: 380px;
  }
}
</style>

<style>
.mx-input {
  border: 1px solid #ccc;
  height: 38px;
}

.calendar-color-custom .mx-input {
  background-color: #fff2cc;
}

.bg-hover:hover {
  background-color: #fff2cc;
}

.wrap-scroll-title {
  position: sticky;
  top: 0;
  z-index: 9999;
  margin-top: -1px;
}
</style>
