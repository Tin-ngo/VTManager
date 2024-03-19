<template>
  <section class="content">
    <div class="container-fluid">
      <div class="card">
        <div class="card-body">
          <div class="row">
            <div class="w-100" :class="contentHeight">
              <div class="border-common pl-2 wrap-scroll-dispatch-title">
                <label>{{ $t("label.search_results") }} </label>
              </div>
              <div
                class="row-table text-center w-100 item-scroll wrap-scroll-dispatch-header"
              >
                <template v-for="(header, idx) in tableHeader">
                  <div
                    class="cell font-weight-bold bg-header"
                    :key="idx"
                    v-if="idx == 1"
                    :style="{ width: header.width }"
                  >
                    {{ header.name }}
                    <input
                      type="checkbox"
                      :checked="isCheckedContent"
                      @change="changeAll"
                      style="width: 20px; height: 20px; margin-left: 5px"
                    />
                  </div>
                  <div
                    v-else
                    :key="`${idx}b`"
                    class="cell font-weight-bold bg-header"
                    :style="{ width: header.width }"
                  >
                    {{ header.name }}
                  </div>
                </template>
              </div>
              <template :options="{ animation: 150 }">
                <draggable v-model="parentRendering" @end="changeDraggable">
                  <ContentItem
                    v-for="(item, idx) in parentRendering"
                    :key="idx"
                    :item="item"
                    :isChecked="selectedItemId.includes(item?.parent.id)"
                    @changeSelectAll="changeSelectAll"
                  />
                </draggable>
              </template>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid footer-item">
      <div class="card">
        <div class="row card-body">
          <div class="col-lg-1 p-0">
            <button class="btn btn-register">
              <font-awesome-icon icon="fas fa-pencil-alt" />
              {{ $t("button.register") }}
            </button>
          </div>
          <div class="col-lg-10">
            <button
              class="btn btn-course-setting"
              @click="transerScreenToShipCourse()"
            >
              <font-awesome-icon icon="fas fa-cog" />{{
                $t("button.course_master_setting")
              }}
            </button>
          </div>
          <div class="col-lg-1 text-right p-0">
            <button class="btn btn-back" @click="goBack()">
              <font-awesome-icon icon="fas fa-arrow-left" />
              {{ $t("button.back") }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import moment from "moment";
import ContentItem from "./ContentItem.vue";
import draggable from "vuedraggable";
import { orderBy, sortBy } from "lodash";

export default {
  components: {
    ContentItem,
    draggable,
  },
  props: {
    setListResult: {
      type: Array,
    },
  },
  data() {
    return {
      isShowDetail: false,
      selectedItemId: [],
      parentRendering: [],
      draggingIndex: -1,
      contentHeight: "scroll-max-height",
    };
  },
  watch: {
    setListResult() {
      this.parentRendering = this.setListResult;
      const order = this.$store.state.orderDraggable.dispatchSettingOrder;
      const orderItem = order?.["parent"];
      if (orderItem) {
        this.parentRendering = sortBy(this.setListResult, function (item) {
          return orderItem.indexOf(item?.parent?.id);
        });
      }
    },
  },
  computed: {
    tableHeader() {
      return {
        0: {
          width: "2%",
          name: " ",
        },
        1: {
          width: "7%",
          name: this.$t("dispatch-setting.label.table.headers.confirm_target"),
        },
        2: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.ship_date"),
        },
        3: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.delivery_date"),
        },
        4: {
          width: "7%",
          name: this.$t("dispatch-setting.label.table.headers.status"),
        },
        5: {
          width: "7%",
          name: this.$t("dispatch-setting.label.table.headers.shipping_course"),
        },
        6: {
          width: "10%",
          name: this.$t(
            "dispatch-setting.label.table.headers.delivery_company"
          ),
        },
        7: {
          width: "10%",
          name: this.$t("dispatch-setting.label.table.headers.vehicle_number"),
        },
        8: {
          width: "7%",
          name: this.$t("dispatch-setting.label.table.headers.vehicle_size"),
        },
        9: {
          width: "10%",
          name: this.$t("dispatch-setting.label.table.headers.loading_rate"),
        },
        10: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.total_volume"),
        },
        11: {
          width: "5%",
          name: this.$t("dispatch-setting.label.table.headers.total_number"),
        },
        12: {
          width: "5%",
          name: this.$t(
            "dispatch-setting.label.table.headers.number_delivery_destination"
          ),
        },
        13: {
          width: "10%",
          name: this.$t("dispatch-setting.label.table.headers.child_or_dry"),
        },
        14: {
          width: "5%",
          name: "",
        },
      };
    },
    isCheckedContent() {
      return (
        JSON.stringify(orderBy(this.selectedItemId, [])) ===
        JSON.stringify(
          orderBy(
            this.setListResult.map((item) => item?.parent?.id),
            []
          )
        )
      );
    },
  },
  methods: {
    moment,
    showDetailData() {
      this.isShowDetail = !this.isShowDetail;
    },
    goBack() {
      this.$router.push({ path: "/main" });
    },
    changeSelectAll(status, id) {
      this.selectedItemId =
        status && !this.selectedItemId.includes(id)
          ? [...this.selectedItemId, id]
          : this.selectedItemId.filter((item) => item !== id);
    },
    changeAll(e) {
      this.selectedItemId = e.target.checked
        ? this.setListResult.map((item) => item?.parent?.id)
        : [];
    },
    handleDragStart(evt) {
      this.draggingIndex = evt.oldIndex;
    },
    handleDragEnd() {
      this.draggingIndex = -1;
    },
    startDragging(idx) {
      this.draggingIndex = idx;
    },
    changeDraggable(data) {
      this.draggingIndex = data.moved.newIndex;
      const orderItem = this.parentRendering.map((item) => item?.parent?.id);
      this.$store.dispatch("orderDraggable/updateOrderDispatchSetting", {
        parent: orderItem,
      });
    },
    transerScreenToShipCourse() {
      this.$router.push({ path: "/ship-course" });
    },
    handleHeightContent() {
      this.contentHeight =
        this.contentHeight == "scroll-max-height"
          ? "scroll-min-height"
          : "scroll-max-height";
    },
  },
};
</script>

<style scoped lang="scss">
.content {
  .border-common {
    border-bottom: 0;
  }

  .row-table {
    display: flex;
    border-bottom: 1px solid #ccc;
    border: 1px solid #d9d9d9;
    border-right: 0;
  }

  .cell {
    border-right: 1px solid #ccc;
    display: flex;
    background-color: #d9d9d9;
    justify-content: center;
    align-items: center;
  }

  .btn-course-setting {
    border: 1px solid #ddd;
    display: inline-block;
    font-weight: 400;
    color: #212529;
    text-align: center;
    vertical-align: middle;
    -webkit-user-select: none;
    -moz-user-select: none;
    -ms-user-select: none;
    user-select: none;
    background-color: transparent;
    padding: 0.25rem 1.75rem;
    font-size: 1rem;
    line-height: 1.5;
    border-radius: 0.25rem;
    transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out,
      border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
  }

  .btn-course-setting:hover {
    color: #212529;
    background-color: #e9ecef;
  }

  .scroll-min-height {
    max-height: 500px;
    overflow-y: auto;
  }

  .scroll-max-height {
    max-height: 585px;
    overflow-y: auto;
  }
}
</style>
