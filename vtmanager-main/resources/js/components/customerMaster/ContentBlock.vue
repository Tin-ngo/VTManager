<template>
  <section>
    <div class="container-fluid">
      <div class="card bg-condition" :class="contentHeight">  <!-- style="height: 545px"-->
        <div class="card-body">
          <div class="border-common col-lg-12" style="width: 100%">
            <label style="margin: 0"
              >{{ $t("customer-master.label.search_results") }}
            </label>
          </div>
          <div class="row">
            <div class="col-lg-12">
              <table style="width: 100%">
                <thead class="bg-header">
                  <tr class="text-center">
                    <template
                      v-for="(header, idx) in $t(
                        'customer-master.label.table_header'
                      )"
                    >
                      <td :key="idx" v-if="idx == 0" style="width: 3%">
                        <input
                          type="checkbox"
                          v-model="isCheckedAll"
                          @change="handleCheckedAll"
                        />
                      </td>
                      <td
                        v-else
                        :key="idx"
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
                    <td>
                      <input
                        type="checkbox"
                        class="w-100"
                        v-model="customer.isChecked"
                      />
                    </td>
                    <td class="text-left max-w360">
                      {{ customer.customer_code }}
                    </td>
                    <td class="text-left max-w360">{{ customer.customer_name }}</td>
                    <td class="text-left max-w890">{{ customer.customer_address1 }}</td>
                    <td>
                      <font-awesome-icon
                        icon="fa-solid fa-pen-to-square"
                        style="font-size: 18px"
                        @click="HandleCreateOrUpdate(customer)"
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
              @click="HandleCreateOrUpdate()"
            >
              <font-awesome-icon icon="fa-solid fa-pencil" />
              {{ $t("button.create") }}
            </button>
            &emsp;
            <button
              class="btn btn-delete"
              @click="HandleDelete()"
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
</template>

<script>


import { getCustomers, deleteCustomers } from "@/services/APIs/MSTService.js";
import { checkBlank, handleBackButton } from "@/utils/helper";
import { ROUTER } from "@/constants";
export default {
  props: {
    customersProp: {
      type: Array,
      default: [],
    },
  },
  data() {
    return {
      customers: {},
      listCustomerDelete: null,
      isCheckedAll: false,
      contentHeight: "scroll-max-height",
    };
  },
  watch: {
    customersProp: {
      handler(newVal) {
        this.customers = newVal;
      },
      immediate: true
    },
  },
  computed: {
    setHeaderColor() {
      return {
        backgroundColor: "#D9D9D9",
      };
    },
  },
  methods: {
    handleCheckedAll() {
      let temp = null;
      if (this.isCheckedAll == true) {
        temp = true;
      } else {
        temp = false;
      }
      for (let index = 0; index < this.customers.length; index++) {
        this.customers[index].isChecked = temp;
      }
    },
    handleHeightContent() {
      this.contentHeight =
        this.contentHeight == "scroll-max-height"
          ? "scroll-min-height"
          : "scroll-max-height";
    },
    async HandleDelete() {
      const listDataSelected = this.customers.filter(
        (item) => item.isChecked === true
      );
      const customerCodeDelete = listDataSelected.map(
        (item) => item.customer_code
      );

      try{
        const result = await deleteCustomers(customerCodeDelete)
        const customers = await getCustomers({})
        this.customers = customers?.customers
      } catch (error) {}
      this.isCheckedAll = false;
    },
    HandleCreateOrUpdate(customer = null) {
      let query = null;
      if(!checkBlank(customer)) {
        query = {
          customerCode: customer?.customer_code,
        }        
      }
      this.$router.push({path: ROUTER.OmsCustomerMasterMaintenance.path, query});
    },
    handleBackButton() {
      handleBackButton(this);
    },
  },
};
</script>

<style scoped>
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
</style>
