<template>
  <div class="content-item">
    <div class="row-table w-100 text-center borderCustorm row-hover">
      <div
        class="cell"
        style="width: 2%"
        @click="showDetailData"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        <div>
          <i
            :class="isShowDetail ? 'fas fa-chevron-up' : 'fas fa-chevron-down'"
            class="text-blue"
          ></i>
        </div>
      </div>
      <div
        class="cell"
        style="width: 14%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        <button class="btn btn-default m-2 text-nowrap">
          {{ this.$t("button.remove") }}
        </button>
        <button class="btn btn-default text-nowrap">
          {{ this.$t("button.merchandise") }}
        </button>
      </div>
      <div
        class="cell"
        style="width: 2%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        <input
          type="checkbox"
          :value="parent?.confirm_target"
          @change="changeChecked"
          v-model="isCheckedItem"
          style="width: 20px; height: 20px"
        />
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ moment(parent?.ship_date, "YYYYMMDD").format("MM/DD") }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ moment(parent?.delivery_date, "YYYYMMDD").format("MM/DD") }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent?.status }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent?.shipping_course }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent?.shipping_course }}
      </div>
      <div
        class="cell"
        style="width: 9%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent?.delivery_company }}
      </div>
      <div
        class="cell"
        style="width: 9%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent?.vehicle_number }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent?.vehicle_size }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent?.loading_rate }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent?.total_volume }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent?.total_number }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent?.number_delivery_destination }}
      </div>
      <div
        class="cell"
        style="width: 9%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent.child_or_dry }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        <div class="btn-details">
          <button class="btn btn-default text-nowrap margin-right0">
            {{ $t("button.detail") }}
          </button>
        </div>
      </div>
    </div>
    <div v-show="isShowDetail" style="background-color: #fff !important">
      <div class="text-center header-item" style="width: 85%; margin-left: 10%">
        <template v-for="(header, idx) in tableHeaderChild">
          <div
            class="d-inline-block font-weight-bold"
            :style="{ width: header.width }"
            :key="idx"
          >
            {{ header.name }}
          </div>
        </template>
      </div>
      <div style="width: 85%; margin-left: 10%">
        <draggable
          v-model="childrenRendering"
          :options="{ animation: 150 }"
          @end="changeDraggable"
        >
          <div
            class="header-child row-child"
            v-for="(itemChild, idxChild) in childrenRendering"
            :key="`child${idxChild}`"
          >
            <div class="d-inline-block" style="width: 5%">
              {{ itemChild.order }}
            </div>
            <div class="d-inline-block" style="width: 10%">
              <select
                class=""
                style="
                  border: 0;
                  border-bottom: 1px solid #ccc;
                  width: 100%;
                  text-align: center;
                  height: 100%;
                  background-color: #fff2cc;
                "
              >
                <option :value="itemChild.course_name">
                  {{ itemChild.course_name }}
                </option>
              </select>
            </div>
            <div class="d-inline-block" style="width: 20%">
              {{ itemChild.customer_name }}
            </div>
            <div class="d-inline-block" style="width: 15%">
              {{ itemChild.delivery_cd }}
            </div>
            <div class="d-inline-block" style="width: 10%">
              {{ itemChild.delivery_name }}
            </div>
            <div class="d-inline-block" style="width: 20%">
              {{ itemChild.number_pieces }}
            </div>
            <div class="d-inline-block" style="width: 5%">
              {{ itemChild.volume }}
            </div>
            <div class="d-inline-block" style="width: 5%">
              {{ itemChild.volume }}
            </div>
            <div class="d-inline-block" style="width: 5%">
              {{ itemChild.volume }}
            </div>
            <div class="d-inline-block" style="width: 5%">
              {{ itemChild.volume }}
            </div>
          </div>
        </draggable>
      </div>
    </div>
  </div>
