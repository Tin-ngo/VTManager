<template>
  <div class="content-item">
    <div class="row-table w-100 text-center">
      <div class="cell" style="width: 15%">
        {{ parent.shipping_course_name }}
      </div>
      <div class="cell" style="width: 10%">
        {{ parent.vehicle_number }}
      </div>
      <div class="cell" style="width: 10%">
        {{ parent.vehicle_size }}
      </div>
      <div class="cell" style="width: 15%">
        {{ moment(parent.shipping_date_delivery_date).format("YYYY/MM/DD") }}
      </div>
      <div class="cell" style="width: 25%">
        {{ parent.customer }}
      </div>
      <div class="cell" style="width: 5%">{{ parent.total_number }}</div>
      <div class="cell" style="width: 10%">
        {{ parent.number_delivery_destination }}
      </div>
      <div class="cell" style="width: 15%">
        {{ moment(parent.slip_issue_date).format("YYYY/MM/DD") }}
      </div>
    </div>
    <div class="text-center header-row">
      <template v-for="(header, idx) in tableHeaderChild">
        <div
          class="d-inline-block header-child font-weight-bold"
          :style="{ width: header.width }"
          :key="idx"
        >
          {{ header.name }}
        </div>
      </template>
    </div>
    <div
      class="d-flex"
      v-for="(itemChild, idxChild) in childrens"
      :key="`child${idxChild}`"
    >
      <div class="item-child" style="width: 5%">
        <input type="checkbox" />
      </div>
      <div class="item-child" style="width: 15%">{{ itemChild.subject }}</div>
      <div class="item-child" style="width: 20%">
        {{ itemChild.delivery_destination_cd }}
      </div>
      <div class="item-child" style="width: 15%">
        {{ itemChild.delivery_destination_name }}
      </div>
      <div class="item-child" style="width: 5%">
        {{ itemChild.delivery_slip_no }}
      </div>
      <div class="item-child" style="width: 5%">
        {{ itemChild.number_of_pieces }}
      </div>
      <div
        v-if="idxChild % 2 === 0"
        class="item-child"
        style="width: 15%; display: flex; justify-content: center"
      >
        <button class="m-1 btn-yes">有</button>
        <button class="m-1 btn-abnormality">無</button>
      </div>
      <div
        v-else
        class="item-child"
        style="width: 15%; display: flex; justify-content: center"
      >
        <button class="m-1 btn-abnormality">有</button>
        <button class="m-1 btn-nothing">無</button>
      </div>
      <div class="item-child" style="width: 20%">
        {{ itemChild.special_note }}
      </div>
    </div>
  </div>
</template>

<script>
import moment from "moment";
export default {
  data() {
    return {};
  },
  props: {
    item: {
      type: Object,
    },
  },
  computed: {
    tableHeaderChild() {
      return {
        0: {
          width: "5%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_primary.subject"
          ),
        },
        1: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_primary.delivery_destination_cd"
          ),
        },
        2: {
          width: "20%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_primary.delivery_destination_name"
          ),
        },
        3: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_primary.delivery_slip_no"
          ),
        },
        4: {
          width: "5%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_primary.number_of_pieces"
          ),
        },
        5: {
          width: "5%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_primary.volume"
          ),
        },
        6: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_primary.abnormality"
          ),
        },
        7: {
          width: "20%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_primary.special_note"
          ),
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
  },
};
</script>

<style lang="scss" scoped>
.header-row {
  border-bottom: 1px solid #ccc;
}

.item-child {
  display: flex;
  text-align: center;
  border-bottom: 1px solid #ccc;
  justify-content: center;
  align-items: center;

  .input {
    width: 35px;
  }

  .btn-yes {
    padding: 0.01rem 1.05rem;
    border: 1px solid #000;
    background-color: #ff9999;
  }

  .btn-nothing {
    padding: 0.01rem 1.05rem;
    border: 1px solid #000;
    background-color: #dae3f3;
  }

  .btn-abnormality {
    padding: 0.01rem 1.05rem;
    border: 1px solid #000;
  }
}
</style>
