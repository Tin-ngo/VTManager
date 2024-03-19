<template>
  <section class="main-section">
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
            <div class="col-lg-lg-9 font-weight-bold">
              {{ $t("label.search_conditions") }}
            </div>
          </div>
          <div v-show="isCollapsed">
            <div class="row">
              <div class="col-lg-1">
                <div class="form-group">
                  <!-- 出荷日 -->
                  <label for="input1">{{
                    $t("dispatch-setting.label.form.ship_date")
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
                </div>
              </div>
              <div class="col-lg-1">
                <div class="form-group">
                  <!-- 配送会社 -->
                  <label for="input2">{{
                    $t("dispatch-setting.label.form.customer")
                  }}</label>
                  <select
                    class="form-control search__group--customer"
                    v-model="customerCd"
                  >
                    <option value=""></option>
                    <option value="得意先_1">得意先_1</option>
                    <option value="得意先_2">得意先_2</option>
                  </select>
                </div>
              </div>
              <div class="col-lg-1">
                <div class="form-group">
                  <!-- 積載率 -->
                  <label for="input3">{{
                    $t("dispatch-setting.label.form.loading_rate")
                  }}</label>
                  <div class="row align-items-baseline">
                    <input
                      type="text"
                      class="form-control search__group--loading_rate col-lg-7"
                      v-model="loadingRate"
                    />
                    <label class="ml-2 form-check-label"
                      >%{{ $t("dispatch-setting.label.form.below") }}</label
                    >
                  </div>
                </div>
              </div>
              <div class="col-lg-1">
                <div class="form-group">
                  <!-- ステータス -->
                  <label for="input4">{{
                    $t("dispatch-setting.label.form.status")
                  }}</label>
                  <select
                    class="form-control search__group--status"
                    v-model="statusCd"
                  >
                    <option value=""></option>
                    <option value="得意先_1">得意先_1</option>
                    <option value="得意先_2">得意先_2</option>
                  </select>
                </div>
              </div>
              <div class="col-lg-1">
                <div class="form-group">
                  <!-- ソート -->
                  <label for="input5">{{
                    $t("dispatch-setting.label.form.sort")
                  }}</label>
                  <select
                    class="form-control search__group--sort"
                    v-model="sort"
                  >
                    <option value=""></option>
                    <option value="得意先_1">得意先_1</option>
                    <option value="得意先_2">得意先_2</option>
                  </select>
                </div>
              </div>
              <div
                class="col-lg-7 d-flex justify-content-end align-items-center mt-2"
              >
                <button class="btn btn-clear mr-2" @click="clear()">
                  <font-awesome-icon
                    :icon="['fas', 'share']"
                    flip="horizontal"
                  />&nbsp;{{ $t("button.clear") }}
                </button>
                <button class="btn btn-search" @click="search()">
                  <font-awesome-icon :icon="['fas', 'search']" />
                  &nbsp;{{ $t("button.search") }}
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <section class="content">
      <div class="container-fluid">
        <div class="card">
          <div class="card-body">
            <div class="row">
              <div class="w-100" :class="contentHeight">
                <div class="border-common pl-2 wrap-scroll-dispatch-title">
                  <label>{{ $t("label.search_results") }} </label>
                </div>
                <div
                  class="row-table text-center w-100 item-scroll wrap-scroll-dispatch-header"
                >
                  <template v-for="(header, idx) in tableHeader">
                    <div
                      class="cell font-weight-bold bg-header"
                      :key="idx"
                      v-if="idx == 1"
                      :style="{ width: header.width }"
                    >
                      {{ header.name }}
                    </div>
                    <div
                      v-else
                      :key="`${idx}b`"
                      class="cell font-weight-bold bg-header"
                      :style="{ width: header.width }"
                    >
                      {{ header.name }}
                    </div>
                  </template>
                </div>
                <template :options="{ animation: 150 }">
                  <draggable v-model="parentRendering" @end="changeDraggable">
                    <ContentItem
                      v-for="(item, idx) in parentRendering"
                      :key="idx"
                      :item="item"
                      :isChecked="selectedItemId.includes(item?.parent.id)"
                      @changeSelectAll="changeSelectAll"
                    />
                  </draggable>
                </template>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="container-fluid footer-item">
        <div class="card">
          <div class="row card-body">
            <button class="btn btn-register mr-3">
              <font-awesome-icon :icon="['fas', 'pencil-alt']" />
              {{ $t("button.register") }}
            </button>
            <button class="btn btn-delivery mr-3">
              <font-awesome-icon :icon="['fas', 'file']" />
              &nbsp;{{ $t("button.delivery_vehicle") }}
            </button>
            <button class="btn btn-delivery">
              <font-awesome-icon :icon="['fas', 'file']" />
              &nbsp;{{ $t("button.delivery_slip") }}
            </button>
            <button class="btn btn-back ml-auto" @click="goBack()">
              <font-awesome-icon :icon="['fas', 'arrow-left']" />
              {{ $t("button.back") }}
            </button>
          </div>
        </div>
      </div>
    </section>
  </section>
</template>

<script>
import moment from "moment";
import ContentItem from "@/components/tms_system/dispatchSetting/ContentItem.vue";
import dataMockup from "@/mocks/mockDispatchSetting.json";
import draggable from "vuedraggable";
import { orderBy, sortBy } from "lodash";
export default {
  components: {
    ContentItem,
    draggable,
  },
  data() {
    return {
      results: [],
      shipDate: null,
      customerCd: null,
      loadingRate: null,
      statusCd: null,
      sort: null,
      isCollapsed: false,
      isShowDetail: false,
      selectedItemId: [],
      parentRendering: [],
      draggingIndex: -1,
      contentHeight: "scroll-max-height",
      searchResults: [],
      data: dataMockup,
    };
  },
  mounted() {
    this.$store.dispatch(
      "auth/setTitle",
      this.$t("dispatch-setting.label.title")
    );
    console.log({ data: this.searchResults });
  },
  watch: {
    searchResults() {
      this.parentRendering = this.searchResults;
      console.log({ data: this.parentRendering });
      const order = this.$store.state.orderDraggable.dispatchSettingOrder;
      const orderItem = order?.["parent"];
      if (orderItem) {
        this.parentRendering = sortBy(this.searchResults, function (item) {
          return orderItem.indexOf(item?.parent?.id);
        });
      }
    },
  },
  computed: {
    tableHeader() {
      return {
        0: {
          width: "2%",
          name: " ",
        },
        1: {
          width: "14%",
          name: " ",
        },
        2: {
          width: "2%",
          name: " ",
        },
        3: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.ship_date"),
        },
        4: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.delivery_date"),
        },
        5: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.status"),
        },
        6: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.shipping_course"),
        },
        7: {
          width: "5%",
          name: this.$t(
            "dispatch-setting.label.table.headers.delivery_company"
          ),
        },
        8: {
          width: "9%",
          name: this.$t("dispatch-setting.label.table.headers.vehicle_number"),
        },
        9: {
          width: "9%",
          name: this.$t("dispatch-setting.label.table.headers.vehicle_size"),
        },
        10: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.loading_rate"),
        },
        11: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.total_volume"),
        },
        12: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.gross_weight"),
        },
        13: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.total_number"),
        },
        14: {
          width: "5%",
          name: this.$t(
            "dispatch-setting.label.table.headers.number_delivery_destination"
          ),
        },
        15: {
          width: "9%",
          name: this.$t("dispatch-setting.label.table.headers.child_or_dry"),
        },
        16: {
          width: "5%",
          name: "",
        },
      };
    },
    isCheckedContent() {
      return (
        JSON.stringify(orderBy(this.selectedItemId, [])) ===
        JSON.stringify(
          orderBy(
            this.setListResult?.map((item) => item?.parent?.id),
            []
          )
        )
      );
    },
  },
  methods: {
    handleHiddenCondition() {
      this.isCollapsed = !this.isCollapsed;
    },
    clear() {
      this.shipDate = null;
      this.customer = null;
      this.loadingRate = null;
      this.statusCd = null;
      this.sort = null;
      this.search();
    },
    async search() {
      this.searchResults = this.data.filter((item) => {
        const shipDate =
          !this.shipDate ||
          item?.parent.ship_date === moment(this.shipDate).format("YYYYMMDD");

        const customer =
          !this.customer ||
          item.childrens.some((child) =>
            child.customer_name.includes(this.customer)
          );
        return shipDate && customer;
      });
    },
    changeSelectAll(status, id) {
      this.selectedItemId =
        status && !this.selectedItemId.includes(id)
          ? [...this.selectedItemId, id]
          : this.selectedItemId.filter((item) => item !== id);
    },
    changeAll(e) {
      this.selectedItemId = e.target.checked
        ? this.setListResult.map((item) => item?.parent?.id)
        : [];
    },
    changeDraggable(data) {
      this.draggingIndex = data.moved.newIndex;
      const orderItem = this.parentRendering?.map((item) => item?.parent?.id);
      this.$store.dispatch("orderDraggable/updateOrderDispatchSetting", {
        parent: orderItem,
      });
    },
    transerScreenToShipCourse() {
      this.$router.push({ path: "/ship-course" });
    },
    handleHeightContent() {
      this.contentHeight =
        this.contentHeight == "scroll-max-height"
          ? "scroll-min-height"
          : "scroll-max-height";
    },
  },
};
</script>

<style lang="scss" scoped>
.condition {
  &__icon {
    background-color: #5b9bd5;
  }
}

.search__group {
  &--customer {
    height: 34px;
  }
  &--loading_rate {
    height: 34px;
  }
  &--status {
    height: 34px;
  }
  &--sort {
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

  .btn-delivery {
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
    padding: 0.25rem 1.75rem;
    font-size: 1rem;
    line-height: 1.5;
    border-radius: 0.25rem;
    transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out,
      border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
  }

  .btn-course-setting:hover {
    color: #212529;
    background-color: #e9ecef;
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

<style>
.mx-input {
  width: 60%;
}

.mx-icon-calendar {
  right: 90px;
}
</style>
