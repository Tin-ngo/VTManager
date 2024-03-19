<template>
  <div>
    <div class="row-table w-100 text-center borderCustorm">
      <div
        :class="isShowDetail ? 'bg-item item-center' : 'cell item-center'"
        @click="showDetailData"
        style="width: 2%; border-left: 1px solid #ccc"
      >
        <font-awesome-icon
          class="text-blue"
          :icon="!isShowDetail ? 'fas fa-chevron-down' : 'fa-chevron-up'"
        />
      </div>
      <div style="width: 7%" :class="classDetail">
        <button
          @click="updateStatusOrder"
          class="btn btn-default m-1 text-nowrap"
          style="font-size: 13px"
        >
          {{ $t("button.on_hold") }}
        </button>
      </div>
      <div style="width: 7%" :class="classDetail">
        <button
          @click="cancel"
          class="btn btn-default m-1 text-nowrap"
          style="font-size: 13px"
        >
          {{ $t("button.cancel") }}
        </button>
      </div>
      <div style="width: 8%" :class="classDetail">
        {{ item[0]?.status_name }}
      </div>
      <div style="width: 5%" :class="classDetail">
        {{ item[0]?.order_no }}
      </div>
      <div style="width: 10%" :class="classDetail">
        {{ item[0]?.tokuisakinm }}
      </div>
      <div style="width: 5%" :class="classDetail">
        {{ item[0]?.denpyono }}
      </div>
      <div style="width: 10%" :class="classDetail">
        {{ checkValidDate(item[0]?.order_date) }}
      </div>
      <div style="width: 10%" :class="classDetail">
        {{ checkValidDate(item[0]?.delivery_date) }}
      </div>
      <div style="width: 7%" :class="classDetail">
        {{ item[0]?.nhsaki_cd }}
      </div>
      <div style="width: 10%" :class="classDetail">
        {{ item[0]?.nhsaki_name1 }} {{ item[0]?.nhsaki_name2 }}
      </div>
      <div style="width: 4%" :class="classDetail">
        {{ item[0]?.mesaino }}
      </div>
      <div style="width: 5%" :class="classDetail">
        {{ sumPrice }}
      </div>
      <div style="width: 10%" :class="classDetail">
        {{ convertTime(item[0]?.["create_date"], "YYYY/MM/DD HH:mm") }} -
      </div>
    </div>
    <div v-show="isShowDetail">
      <div
        class="text-center row-table-child"
        style="width: 92%; margin-left: 2%"
      >
        <template v-for="(header, idx) in tableHeaderChild">
          <div
            class="cell font-weight-bold"
            style="font-size: 14px"
            :style="{ width: header.width }"
            :key="idx"
          >
            {{ header.name }}
          </div>
        </template>
      </div>
      <div
        class="row-table-child"
        style="width: 92%; margin-left: 2%; font-size: 14px"
        v-for="(itemChild, index) in item"
        :key="`child${index}`"
      >
        <div class="cell" style="width: 3%">{{ itemChild?.mesaino }}</div>
        <div class="cell" style="width: 7%">
          {{ itemChild?.status_name }}
        </div>
        <div class="cell" style="width: 7%">
          <select class="select-item" v-model="itemChild.tax_code">
            <option value=""></option>
            <option
              v-for="(element, index) in taxCodeOrder"
              :value="element?.倉庫コード"
              :key="`taxCode${index}}`"
            >
              {{ element?.倉庫名 }}
            </option>
          </select>
        </div>
        <div class="cell" style="width: 10%">
          {{ itemChild?.nhsaki_item_name }}
        </div>
        <div class="cell" style="width: 5%">
          {{ itemChild?.lot_no }}
        </div>
        <div class="cell" style="width: 10%">
          {{ checkValidDate(itemChild?.symlmt, "YYYY/MM/DD") }}
        </div>
        <div class="cell" style="width: 5%">
          {{ itemChild?.order_num1 }}
        </div>
        <div class="cell date-picker-custom" style="width: 10%">
          <date-picker
            format="YYYY/MM/DD"
            :value="moment(itemChild?.ship_date, 'YYYYMMDD').toDate()"
            @input="(date) => change('ship_date', itemChild, date)"
            id="datePicker"
            :clearable="false"
          >
            <template v-slot:icon-calendar>
              <i class="fas fa-calendar-alt"></i>
            </template>
          </date-picker>
        </div>
        <div class="cell date-picker-custom" style="width: 10%">
          <date-picker
            format="YYYY/MM/DD"
            :value="moment(itemChild.delivery_date, 'YYYYMMDD').toDate()"
            @input="(date) => change('delivery_date', itemChild, date)"
            id="datePicker1"
            class="w-100"
            :clearable="false"
          >
            <template v-slot:icon-calendar>
              <i class="fas fa-calendar-alt"></i>
            </template>
          </date-picker>
        </div>
        <div class="cell" style="width: 8%">
          {{ itemChild?.assign_num1 }}
        </div>
        <div class="cell input-item" style="width: 5%">
          <input
            type="text"
            class="form-control"
            @change="change('ship_num1', itemChild)"
            :value="itemChild?.ship_num1"
          />
        </div>
        <div class="cell" style="width: 5%">
          {{ itemChild?.missing_num1 }}
        </div>
        <div class="cell" style="width: 5%">
          {{ itemChild?.irisu }}
        </div>
        <div class="cell" style="width: 5%">
          {{ itemChild?.ship_num1 / itemChild?.irisu }}
        </div>
        <div class="cell" style="width: 5%">
          {{ itemChild?.remain_num1 }}
        </div>
      </div>
      <button @click="update" class="btn btn-primary d-block mr-auto my-2 ml-4">
        <font-awesome-icon icon="fas fa-pencil-alt" />
        {{ $t("button.change_confirm") }}
      </button>
    </div>
  </div>
