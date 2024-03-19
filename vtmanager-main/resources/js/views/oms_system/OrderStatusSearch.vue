<template>
  <section class="main-section">
    <HeaderBlock
      ref="HeaderBlock"
      @setListSlcOmsT1Order="setListSlcOmsT1Order"
      @toggleCondition="toggleCondition()"
    />
    <ContentBlock
      :listSlcOmsT1Order="listSlcOmsT1Order"
      :taxCodeOrder="taxCodeOrder"
      @reload="reload"
      ref="ContentBlock"
    />
  </section>
</template>

<script>
import HeaderBlock from "@/components/orderStatusSearch/HeaderBlock.vue";
import ContentBlock from "@/components/orderStatusSearch/ContentBlock.vue";
import { getDropDownTaxCodeOrder } from "@/services/APIs/OMSService";

export default {
  components: {
    ContentBlock,
    HeaderBlock,
  },

  data() {
    return {
      listSlcOmsT1Order: {},
      taxCodeOrder: [],
    };
  },
  async mounted() {
    this.$store.dispatch("auth/setTitle", this.$t("order-status.label.title"));
    this.taxCodeOrder = await getDropDownTaxCodeOrder();
  },
  methods: {
    setListSlcOmsT1Order(data) {
      this.listSlcOmsT1Order = data;
    },
    reload() {
      this.$refs.HeaderBlock.search();
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

.border-date-picker .mx-input {
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
