<template>
  <section>
    <div class="container-fluid">
      <div class="card bg-condition">
        <div class="card-body">
          <div :class="contentHeight" class="wrap-scroll">
            <div
              class="search-result pl-2 w-100 mg-0 item-scroll"
              style="border: 1px solid #ccc; line-height: 32px; height: 34px"
            >
              <label style="margin-bottom: 0" class="wrap-scroll-dispatch-title">{{
                $t("label.search_results")
              }}</label>
            </div>
            <div
              class="text-center row-table header-row w-100 item-scroll wrap-scroll-dispatch-header"
            >
              <template v-for="(header, idx) in tableHeader">
                <div
                  :key="idx"
                  v-if="idx == 0"
                  class="cell align-items-center header-color text-white header-btn bg-header"
                  :style="{
                    width: header.width,
                    background: '#ccc',
                    color: 'black',
                    'border-color': 'white',
                    'text-align': 'center'
                  }"
                >
                  {{ header.name }}
                </div>
                <div
                  v-else
                  :class="[
                    'cell align-items-center header-color d-flex justify-content-center bg-header',
                    { 'header-color': idx !== 14 },
                  ]"
                  :key="idx"
                  :style="{
                    width: header.width,
                    background: '#ccc',
                    color: 'black',
                    'border-color': 'white',
                  }"
                >
                  {{ header.name }}
                </div>
              </template>
            </div>
            <template>
              <ContentItem
                v-for="(item, idx) in listData"
                :item="item"
                :key="idx"
                class="w-100"
                @reload="reload"
              />
            </template>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid footer-item">
      <div class="card">
        <div class="row card-body">
          <div class="col-lg-3">
            <button class="btn btn-delete" @click="deleteAll">
              <font-awesome-icon icon="fas fa-pencil-alt" />
              {{ $t("button.cancel_all") }}
            </button>
          </div>
          <div class="col-lg-9 text-right">
            <button class="btn btn-back" @click="goBack()">
              <i class="fas fa-arrow-left"></i>
              {{ $t("button.back") }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import moment from "moment";
import ContentItem from "./ContentItem.vue";
import { deleteOrders } from "@/services/APIs/OMSService";
export default {
  components: {
    ContentItem,
  },
  props: {
    listData: {
      type: Array
    },
  },
  computed: {
    tableHeader() {
      return {
        0: {
          width: "3%",
          name: "", // 削除
        },
        1: {
          width: "6%",
          name: this.$t("label.cancel"),
        },
        2: {
          width: "3%",
          name: this.$t("label.edit"),
        },
        3: {
          width: "6%",
          name: this.$t("order-inquiry.label.table.headers.status"),
        },
        4: {
          width: "6%",
          name: this.$t("order-inquiry.label.table.headers.order_number"),
        },
        5: {
          width: "6%",
          name: this.$t("order-inquiry.label.table.headers.slip_number"),
        },
        6: {
          width: "8%",
          name: this.$t("order-inquiry.label.table.headers.order_date"),
        },
        7: {
          width: "8%",
          name: this.$t("order-inquiry.label.table.headers.delivery_date"),
        },
        8: {
          width: "8%",
          name: this.$t("order-inquiry.label.table.headers.delivery_code"),
        },
        9: {
          width: "11%",
          name: this.$t("order-inquiry.label.table.headers.shipping_name"),
        },
        10: {
          width: "10%",
          name: this.$t("order-inquiry.label.table.headers.delivery_to_address"),
        },
        11: {
          width: "4%",
          name: this.$t("order-inquiry.label.table.headers.number_items"),
        },
        12: {
          width: "5%",
          name: this.$t("order-inquiry.label.table.headers.total_quantity"),
        },
        13: {
          width: "6%",
          name: this.$t(
            "order-inquiry.label.table.headers.ship_date"
          ),
        },
        14: {
          width: "7%",
          name: this.$t("order-inquiry.label.table.headers.purchase_total"),
        },
        15: {
          width: "10%",
          name: this.$t("order-inquiry.label.table.headers.entry_date"),
        },
      };
    },
  },

  data() {
    return {
      isShowDetail: false,
      contentHeight: "scroll-max-height",
    };
  },
  methods: {
    removeValueSearch(){
      localStorage.setItem("orderInquiry_orderStartDate", null);
      localStorage.setItem("orderInquiry_orderEndDate", null);
      localStorage.setItem("orderInquiry_deliveryStartDate", null);
      localStorage.setItem("orderInquiry_deliveryEndDate", null);
      localStorage.setItem("orderInquiry_status", "");
      localStorage.setItem("orderInquiry_deliveryDestinationName", "");
      localStorage.setItem("orderInquiry_productCd", "");
      localStorage.setItem("orderInquiry_productName", "");
      localStorage.setItem("orderInquiry_registerDate", null);
      localStorage.setItem("orderInquiry_registerTime",  "");
      localStorage.setItem("orderInquiry_orderNumber", "");
    },

    goBack() {
      this.removeValueSearch()
      this.$router.push({ name: "Main" });
    },

    handleHeightContent() {
      this.contentHeight =
        this.contentHeight == "scroll-max-height"
          ? "scroll-min-height"
          : "scroll-max-height";
    },
    reload(){
      this.$emit("reload");
    },
    async deleteAll(){
      const numDelete = []
      for(let index = 0; index < this.listData.length; index ++){
        numDelete.push(this.listData[index][0]['denpyono'])
      }
    //  console.log('numDelete', numDelete);
     const result = await deleteOrders(numDelete)
     if(typeof result !== 'undefined'){
      this.$toast.success("正常に削除されました")
      this.$emit("reload")
     }else{
      this.$toast.error("削除に失敗しました")
     }
    }
  },
};
</script>

<style scoped>
.table {
  background-color: #fff;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  overflow: hidden;
  width: 80%;
}

.row-table {
  display: flex;
  border-bottom: 1px solid #ccc;
  border: 1px solid #ccc;
  border-right: 0;
}

.cell {
  border-right: 1px solid gray;
}

.header-color {
  background-color: #2f75b5;
}

.header-btn {
  display: grid;
}

.mg-0 {
  margin: 0;
}
.mg-0 label {
  margin: 0;
}

.scroll-min-height {
  max-height: 285px;
  overflow-y: auto;
}

.scroll-max-height {
  max-height: 460px;
  overflow-y: auto;
}
</style>
