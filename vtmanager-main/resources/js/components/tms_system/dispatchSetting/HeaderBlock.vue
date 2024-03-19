<template>
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
                  <label class="ml-2"
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
                <select class="form-control search__group--sort" v-model="sort">
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
                <font-awesome-icon icon="fas fa-search" />
                &nbsp;{{ $t("button.search") }}
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import moment from "moment";
import dataMockup from "@/mocks/mockDispatchSetting.json";
export default {
  data() {
    return {
      shipDate: null,
      customerCd: null,
      loadingRate: null,
      statusCd: null,
      sort: null,
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
    clear() {
      this.shipDate = null;
      this.customer = null;
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
.mx-input {
  width: 60%;
}

.mx-icon-calendar {
  right: 90px;
}
</style>
