<template>
  <section class="main-section">
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
            <div class="col-lg-9">
              <label class="mb-0"
                >&nbsp;{{ $t("label.search_conditions") }}</label
              >
            </div>
          </div>
          <div v-show="isCollapsed" style="margin-left: 18px">
            <div class="form-row">
              <div class="form-group col-lg-2">
                <label>{{
                  $t("delivery-destination.label.form.customer")
                }}</label>
                <div class="col-lg-11 pl-0">
                  <select
                    name="customer-code"
                    id="customer-code"
                    class="input-select form-control"
                    v-model="customerCd"
                  >
                    <option value=""></option>
                    <option
                      v-for="(item, idx) in customers"
                      :key="idx"
                      :value="item?.得意先コード"
                    >
                      {{ item?.得意先名称 }}
                    </option>
                  </select>
                </div>
              </div>
              <div class="form-group col-lg-2">
                <label>{{
                  $t("delivery-destination.label.form.delivery_cd")
                }}</label>
                <input type="text" class="form-control" v-model="deliveryCd" />
              </div>
              <div class="form-group col-lg-2">
                <label>{{
                  $t("delivery-destination.label.form.delivery_name")
                }}</label>
                <input
                  type="text"
                  class="form-control"
                  v-model="deliveryName"
                />
              </div>
              <div class="col d-flex justify-content-end align-items-center">
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
    <div class="container-fluid">
      <div class="card bg-condition" style="height: 540px">
        <div class="card-body">
          <div class="row">
            <div class="scrollbar">
              <table id="table-result" class="table text-nowrap">
                <thead class="thead-main">
                  <tr
                    class="tr-main"
                    style="
                      box-shadow: 0 -10px 10px #ccc, 1px 10px 10px -1px #ccc;
                    "
                  >
                    <th
                      colspan="6"
                      class="thead-tr-1 text-left px-2 bg-white"
                      style="border-top: 1px solid #ccc !important"
                    >
                      {{ $t("label.search_results") }}
                    </th>
                  </tr>
                  <tr
                    class="text-center"
                    style="box-shadow: 0px 0 0px 1px #ccc"
                  >
                    <th class="bg-header">
                      <input
                        type="checkbox"
                        class="form-checkbox-input"
                        name="selectRow"
                        @change="setSelectAll"
                        :checked="selectAll"
                      />
                    </th>
                    <th
                      v-for="(header, idx) in tableHeader"
                      :key="idx"
                      class="bg-header"
                    >
                      {{ header }}
                    </th>
                    <th class="bg-header"></th>
                  </tr>
                </thead>
                <tbody>
                  <tr
                    v-for="(item, index) in deliveries"
                    class="hover-row"
                    :key="index"
                  >
                    <td class="text-center">
                      <input
                        type="checkbox"
                        class="form-checkbox-input"
                        name="selectRow"
                        @change="selectItem(item.delivery_cd, item.customer_cd)"
                        :checked="
                          listChecked.includes(
                            `${item.delivery_cd}-${item.customer_cd}`
                          )
                        "
                      />
                    </td>
                    <td>{{ item?.customer_name }}</td>
                    <td>{{ item?.delivery_cd }}</td>
                    <td>
                      {{ item?.delivery_name1 }} {{ item?.delivery_name2 }}
                    </td>
                    <td>
                      {{ item?.delivery_address1 }}
                      {{ item?.delivery_address2 }}
                    </td>
                    <td class="text-center">
                      <button id="selection-btn" class="btn mr-2">
                        <i
                          class="fas fa-check-circle"
                          style="color: #065ff9"
                        ></i>
                      </button>
                      <button
                        id="edit-btn"
                        class="btn"
                        @click="redirectToDeliveryDestinationMaintenance(item)"
                      >
                        <i class="fas fa-edit"></i>
                      </button>
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
      <div class="card bg-condition">
        <div class="card-body">
          <div class="row">
            <button
              class="btn btn-create mr-3 text-nowrap"
              @click="addNewMode()"
            >
              <i class="fas fa-pencil-alt"></i>&nbsp;{{ $t("button.create") }}
            </button>
            <button
              class="btn btn-delete text-nowrap"
              @click="deleteDelivery()"
            >
              <i class="fas fa-pencil-alt"></i>&nbsp;{{ $t("button.delete") }}
            </button>
            <button class="btn btn-back ml-auto" @click="goBack()">
              <i class="fas fa-arrow-left"></i>&nbsp;{{ $t("button.back") }}
            </button>
          </div>
        </div>
      </div>
    </div>
    <LoadingModalVue v-show="isLoading" />
  </section>
</template>

<script>
import { getCustomerByID } from "../../services/APIs/OMSService";
import { ROUTER } from "../../constants";
import { orderBy } from "lodash";
import { getDeliveries, deleteDelivery } from "@/services/APIs/MSTService";
import LoadingModalVue from "@/components/modals/LoadingModal.vue";

