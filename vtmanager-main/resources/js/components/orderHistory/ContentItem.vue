<template>
  <div>
    <div class="row-table w-100 text-center">
      <div
        :class="isShowDetail ? 'cell bg-item' : 'cell'"
        @click="showDetailData"
        style="width: 2%"
      >
        <font-awesome-icon
          class="text-blue"
          :icon="!isShowDetail ? 'fas fa-chevron-down' : 'fa-chevron-up'"
        />
      </div>
      <div
        class="cell"
        style="width: 7%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["denpyono"] }}
      </div>
      <div
        class="cell"
        style="width: 6%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["orderno"] }}
      </div>
      <div
        class="cell"
        style="width: 7%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["status_name"] }}
      </div>
      <div
        class="cell-border text-left"
        style="width: 13%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["nhsakicd"] }}
      </div>
      <div
        class="cell"
        style="width: 9%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["nhsaki_name1"] }} {{ item[0]?.["nhsaki_name2"] }}
      </div>
      <div
        class="cell-border text-left"
        style="width: 15%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["nhsaki_ad1"] }} {{ item[0]?.["nhsaki_ad2"] }}
      </div>
      <div
        class="cell-border text-left"
        style="width: 25%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["denpyono"] }}
      </div>
      <div
        class="cell-border text-right"
        style="width: 10%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item.countDenpyono }}
      </div>
      <div
        class="cell-border text-right"
        style="width: 7%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item.count_ship_num1 }}
      </div>
    </div>
    <div v-show="isShowDetail" class="bg-white">
      <!--isShowDetail-->
      <div
        class="text-center row-table-child header-row"
        style="
          width: 98%;
          margin-left: 2%;
          border-left: none;
          border-right: none;
        "
      >
        <template v-for="(header, idx) in tableHeaderChild">
          <div
            class="d-inline-block cell-sub header-child"
            :style="{ width: header.width }"
            :key="idx"
          >
            {{ header.name }}
          </div>
        </template>
      </div>

      <div
        class="row-table-child table-child"
        v-for="(itemChild, index) in item"
        :key="`child${index}`"
      >
        <div class="cell-sub" style="width: 2%">{{ index + 1 }}</div>
        <div class="cell-sub" style="width: 7%">
          {{ itemChild?.status_name }}
        </div>
        <div class="cell-sub" style="width: 7%">
          {{ itemChild?.itemcd }}
        </div>
        <div class="text-left padding4" style="width: 13%">
          {{ itemChild?.item_name }}
        </div>
        <div class="cell-sub" style="width: 5%">
          {{ itemChild?.lotno }}
        </div>
        <div class="cell-sub" style="width: 9%">
          {{
            moment(itemChild?.symlmt).format("YYYY/MM/DD") == "Invalid date"
              ? ""
              : moment(itemChild?.symlmt).format("YYYY/MM/DD")
          }}
        </div>
        <div class="text-right padding4" style="width: 6%">
          {{ itemChild?.order_num1 }}
        </div>
        <div class="text-right padding4" style="width: 4%">
          {{ itemChild?.irisu }}
        </div>
        <div class="text-right padding4" style="width: 5%">
          {{ itemChild?.ship_num1 }}
        </div>
        <div class="cell-sub" style="width: 5%">
          ¥{{ itemChild?.sell_amount }}
        </div>
        <div class="cell-sub" style="width: 4%">
          {{ itemChild?.warehouse_name }}
        </div>
        <div class="cell-sub" style="width: 8%">
          {{
            moment(itemChild?.ship_date).format("YYYY/MM/DD") == "Invalid date"
              ? ""
              : moment(itemChild?.ship_date).format("YYYY/MM/DD")
          }}
        </div>
        <div class="cell-sub" style="width: 8%">
          {{
            moment(itemChild?.納品予定日).format("YYYY/MM/DD") == "Invalid date"
              ? ""
              : moment(itemChild?.納品予定日).format("YYYY/MM/DD")
          }}
        </div>
        <div class="cell-sub" style="width: 8%">
          {{
            moment(itemChild?.delivery_completion_date).format("YYYY/MM/DD") ==
            "Invalid date"
              ? ""
              : moment(itemChild?.delivery_completion_date).format("YYYY/MM/DD")
          }}
        </div>
        <div class="cell-sub" style="width: 9%">
          {{ itemChild?.ship_document_num }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import moment from "moment";

export default {
  data() {
    return {
      isShowDetail: false,
      headersChild: this.tableHeaderChild,
      checkBoxChild: [],
      estimateShippingDate: null,
      deadline: null,
      inputCheckBox: false,
    };
  },
  props: {
    item: {
      type: Array,
    },
  },
  created() {},
  computed: {
    tableHeaderChild() {
      return {
        0: {
          width: "2%",
          name: "",
        },
        1: {
          width: "7%",
          name: this.$t("order-history.label.table.header_childs.status"),
        },
        2: {
          width: "7%",
          name: this.$t("order-history.label.table.header_childs.product_cd"),
        },
        3: {
          width: "13%",
          name: this.$t("order-history.label.table.header_childs.product_name"),
        },
        4: {
          width: "5%",
          name: this.$t("order-history.label.table.header_childs.lot_no"),
        },
        5: {
          width: "9%",
          name: this.$t("order-history.label.table.header_childs.control_date"),
        },
        6: {
          width: "6%",
          name: this.$t("order-history.label.table.header_childs.number_order"),
        },
        7: {
          width: "4%",
          name: this.$t("order-history.label.table.header_childs.quantity"),
        },

        8: {
          width: "5%",
          name: this.$t(
            "order-history.label.table.header_childs.expected_arrival_quantity"
          ),
        },
        9: {
          width: "5%",
          name: this.$t(
            "order-history.label.table.header_childs.purchase_price"
          ),
        },
        10: {
          width: "4%",
          name: this.$t("order-history.label.table.header_childs.warehouse"),
        },
        11: {
          width: "8%",
          name: this.$t(
            "order-history.label.table.header_childs.estimate_ship_date"
          ),
        },
        12: {
          width: "8%",
          name: this.$t("order-history.label.table.header_childs.deadline"),
        }, //
        13: {
          width: "8%",
          name: this.$t(
            "order-history.label.table.header_childs.delivery_completion_date"
          ), //
        },
        14: {
          width: "9%",
          name: this.$t("order-history.label.table.header_childs.shipping_no"),
        },
      };
    },
  },
  methods: {
    moment,
    showDetailData() {
      this.isShowDetail = !this.isShowDetail;
    },
    subString(string) {
      return string.length <= 40 ? string : string.slice(1, 40);
    },

    isChangeColorRow() {
      this.isShowDetail ? "bg-item" : "";
    },
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
  max-width: 800px;
}

.row-table {
  display: flex;
  border-bottom: 1px solid #ccc;
  border: 1px solid #ccc;
  border-top: 0;
  border-right: 0;
  /* height: var(--height-row);
  line-height: var(--height-row); */
}

.row-table:hover {
  background-color: #fff2cc;
}

.row-table-child {
  display: flex;
  border-bottom: 1px solid #ccc;
  border: 1px solid #ccc;
  border-top: 0;
  border-right: 0;
  min-height: var(--height-row);
  line-height: var(--height-row);
}

.cell {
  border-right: 1px solid #ccc;
  display: flex;
  justify-content: center;
  align-items: center;
}

.cell-border {
  border-right: 1px solid #ccc;
  padding: 0 4px;
}
.padding4 {
  padding: 0 4px;
}

.cell-sub {
  display: flex;
  justify-content: center;
  align-items: center;
}

.mx-datepicker {
  max-width: 70px;
  margin-right: auto;
}

.collapse svg {
  rotate: -180deg;
}

.bg-white {
  background-color: #fff !important;
}

.table-child {
  width: 98%;
  margin-left: 2%;
  font-size: 14px;
  border-left: none;
  border-right: none;
}

.table-child:hover {
  background-color: var(--color-hover-row);
}

.header-child {
  font-size: 14px;
  font-weight: bold;
}
</style>
