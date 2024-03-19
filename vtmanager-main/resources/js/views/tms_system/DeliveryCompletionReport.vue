<template>
  <section class="header">
    <div class="container-fluid pt-2">
      <div class="card card-primary card-outline card-outline-tabs">
        <div class="card-header p-0 border-bottom-0">
          <ul class="nav nav-tabs" id="custom-tabs-four-tab" role="tablist">
            <li class="nav-item">
              <a
                class="nav-link active"
                id="custom-tabs-four-home-tab"
                data-toggle="pill"
                href="#custom-tabs-four-home"
                role="tab"
                aria-controls="custom-tabs-four-home"
                aria-selected="true"
                ><div
                  class="d-flex justify-content-center align-items-center rounded-circle border border-dark"
                  style="
                    width: 25px;
                    height: 25px;
                    background-color: #white;
                    color: #000;
                    font-weight: bold;
                  "
                >
                  1
                </div>
              </a>
            </li>
            <li class="nav-item">
              <a
                class="nav-link"
                id="custom-tabs-four-profile-tab"
                data-toggle="pill"
                href="#custom-tabs-four-profile"
                role="tab"
                aria-controls="custom-tabs-four-profile"
                aria-selected="false"
                ><div
                  class="d-flex justify-content-center align-items-center rounded-circle border border-dark"
                  style="
                    width: 25px;
                    height: 25px;
                    background-color: #white;
                    color: #000;
                    font-weight: bold;
                  "
                >
                  2
                </div></a
              >
            </li>
          </ul>
        </div>
        <div class="card-body">
          <div class="tab-content" id="custom-tabs-four-tabContent">
            <div
              class="tab-pane fade active show"
              id="custom-tabs-four-home"
              role="tabpanel"
              aria-labelledby="custom-tabs-four-home-tab"
            >
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
                  <div v-show="isCollapsed">
                    <div class="form-row search">
                      <div class="col-lg-10 row">
                        <div class="form-group col-lg-2">
                          <label>{{
                            $t(
                              "delivery-completion-report.label.form.ship_or_delivery_date"
                            )
                          }}</label>
                          <select
                            class="form-control search__group--customer col-lg-10"
                            v-model="shipOrDeliveryDate"
                          >
                            <option value=""></option>
                            <option value="1">出荷日/配送日_1</option>
                            <option value="2">出荷日/配送日_2</option>
                          </select>
                        </div>
                        <div class="form-group col-lg-2">
                          <label>{{
                            $t("delivery-completion-report.label.form.customer")
                          }}</label>
                          <select
                            class="form-control search__group--customer col-lg-10"
                            v-model="customerCd"
                          >
                            <option value=""></option>
                            <option value="1">得意先_1</option>
                            <option value="2">得意先_2</option>
                          </select>
                        </div>
                        <div class="form-group col-lg-2">
                          <label>{{
                            $t(
                              "delivery-completion-report.label.form.shipping_course"
                            )
                          }}</label>
                          <select
                            class="form-control search__group--customer col-lg-10"
                            v-model="shippingCourse"
                          >
                            <option value=""></option>
                            <option value="1">配送コース_1</option>
                            <option value="2">配送コース_2</option>
                          </select>
                        </div>
                        <div class="form-group col-lg-2">
                          <label>{{
                            $t(
                              "delivery-completion-report.label.form.vehicle_number"
                            )
                          }}</label>
                          <select
                            class="form-control search__group--customer col-lg-10"
                            v-model="vehicleNumber"
                          >
                            <option value=""></option>
                            <option value="1">車両番号_1</option>
                            <option value="2">車両番号_2</option>
                          </select>
                        </div>
                        <div class="form-group col-lg-2">
                          <label>{{
                            $t("delivery-completion-report.label.form.status")
                          }}</label>
                          <select
                            class="form-control search__group--customer col-lg-10"
                            v-model="statusCd"
                          >
                            <option value=""></option>
                            <option value="1">ステータス_1</option>
                            <option value="2">ステータス_2</option>
                          </select>
                        </div>
                      </div>

                      <div
                        class="col d-flex justify-content-end align-items-center"
                      >
                        <button class="btn btn-clear mr-2" @click="clear()">
                          <font-awesome-icon
                            :icon="['fas', 'share']"
                            flip="horizontal"
                          />
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
              </div>
              <div class="content">
                <div class="card">
                  <div class="card-body">
                    <div class="form-row search">
                      <div class="form-group col-lg-2 search__group">
                        <label class="mr-1 d-flex align-items-center"
                          >{{
                            $t(
                              "delivery-completion-report.label.form.delivery_completion_date"
                            )
                          }}
                          <span
                            class="badge badge-danger"
                            style="margin-bottom: 5px"
                            >必须</span
                          >
                        </label>
                        <date-picker
                          format="MM/DD"
                          id="datePicker1"
                          :clearable="false"
                          class="search__group--date"
                        >
                          <template v-slot:icon-calendar>
                            <font-awesome-icon icon="fas fa-calendar-alt" />
                          </template>
                        </date-picker>
                      </div>
                    </div>

                    <div class="table-item form-group">
                      <div class="row-table text-center w-100">
                        <template v-for="(header, idx) in tableHeader">
                          <div
                            class="cell font-weight-bold bg-header"
                            :style="{ width: header.width }"
                            :key="idx"
                          >
                            {{ header.name }}
                          </div>
                        </template>
                      </div>
                      <template>
                        <ContentItem
                          v-for="(item, idx) in searchResults"
                          :key="idx"
                          :item="item"
                        />
                      </template>
                      <div class="d-flex mt-4 form-group">
                        <div class="col-lg-2">
                          <button class="btn btn-register">
                            <font-awesome-icon
                              icon="fas fa-pencil-alt"
                            />&nbsp;{{ $t("button.confirm") }}
                          </button>
                        </div>
                        <div class="col-lg-2">
                          <button class="btn btn-clear">
                            <font-awesome-icon
                              :icon="['fas', 'share']"
                              flip="horizontal"
                            />&nbsp;{{ $t("button.reset") }}
                          </button>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div
              class="tab-pane fade"
              id="custom-tabs-four-profile"
              role="tabpanel"
              aria-labelledby="custom-tabs-four-profile-tab"
            >
              <div class="card">
                <div class="card-body">
                  <div class="row">
                    <div class="col-lg-2">
                      <div class="form-group">
                        <!-- 配送完了日 -->
                        <label for="input1">{{
                          $t(
                            "delivery-completion-report.label.form.delivery_completion_date"
                          )
                        }}</label>
                        <date-picker
                          format="YYYY/MM/DD"
                          id="datePicker1"
                          :clearable="false"
                          v-model="shipDate"
                          class="search__group--date"
                        >
                          <template v-slot:icon-calendar>
                            <font-awesome-icon icon="fas fa-calendar-alt" />
                          </template>
                        </date-picker>
                        <button class="btn btn-default ml-1">
                          {{ this.$t("button.setting") }}
                        </button>
                      </div>
                    </div>
                    <div class="col-lg-2">
                      <div class="form-group">
                        <!-- 配送伝票No -->
                        <label for="input2">
                          {{
                            $t(
                              "delivery-completion-report.label.form.delivery_slip_no"
                            )
                          }}
                        </label>
                        <div class="d-flex align-items-center">
                          <input
                            type="text"
                            class="form-control delivery_slip"
                          />
                          <button class="btn btn-default ml-1 text-nowrap">
                            {{ this.$t("button.search") }}
                          </button>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

              <div class="card content">
                <div class="card-body">
                  <div class="table-item form-group">
                    <div class="row-table text-center w-100">
                      <template v-for="(header, idx) in tableHeaderTab2">
                        <div
                          class="cell font-weight-bold bg-header"
                          :style="{ width: header.width }"
                          :key="idx"
                        >
                          {{ header.name }}
                        </div>
                      </template>
                    </div>
                    <template>
                      <ContentItem
                        v-for="(item, idx) in searchResults"
                        :key="idx"
                        :item="item"
                      />
                    </template>
                    <div class="d-flex mt-4 form-group">
                      <div class="col-lg-2">
                        <button class="btn btn-register">
                          <font-awesome-icon icon="fas fa-pencil-alt" />&nbsp;{{
                            $t("button.confirm")
                          }}
                        </button>
                      </div>
                      <div class="col-lg-2">
                        <button class="btn btn-clear">
                          <font-awesome-icon
                            :icon="['fas', 'share']"
                            flip="horizontal"
                          />&nbsp;{{ $t("button.reset") }}
                        </button>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid">
      <div class="card">
        <div class="card-body">
          <table class="table table-bordered">
            <thead>
              <tr>
                <th
                  v-for="(header, idx) in tableHeader"
                  :key="idx"
                  class="bg-header"
                >
                  {{ header }}
                </th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(item, index) in 1" :key="index">
                <td>{{ item }}</td>
                <td>{{ item }}</td>
                <td>{{ item }}</td>
                <td>{{ item }}</td>
                <td>{{ item }}</td>
                <td>{{ item }}</td>
                <td>{{ item }}</td>
                <td>{{ item }}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
    <div class="container-fluid">
      <div class="card">
        <div class="card-body">
          <div class="row justify-content-end">
            <button class="btn btn-back" @click="goBack()">
              <font-awesome-icon icon="fas fa-arrow-left" />{{
                $t("button.back")
              }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
const dataMockup = [
  {
    parent: {
      shipping_course_id: "1",
      shipping_course_name: "配送コース名_1",
      vehicle_id: 1,
      vehicle_number: "車両番号_1",
      vehicle_size: "車両サイズ_1",
      shipping_date_delivery_date: "20230918",
      customer_id: 1,
      customer: "得意先_1",
      total_number: "1",
      number_delivery_destination: "納入先数_1",
      slip_issue_date: "20230912",
    },
    childrens: [
      {
        subject: "対象_1",
        delivery_destination_cd: "納入先ｺｰﾄﾞ_1",
        delivery_destination_name: "納入先名1",
        delivery_slip_no: "個数_1",
        number_of_pieces: "個数1",
        volume: "容積1",
        abnormality: "異常有無1",
        special_note: "特記1",
      },
      {
        subject: "対象2",
        delivery_destination_cd: "納入先ｺｰﾄﾞ2",
        delivery_destination_name: "納入先名2",
        delivery_slip_no: "個数_12",
        number_of_pieces: "個数2",
        volume: "容積2",
        abnormality: "異常有無2",
        special_note: "特記2",
      },
      {
        subject: "対象3",
        delivery_destination_cd: "納入先ｺｰﾄﾞ3",
        delivery_destination_name: "納入先名3",
        delivery_slip_no: "個数_1",
        number_of_pieces: "個数3",
        volume: "容積3",
        abnormality: "異常有無3",
        special_note: "特記3",
      },
    ],
    childrens2: [
      {
        order: "順番6",
        delivery_cd: "納入先ｺｰﾄﾞ6",
        delivery_name: "納入先名6",
        delivery_slip_no: "配送伝票№6",
        delivery_completion_date: "20230705",
        delivery_completion_time: "0644",
        number_of_pieces: "個数6",
        volume: "容積6",
        abnormality: "異常有無6",
        notices: "特記事項6",
      },
      {
        order: "順番8",
        delivery_cd: "納入先ｺｰﾄﾞ8",
        delivery_name: "納入先名8",
        delivery_slip_no: "配送伝票№8",
        delivery_completion_date: "20230415",
        delivery_completion_time: "0622",
        number_of_pieces: "個数8",
        volume: "容積8",
        abnormality: "異常有無8",
        notices: "特記事項8",
      },
    ],
  },
  {
    parent: {
      shipping_course_id: 2,
      shipping_course_name: "配送コース名_2",
      vehicle_id: 2,
      vehicle_number: "車両番号_2",
      vehicle_size: "車両サイズ_2",
      shipping_date_delivery_date: "20230918",
      customer_id: 2,
      customer: "得意先_2",
      total_number: "2",
      number_delivery_destination: "納入先数_2",
      slip_issue_date: "20230912",
    },
    childrens: [
      {
        subject: "対象4",
        delivery_destination_cd: "納入先ｺｰﾄﾞ4",
        delivery_destination_name: "納入先名4",
        delivery_slip_no: "個数_1",
        number_of_pieces: "個数4",
        volume: "容積4",
        abnormality: "異常有無4",
        special_note: "特記4",
      },
      {
        subject: "対象5",
        delivery_destination_cd: "納入先ｺｰﾄﾞ5",
        delivery_destination_name: "納入先名5",
        delivery_slip_no: "個数_1",
        number_of_pieces: "個数5",
        volume: "容積5",
        abnormality: "異常有無5",
        special_note: "特記5",
      },
      {
        subject: "対象6",
        delivery_destination_cd: "納入先ｺｰﾄﾞ6",
        delivery_destination_name: "納入先名6",
        delivery_slip_no: "個数_1",
        number_of_pieces: "個数6",
        volume: "容積6",
        abnormality: "異常有無6",
        special_note: "特記6",
      },
    ],
    childrens2: [
      {
        order: "順番2",
        delivery_cd: "納入先ｺｰﾄﾞ2",
        delivery_name: "納入先名2",
        delivery_slip_no: "配送伝票№2",
        delivery_completion_date: "20230705",
        delivery_completion_time: "0644",
        number_of_pieces: "個数2",
        volume: "容積2",
        abnormality: "異常有無2",
        notices: "特記事項2",
      },
      {
        order: "順番3",
        delivery_cd: "納入先ｺｰﾄﾞ3",
        delivery_name: "納入先名3",
        delivery_slip_no: "配送伝票№3",
        delivery_completion_date: "20230415",
        delivery_completion_time: "0622",
        number_of_pieces: "個数3",
        volume: "容積3",
        abnormality: "異常有無3",
        notices: "特記事項3",
      },
    ],
  },
];
export default {
  components: {},
  data() {
    return {
      results: [],
      shipOrDeliveryDate: null,
      customerCd: null,
      shippingCourse: null,
      vehicleNumber: null,
      shipDate: null,
      statusCd: null,
      isCollapsed: false,
      searchResults: [],
      data: dataMockup,
    };
  },
  mounted() {
    this.$store.dispatch(
      "auth/setTitle",
      this.$t("delivery-completion-report.label.title")
    );
  },
  computed: {
    tableHeader() {
      return {
        0: this.$t(
          "delivery-completion-report.label.table.headers.delivery_course_name"
        ),
        1: this.$t(
          "delivery-completion-report.label.table.headers.vehicle_number"
        ),
        2: this.$t(
          "delivery-completion-report.label.table.headers.vehicle_size"
        ),
        3: this.$t(
          "delivery-completion-report.label.table.headers.ship_or_delivery_date"
        ),
        4: this.$t("delivery-completion-report.label.table.headers.customer"),
        5: this.$t(
          "delivery-completion-report.label.table.headers.total_number"
        ),
        6: this.$t(
          "delivery-completion-report.label.table.headers.number_delivery_destination"
        ),
        7: this.$t(
          "delivery-completion-report.label.table.headers.slip_issue_date"
        ),
      };
    },
    tableHeaderTab2() {
      return {
        0: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.header_tab_2.ship_course_name"
          ),
        },
        1: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.header_tab_2.vehicle_name"
          ),
        },
        2: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.header_tab_2.vehicle_size"
          ),
        },
        3: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.header_tab_2.ship_date"
          ),
        },
        4: {
          width: "25%",
          name: this.$t(
            "delivery-completion-report.label.table.header_tab_2.ship_warehouse"
          ),
        },
        5: {
          width: "5%",
          name: this.$t(
            "delivery-completion-report.label.table.header_tab_2.total_number"
          ),
        },
        6: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.header_tab_2.number_delivery_destination"
          ),
        },
        7: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.header_tab_2.slip_issue_date"
          ),
        },
      };
    },
  },
  methods: {
    handleHiddenCondition() {
      this.isCollapsed = !this.isCollapsed;
    },
    clear() {
      this.shipOrDeliveryDate = null;
      this.customerCd = null;
      this.shippingCourse = null;
      this.vehicleNumber = null;
      this.statusCd = null;
      this.search();
    },
    async search() {
      this.searchResults = this.data.filter((item) => {
        const customer =
          !this.customerCd || item?.parent.customer_id == this.customerCd;

        const shippingCourse =
          !this.shippingCourse ||
          item?.parent.shipping_course_id == this.shippingCourse;

        const status = !this.statusCd || item?.parent.status == this.statusCd;

        const vehicleNumber =
          !this.vehicleNumber || item?.parent.vehicle_id == this.vehicleNumber;

        return shippingCourse && customer && status && vehicleNumber;
      });
      this.$emit("search", this.searchResults);
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
    height: 34px;
  }
}

.content {
  .border-common {
    border-bottom: 0;
  }

  .row-table {
    display: flex;
    border-bottom: 1px solid #ccc;
    border: 1px solid #d9d9d9;
    border-right: 0;
  }

  .cell {
    border-right: 1px solid #ccc;
    display: flex;
    background-color: #d9d9d9;
    justify-content: center;
    align-items: center;
  }

  .table-item {
    width: 70%;
  }

  .content-item {
    .cell {
      background-color: white;
    }
  }
}

.mx-datepicker {
  width: 180px;
}

button {
  height: 34px;
}

.delivery_slip {
  height: 35px;
}
</style>