</template>

<script>
import moment from "moment";
import { updateSlcOmsT1Order } from "@/services/APIs/OMSService";
import { convertTime } from "@/utils/helper";
import {
  DATE_FORMAT_BASIC,
  DATE_FORMAT_SLASH,
  STATUS_ON_HOLD,
} from "@/constants";
import { sumBy } from "lodash";

export default {
  data() {
    return {
      isShowDetail: false,
      modelInputChildren: [],
    };
  },
  props: {
    item: {
      type: Array,
      default: {},
    },
    isChecked: {
      type: Boolean,
    },
    taxCodeOrder: {
      type: Array,
    },
  },
  computed: {
    tableHeaderChild() {
      return {
        0: {
          width: "3%",
          name: "",
        },
        1: {
          width: "7%",
          name: this.$t("order-status.label.table.header_childs.status"),
        },
        2: {
          width: "7%",
          name: this.$t("order-status.label.table.header_childs.warehouse"),
        },
        3: {
          width: "10%",
          name: this.$t("order-status.label.table.header_childs.commodity_nm"),
        },
        4: {
          width: "5%",
          name: this.$t("order-status.label.table.header_childs.lot_no"),
        },
        5: {
          width: "10%",
          name: this.$t(
            "order-status.label.table.header_childs.expiration_date"
          ),
        },
        6: {
          width: "5%",
          name: this.$t("order-status.label.table.header_childs.order_qty"),
        },
        7: {
          width: "10%",
          name: this.$t("order-status.label.table.header_childs.ship_date"),
        },
        8: {
          width: "10%",
          name: this.$t("order-status.label.table.header_childs.delivery_date"),
        },
        9: {
          width: "8%",
          name: this.$t(
            "order-status.label.table.header_childs.number_allocation"
          ),
        },
        10: {
          width: "5%",
          name: this.$t("order-status.label.table.header_childs.shipment_qty"),
        },
        11: {
          width: "5%",
          name: this.$t("order-status.label.table.header_childs.qty_shortage"),
        },
        12: {
          width: "5%",
          name: this.$t(
            "order-status.label.table.header_childs.quantity_per_carton"
          ),
        },
        13: {
          width: "5%",
          name: this.$t("order-status.label.table.header_childs.delivery_qty"),
        },
        14: {
          width: "5%",
          name: this.$t(
            "order-status.label.table.header_childs.remain_quantity"
          ),
        },
      };
    },
    classDetail() {
      return this.isShowDetail ? "cell bg-item" : "cell";
    },
    sumPrice() {
      return sumBy(this.item, (val) => parseInt(val.order_num1)) || 0;
    },
  },
  watch: {
    modelInputChildren() {
      console.log({ modelInputChildren: this.modelInputChildren });
    },
  },
  methods: {
    convertTime,
    moment,
    showDetailData() {
      this.isShowDetail = !this.isShowDetail;
      return "bg-item";
    },
    change(key, item, type = "normal") {
      item[key] =
        type === "normal"
          ? event.target.value
          : moment(type).format(DATE_FORMAT_BASIC);
    },
    async update() {
      try {
        const result = await updateSlcOmsT1Order(this.item);
        this.$emit("reload");
        if (result.errors)
          return this.$toast.error(this.$t("label.update_fail"));
        return this.$toast.success(this.$t("label.update_successfull"));
      } catch (error) {
        return this.$toast.error(this.$t("label.update_fail"));
      }
    },
    async cancel() {
      const dataUpdate = this.item.map((element) => {
        return {
          owner_id: element["owner_id"],
          denpyono: element["denpyono"],
          mesaino: element["mesaino"],
          delete_flg: 1,
        };
      });
      try {
        await updateSlcOmsT1Order(dataUpdate);
        this.$emit("reload");
        return this.$toast.success(this.$t("label.update_successfull"));
      } catch (error) {
        return this.$toast.error(this.$t("label.update_fail"));
      }
    },
    async updateStatusOrder() {
      const dataUpdate = this.item.map((element) => {
        return {
          owner_id: element["owner_id"],
          status_code: STATUS_ON_HOLD,
        };
      });
      try {
        await updateSlcOmsT1Order(dataUpdate);
        this.$emit("reload");
        return this.$toast.success(this.$t("label.update_successfull"));
      } catch (error) {
        return this.$toast.error(this.$t("label.update_fail"));
      }
    },
    checkValidDate(date) {
      if (date && moment(date).isValid()) {
        return moment(date).format(DATE_FORMAT_SLASH);
      } else {
        return "";
      }
    },
  },
};
</script>

