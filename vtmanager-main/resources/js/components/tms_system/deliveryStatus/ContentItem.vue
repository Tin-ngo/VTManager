<template>
  <div class="content-item">
    <div
      class="row-table w-100 text-center borderCustorm"
      style="border-top: none"
    >
      <div
        class="cell"
        style="width: 3%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        <div @click="showDetailData" class="detail-icon">
          <i
            :class="isShowDetail ? 'fas fa-chevron-up' : 'fas fa-chevron-down'"
            class="text-blue"
          ></i>
        </div>
      </div>
      <div
        class="cell"
        style="width: 8%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ moment(parent.ship_date).format("YYYY/MM/DD") }}
      </div>
      <div
        class="cell"
        style="width: 15%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent.shipping_warehouse }}
      </div>
      <div
        class="cell"
        style="width: 10%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent.status }}
      </div>
      <div
        class="cell"
        style="width: 15%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent.shipping_course_name }}
      </div>
      <div
        class="cell"
        style="width: 6%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent.number_delivery_destinations }}
      </div>
      <div
        class="cell"
        style="width: 15%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent.delivery_company }}
      </div>
      <div
        class="cell"
        style="width: 12%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent.vehicle_number }}
      </div>
      <div
        class="cell"
        style="width: 12%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent.vehicle_size }}
      </div>
      <div
        class="cell"
        style="width: 5%"
        :class="isShowDetail ? 'bg-item' : ''"
      >
        {{ parent.loading_rate }}
      </div>
    </div>
    <div
      v-show="isShowDetail"
      class="bg-white"
      style="margin-left: 7%; margin-right: 2%"
    >
      <div class="text-center header-row">
        <template v-for="(header, idx) in tableHeaderChild">
          <div
            class="d-inline-block header-child font-weight-bold"
            :style="{
              width: header.width,
              'border-bottom': '1px solid #ccc',
              'max-width': '100%',
            }"
            :key="idx"
          >
            {{ header.name }}
          </div>
        </template>
      </div>
      <div
        class="header-child row-child"
        v-for="(itemChild, idxChild) in childrens"
        :key="`child${idxChild}`"
      >
        <div class="d-inline-block text-center" style="width: 5%">
          {{ itemChild.order }}
        </div>
        <div class="d-inline-block text-left" style="width: 6%">
          {{ itemChild.delivery_cd }}
        </div>
        <div class="d-inline-block text-left" style="width: 21%">
          {{ itemChild.delivery_name }}
        </div>
        <div class="d-inline-block text-left" style="width: 14%">
          {{ itemChild.delivery_slip_no }}
        </div>
        <div class="d-inline-block text-center" style="width: 12%">
          {{ itemChild.delivery_completion_time }}
        </div>
        <div class="d-inline-block text-center" style="width: 5%">
          {{ itemChild.number_of_pieces }}
        </div>
        <div class="d-inline-block text-center" style="width: 5%">
          {{ itemChild.volume }}
        </div>
        <div class="d-inline-block text-center" style="width: 12%">
          {{ itemChild.abnormality }}
        </div>
        <div class="d-inline-block text-left" style="width: 20%">
          {{ itemChild.notices }}
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
  computed: {
    tableHeaderChild() {
      return {
        0: {
          width: "5%",
          name: this.$t("delivery-status.label.table.header_childs.order"),
        },
        1: {
          width: "6%",
          name: this.$t(
            "delivery-status.label.table.header_childs.delivery_cd"
          ),
        },
        2: {
          width: "21%",
          name: this.$t(
            "delivery-status.label.table.header_childs.delivery_name"
          ),
        },
        3: {
          width: "14%",
          name: this.$t(
            "delivery-status.label.table.header_childs.delivery_slip_no"
          ),
        },
        4: {
          width: "12%",
          name: this.$t(
            "delivery-status.label.table.header_childs.delivery_completion_time"
          ),
        },
        5: {
          width: "5%",
          name: this.$t(
            "delivery-status.label.table.header_childs.number_of_pieces"
          ),
        },
        6: {
          width: "5%",
          name: this.$t("delivery-status.label.table.header_childs.volume"),
        },
        7: {
          width: "12%",
          name: this.$t(
            "delivery-status.label.table.header_childs.abnormality"
          ),
        },
        8: {
          width: "20%",
          name: this.$t("delivery-status.label.table.header_childs.notices"),
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
  methods: {
    moment,
    showDetailData() {
      this.isShowDetail = !this.isShowDetail;
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

  .header-child:last-child {
    border-bottom: 0;
  }

  .header-child {
    border-bottom: 1px solid #ccc;
    text-align: center;
    min-height: var(--height-row);
    line-height: var(--height-row);
  }

  .detail-icon {
    width: 40%;
    height: 100%;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .borderCustorm {
    box-shadow: 0 -1px 0px #ccc, 1px 1px 0px -1px #ccc;
  }

  .borderCustorm:hover {
    background-color: #fff2cc;
  }

  .row-table-child:hover {
    background-color: #fff2cc;
  }
  .bg-white {
    background-color: #fff;
  }

  .row-child:hover {
    background-color: var(--color-hover-row);
  }
}
</style>
