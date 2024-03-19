<template>
  <section class="main-section">
    <HeaderBlock @search="listSlcMst04Product"  ref="HeaderBlock" @toggleCondition="toggleCondition" />
    <ContentBlock :listSlcMst04Product="setSlcMst04Product" @search="search()" @messageError="setMessageError" ref="ContentBlock"/>
  </section>
</template>

<script>
import HeaderBlock from "@/components/CommodityMaster/HeaderBlock.vue";
import ContentBlock from "@/components/CommodityMaster/ContentBlock.vue";
import { OmsCommodityMaster } from "../../constants/router";

export default {
  components: {
    ContentBlock,
    HeaderBlock,
  },
  mounted() {
    this.$store.dispatch("auth/setTitle", OmsCommodityMaster);
  },
  data() {
    return {
      setSlcMst04Product: [],
    };
  },
  methods: {
    listSlcMst04Product(data) {
      this.setSlcMst04Product = data;
    },
    setMessageError(data){
      this.$refs.HeaderBlock.setMessageError(data);
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
</style>
