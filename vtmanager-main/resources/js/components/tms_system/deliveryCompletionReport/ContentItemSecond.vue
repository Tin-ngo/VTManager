<template></template>

<script>
import moment from "moment";
export default {
  data() {
    return {};
  },
  props: {
    item2: {
      type: Object,
    },
  },
  computed: {
    tableHeaderChild() {
      return {
        0: {
          width: "5%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_secondary.order"
          ),
        },
        1: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_secondary.delivery_cd"
          ),
        },
        2: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_secondary.delivery_name"
          ),
        },
        3: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_secondary.delivery_slip_no"
          ),
        },
        4: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_secondary.delivery_completion_date"
          ),
        },
        5: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_secondary.delivery_completion_time"
          ),
        },
        6: {
          width: "5%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_secondary.number_of_pieces"
          ),
        },
        7: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_secondary.volume"
          ),
        },
        8: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_secondary.abnormality"
          ),
        },
        9: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.header_childs_secondary.notices"
          ),
        },
      };
    },
    parent() {
      return this.item2?.parent;
    },
    childrens() {
      return this.item2?.childrens2;
    },
  },
  methods: {
    moment,
    formatTime(time) {
      return time.slice(0, 2) + ":" + time.slice(2, 4);
    },
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
