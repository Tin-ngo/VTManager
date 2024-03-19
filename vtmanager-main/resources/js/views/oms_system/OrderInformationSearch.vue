<template>
  <div>
    <div class="container-fluid">
      <div class="card bg-condition">
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
            <div class="col-lg-9">検索条件</div>
          </div>
          <div v-show="isCollapsed">
            <div class="form-row">
              <div class="form-group col-lg-3">
                <label class="form-check-label">発注日</label>
                <div class="date-picker-wrapper">
                  <date-picker
                    format="YYYY/MM/DD"
                    id="datePicker1"
                    :clearable="false"
                    v-model="orderStartDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>
                  <label for="" class="date-range-label">～</label>
                  <date-picker
                    format="YYYY/MM/DD"
                    id="datePicker2"
                    :clearable="false"
                    v-model="orderEndDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>
                </div>
              </div>

              <div class="form-group col-lg-3">
                <label class="form-check-label">納期</label>
                <div class="date-picker-wrapper">
                  <date-picker
                    format="YYYY/MM/DD"
                    id="datePicker1"
                    :clearable="false"
                    v-model="deliveryStartDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>
                  <label for="" class="date-range-label">～</label>
                  <date-picker
                    format="YYYY/MM/DD"
                    id="datePicker2"
                    :clearable="false"
                    v-model="deliveryEndDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>
                </div>
              </div>
              <div class="form-group col-lg-2">
                <label class="form-check-label">確定対象</label>
                <select class="form-control col-lg-8">
                  <option value="">対象</option>
                  <option value="">非対象</option>
                </select>
              </div>
            </div>

            <div class="form-row">
              <div class="form-group col-lg-2">
                <label class="form-check-label">納入先名</label>
                <input
                  type="text"
                  class="form-control"
                  v-model="deliveryDestinationName"
                />
              </div>
              <div class="form-group col-lg-1">
                <label class="form-check-label">商品コード</label>
                <input type="text" class="form-control" v-model="itemCd" />
              </div>
              <div class="form-group col-lg-2">
                <label class="form-check-label">商品名</label>
                <input type="text" class="form-control" v-model="itemName" />
              </div>
            </div>

            <div class="form-row">
              <div class="form-group col-lg-2">
                <label class="form-check-label">確定対象</label>
                <select class="form-control col-lg-8">
                  <option value="">対象</option>
                  <option value="">非対象</option>
                </select>
              </div>
              <div class="form-group col-lg-3">
                <label class="form-check-label">納期</label>
                <div class="date-picker-wrapper">
                  <date-picker
                    format="YYYY/MM/DD"
                    id="datePicker1"
                    :clearable="false"
                    v-model="deliveryStartDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>
                  <label for="" class="date-range-label">～</label>
                  <date-picker
                    format="YYYY/MM/DD"
                    id="datePicker2"
                    :clearable="false"
                    v-model="deliveryEndDate"
                  >
                    <template v-slot:icon-calendar>
                      <font-awesome-icon icon="fas fa-calendar-alt" />
                    </template>
                  </date-picker>
                </div>
              </div>
              <div class="form-group col-lg-1">
                <label class="form-check-label">商品名</label>
                <input type="text" class="form-control" v-model="itemName" />
              </div>
              <div
                class="col-lg-6 d-flex justify-content-end align-items-center"
              >
                <button class="btn btn-default mr-2 btn-back">
                  <font-awesome-icon icon="fas fa-rotate-left" />クリア
                </button>
                <button class="btn btn-primary" @click="search">
                  <font-awesome-icon icon="fas fa-search" />
                  検索
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import {} from "@/services/APIs/OMSService";
export default {
  data() {
    return {
      customerCd: null,
      statusCd: null,
      orderStartDate: null,
      orderEndDate: null,
      deliveryStartDate: null,
      deliveryEndDate: null,
      deliveryDestinationName: null,
      itemCd: null,
      itemName: null,
      orderNumber: null,
      isCollapsed: false,
      params: {
        ownerId: 1, // TODO
      },
      listCustomer: [],
      listStatus: [],
    };
  },
  async mounted() {
    await this.search();
    this.$store.dispatch("auth/setTitle", "AAA");
  },
  async created() {},
  methods: {
    handleHiddenCondition() {
      this.isCollapsed = !this.isCollapsed;
    },
    async search() {
      const params = {};
      if (this.customerCd) {
        params.customerCd = this.customerCd;
      }
      if (this.statusCd) {
        params.statusCd = this.statusCd;
      }
      if (this.orderStartDate) {
        params.orderStartDate = this.orderStartDate;
      }
      if (this.orderEndDate) {
        params.orderEndDate = this.orderEndDate;
      }
      if (this.deliveryStartDate) {
        params.deliveryStartDate = this.deliveryStartDate;
      }
      if (this.deliveryEndDate) {
        params.deliveryEndDate = this.deliveryEndDate;
      }
      if (this.deliveryDestinationName) {
        params.deliveryDestinationName = this.deliveryDestinationName;
      }
      if (this.itemCd) {
        params.itemCd = this.itemCd;
      }
      if (this.itemName) {
        params.itemName = this.itemName;
      }
      //TODO:
      // if (this.orderNumber) {
      //   params.orderNumber = this.orderNumber;
      // }
    },
  },
};
</script>

<style>
.date-picker-wrapper .date-range-label {
  margin: 0 8px;
}

.date-picker-wrapper {
  display: flex;
  align-items: center;
}

.mx-input {
  height: 38px;
}
</style>
