<template>
  <div class="container-fluid pt-2">
    <div class="card bg-condition">
      <div class="card-body">
        <div class="row form-group">
          <div
            class="border px-2 bg-condition-icon rounded"
            @click="toggleSearchForm"
          >
            <i
              :class="isSearchFormOpen ? 'fas fa-regular fa-minus' : 'fas fa-regular fa-plus'"
              class="text-white"
            ></i>
          </div>
          <div class="col-lg-9 bold">
            {{ $t("customer-master.label.search_conditions") }}
          </div>
        </div>
        <div v-show="isSearchFormOpen">
          <div class="form-row" style="margin: 0 12px">
            <div class="form-group col-lg-2">
              <label class="form-check-label bold">{{
                $t("customer-master.label.customer_code")
              }}</label>
              <input
                type="text"
                class="form-control border-custom"
                v-model="customerCode"
              />
            </div>

            <div class="form-group col-lg-2">
              <label class="form-check-label bold">{{
                $t("customer-master.label.customer_name")
              }}</label>
              <input
                type="text"
                class="form-control border-custom"
                v-model="customerName"
              />
            </div>

            <div class="col d-flex justify-content-end align-items-center">
              <button class="btn btn-clear mr-2" @click="clear()">
                <font-awesome-icon
                  :icon="['fas', 'share']"
                  flip="horizontal"
                />{{ $t("button.clear") }}
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
</template>

<script>


import { getCustomers } from "@/services/APIs/MSTService.js";
import {checkBlank, handleConditionSearch} from "@/utils/helper"
import {SEARCH_STATE, ROUTER_NAME} from "@/constants"
export default {
  data() {
    return {
      screenName: ROUTER_NAME.MstCustomerMaster,
      customers: [],
      customerCode: "",
      customerName: "",
      isSearchFormOpen: false,
    };
  },
  async mounted() {
    const constionSearch = localStorage.getItem(this.screenName);
    if(checkBlank(constionSearch) && checkBlank(constionSearch?.customerCode)) this.customerCode = constionSearch?.customerCode;
    if(checkBlank(constionSearch) && checkBlank(constionSearch?.customerName)) this.customerName = constionSearch?.customerName;
    this.search();
  },
  methods: {
    toggleSearchForm() {
      this.isSearchFormOpen = !this.isSearchFormOpen;
      this.$emit("toggleCondition");
    },
    clear() {
      this.customerCode = "";
      this.customerName = "";
      this.search();
    },
    async search() {
      handleConditionSearch(this, SEARCH_STATE.ADD_CONDITION);
      const result = await getCustomers({
        customerCode : this.customerCode,
        customerName : this.customerName
      })
      this.customers = result?.customers

      for (let index = 0; index < this.customers.length; index++) {
        this.customers[index].isChecked = false;
      }

      this.$emit("getCustomers", this.customers);
    },
  },
};
</script>
<style>
thead {
  box-shadow: 0 -1px 0px #ccc, 1px 1px 0px -1px #ccc;
}

.bg-condition-icon {
  background-color: #5b9bd5;
  font-weight: bold;
}

.bold {
  font-weight: bold;
}
</style>
