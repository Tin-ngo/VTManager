<template>
  <section>
    <div class="container-fluid">
      <div class="card bg-condition">
        <div class="card-body">
          <div class="row" style="height: 100%">
            <div class="w-100 wrap-scroll" :class="contentHeight">
              <div class="text-center row-table header-row w-100 item-scroll">
                <template v-for="(header, idx) in tableHeader">
                  <div
                    class="cell bg-header text-center"
                    :key="idx"
                    v-if="idx == 0"
                    :style="{ width: header.width }"
                  >
                    {{ header.name }}
                  </div>
                  <div
                    v-else
                    :key="`${idx}b`"
                    class="cell bg-header"
                    :style="{ width: header.width }"
                  >
                    {{ header.name }}
                  </div>
                </template>
              </div>
              <template>
                <ContentItem
                  v-for="(item, idx) in listSlcOmsT1Order"
                  @reload="reload"
                  :item="item"
                  :taxCodeOrder="taxCodeOrder"
                  :isChecked="selectAll"
                  :key="idx"
                />
              </template>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid footer-item">
      <div class="card">
        <div class="card-body">
          <div class="col-lg-12 text-right">
            <button class="btn btn-default" @click="back">
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
import ContentItem from "./ContentItem.vue";

export default {
  components: {
    ContentItem,
  },
  props: {
    listSlcOmsT1Order: {
      type: Object | Array,
    },
    taxCodeOrder: {
      type: Array,
    },
  },
  data() {
    return {
      isShowDetail: false,
      checkBoxChild: "",
      estimateShippingDate: null,
      deadline: null,
      selectAll: null,
      contentHeight: "scroll-max-height",
    };
  },
  computed: {
    tableHeader() {
      return {
        0: {
          width: "2%",
          name: "",
        },
        1: {
          width: "7%",
          name: "",
        },
        2: {
          width: "7%",
          name: "",
        },
        3: {
          width: "8%",
          name: this.$t("order-status.label.table.header.status"),
        },
        4: {
          width: "5%",
          name: this.$t("order-status.label.table.header.order_no"),
        },
        5: {
          width: "10%",
          name: this.$t("order-status.label.table.header.customer_name"),
        },
        6: {
          width: "5%",
          name: this.$t("order-status.label.table.header.order_number"),
        },
        7: {
          width: "10%",
          name: this.$t("order-status.label.table.header.order_date"),
        },
        8: {
          width: "10%",
          name: this.$t("order-status.label.table.header.delivery_date"),
        },
        9: {
          width: "7%",
          name: this.$t("order-status.label.table.header.delivery_cd"),
        },
        10: {
          width: "10%",
          name: this.$t("order-status.label.table.header.delivery_name"),
        },
        11: {
          width: "4%",
          name: this.$t("order-status.label.table.header.detail_total"),
        },
        12: {
          width: "5%",
          name: this.$t("order-status.label.table.header.total_quanlity"),
        },
        13: {
          width: "10%",
          name: this.$t("order-status.label.table.header.entry_date"),
        },
      };
    },
  },
  methods: {
    showDetailData() {
      this.isShowDetail = !this.isShowDetail;
    },
    back() {
      this.$router.push({ name: "Main" });
    },
    reload() {
      this.$emit("reload");
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

<style scoped>
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
  justify-content: center;
  align-items: center;
}

.checkbox-item {
  width: 20px;
  height: 20px;
  margin-left: 5px;
}

.scroll-min-height {
  max-height: 275px;
  overflow-y: auto;
}

.scroll-max-height {
  max-height: 450px;
  overflow-y: auto;
}
</style>
