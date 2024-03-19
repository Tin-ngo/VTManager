<template>
  <div class="container-fluid pt-2">
    <div class="col-lg-12">
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
            </div>
            <div
              class="tab-pane fade"
              id="custom-tabs-four-profile"
              role="tabpanel"
              aria-labelledby="custom-tabs-four-profile-tab"
            >
              Mauris tincidunt mi at erat gravida, eget tristique urna bibendum.
              Mauris pharetra purus ut ligula tempor, et vulputate metus
              facilisis. Lorem ipsum dolor sit amet, consectetur adipiscing
              elit. Vestibulum ante ipsum primis in faucibus orci luctus et
              ultrices posuere cubilia Curae; Maecenas sollicitudin, nisi a
              luctus interdum, nisl ligula placerat mi, quis posuere purus
              ligula eu lectus. Donec nunc tellus, elementum sit amet ultricies
              at, posuere nec nunc. Nunc euismod pellentesque diam.
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
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
  data() {
    return {
      shipOrDeliveryDate: null,
      customerCd: null,
      shippingCourse: null,
      vehicleNumber: null,
      statusCd: null,
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
</style>
