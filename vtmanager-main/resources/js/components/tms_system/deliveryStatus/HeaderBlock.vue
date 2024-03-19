<template>
  <div>
    <div class="container-fluid pt-2">
      <div class="card condition">
        <div class="card-body">
          <div class="row form-group mg-0">
            <div class="form-group col-lg-3 mg-0 padding-0">
              <label class="search__group--date">{{
                $t("order-history.label.form.ship_date")
              }}</label>
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
            <div class="col d-flex justify-content-end align-items-center">
              <button class="btn btn-clear mr-2" @click="clear()">
                <font-awesome-icon
                  :icon="['fas', 'share']"
                  flip="horizontal"
                />&nbsp;{{ $t("button.clear") }}
              </button>
              <button class="btn btn-search" @click="search()">
                <font-awesome-icon icon="fas fa-search" />
                &nbsp;{{ $t("button.search") }}
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid pt-2">
      <div class="card condition">
        <div class="card-body">
          <div class="row form-group">
            <div
              class="border px-2 condition__icon rounded"
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
          <div v-show="isCollapsed" class="search">
            <div class="form-row">
              <div class="form-group col-lg-2 search__group">
                <label class="search__group--date">出荷倉庫</label>
                <select
                  class="form-control search__group--customer col-lg-10"
                  v-model="shippingWarehouse"
                >
                  <option value=""></option>
                  <option value="1">出荷倉庫1</option>
                  <option value="2">出荷倉庫2</option>
                  <option value="3">出荷倉庫3</option>
                </select>
              </div>

              <div class="form-group col-lg-2">
                <label>配送会社</label>
                <select
                  class="form-control search__group--customer col-lg-10"
                  v-model="deliveryCompany"
                >
                  <option value=""></option>
                  <option value="1">配送会社1</option>
                  <option value="2">配送会社2</option>
                  <option value="3">配送会社3</option>
                </select>
              </div>
              <div class="form-group col-lg-2">
                <label>{{
                  $t("delivery-status.label.form.shipping_course")
                }}</label>
                <select
                  class="form-control search__group--customer col-lg-10"
                  v-model="shippingCourse"
                >
                  <option value=""></option>
                  <option value="1">配送コース_1</option>
                  <option value="2">配送コース_2</option>
                  <option value="3">配送コース_3</option>
                </select>
              </div>
              <div class="form-group col-lg-2">
                <label>{{
                  $t("delivery-status.label.form.vehicle_number")
                }}</label>
                <select
                  class="form-control search__group--customer col-lg-10"
                  v-model="vehicleNumber"
                >
                  <option value=""></option>
                  <option value="1">xxxxxxxxx1</option>
                  <option value="2">xxxxxxxxx2</option>
                  <option value="3">xxxxxxxxx3</option>
                  <option value="4">xxxxxxxxx4</option>
                  <option value="5">xxxxxxxxx5</option>
                </select>
              </div>
            </div>
            <div class="form-row">
              <div class="col-lg-4 form-group">
                <label for="">納品先名</label>
                <input
                  type="text"
                  class="form-control search__group--deliveryName"
                  style="width: 85% !important"
                  v-model="deliveryName"
                />
              </div>
              <div class="form-group col-lg-2">
                <label>{{ $t("delivery-status.label.form.status") }}</label>
                <select
                  class="form-control search__group--customer col-lg-10"
                  v-model="status"
                >
                  <option value=""></option>
                  <option value="1">ステータス1</option>
                  <option value="2">ステータス2</option>
                  <option value="3">ステータス3</option>
                  <option value="4">ステータス4</option>
                  <option value="5">ステータス5</option>
                </select>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import moment from "moment";
