<template>
  <div>
    <div class="row-table w-100 text-center data-parent">
      <div
        :class="isShowDetail ? 'bg-item cell' : 'cell'"
        @click="showDetailData"
        style="width: 3%; color: blue"
      >
        <i
          :class="isShowDetail ? 'fas fa-chevron-up' : 'fas fa-chevron-down'"
        ></i>
      </div>

      <div
        class="cell"
        style="width: 6%; cursor: pointer"
        :class="isShowDetail ? 'bg-item' : ''"
        @click="deleteOrder(item[0].denpyono)"
      >
        <!-- <input type="checkbox" v-model="modelInputChildren" :value="idxChild" /> -->
        <i class="fas fa-ban text-danger fa-rotate-90"></i>
      </div>
      <div
        class="cell"
        :class="isShowDetail ? 'bg-item' : ''"
        style="width: 3%"
        role="button"
        @click="transferScreenOrderCorrection(item[0])"
      >
        <i class="fas fa-edit"></i>
      </div>
      <div
        class="cell"
        style="width: 6%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["status_name"] }}
      </div>
      <div
        class="cell"
        style="width: 6%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["order_no"] }}
      </div>
      <div
        class="cell"
        style="width: 6%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["denpyono"] }}
      </div>
      <div
        class="cell"
        style="width: 8%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{
          moment(item[0]?.["order_date"]).format("YYYY/MM/DD") == "Invalid date"
            ? ""
            : moment(item[0]?.["order_date"]).format("YYYY/MM/DD")
        }}
      </div>
      <div
        class="cell"
        style="width: 8%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{
          moment(item[0]?.["delivery_date"]).format("YYYY/MM/DD") ==
          "Invalid date"
            ? ""
            : moment(item[0]?.["delivery_date"]).format("YYYY/MM/DD")
        }}
      </div>
      <div
        class="cell"
        style="width: 8%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["nhsaki_cd"] }}
      </div>
      <div
        class="cell-border text-left"
        style="width: 11%; display: flex; justify-content: left"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        <!-- {{ item?.nhsaki_name1 }} - {{ item?.nhsaki_name2 }} -->
        {{ item[0]?.["nhsaki_name1"] }}
        {{
          item[0]?.["nhsaki_name1"] != null && item[0]?.["nhsaki_name2"] != null
            ? "-"
            : ""
        }}
        {{ item[0]?.["nhsaki_name2"] }}
      </div>
      <div
        class="cell-border text-left"
        style="width: 10%; display: flex; justify-content: left"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item[0]?.["nhsaki_ad1"] }}
        {{
          item[0]?.["nhsaki_ad1"] != null && item[0]?.["nhsaki_ad2"] != null
            ? "-"
            : ""
        }}
        {{ item[0]?.["nhsaki_ad2"] }}
      </div>
      <div
        class="cell-border text-right"
        style="width: 4%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ item?.countDenpyono }}
      </div>
      <div
        class="cell-border text-right"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ isNaN(item?.count_ship_num1) == true ? "0" : item?.count_ship_num1 }}
      </div>
      <div
        class="cell"
        style="width: 6%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        <!-- {{ moment(item?.ship_date).format("YYYY/MM/DD") }} -->
        {{
          moment(item[0]?.["ship_date"]).format("YYYY/MM/DD") == "Invalid date"
            ? ""
            : moment(item[0]?.["ship_date"]).format("YYYY/MM/DD")
        }}
      </div>
      <div
        class="cell"
        :class="isShowDetail ? 'bg-item' : ''"
        style="width: 7%; font-weight: bold"
      >
        {{ item?.sum_price }}
      </div>

      <div
        class="cell"
        style="width: 10%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{
          moment(item[0]?.["create_date"]).format("YYYY/MM/DD") ==
          "Invalid date"
            ? ""
            : moment(item[0]?.["create_date"]).format("YYYY/MM/DD")
        }}
        {{
          moment(item[0]?.["create_date"]).format("YYYY/MM/DD") !=
            "Invalid date" && item[0]?.["create_time"] != null
            ? "-"
            : ""
        }}
        {{
          item[0]?.["create_time"] == null
            ? ""
            : formatTime(item[0]?.["create_time"])
        }}
      </div>
    </div>

    <div v-show="isShowDetail" style="margin-left: 11%; margin-right: 26.5%">
      <div
        class="row-table-child w-100"
        style="border-left: none; border-right: none"
      >
        <template v-for="(header, idx) in tableHeaderChild">
          <div
            class="d-inline-block cell border-custom font-weight-bold"
            style="font-size: 14px; border: none"
            :style="{
              width: header.width,
              'text-align': 'center',
            }"
            :key="idx"
          >
            {{ header.name }}
          </div>
        </template>
      </div>
      <div
        class="row-table-child"
        v-for="(itemChild, idxChild) in item"
        :key="`child${idxChild}`"
        style="border-right: none; border-left: none"
      >
        <div class="cell-sub" style="width: 5%">
          {{ itemChild?.["meisai_no"] }}
        </div>
        <div class="cell-sub" style="width: 10%">
          {{ itemChild?.["status_name"] }}
        </div>
        <div class="cell-sub" style="width: 10%">
          {{ itemChild?.["item_cd"] }}
        </div>
        <div class="cell-sub" style="width: 17%">
          {{ itemChild?.["item_name"] }}
        </div>
        <div class="cell-sub" style="width: 12%">
          {{ itemChild?.["lot_no"] }}
        </div>
        <div class="text-right cell-sub" style="width: 12%">
          {{
            moment(itemChild?.["symlmt"]).format("YYYY/MM/DD") == "Invalid date"
              ? ""
              : moment(item[0]?.["symlmt"]).format("YYYY/MM/DD")
          }}
        </div>
        <div class="text-right cell-sub" style="width: 5%; text-align: right">
          {{ itemChild?.["order_num1"] }}
        </div>
        <div class="text-right cell-sub" style="width: 5%; text-align: right">
          {{ itemChild?.["irisu"] }}
        </div>
        <div class="text-right cell-sub" style="width: 10%">
          {{ itemChild?.["ship_num1"] }}
        </div>
        <div class="cell-sub" style="width: 10%; font-weight: bold">
          {{
            isNaN(parseInt(itemChild?.["sell_price"])) == true
              ? "0"
              : parseInt(itemChild?.["sell_price"])
          }}{{ currentSymbol }}
        </div>
        <div class="cell-sub" style="width: 10%">
          {{
            moment(itemChild?.["delivery_date"]).format("YYYY/MM/DD") ==
            "Invalid date"
              ? ""
              : moment(item[0]?.["delivery_date"]).format("YYYY/MM/DD")
          }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import moment from "moment";
import { getCurrencySymbol, deleteOrder } from "@/services/APIs/OMSService";

export default {
  data() {
    return {
      isShowDetail: false,
      checkBoxChild: [],
      estimateShippingDate: null,
      deadline: null,
      inputCheckBox: false,
      modelInputChildren: [],
      currentSymbol: "",
    };
  },
  props: {
    item: {
      type: Array,
    },
  },
  computed: {
    tableHeaderChild() {
      return {
        0: {
          width: "5%",
          name: "",
        },
        1: {
          width: "10%",
          name: this.$t("order-inquiry.label.table.header_childs.status"),
        },
        2: {
          width: "10%",
          name: this.$t("order-inquiry.label.table.header_childs.commodity_cd"),
        },
        3: {
          width: "17%",
          name: this.$t("order-inquiry.label.table.header_childs.commodity_nm"),
        },
        4: {
          width: "12%",
          name: this.$t("order-inquiry.label.table.header_childs.lot_no"),
        },
        5: {
          width: "12%",
          name: this.$t("order-inquiry.label.table.header_childs.control_date"),
        },
        6: {
          width: "5%",
          name: this.$t(
            "order-inquiry.label.table.header_childs.number_orders"
          ),
        },
        7: {
          width: "5%",
          name: this.$t("order-inquiry.label.table.header_childs.quantity"),
        },
        8: {
          width: "10%",
          name: this.$t(
            "order-inquiry.label.table.header_childs.expected_arrival_quantity"
          ),
        },
        9: {
          width: "10%",
          name: this.$t(
            "order-inquiry.label.table.header_childs.purchase_amount"
          ),
        },
        10: {
          width: "10%",
          name: this.$t("order-inquiry.label.table.header_childs.stock_date"),
        },
      };
    },
    childrens() {
      return this.item;
    },
  },

  watch: {
    modelInputChildren() {
      console.log({ modelInputChildren: this.modelInputChildren });
    },
  },
  async created() {
    this.currentSymbol = await getCurrencySymbol("OMS");
  },
  methods: {
    moment,
    showDetailData() {
      this.isShowDetail = !this.isShowDetail;
    },
    subString(string) {
      return string.length <= 40 ? string : string.slice(1, 40);
    },
    formatTime(inputString) {
      const firstPart = inputString.slice(0, 2);
      const secondPart = inputString.slice(2);
      return `${firstPart}:${secondPart}`;
    },

    transferScreenOrderCorrection(data) {
      console.log({ data: data });
      this.$router.push({
        path: "/order-correction",
        query: {
          dataOrder: data,
        },
      });
    },

    formatTime(Str) {
      const timeString = `${Math.floor(Str / 100)}:${(Str % 100)
        .toString()
        .padStart(2, "0")}`;
      return timeString;
    },

    async deleteOrder(number) {
      //console.log('number', number);
      const result = await deleteOrder(number);
      if (typeof result !== "undefined") {
        this.$toast.success("正常に削除されました");
        this.$emit("reload");
      } else {
        this.$toast.error("削除に失敗しました");
      }
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
}

.row-table-child {
  display: flex;
  border-bottom: 1px solid #ccc;
  border: 1px solid #ccc;
  border-top: 0;
  min-height: var(--height-row);
}

.cell {
  border-right: 1px solid #ccc;
  overflow-wrap: break-word;
}

.cell-border {
  border-right: 1px solid #ccc;
  padding-right: 4px;
  padding-left: 4px;
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

.data-parent {
  background-color: #fff2cc;
  min-height: 34px;
}

.data-parent:hover {
  filter: brightness(90%);
}

.data-parent > div {
  display: flex;
  justify-content: center;
  align-items: center;
}

.border-custom:hover {
  background-color: #fff2cc;
}

.row-table-child:hover {
  background-color: #fff2cc;
}

.row-table-child div {
  min-height: var(--height-row);
  line-height: 34px;
}

.text-right {
  display: flex !important;
  justify-content: right !important;
}
</style>
