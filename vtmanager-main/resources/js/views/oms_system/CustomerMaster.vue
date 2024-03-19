<template>
  <div class="main-section">
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
              <!-- 得意先コード -->
              <div class="form-group col-lg-2">
                <label class="form-check-label bold">
                  {{$t("customer-master.label.customer_code")}}
                </label>
                <input
                  type="text"
                  class="form-control border-custom"
                  v-model="conditionSearch.customerCode"
                />
              </div>
              <!-- 得意先名 -->
              <div class="form-group col-lg-2">
                <label class="form-check-label bold">
                  {{ $t("customer-master.label.customer_name") }}
                </label>
                <input
                  type="text"
                  class="form-control border-custom"
                  v-model="conditionSearch.customerName"
                />
              </div>
  
              <div class="col d-flex justify-content-end align-items-center">
                <!-- クリア -->
                <button class="btn btn-clear mr-2" @click="clear()">
                  <font-awesome-icon
                    :icon="['fas', 'share']"
                    flip="horizontal"
                  />
                  {{$t("button.clear")}}
                </button>
                <!-- 検索 -->
                <button class="btn btn-search" @click="search()">
                  <font-awesome-icon icon="fas fa-search" />
                  {{$t("button.search")}}
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <section>
      <div class="container-fluid">
        <div class="card bg-condition" :class="contentHeight">  <!-- style="height: 545px"-->
          <div class="card-body">
            <div class="border-common col-lg-12" style="width: 100%">
              <label style="margin: 0">
                {{ $t("customer-master.label.search_results") }}
              </label>
            </div>
            <div class="row">
              <div class="col-lg-12">
                <table style="width: 100%">
                  <thead class="bg-header">
                    <tr class="text-center">
                      <template v-for="(header, idx) in $t('customer-master.label.table_header')" >
                        <td :key="idx" v-if="idx == 0" style="width: 3%" :hidden="!isOpenedFromMenu">
                          <input
                            type="checkbox"
                            v-model="selectAll"
                            @change="selectRows()"
                          />
                        </td>
                        <td
                          v-else
                          :key="idx"
                          :hidden="idx == 4 && !isOpenedFromMenu"
                          :style="
                            idx == 1
                              ? 'width: 20% !important;'
                              : idx == 2
                              ? 'width: 20% !important;'
                              : idx == 3
                              ? 'width: 50% !important;'
                              : idx == 4
                              ? 'width: 10% !important;'
                              : ''
                          "
                        >
                          {{ header }}
                        </td>
                      </template>
                    </tr>
                  </thead>
                  <tbody>
                    <tr
                      class="text-center bg-data-parent row-hover"
                      v-for="(customer, key) in customers"
                      :key="key"
                    >
                      <td v-if="isOpenedFromMenu">
                        <input
                          type="checkbox"
                          class="w-100"
                          v-model="customer.selected"
                          @change="selectRow(customer)"
                        />
                      </td>
                      <td class="text-left max-w360">
                        {{ customer.customer_code }}
                      </td>
                      <td class="text-left max-w360">
                        {{ customer.customer_name }}
                      </td>
                      <td class="text-left max-w890">
                        {{ customer.customer_address1 }}
                      </td>
                      <td v-if="isOpenedFromMenu">
                        <font-awesome-icon
                          icon="fa-solid fa-pen-to-square"
                          style="font-size: 18px"
                          @click="HandleCreateOrUpdateButton(customer)"
                        />
                      </td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>
        </div>
      </div>
  
      <div class="container-fluid footer-item">
        <div class="card">
          <div class="card-body row">
            <div class="col-lg-6">
              <button
                class="btn btn-create"
                @click="HandleCreateOrUpdateButton()"
                v-if="isOpenedFromMenu"
              >
                <font-awesome-icon icon="fa-solid fa-pencil" />
                {{ $t("button.create") }}
              </button>
              &emsp;
              <button
                class="btn btn-delete"
                @click="HandleDeleteButton()"
                v-if="isOpenedFromMenu"
              >
                <font-awesome-icon icon="fa-solid fa-pencil" />
                {{ $t("button.delete") }}
              </button>
            </div>
            <div class="col text-right">
              <button class="btn btn-back" @click="handleBackButton">
                <font-awesome-icon icon="fas fa-arrow-left" />
                {{ $t("button.back") }}
              </button>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
  
</template>

<script>
import { SEARCH_STATE, ROUTER, ROUTER_NAME, RESPONSE_CODE } from "@/constants"
import { MstCustomerMaster } from "../../constants/router";
import { checkBlank, handleConditionSearch, handleBackButton, setIsOpenedFromMenu, handlePageReload } from "@/utils/helper"
import { getCustomers, deleteCustomer } from "@/services/APIs/MSTService.js";

