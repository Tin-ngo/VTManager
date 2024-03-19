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

              <div class="form-group col-lg-1">
                <label class="">{{
                  $t("vehicle-master.label.vehicle_number")
                }}</label>
                <input
                  type="text"
                  class="form-control border-custom"
                  v-model="vehicleNumber"
                />
              </div>

              <div class="form-group col-lg-1">
                <label class="">{{
                  $t("vehicle-master.label.vehicle_size")
                }}</label>
                <select class="form-control" v-model="vehicleSize">
                  <option value=""></option>
                  <option value="1">車両サイズ_1</option>
                  <option value="2">車両サイズ_2</option>
                  <option value="3">車両サイズ_3</option>
                  <option value="4">車両サイズ_4</option>
                  <option value="5">車両サイズ_5</option>
                </select>
              </div>

              <div class="form-group col-lg-1">
                <label class="">{{
                  $t("vehicle-master.label.vehicle_classification")
                }}</label>
                <select class="form-control" v-model="vehicleClassification">
                  <option value=""></option>
                  <option value="1">車両区分_1</option>
                  <option value="2">車両区分_2</option>
                  <option value="3">車両区分_3</option>
                  <option value="4">車両区分_4</option>
                  <option value="5">車両区分_5</option>
                </select>
              </div>

              <div class="col d-flex justify-content-end align-items-center">
                <button class="btn btn-default mr-2 btn-clear" @click="clear()">
                  <font-awesome-icon
                    :icon="['fas', 'share']"
                    flip="horizontal"
                  />
                  {{ $t("button.clear") }}
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
            <div class="row w-100">
              <div class="table table-bordered">
                <table class="w-100">
                  <thead>
                    <tr
                      class="text-center bg-header wrap-scroll-dispatch-header"
                    >
                      <template v-for="(header, idx) in tableHeader">
                        <td :key="idx" v-if="idx == 0">
                          <input
                            type="checkbox"
                            @change="setSelectAll"
                            :checked="selectAll"
                          />
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
                        <input
                          type="checkbox"
                          @change="selectItem(item.shipping_company_id)"
                          :checked="
                            listChecked.includes(item.shipping_company_id)
                          "
                        />
                      </td>
                      <td>{{ item?.shipping_company_name }}</td>
                      <td>{{ item?.vehicle_number }}</td>
                      <td>{{ item?.vehicle_size }}</td>
                      <td>{{ item?.vehicle_classification }}</td>
                      <td>{{ item?.maximum_loading_capacity }}</td>
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
                @click="transferScreenToVehicleMaintenance()"
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
import { TmsVehicleMaster } from "../../constants/router";
import { orderBy } from "lodash";