<style scoped lang="scss">
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
  border-right: 0;
}

.row-table-child {
  display: flex;
  border-bottom: 1px solid #ccc;
  border-top: 0;
  border-right: 0;
  min-height: var(--height-row);
  text-align: center;

  .cell {
    border-right: 0;
    display: flex;
    align-items: center;
    justify-content: center;
  }
}

.cell {
  border-right: 1px solid #ccc;
  display: flex;
  align-items: center;
  justify-content: center;
}

.item-center {
  display: flex;
  align-items: center;
  justify-content: center;
}
.mx-datepicker {
  width: 100%;
  margin-right: auto;
}

.collapse svg {
  rotate: -180deg;
}

.data-parent:hover {
  filter: brightness(90%);
}

.row-table:hover {
  background-color: #fff2cc;
}

.row-table-child:hover {
  background-color: #668ee4;
}

.checkbox-item {
  width: 20px;
  height: 20px;
}

.select-item {
  width: 100%;
  border: 0;
  height: 100%;
  background-color: #fff2cc;
}

.input-item {
  input {
    width: 100%;
    height: 100%;
    border: 0;
    background-color: #fff2cc;
    border-radius: 0;
  }
}
</style>

<style>
.date-picker-custom .mx-input {
  margin-left: 4px;
  background-color: #fff2cc;
  border-radius: 0;
  height: 100%;
}

.borderCustorm {
  box-shadow: 0 -1px 0px #ccc, 1px 1px 0px -1px #ccc;
}
</style>