export default {
  created() {
    window.addEventListener('beforeunload', (event) => handlePageReload(event, this));
  },
  mounted() {
    setIsOpenedFromMenu(this);

    this.$store.dispatch("auth/setTitle", MstCustomerMaster);
    
    const constionSearch = localStorage.getItem(this.screenName);
    if(!checkBlank(constionSearch)) this.conditionSearch = JSON.parse(constionSearch);
    this.search();
  },
  data() {
    return {
      screenName: ROUTER_NAME.MstCustomerMaster,
      isOpenedFromMenu: false,
      isSearchFormOpen: false,
      conditionSearch : {
        customerCode: "",
        customerName: "",
      },
      customers: [],
      selectAll : false,
      messageError: "",
      contentHeight: "scroll-max-height",
    };
  },
  computed: {
    setHeaderColor() {
      return {
        backgroundColor: "#D9D9D9",
      };
    },
  },
  methods: {
    toggleSearchForm() {
      this.isSearchFormOpen = !this.isSearchFormOpen;
      this.handleHeightContent();
    },
    handleHeightContent() {
      this.contentHeight =
        this.contentHeight == "scroll-max-height"
          ? "scroll-min-height"
          : "scroll-max-height";
    },
    async search() {
      this.selectAll = false;
      handleConditionSearch(this, SEARCH_STATE.ADD_CONDITION);
      const result = await getCustomers(this.conditionSearch)
      this.customers = result?.customers      
    },
    clear() {
      this.conditionSearch ={
        customerCode: "",
        customerName: "",
      };
      this.search();
    },
    selectRows() {
      const customerTmp = this.customers?.map(customer => ({ ...customer, selected: this.selectAll }));
      this.customers = [...customerTmp];
    },
    selectRow(){
      this.selectAll = this.customers.every(customer => customer.selected === true);
    },
    HandleCreateOrUpdateButton(customer = null) {
      let query = null;
      if(!checkBlank(customer)) {
        query = {
          customerCode: customer?.customer_code,
        }        
      }
      this.$router.push({
        name: ROUTER.OmsCustomerMasterMaintenance.name, 
        query,
        params: {
          isOpenedFromMenu: this.isOpenedFromMenu,
        }
      });
    },
    async HandleDeleteButton() {
      this.messageError = "";
      const customerCodes = this.customers.filter(customer => customer.selected === true).map(customer => customer.customer_code);
      const result = await deleteCustomer(customerCodes)
      if(result?.status_code === RESPONSE_CODE.OK) {
        this.$toast.success(this.$t(this.isUpdate ? "label.update_successfull" : "label.create_successfull"));
        await this.search();
        return;
      } else {
        this.messageError = result?.message;
      }
    },
    handleBackButton() {
      handleBackButton(this);
    }
  },
};
</script>

<style scoped>

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

/** 
Content

*/

table,
thead,
th,
tr,
td {
  border: 1px solid #ccc !important;
}

.bg-data-parent {
  background-color: #fff;
  height: 35px;
}

table {
  max-height: 450px;
  overflow-y: scroll;
}

thead {
  position: sticky;
  top: 0;
  z-index: 1;
  background: white;
  /* box-shadow: 0 -10px 0px black, 1px 1px 0px -1px black; */
}

td.text-left {
  padding: 0 4px;
}

.row-hover:hover {
  background-color: #fff2cc;
}

.scroll-min-height {
  max-height: 550px;
  overflow-y: auto;
}

.scroll-max-height {
  max-height: 625px;
  overflow-y: auto;
}

.max-w360{
  max-width: 360px;
}

.max-w890{
  max-width: 890px;
}

/** 
Content

*/
label {
  font-weight: bold;
}
.mx-input-wrapper {
  width: 95%;
}

.mx-input {
  height: 38px;
}

.datepicker-data .mx-input-wrapper {
  width: 100%;
}

.datepicker-data .mx-input {
  background-color: #fbe5d6;
}

.bg-condition-icon {
  background-color: #5b9bd5;
}

.bg-select {
  background-color: #fbe5d6;
}

.bg-data-parent {
  background-color: #fff2cc;
}

.input-custom {
  width: 56%;
}

.btn-handle-regist {
  margin-top: 30px;
  margin-left: 15px;
}

.datepicker-gap {
  margin-left: 100px;
}

.date-picker-wrapper {
  display: flex;
  align-items: center;
}

.date-picker-wrapper .date-range-label {
  margin: 0 8px;
}
</style>