const dataMockup = [
  {
    shipping_company_id: 1,
    shipping_company_name: "配送会社名_1",
    vehicle_number: "車両番号_1",
    vehicle_size_id: 1,
    vehicle_size: "車両サイズ_1",
    vehicle_classification_id: 1,
    vehicle_classification: "車両区分_1",
    maximum_loading_capacity: "12,345,678 ㎏",
  },
  {
    shipping_company_id: 2,
    shipping_company_name: "配送会社名_2",
    vehicle_number: "車両番号_2",
    vehicle_size_id: 2,
    vehicle_size: "車両サイズ_2",
    vehicle_classification_id: 2,
    vehicle_classification: "車両区分_2",
    maximum_loading_capacity: "12,345,678 ㎏",
  },
  {
    shipping_company_id: 3,
    shipping_company_name: "配送会社名_3",
    vehicle_number: "車両番号_3",
    vehicle_size_id: 3,
    vehicle_size: "車両サイズ_3",
    vehicle_classification_id: 3,
    vehicle_classification: "車両区分_3",
    maximum_loading_capacity: "12,345,678 ㎏",
  },
  {
    shipping_company_id: 4,
    shipping_company_name: "配送会社名_4",
    vehicle_number: "車両番号_4",
    vehicle_size_id: 4,
    vehicle_size: "車両サイズ_4",
    vehicle_classification_id: 4,
    vehicle_classification: "車両区分_4",
    maximum_loading_capacity: "12,345,678 ㎏",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    vehicle_number: "車両番号_5",
    vehicle_size_id: 5,
    vehicle_size: "車両サイズ_5",
    vehicle_classification_id: 5,
    vehicle_classification: "車両区分_5",
    maximum_loading_capacity: "12,345,678 ㎏",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    vehicle_number: "車両番号_5",
    vehicle_size_id: 5,
    vehicle_size: "車両サイズ_5",
    vehicle_classification_id: 5,
    vehicle_classification: "車両区分_5",
    maximum_loading_capacity: "12,345,678 ㎏",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    vehicle_number: "車両番号_5",
    vehicle_size_id: 5,
    vehicle_size: "車両サイズ_5",
    vehicle_classification_id: 5,
    vehicle_classification: "車両区分_5",
    maximum_loading_capacity: "12,345,678 ㎏",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    vehicle_number: "車両番号_5",
    vehicle_size_id: 5,
    vehicle_size: "車両サイズ_5",
    vehicle_classification_id: 5,
    vehicle_classification: "車両区分_5",
    maximum_loading_capacity: "12,345,678 ㎏",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    vehicle_number: "車両番号_5",
    vehicle_size_id: 5,
    vehicle_size: "車両サイズ_5",
    vehicle_classification_id: 5,
    vehicle_classification: "車両区分_5",
    maximum_loading_capacity: "12,345,678 ㎏",
  },
  {
    shipping_company_id: 5,
    shipping_company_name: "配送会社名_5",
    vehicle_number: "車両番号_5",
    vehicle_size_id: 5,
    vehicle_size: "車両サイズ_5",
    vehicle_classification_id: 5,
    vehicle_classification: "車両区分_5",
    maximum_loading_capacity: "12,345,678 ㎏",
  },
];
export default {
  data() {
    return {
      shipCompanyName: null,
      vehicleNumber: null,
      vehicleSize: null,
      vehicleClassification: null,
      isCollapsed: false,
      searchResults: [],
      data: dataMockup,
      listChecked: [],
      contentHeight: "scroll-max-height",
    };
  },
  async mounted() {
    this.$store.dispatch(
      "auth/setTitle",
      this.$t("vehicle-master.label.header")
    );
    this.search();
  },
  computed: {
    tableHeader() {
      return {
        0: "",
        1: this.$t("vehicle-master.label.shipping_company_name"),
        2: this.$t("vehicle-master.label.vehicle_number"),
        3: this.$t("vehicle-master.label.vehicle_size"),
        4: this.$t("vehicle-master.label.vehicle_classification"),
        5: this.$t("vehicle-master.label.maximum_loading_capacity"),
        6: "",
      };
    },
    selectAll() {
      return (
        JSON.stringify(orderBy(this.listChecked, [])) ===
        JSON.stringify(
          orderBy(
            this.searchResults.map((item) => item.shipping_company_id),
            []
          )
        )
      );
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
      this.vehicleNumber = null;
      this.vehicleSize = null;
      this.vehicleClassification = null;
      this.search();
    },
    async search() {
      this.searchResults = this.data.filter((item) => {
        const shipCompanyName =
          !this.shipCompanyName ||
          item?.shipping_company_id == this.shipCompanyName;

        const vehicleNumber =
          !this.vehicleNumber ||
          item?.vehicle_number.includes(this.vehicleNumber);

        const vehicleSize =
          !this.vehicleSize || item?.vehicle_size_id == this.vehicleSize;

        const vehicleClassification =
          !this.vehicleClassification ||
          item?.vehicle_classification_id == this.vehicleClassification;
        return (
          shipCompanyName &&
          vehicleNumber &&
          vehicleSize &&
          vehicleClassification
        );
      });
    },
    goBack() {
      this.$router.push({
        path: "/main",
      });
    },

    transferScreenToVehicleMaintenance() {
      this.$router.push({ path: "/vehicle-maintenance" });
    },
    selectItem(id) {
      if (this.listChecked.includes(id)) {
        this.listChecked = this.listChecked.filter((item) => item !== id);
      } else {
        this.listChecked.push(id);
      }
    },
    setSelectAll(event) {
      this.listChecked = event.target.checked
        ? this.searchResults.map((item) => item.shipping_company_id)
        : [];
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
    max-height: 580px;
    overflow-y: auto;
  }
}
</style>