export default {
  components: {
    LoadingModalVue,
  },
  data() {
    return {
      customerCd: null,
      deliveryCd: null,
      deliveryName: null,
      isCollapsed: false,
      listChecked: [],
      searchResults: [],
      router: ROUTER,
      customers: [],
      deliveries: [],
      isLoading: false,
    };
  },
  mounted() {
    this.$store.dispatch(
      "auth/setTitle",
      this.$t("delivery-destination.label.title")
    );
    const searchStorage =
      this.$store.state.search?.searchQuery?.deliveryDestination;
    this.customerCd = searchStorage?.customerCd;
    this.deliveryCd = searchStorage?.deliveryCd;
    this.deliveryName = searchStorage?.deliveryName1;
    this.search();
  },
  async created() {
    this.customers = await getCustomerByID();
  },
  computed: {
    tableHeader() {
      return {
        0: this.$t("delivery-destination.label.table.headers.customer"),
        1: this.$t("delivery-destination.label.table.headers.delivery_cd"),
        2: this.$t("delivery-destination.label.table.headers.delivery_name"),
        3: this.$t("delivery-destination.label.table.headers.delivery_address"),
      };
    },
    selectAll() {
      return (
        JSON.stringify(orderBy(this.listChecked, [])) ===
        JSON.stringify(
          orderBy(
            this.deliveries?.map(
              (item) => `${item.delivery_cd}-${item.customer_cd}`
            ),
            []
          )
        )
      );
    },
  },
  methods: {
    clear() {
      this.customerCd = null;
      this.deliveryCd = null;
      this.deliveryName = null;
      this.search();
    },
    async search() {
      this.isLoading = true;
      const params = {};
      if (this.customerCd) {
        params.customerCd = this.customerCd;
      }
      if (this.deliveryCd) {
        params.deliveryCd = this.deliveryCd;
      }
      if (this.deliveryName) {
        params.deliveryName = this.deliveryName;
      }
      this.deliveries = await getDeliveries(params);
      this.$store.dispatch("search/updateSearchQuery", {
        deliveryDestination: params,
      });
      this.listChecked = [];
      this.isLoading = false;
    },
    handleHiddenCondition() {
      this.isCollapsed = !this.isCollapsed;
    },
    goBack() {
      this.$router.push({
        path: this.router?.ComMain?.path,
      });
    },
    selectItem(deliveryCd, customerCd) {
      const key = `${deliveryCd}-${customerCd}`;
      if (this.listChecked.includes(key)) {
        this.listChecked = this.listChecked.filter((item) => item !== key);
      } else {
        this.listChecked.push(key);
      }
    },
    setSelectAll(event) {
      this.listChecked = event.target.checked
        ? this.deliveries.map(
            (item) => `${item.delivery_cd}-${item.customer_cd}`
          )
        : [];
    },
    redirectToDeliveryDestinationMaintenance(data) {
      let query = {};
      query.delivery_cd = data?.delivery_cd;
      query.customer_cd = data?.customer_cd;
      query.delivery_name1 = data?.delivery_name1;
      query.delivery_name2 = data?.delivery_name2;
      query.delivery_address1 = data?.delivery_address1;
      query.delivery_address2 = data?.delivery_address2;
      query.delivery_telno = data?.delivery_telno;
      query.delivery_lead_time = data?.delivery_lead_time;
      this.$router.push({
        path: this.router?.MSTDeliveryDestinationMaintenance?.path,
        query,
      });
    },
    addNewMode() {
      this.$router.push({
        path: this.router?.MSTDeliveryDestinationMaintenance?.path,
      });
    },
    async deleteDelivery() {
      this.isLoading = true;
      try {
        await deleteDelivery(this.listChecked.join(","));
        this.search();
      } catch (error) {}
      this.isLoading = false;
    },
  },
};
</script>

<style scoped>
.bg-condition-icon {
  background-color: #5b9bd5;
}

#drop-down-button {
  background-color: #4472c4;
}

#selection-btn,
#edit-btn {
  padding: 0px;
}

#table-label {
  width: 100%;
  border-bottom: none;
}

#table-result {
  border-collapse: collapse;
  border-spacing: 0px;
}

table,
tr,
td {
  height: var(--height-row);
  line-height: var(--height-row);
}

.thead-main {
  position: sticky;
  top: 0;
  z-index: 2;
  background-color: #d9d9d9;
  height: 50px;
}

#table-result thead tr th {
  background-color: #d9d9d9;
  padding: 0px;
}

#table-result tbody td {
  padding: 0px;
  padding-left: 2px !important;
  padding-right: 2px !important;
  border-bottom: 1px solid #ccc !important;
  border-right: 1px solid #ccc !important;
  vertical-align: middle;
}

#table-result thead th:first-child,
#table-result tbody td:first-child {
  border-left: 1px solid #ccc;
}

#table-result thead tr:last-child th {
  border-top: none;
}

.scrollbar {
  overflow: auto;
  height: 495px;
  width: 100%;
}

.table td,
.table th {
  border-top: none !important;
}

.hover-row:hover {
  background-color: #fff2cc;
}
</style>
