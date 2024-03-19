<template>
  <div class="content-item">
    <div class="row-table w-100 text-center" id="elementDrag" :draggable="true" @dragstart="dragStart" @dragend="dragEnd">
      <div class="cell-border" style="width: 15%; border-left: 1px solid #ccc !important; box-shadow: 0px 2px 0px -1px #ccc;">
        {{ item?.delivery_order }}
      </div>
      <div class="cell-border text-left" style="width: 25%; box-shadow: 0px 2px 0px -1px #ccc;">
        {{ item?.ship_name }}
      </div>
      <div class="cell-border text-left" style="width: 48%; box-shadow: 0px 2px 0px -1px #ccc;">
        {{ item?.ship_address }}
      </div>
    </div>
  </div>
</template>
<script>
import moment from "moment";
export default {
  data() {
    return {
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
          name: this.$t("delivery-status.table_header_children.order"),
        },
        1: {
          width: "15%",
          name: this.$t("delivery-status.table_header_children.delivery_cd"),
        },
        2: {
          width: "15%",
          name: this.$t("delivery-status.table_header_children.delivery_name"),
        },
        3: {
          width: "10%",
          name: this.$t(
            "delivery-status.table_header_children.delivery_slip_no"
          ),
        },
        4: {
          width: "10%",
          name: this.$t(
            "delivery-status.table_header_children.delivery_completion_time"
          ),
        },
        5: {
          width: "15%",
          name: this.$t(
            "delivery-status.table_header_children.number_of_pieces"
          ),
        },
        6: {
          width: "10%",
          name: this.$t("delivery-status.table_header_children.volume"),
        },
        7: {
          width: "10%",
          name: this.$t("delivery-status.table_header_children.abnormality"),
        },
        8: {
          width: "10%",
          name: this.$t("delivery-status.table_header_children.notices"),
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
    dragStart(event) {
      event.dataTransfer.setData('text/plain', JSON.stringify(this.item.id));
      const draggedData = event.dataTransfer.getData('text/plain');
      this.idDraggedData = draggedData
    },
    dragEnd(event) {
      const endPosition = { x: event.clientX, y: event.clientY };
       if(event.clientX < 1000){
        this.$emit("idDrag", this.idDraggedData)
       }
      
    },

    
  },
};
</script>
<style scoped lang="scss">
.content-item {
  .row-table {
    display: flex;
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
  }

  .detail-icon {
    width: 40%;
    height: 100%;
    text-align: center;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .cell-border{
    border-right: 1px solid #ccc;
    padding: 0 4px;
  }
}
</style>