const dataMockup = [
  {
    parent: {
      ship_date: "20231019",
      shipping_warehouse: "出荷倉庫1",
      shipping_warehouse_cd: "1",
      status: "ステータス1",
      status_cd: "1",
      shipping_course_name: "配送コース1",
      shipping_course_cd: "1",
      number_delivery_destinations: "999",
      delivery_company: "配送会社1",
      delivery_company_cd: "1",
      vehicle_number: "xxxxxxxxx1",
      vehicle_number_cd: "1",
      vehicle_size: "xxxxxxxxx1",
      loading_rate: "999%",
    },
    childrens: [
      {
        order: "1",
        delivery_cd: "xxxxxxxxx1",
        delivery_name: "delivery_name11",
        delivery_slip_no: "xxxxxxxxx1",
        delivery_completion_time: "HH:MM",
        number_of_pieces: "99999",
        volume: "99999",
        abnormality: "KK",
        notices: "xxxxxxxxx1xxxxxxxxx2",
      },
      {
        order: "2",
        delivery_cd: "xxxxxxxxx1",
        delivery_name: "delivery_name12",
        delivery_slip_no: "xxxxxxxxx1",
        delivery_completion_time: "HH:MM",
        number_of_pieces: "99999",
        volume: "99999",
        abnormality: "KK",
        notices: "xxxxxxxxx1xxxxxxxxx2",
      },
      {
        order: "3",
        delivery_cd: "xxxxxxxxx1",
        delivery_name: "delivery_name13",
        delivery_slip_no: "xxxxxxxxx1",
        delivery_completion_time: "HH:MM",
        number_of_pieces: "99999",
        volume: "99999",
        abnormality: "KK",
        notices: "xxxxxxxxx1xxxxxxxxx2",
      },
    ],
  },
  {
    parent: {
      ship_date: "20231019",
      shipping_warehouse: "出荷倉庫2",
      shipping_warehouse_cd: "2",
      status: "ステータス2",
      status_cd: "2",
      shipping_course_name: "配送コース2",
      shipping_course_cd: "2",
      number_delivery_destinations: "999",
      delivery_company: "配送会社2",
      delivery_company_cd: "2",
      vehicle_number: "xxxxxxxxx2",
      vehicle_number_cd: "2",
      vehicle_size: "xxxxxxxxx1",
      loading_rate: "999%",
    },
    childrens: [
      {
        order: "1",
        delivery_cd: "xxxxxxxxx1",
        delivery_name: "delivery_name21",
        delivery_slip_no: "xxxxxxxxx1",
        delivery_completion_time: "HH:MM",
        number_of_pieces: "99999",
        volume: "99999",
        abnormality: "KK",
        notices: "xxxxxxxxx1xxxxxxxxx2",
      },
      {
        order: "2",
        delivery_cd: "xxxxxxxxx1",
        delivery_name: "delivery_name22",
        delivery_slip_no: "xxxxxxxxx1",
        delivery_completion_time: "HH:MM",
        number_of_pieces: "99999",
        volume: "99999",
        abnormality: "KK",
        notices: "xxxxxxxxx1xxxxxxxxx2",
      },
      {
        order: "3",
        delivery_cd: "xxxxxxxxx1",
        delivery_name: "delivery_name23",
        delivery_slip_no: "xxxxxxxxx1",
        delivery_completion_time: "HH:MM",
        number_of_pieces: "99999",
        volume: "99999",
        abnormality: "KK",
        notices: "xxxxxxxxx1xxxxxxxxx2",
      },
    ],
  },
  {
    parent: {
      ship_date: "20231019",
      shipping_warehouse: "出荷倉庫3",
      shipping_warehouse_cd: "3",
      status: "ステータス3",
      status_cd: "3",
      shipping_course_name: "配送コース3",
      shipping_course_cd: "3",
      number_delivery_destinations: "999",
      delivery_company: "配送会社3",
      delivery_company_cd: "3",
      vehicle_number: "xxxxxxxxx3",
      vehicle_number_cd: "3",
      vehicle_size: "xxxxxxxxx1",
      loading_rate: "999%",
    },
    childrens: [
      {
        order: "1",
        delivery_cd: "xxxxxxxxx1",
        delivery_name: "delivery_name31",
        delivery_slip_no: "xxxxxxxxx1",
        delivery_completion_time: "HH:MM",
        number_of_pieces: "99999",
        volume: "99999",
        abnormality: "KK",
        notices: "xxxxxxxxx1xxxxxxxxx2",
      },
      {
        order: "2",
        delivery_cd: "xxxxxxxxx1",
        delivery_name: "delivery_name32",
        delivery_slip_no: "xxxxxxxxx1",
        delivery_completion_time: "HH:MM",
        number_of_pieces: "99999",
        volume: "99999",
        abnormality: "KK",
        notices: "xxxxxxxxx1xxxxxxxxx2",
      },
      {
        order: "3",
        delivery_cd: "xxxxxxxxx1",
        delivery_name: "delivery_name33",
        delivery_slip_no: "xxxxxxxxx1",
        delivery_completion_time: "HH:MM",
        number_of_pieces: "99999",
        volume: "99999",
        abnormality: "KK",
        notices: "xxxxxxxxx1xxxxxxxxx2",
      },
    ],
  },
];
export default {
  data() {
    return {
      shipDate: null,
      shippingWarehouse: null,
      deliveryCompany: null,
      shippingCourse: null,
      vehicleNumber: null,
      deliveryName: null,
      status: null,
      isCollapsed: false,
      searchResults: [],
      data: dataMockup,
    };
  },
  mounted() {
    this.search();
  },
  methods: {
    handleHiddenCondition() {
      this.isCollapsed = !this.isCollapsed;
      this.$emit("toggleCondition");
    },
    async search() {
      this.searchResults = this.data.filter((item) => {
        const shipDate =
          !this.shipDate ||
          item?.parent.ship_date === moment(this.shipDate).format("YYYYMMDD");

        const shipping_warehouse =
          !this.shippingWarehouse ||
          item?.parent.shipping_warehouse_cd == this.shippingWarehouse;

        const deliverycompany =
          !this.deliveryCompany ||
          item?.parent.delivery_company_cd == this.deliveryCompany;

        // const status = !this.status || item?.parent.status_id == this.status;

        const shipCourse =
          !this.shippingCourse ||
          item?.parent.shipping_course_cd == this.shippingCourse;

        const vehicleNumber =
          !this.vehicleNumber ||
          item?.parent.vehicle_number_cd == this.vehicleNumber;

        const deliveryName =
          !this.deliveryName ||
          item.childrens.some((child) =>
            child.delivery_name.includes(this.deliveryName)
          );

        const status = !this.status || item?.parent.status_cd == this.status;

        return (
          shipDate &&
          shipping_warehouse &&
          deliverycompany &&
          shipCourse &&
          vehicleNumber &&
          deliveryName &&
          status
        );
      });
      this.$emit("search", this.searchResults);
    },
    clear() {
      this.shipOrDeliveryDate = null;
      this.customer = null;
      this.shipCourse = null;
      this.status = null;
      this.vehicleNumber = null;
      this.deliveryDestinationName = null;
      this.search();
    },
  },
};
</script>

<style lang="scss">
.condition {
  &__icon {
    background-color: #5b9bd5;
  }
}

.search__group {
  &--customer {
    min-height: 34px;
  }

  &--date {
    margin-right: 4.25rem;
  }

  &--vehicleNumber {
    width: 81%;
  }

  &--deliveryName {
    width: 92%;
  }
}

.mg-0 {
  margin: 0 !important;
}
.padding-0 {
  padding: 0;
}
</style>