</template>
<script>
import moment from "moment";
import draggable from "vuedraggable";
import { sortBy } from "lodash";
export default {
  components: {
    draggable,
  },
  data() {
    return {
      isShowDetail: false,
      isCheckedItem: false,
      childrenRendering: [],
    };
  },
  props: {
    item: {
      type: Object,
    },
    isChecked: {
      type: Boolean,
    },
  },
  watch: {
    isChecked() {
      this.isCheckedItem = this.isChecked;
    },
    item() {
      this.childrenRendering = this.item?.childrens;
      const order = this.$store.state.orderDraggable.dispatchSettingOrder;
      const orderItem = order?.[this.item?.parent?.id];
      if (orderItem) {
        this.childrenRendering = sortBy(this.item?.childrens, function (item) {
          return orderItem.indexOf(item.order);
        });
      }
    },
  },
  computed: {
    tableHeaderChild() {
      return {
        0: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.header_childs.order"),
        },
        1: {
          width: "10%",
          name: this.$t(
            "dispatch-setting.label.table.header_childs.course_name"
          ),
        },
        2: {
          width: "20%",
          name: this.$t(
            "dispatch-setting.label.table.header_childs.customer_name"
          ),
        },
        3: {
          width: "15%",
          name: this.$t(
            "dispatch-setting.label.table.header_childs.OMS_status"
          ),
        },
        4: {
          width: "10%",
          name: this.$t(
            "dispatch-setting.label.table.header_childs.delivery_cd"
          ),
        },
        5: {
          width: "20%",
          name: this.$t(
            "dispatch-setting.label.table.header_childs.delivery_name"
          ),
        },
        6: {
          width: "5%",
          name: this.$t(
            "dispatch-setting.label.table.header_childs.time_specification"
          ),
        },
        7: {
          width: "5%",
          name: this.$t(
            "dispatch-setting.label.table.header_childs.number_pieces"
          ),
        },
        8: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.header_childs.volume"),
        },
        9: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.header_childs.weight"),
        },
      };
    },
    parent() {
      return this.item?.parent;
    },
    childrens() {
      return this.item?.childrens;
    },
  },
  created() {
    this.childrenRendering = this.item?.childrens;
    const order = this.$store.state.orderDraggable.dispatchSettingOrder;
    const orderItem = order?.[this.item?.parent?.id];
    if (orderItem) {
      this.childrenRendering = sortBy(this.item?.childrens, function (item) {
        return orderItem.indexOf(item.order);
      });
    }
  },
  methods: {
    moment,
    showDetailData() {
      this.isShowDetail = !this.isShowDetail;
    },
    onDragEnd(event) {
      console.log(event);
    },
    changeChecked(event) {
      this.$emit(
        "changeSelectAll",
        event.target.checked,
        this.item?.parent?.id
      );
    },
    changeDraggable(data) {
      const orderItem = this.childrenRendering.map((item) => item.order);
      const item = {};
      item[this.parent?.id] = orderItem;
      this.$store.dispatch("orderDraggable/updateOrderDispatchSetting", item);
    },
  },
};
</script>
<style scoped lang="scss">
.content-item {
  .row-table {
    display: flex;
    border: 1px solid #ccc;
    border-right: 0;
  }

  .cell {
    border-right: 1px solid #ccc;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .header-item {
    border-bottom: 1px solid #ccc;
  }

  .header-child {
    border-bottom: 1px solid #ccc;
    text-align: center;
  }

  .header-child:last-child {
    border-bottom: 0;
  }

  .detail-icon {
    width: 40%;
    border-right: 1px solid #ccc;
    height: 100%;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .btn-default {
    padding: 0 0.75rem;
    margin-right: 5px;
    border-radius: 0;
  }

  .margin-right0 {
    margin-right: 0;
  }

  .d-inline-block {
    line-height: 34px;
  }

  .row-child:hover {
    background-color: var(--color-hover-row);
  }

  .d-inline-block,
  .header-child {
    min-height: 34px !important;
  }

  .borderCustorm {
    border-top: none;
    box-shadow: 0 -1px 0px #ccc, 1px 1px 0px -1px #ccc;
  }

  .row-hover:hover {
    background-color: #fff2cc;
  }
}
</style>
