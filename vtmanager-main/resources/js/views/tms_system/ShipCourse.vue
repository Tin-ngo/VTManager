<template>
  <section class="content-vehicle main-section">
    <div class="container-fluid pt-2">
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
              <div class="form-group col-lg-2">
                <label class="">{{
                  $t("vehicle-master.label.shipping_company_name")
                }}</label>
                <select class="form-control" v-model="shipCompanyName">
                  <option value=""></option>
                  <option value="1">配送会社名_1</option>
                  <option value="2">配送会社名_2</option>
                  <option value="3">配送会社名_3</option>
                  <option value="4">配送会社名_4</option>
                  <option value="5">配送会社名_5</option>
                </select>
              </div>
              <div class="col d-flex justify-content-end align-items-center">
                <button class="btn btn-default mr-2 btn-clear" @click="clear()">
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
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid">
      <div class="card">
        <div class="card-body">
          <div :class="contentHeight">
            <div class="border-common wrap-scroll-dispatch-title">
              <label>{{ $t("label.search_results") }} </label>
            </div>
            <div class="">
              <div class="table table-bordered w-100">
                <table class="w-100">
                  <thead>
                    <tr
                      class="text-center bg-header wrap-scroll-dispatch-header"
                    >
                      <template v-for="(header, idx) in tableHeader">
                        <td :key="idx" v-if="idx == 0">
                          <input type="checkbox" v-model="selectAll" />
                        </td>
                        <td
                          v-else
                          :key="idx"
                          :style="idx == 1 ? 'width: 35%' : ''"
                        >
                          {{ header }}
                        </td>
                      </template>
                    </tr>
                  </thead>
                  <tbody>
                    <tr
                      v-for="(item, index) in searchResults"
                      :key="index"
                      class="text-center row-hover"
                    >
                      <td>
                        <input type="checkbox" :checked="selectAll" />
                      </td>
                      <td>{{ item?.shipping_company_name }}</td>
                      <td>{{ item?.shipping_course_cd }}</td>
                      <td>{{ item?.shipping_course_name }}</td>
                      <td>{{ item?.vehicle_number }}</td>
                      <td>{{ item?.vehicle_size }}</td>
                      <td class="text-right">{{ item?.number_delivery }}</td>
                      <td role="button">
                        <font-awesome-icon icon="fas fa-pen-to-square" />
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid footer-item">
      <div class="card">
        <div class="card-body">
          <div class="row">
            <div class="col-lg-1">
              <button
                class="btn btn-create text-nowrap"
                @click="transferScreenToDeliveryCourseMaintenance()"
              >
                <font-awesome-icon icon="fas fa-pencil-alt" />
                {{ $t("button.create") }}
              </button>
            </div>
            <div class="col-lg-1">
              <button class="btn btn-delete text-nowrap">
                <font-awesome-icon icon="fas fa-pencil-alt" />
                {{ $t("button.delete") }}
              </button>
            </div>
            <div class="col-lg-10 text-right">
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
import { TmsShipCourse } from "../../constants/router";
const dataMockup = [
  {
    shipping_company_id: 1,
    shipping_company_name: "配送会社名_1",
    shipping_course_cd: "配送コースコード_1",
    shipping_course_name: "配送コース名_1",
    vehicle_number: "車両番号_1",
    vehicle_size: "車両サイズ_1",
    number_delivery: "1",
  },
  {
    shipping_company_id: 2,
    shipping_company_name: "配送会社名_2",
    shipping_course_cd: "配送コースコード_2",
    shipping_course_name: "配送コース名_2",
    vehicle_number: "車両番号_2",
    vehicle_size: "車両サイズ_2",
    number_delivery: "12",
  },
  {
    shipping_company_id: 3,
    shipping_company_name: "配送会社名_3",
    shipping_course_cd: "配送コースコード_3",
    shipping_course_name: "配送コース名_3",
    vehicle_number: "車両番号_3",
    vehicle_size: "車両サイズ_3",
    number_delivery: "123",
  },
  {
    shipping_company_id: 4,
    shipping_company_name: "配送会社名_4",
    shipping_course_cd: "配送コースコード_4",
    shipping_course_name: "配送コース名_4",
    vehicle_number: "車両番号_4",
    vehicle_size: "車両サイズ_4",
    number_delivery: "1234",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    shipping_course_cd: "配送コースコード_5",
    shipping_course_name: "配送コース名_5",
    vehicle_number: "車両番号_5",
    vehicle_size: "車両サイズ_5",
    number_delivery: "12345",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    shipping_course_cd: "配送コースコード_5",
    shipping_course_name: "配送コース名_5",
    vehicle_number: "車両番号_5",
    vehicle_size: "車両サイズ_5",
    number_delivery: "12345",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    shipping_course_cd: "配送コースコード_5",
    shipping_course_name: "配送コース名_5",
    vehicle_number: "車両番号_5",
    vehicle_size: "車両サイズ_5",
    number_delivery: "12345",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    shipping_course_cd: "配送コースコード_5",
    shipping_course_name: "配送コース名_5",
    vehicle_number: "車両番号_5",
    vehicle_size: "車両サイズ_5",
    number_delivery: "12345",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    shipping_course_cd: "配送コースコード_5",
    shipping_course_name: "配送コース名_5",
    vehicle_number: "車両番号_5",
    vehicle_size: "車両サイズ_5",
    number_delivery: "12345",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    shipping_course_cd: "配送コースコード_5",
    shipping_course_name: "配送コース名_5",
    vehicle_number: "車両番号_5",
    vehicle_size: "車両サイズ_5",
    number_delivery: "12345",
  },
];
export default {
  data() {
    return {
      shipCompanyName: null,
      isCollapsed: false,
      searchResults: [],
      data: dataMockup,
      selectAll: false,
      contentHeight: "scroll-max-height",
    };
  },
  async mounted() {
    this.$store.dispatch("auth/setTitle", this.$t("ship-course.label.header"));
    this.search();
  },
  computed: {
    tableHeader() {
      return {
        0: "",
        1: this.$t("ship-course.label.shipping_company_name"),
        2: this.$t("ship-course.label.shipping_course_cd"),
        3: this.$t("ship-course.label.shipping_course_name"),
        4: this.$t("ship-course.label.vehicle_number"),
        5: this.$t("ship-course.label.vehicle_size"),
        6: this.$t("ship-course.label.number_delivery"),
        7: "",
      };
    },
  },
  methods: {
    handleHiddenCondition() {
      this.isCollapsed = !this.isCollapsed;
      this.contentHeight =
        this.contentHeight == "scroll-max-height"
          ? "scroll-min-height"
          : "scroll-max-height";
    },
    clear() {
      this.shipCompanyName = null;
      this.search();
    },
    async search() {
      this.searchResults = this.data.filter((item) => {
        const shipCompanyName =
          !this.shipCompanyName ||
          item?.shipping_company_id == this.shipCompanyName;

        return shipCompanyName;
      });
    },
    goBack() {
      this.$router.push({
        path: "/main",
      });
    },
    transferScreenToDeliveryCourseMaintenance() {
      this.$router.push({ path: "/delivery-course-maintenance" });
    },
  },
};
</script>

<style lang="scss" scoped>
.content-vehicle {
  .bg-condition-icon {
    background-color: #5b9bd5;
  }

  table > thead > tr {
    background-color: #d9d9d9;
    font-weight: 700;
  }

  .table.table-bordered {
    border: none;
  }

  td > input {
    width: 20px;
    height: 20px;
  }

  .row-hover:hover {
    background-color: #fff2cc;
  }

  .scroll-min-height {
    max-height: 500px;
    overflow-y: auto;
  }

  .scroll-max-height {
    max-height: 585px;
    overflow-y: auto;
  }
}
</style>
