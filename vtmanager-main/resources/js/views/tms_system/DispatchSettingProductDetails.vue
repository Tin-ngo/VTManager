<template>
  <section class="main-section">
    <div class="container-fluid pt-2">
      <div class="card content">
        <div class="card-body">
          <div class="form-row form-group">
            <div class="form-group col-lg-1">
              <label class="">
                {{ this.$t("dispatch-setting-product-details.label.form.ship_date"), }}
              </label>
              <input
                type="text"
                class="form-control input-item"
                v-model="shipDate"
              />
            </div>
            <div class="form-group col-lg-1">
              <label class="">
                {{ this.$t("dispatch-setting-product-details.label.form.delivery_date"),}}
              </label>
              <input
                type="text"
                class="form-control input-item"
                v-model="deliveryDate"
              />
            </div>
          </div>

          <div class="form-row form-group">
            <div class="form-group col-lg-1">
              <label>
                {{ this.$t("dispatch-setting-product-details.label.form.shipping_course_name"),}}
              </label>
              <input
                type="text"
                class="form-control input-item"
                v-model="shippingCourseName"
              />
            </div>
            <div class="form-group col-lg-2">
              <label class="">
                {{ this.$t("dispatch-setting-product-details.label.form.shipping_company_name"),}}
              </label>
              <input
                type="text"
                class="form-control input-item"
                v-model="shippingCompanyName"
              />
            </div>
            <div class="form-group col-lg-1">
              <label class="">
                {{ this.$t("dispatch-setting-product-details.label.form.number_delivery_destinations"),}}
              </label>
              <input
                type="text"
                class="form-control input-item text-right"
                v-model="numberDeliveryDestinations"
              />
            </div>
          </div>

          <div class="form-row form-group">
            <div class="form-group col-lg-1">
              <label class="">
                {{ this.$t("dispatch-setting-product-details.label.form.vehicle_number"),}}
              </label>
              <input
                type="text"
                class="form-control input-item"
                v-model="vehicleNumber"
              />
            </div>
            <div class="form-group col-lg-1">
              <label class="">
                {{ this.$t("dispatch-setting-product-details.label.form.vehicle_size"),}}
              </label>
              <input
                type="text"
                class="form-control input-item"
                v-model="vehicleSize"
              />
            </div>
            <div class="form-group col-lg-1 text-center">
              <label class="">
                {{ this.$t("dispatch-setting-product-details.label.form.chilled_or_dry"),}}
              </label>
              <input
                type="text"
                class="form-control input-item text-center"
                v-model="chilledOrDry"
              />
            </div>
          </div>

          <div class="form-row form-group">
            <div class="form-group col-lg-10">
              <div class="form-row form-group">
                <div class="form-group col-lg-1">
                  <label class="">
                    {{ this.$t("dispatch-setting-product-details.label.form.total_number"),}}
                  </label>
                  <input
                    type="text"
                    class="form-control input-item text-right"
                    v-model="totalNumber"
                  />
                </div>
                <div class="form-group col-lg-1">
                  <label class="">
                    {{ this.$t("dispatch-setting-product-details.label.form.total_volume"),}}
                  </label>
                  <div class="form-row form-group">
                    <div class="form-group col-lg-8 mg-0">
                      <input
                        type="text"
                        class="form-control input-item text-right"
                        v-model="totalVolume"
                      />
                    </div>
                    <div class="form-group col-lg-4 mg-0">
                      <label class="">㎥</label>
                    </div>
                  </div>
                </div>
                <div class="form-group col-lg-1">
                  <label class="">
                    {{ this.$t("dispatch-setting-product-details.label.form.total_weight"),}}
                  </label>
                  <div class="form-row form-group">
                    <div class="form-group col-lg-8 mg-0">
                      <input
                        type="text"
                        class="form-control input-item text-right"
                        v-model="totalWeight"
                      />
                    </div>
                    <div class="form-group col-lg-4 mg-0">
                      <label class="">Kg</label>
                    </div>
                  </div>
                </div>
                <div class="form-group col-lg-1">
                  <label class="">
                    {{ this.$t("dispatch-setting-product-details.label.form.loading_rate"),}}
                  </label>
                  <div class="form-row form-group">
                    <div class="form-group col-lg-8 mg-0">
                      <input
                        type="text"
                        class="form-control input-item text-right"
                        v-model="loadingRate"
                      />
                    </div>
                    <div class="form-group col-lg-4 mg-0">
                      <label class="">%</label>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <!-- table -->
          <div class="w-100 scroll-table">
            <table class="w-100">
              <thead class="bg-header-table">
                <tr class="text-center bg-header">
                  <template v-for="(header, idx) in tableHeader">
                    <td :key="idx" :style="{ width: header.width }">
                      {{ header.name }}
                    </td>
                  </template>
                </tr>
              </thead>
              <tbody>
                <tr
                  class="bg-hover"
                  v-for="(item, index) in deliveryProducts"
                  :style="
                    item.total_volume == 0
                      ? 'color: red'
                      : item.total_weight == 0
                      ? 'color: red'
                      : ''
                  "
                >
                  <td class="text-center">{{ item.id }}</td>
                  <td class="text-left">{{ item.product_code }}</td>
                  <td class="text-left">
                    {{ item.product_name }}
                  </td>
                  <td class="text-right">
                    {{ formatNumber(item.total_number_shipments) }}
                  </td>
                  <td class="text-right">{{ decimal(item.total_volume) }}</td>
                  <td class="text-right">{{ decimal(item.total_weight) }}</td>
                  <td class="text-center td-btn">
                    <button @click="switchScreen(item.product_code)">
                      {{ $t("button.size_not_registered") }}
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
          <!-- end table -->
        </div>
      </div>
    </div>
    <div class="container-fluid footer-item">
      <div class="card">
        <div class="card-body">
          <div class="row">
            <div class="col-lg-12 text-right p-0">
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
</template>

