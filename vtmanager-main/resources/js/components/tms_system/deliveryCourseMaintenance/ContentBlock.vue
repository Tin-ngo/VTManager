<template>
  <div class="container-fluid">
    <div class="card"></div>
    <div class="card">
      <div class="card-body">
        <div class="form-row">
          <div class="form-group col-lg-2 search__group">
            <label class="mr-1 d-flex align-items-center"
              >{{ $t("delivery-course-maintenance.label.ship_company_name") }}
              <span class="badge badge-danger" style="margin-bottom: 5px"
                >必须</span
              >
            </label>
            <div class="col-lg-10 padding0">
              <select
                class="form-control input-border"
                v-model="ship_company_name"
                :disabled="isUpdate == true ? true : false"
              >
                <option value=""></option>
                <option value="1">配送会社名1</option>
                <option value="2">配送会社名2</option>
                <option value="3">配送会社名3</option>
              </select>
            </div>
          </div>
          <div class="col-lg-10"></div>

          <div class="form-group col-lg-2 search__group">
            <label class="mr-1 d-flex align-items-center"
              >{{ $t("delivery-course-maintenance.label.ship_course_code") }}
              <span class="badge badge-danger" style="margin-bottom: 5px"
                >必须</span
              >
            </label>
            <div class="col-lg-12 padding0">
              <input
                type="text"
                style="width: 96%"
                class="form-control border-custom"
                v-model="shipCourseCode"
                :disabled="isUpdate == true ? true : false"
              />
            </div>
          </div>
          <div class="col-lg-10"></div>

          <div class="form-group col-lg-7 search__group">
            <label class="mr-1 d-flex align-items-center"
              >{{ $t("delivery-course-maintenance.label.ship_course_name") }}
              <span class="badge badge-danger" style="margin-bottom: 5px"
                >必须</span
              >
            </label>
            <div class="col-lg-12 padding0">
              <input
                type="text"
                style="width: 96%"
                class="form-control border-custom"
                v-model="shipCourseName"
              />
            </div>
          </div>
          <div class="col-lg-5"></div>

          <div class="form-group col-lg-2 search__group">
            <label class="mr-1 d-flex align-items-center"
              >{{ $t("delivery-course-maintenance.label.vehicle_number") }}
            </label>
            <div class="col-lg-9 padding0">
              <select class="form-control input-border" v-model="vehicalNumber">
                <option value=""></option>
                <option value="1">車両番号1</option>
                <option value="2">車両番号2</option>
                <option value="3">車両番号3</option>
              </select>
            </div>
          </div>
          <div class="col-lg-10"></div>

          <!-- content table (2 table) -->
          <div
            class="form-group col-lg-12 search__group"
            style="position: relative; margin-top: 14px"
          >
            <div
              class="icon-right"
              style="position: absolute; top: 50%; left: calc(50% - 170px)"
            >
              <img
                src="images/arrow-right.png"
                alt="配送コースメンテナンス arrow right"
              />
            </div>
            <!-- content table 1 -->
            <div class="row">
              <div class="col-lg-6">
                <div class="row">
                  <div class="col-lg-12">
                    <label class="mr-1 d-flex align-items-center"
                      >{{
                        $t(
                          "delivery-course-maintenance.label.title_delivery_destination_list"
                        )
                      }}
                    </label>
                  </div>
                  <div class="form-group col-md-4 search__group">
                    <label class="mr-1 d-flex align-items-center"
                      >{{ $t("delivery-course-maintenance.label.customer") }}
                    </label>
                    <select
                      class="form-control input-border"
                      style="width: 85%"
                      v-model="customer"
                    >
                      <option value=""></option>
                      <option value="1">得意先1</option>
                      <option value="2">得意先2</option>
                      <option value="3">得意先3</option>
                    </select>
                  </div>
                  <div
                    class="col-lg-5"
                    style="margin-top: 35px; margin-left: 17px"
                  >
                    <button class="btn btn-clear mr-2" @click="clear()">
                      <font-awesome-icon icon="fas fa-rotate-left" />{{
                        $t("button.clear")
                      }}
                    </button>

                    <button class="btn btn-search" @click="search()">
                      <font-awesome-icon icon="fas fa-search" />
                      {{ $t("button.search") }}
                    </button>
                  </div>
                </div>

                <div class="row">
                  <div class="col-lg-12">
                    <div class="table-item form-group" style="height: 240px">
                      <div class="row-table w-100">
                        <template v-for="(header, idx) in tableHeaderLeft">
                          <div
                            class="cell font-weight-bold text-center bg-header"
                            style="
                              display: inline-block;
                              background-color: #ccc;
                              height: var(--height-row-header);
                              line-height: var(--height-row-header);
                            "
                            :key="idx"
                            :style="{ width: header.width }"
                          >
                            {{ header.name }}
                          </div>
                        </template>
                      </div>
                      <template>
                        <ContentItemLeft
                          @idDrag="getIdDrag"
                          v-for="(item, idx) in dataShowLeft"
                          :item="item"
                          :key="idx"
                        />
                      </template>
                    </div>
                  </div>
                </div>
              </div>

              <!-- table right -->
              <div class="col-lg-6" id="table-right">
                <div class="row">
                  <div class="col-lg-12">
                    <label class="mr-1 d-flex align-items-center"
                      >{{
                        $t(
                          "delivery-course-maintenance.label.title_delivery_destination_list"
                        )
                      }}
                    </label>
                  </div>
                  <div class="form-group col-md-8 search__group">
                    <span
                      style="
                        display: inline-block;
                        width: 100%;
                        font-size: 13px;
                        margin: 12px 0;
                        margin-left: 12px;
                      "
                    >
                      配送先一覧よりドラッグ＆ドロップでコースに追加してください
                      <br />
                      ドラッグ＆ドロップで配送順を並び替えることができます
                    </span>
                  </div>
                </div>

                <div class="row">
                  <div class="col-lg-12">
                    <div class="table-item form-group" style="height: 240px">
                      <div class="row-table w-100">
                        <template v-for="(header, idx) in tableHeaderRight">
                          <div
                            class="cell text-center bg-header li"
                            style="
                              display: inline-block;
                              background-color: #ccc;
                              height: var(--height-row-header);
                              line-height: var(--height-row-header);
                            "
                            :key="idx"
                            :style="{ width: header.width }"
                          >
                            {{ header.name }}
                          </div>
                        </template>
                      </div>
                      <template>
                        <ContentItemRight
                          @idDrag="removeIdDrag"
                          v-for="(item, idx) in dataShowRight"
                          :item="item"
                          :key="idx"
                        />
                      </template>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- bottom -->
    <div class="card">
      <div class="card-body">
        <div class="row">
          <div class="col-lg-1 p-0">
            <button class="btn btn-register">
              <font-awesome-icon icon="fas fa-pencil-alt" /> 登錄
            </button>
          </div>
          <div class="col-lg-11 text-right p-0">
            <button class="btn btn-back" @click="goBack()">
              <font-awesome-icon icon="fas fa-arrow-left" />
              {{ $t("button.back") }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ContentItemLeft from "./ContentItemLeft.vue";
import ContentItemRight from "./ContentItemRight.vue";
import moment from "moment";
const dataMockup = [
  {
    id: 1,
    delivery_order: "",
    ship_name: "xxxxxxxx10xxxxxxxx2",
    ship_address: "xxxxxxxx10xxxxxxxx20xxxxxxxx3",
    ship_company_name: "配送会社名1",
    ship_company_id: "1",
    shipCourseCode: "配送コースコード1",
    shipCourseName: "配送コース名1",
    vehicalNumber_name: "車両番号1",
    vehicalNumber_id: "1",
    customer_name: "得意先1",
    customer_id: "1",
  },
  {
    id: 2,
    delivery_order: "",
    ship_name: "xxxxxxxx10xxxxxxxx2",
    ship_address: "xxxxxxxx10xxxxxxxx20xxxxxxxx3",
    ship_company_name: "配送会社名2",
    ship_company_id: "2",
    shipCourseCode: "配送コースコード2",
    shipCourseName: "配送コース名2",
    vehicalNumber_name: "車両番号2",
    vehicalNumber_id: "2",
    customer_name: "得意先2",
    customer_id: "2",
  },
  {
    id: 3,
    delivery_order: "",
    ship_name: "xxxxxxxx10xxxxxxxx2",
    ship_address: "xxxxxxxx10xxxxxxxx20xxxxxxxx3",
    ship_company_name: "配送会社名3",
    ship_company_id: "3",
    shipCourseCode: "配送コースコード3",
    shipCourseName: "配送コース名3",
    vehicalNumber_name: "車両番号3",
    vehicalNumber_id: "3",
    customer_name: "得意先3",
    customer_id: "3",
  },
  {
    id: 4,
    delivery_order: "",
    ship_name: "xxxxxxxx10xxxxxxxx2",
    ship_address: "xxxxxxxx10xxxxxxxx20xxxxxxxx3",
    ship_company_name: "配送会社名4",
    ship_company_id: "4",
    shipCourseCode: "配送コースコード4",
    shipCourseName: "配送コース名4",
    vehicalNumber_name: "車両番号4",
    vehicalNumber_id: "4",
    customer_name: "得意先4",
    customer_id: "4",
  },
  {
    id: 5,
    delivery_order: "",
    ship_name: "xxxxxxxx10xxxxxxxx2",
    ship_address: "xxxxxxxx10xxxxxxxx20xxxxxxxx3",
    ship_company_name: "配送会社名5",
    ship_company_id: "5",
    shipCourseCode: "配送コースコード5",
    shipCourseName: "配送コース名5",
    vehicalNumber_name: "車両番号5",
    vehicalNumber_id: "5",
    customer_name: "得意先5",
    customer_id: "5",
  },
  {
    id: 6,
    delivery_order: "",
    ship_name: "xxxxxxxx10xxxxxxxx2",
    ship_address: "xxxxxxxx10xxxxxxxx20xxxxxxxx3",
    ship_company_name: "配送会社名6",
    ship_company_id: "6",
    shipCourseCode: "配送コースコード6",
    shipCourseName: "配送コース名6",
    vehicalNumber_name: "車両番号6",
    vehicalNumber_id: "6",
    customer_name: "得意先6",
    customer_id: "6",
  },
];

export default {
  components: {
    ContentItemLeft,
    ContentItemRight,
  },
  data() {
    return {
      listData: dataMockup,
      dataShowLeft: dataMockup,
      dataShowRight: null,
      searchResults: dataMockup,

      ship_company_name: null,
      shipCourseCode: null,
      shipCourseName: null,
      vehicalNumber: null,
      customer: null,
    };
  },
  async created() {
    this.setDataList();
  },
  mounted() {},
  props: {
    isUpdate: {
      type: Boolean,
    },
  },
  computed: {
    tableHeaderLeft() {
      return {
        0: {
          width: "25%",
          name: this.$t(
            "delivery-course-maintenance.label.table_header.ship_name"
          ),
        },
        1: {
          width: "48%",
          name: this.$t(
            "delivery-course-maintenance.label.table_header.ship_address"
          ),
        },
      };
    },
    tableHeaderRight() {
      return {
        0: {
          width: "15%",
          name: this.$t(
            "delivery-course-maintenance.label.table_header.delivery_order"
          ),
        },
        1: {
          width: "25%",
          name: this.$t(
            "delivery-course-maintenance.label.table_header.ship_name"
          ),
        },
        2: {
          width: "48%",
          name: this.$t(
            "delivery-course-maintenance.label.table_header.ship_address"
          ),
        },
      };
    },
  },
  methods: {
    moment,
    setDataList() {
      this.dataShowLeft = this.searchResults.filter(
        (item) => item.delivery_order == ""
      );
      this.dataShowRight = this.searchResults.filter(
        (item) => item.delivery_order != ""
      );
      let newDelivery_order = 1;
      this.dataShowRight.forEach((item) => {
        item.delivery_order = newDelivery_order;
        newDelivery_order++; // Tăng giá trị mớiId sau khi cập nhật
      });
      this.dataShowRight.sort((a, b) => a.delivery_order - b.delivery_order);
    },
    goBack() {
      this.$router.push({ path: "/main" });
    },
    async search() {
      this.searchResults = this.listData.filter((item) => {
        const customer = !this.customer || item?.customer_id == this.customer;

        const ship_company_name =
          !this.ship_company_name ||
          item?.ship_company_id == this.ship_company_name;

        const shipCourseCode =
          !this.shipCourseCode ||
          item?.shipCourseCode
            .toLowerCase()
            .indexOf(this.shipCourseCode?.toLowerCase()) !== -1;

        const shipCourseName =
          !this.shipCourseName ||
          item?.shipCourseName
            .toLowerCase()
            .indexOf(this.shipCourseName?.toLowerCase()) !== -1;

        const vehicalNumber =
          !this.vehicalNumber || item?.vehicalNumber_id == this.vehicalNumber;

        return (
          customer &
          ship_company_name &
          shipCourseCode &
          shipCourseName &
          vehicalNumber
        );
      });
      this.dataShowLeft = this.searchResults;
      this.setDataList();
    },

    getIdDrag(data) {
      if (data) {
        this.searchResults.forEach((item) => {
          if (item.id == data) {
            item.delivery_order = this.getMaxDelivery_order();
          }
        });
        this.setDataList();
        this.getMaxDelivery_order();
      }
    },

    removeIdDrag(data) {
      if (data) {
        const itemToUpdate = this.searchResults.find((item) => item.id == data);

        if (itemToUpdate) {
          itemToUpdate.delivery_order = "";
        }
        this.setDataList();
        this.getMaxDelivery_order();
      }
    },

    getMaxDelivery_order() {
      return (
        parseInt(
          Math.max(...this.searchResults.map((item) => item.delivery_order))
        ) + 1
      );
    },

    clear() {
      this.ship_company_name = null;
      this.shipCourseCode = null;
      this.shipCourseName = null;
      this.vehicalNumber = null;
      this.customer = null;
      this.search();
    },
  },
};
</script>

<style scoped lang="scss">
.content {
  .border-common {
    border-bottom: 0;
  }

  .row-table {
    display: flex;
    border-bottom: 1px solid #ccc;
    border-right: 0;
  }

  .cell {
    border-right: 1px solid #ccc;
    display: flex;
    background-color: #d9d9d9;
    justify-content: center;
    align-items: center;
  }
}

.content-item {
  .cell {
    background-color: #fff;
    border-right: 1px solid #ccc;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .cell:first-child {
    border-left: 1px solid #ccc;
  }
}

.btn-shipping-list {
  border: 1px solid #ddd;
  display: inline-block;
  font-weight: 400;
  color: white;
  text-align: center;
  vertical-align: middle;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
  background-color: #f89039;
  padding: 0.25rem 0.75rem;
  font-size: 1rem;
  line-height: 1.5;
  border-radius: 0.25rem;
  transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out,
    border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}

.btn-shipping-list:hover {
  color: white;
  background-color: #f5a462;
}

.mg-top {
  margin-top: 100px !important;
}

.padding0 {
  padding-left: 0;
  padding-right: 0;
}

.btn-register {
  margin-left: 10px;
}
</style>
