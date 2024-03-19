<template>
  <section class="main-section">
    <HeaderBlock
      @setListSlcOmsT1Order="setListSlcOmsT1Order"
      @toggleCondition="toggleCondition()"
    />
    <ContentBlock :listSlcOmsT1Order="listSlcOmsT1Order" ref="ContentBlock" />
  </section>
</template>

<script>
import HeaderBlock from "@/components/orderHistory/HeaderBlock.vue";
import ContentBlock from "@/components/orderHistory/ContentBlock.vue";
export default {
  components: {
    HeaderBlock,
    ContentBlock,
  },
  data() {
    return {
      listSlcOmsT1Order: [],

      //data test
      userCategory: 1, // 0, 2, 3, 4, 9  // 1 => title 発注履歴照会  else title 受注履歴照会
    };
  },
  async mounted() {
    this.$store.dispatch("auth/setTitle", this.$t("order-history.label.title"));
  },
  methods: {
    setListSlcOmsT1Order(data) {
      this.listSlcOmsT1Order = data;
    },
    toggleCondition() {
      this.$refs.ContentBlock.handleHeightContent();
    },
  },
};
</script>

<style>
.mx-input-wrapper {
  width: 95%;
}

.mx-input {
  height: 38px;
  border: 1px solid #ccc;
}

.datepicker-data .mx-input-wrapper {
  width: 100%;
}

.datepicker-data .mx-input {
  background-color: #fbe5d6;
}

.bg-condition-icon {
  background-color: #5b9bd5;
}

table,
th,
td {
  border: 1px solid #ccc !important;
  border-collapse: collapse;
}

.bg-select {
  background-color: #fbe5d6;
}

.bg-data-parent {
  background-color: #fff2cc;
}

.input-custom {
  width: 56%;
}

.btn-regist {
  height: 100px;
}

.btn-handle-regist {
  margin-top: 30px;
  margin-left: 15px;
}

.datepicker-gap {
  margin-left: 100px;
}

.date-picker-wrapper {
  display: flex;
  align-items: center;
}

.date-picker-wrapper .date-range-label {
  margin: 0 8px;
}

.border-custom {
  border: 1px solid #ccc;
}
</style>