<script>
import moment from "moment";
const dataMockup = [
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "123456",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "0",
    total_weight: "123456",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "0",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "123456",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "123456",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "123456",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "123456",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "123456",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "123456",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "123456",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "123456",
  },
  {
    id: "123",
    product_code: "xxxxxxxxx1xxxxxxxxx2",
    product_name: "xxxxxxxxx1xxxxxxxxx2xxxxxxxxx3xxxxxxxxx4xxxxxxxxx5",
    total_number_shipments: "123456",
    total_volume: "123456",
    total_weight: "123456",
  },
];
export default {
  components: {},
  mounted() {
    this.$store.dispatch(
      "auth/setTitle",
      this.$t("dispatch-setting-product-details.label.title")
    );
  },
  computed: {
    tableHeader() {
      return {
        0: {
          width: "3%",
          name: " ",
        },
        1: {
          width: "20%",
          name: this.$t(
            "dispatch-setting-product-details.label.table.headers.product_code"
          ), //"商品コード",
        },
        2: {
          width: "40%",
          name: this.$t(
            "dispatch-setting-product-details.label.table.headers.product_name"
          ), //"商品名",
        },
        3: {
          width: "8%",
          name: this.$t(
            "dispatch-setting-product-details.label.table.headers.total_number_shipments"
          ), //"出荷合計数",
        },
        4: {
          width: "8%",
          name: this.$t(
            "dispatch-setting-product-details.label.table.headers.total_volume"
          ), //"容積合計",
        },
        5: {
          width: "8%",
          name: this.$t(
            "dispatch-setting-product-details.label.table.headers.total_weight"
          ), //"重量合計",
        },
        6: {
          width: "10%",
          name: " ",
        },
      };
    },
  },
  data() {
    return {
      deliveryProducts: dataMockup,
      // v-model
      shipDate: "",
      deliveryDate: "",
      shippingCourseName: "",
      shippingCompanyName: "",
      numberDeliveryDestinations: "",
      vehicleNumber: "",
      vehicleSize: "",
      chilledOrDry: "",
      totalNumber: "",
      totalVolume: "",
      totalWeight: "",
      loadingRate: "",
    };
  },
  created() {
    this.shipDate = "YYYY/MM/DD";
    this.deliveryDate = "YYYY/MM/DD";
    this.shippingCourseName = "001";
    this.shippingCompanyName = "A社";
    this.numberDeliveryDestinations = "13";
    this.vehicleNumber = "A001";
    this.vehicleSize = "4トン";
    this.chilledOrDry = "チルド";
    this.totalNumber = "100";
    this.totalVolume = "20.0";
    this.totalWeight = "20.0";
    this.loadingRate = "125";
  },
  methods: {
    moment,
    goBack() {
      this.$router.push({ path: "/dispatch-setting" });
    },
    decimal(number) {
      return parseInt(number).toFixed(1);
    },
    formatNumber(number) {
      return parseInt(number).toLocaleString();
    },
    switchScreen(productCode) {
      console.log("product code", productCode);
    },
  },
};
</script>
<style>
table,
th,
td {
  border: 1px solid #ccc !important;
  border-collapse: collapse;
}

td {
  padding-left: 4px;
  padding-right: 4px;
}

.input-item {
  border: 0;
  border-bottom: 1px solid #000;
  border-radius: 0;
}

label {
  margin: 0;
}

.form-group {
  margin-right: 20px;
  margin-bottom: 8px;
}

.scroll-table {
  width: 100%;
  overflow: auto;
  max-height: 350px;
}

thead {
  position: sticky;
  top: 0;
  z-index: 1;
  box-shadow: 0 -10px 0px black, 1px 1px 0px -1px black;
}

.mg-0 {
  margin: 0;
}

.mg-0 label {
  margin-top: 8px;
  font-size: 20px !important;
  font-weight: 400 !important;
  text-decoration: underline;
}

input {
  padding-left: 0 !important;
  padding-right: 0 !important;
  padding-bottom: 0 !important;
}

.text-left {
  text-align: left !important;
}
.text-right {
  text-align: right !important;
}
.text-center {
  text-align: center !important;
}

.text-red {
  color: red !important;
}

.td-btn button {
  border: 1px solid #000;
  font-size: 14px;
  padding: 0 14px;
}
</style>
