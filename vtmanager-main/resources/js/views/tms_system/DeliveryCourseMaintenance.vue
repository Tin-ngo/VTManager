<template>
    <div>
      <section>
        <ContentBlock :isUpdate="isUpdate"/>
      </section>
    </div>
  </template>
  
  <script>
  import ContentBlock from "@/components/tms_system/deliveryCourseMaintenance/ContentBlock.vue";
  import { TmsDeliveryCourseMaintenance } from "../../constants/router";
  export default {
    components: {
      ContentBlock
    },
    mounted() {
      this.$store.dispatch("auth/setTitle", TmsDeliveryCourseMaintenance);
    },
    data() {
      return {
        isUpdate: false
      };
    },
    methods: {
    },
  };
  </script>
  