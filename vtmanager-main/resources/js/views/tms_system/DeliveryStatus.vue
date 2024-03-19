<template>
  <section class="main-section">
    <HeaderBlock @search="setListResult" @toggleCondition="toggleCondition()" />
    <ContentBlock :setListResult="results" ref="ContentBlock" />
  </section>
</template>

<script>
import HeaderBlock from "@/components/tms_system/deliveryStatus/HeaderBlock.vue";
import ContentBlock from "@/components/tms_system/deliveryStatus/ContentBlock.vue";
export default {
  components: {
    HeaderBlock,
    ContentBlock,
  },
  mounted() {
    this.$store.dispatch(
      "auth/setTitle",
      this.$t("delivery-status.label.title")
    );
  },
  data() {
    return {
      results: [],
    };
  },
  methods: {
    setListResult(data) {
      this.results = data;
    },
    toggleCondition() {
      this.$refs.ContentBlock.handleHeightContent();
    },
  },
};
</script>
