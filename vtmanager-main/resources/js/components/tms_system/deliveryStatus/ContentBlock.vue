<template>
  <section>
    <div class="container-fluid">
      <div class="card content">
        <div class="card-body">
          <div class="row" :class="contentHeight">
            <div class="w-100">
              <div class="border-common pl-2 wrap-scroll-dispatch-title">
                <label>{{ $t("label.search_results") }} </label>
              </div>
              <div
                style="border-left: 1px solid #ccc"
                class="row-table header-row text-center w-100 item-scroll wrap-scroll-dispatch-header"
              >
                <template v-for="(header, idx) in tableHeader">
                  <div
                    class="cell font-weight-bold bg-header"
                    :key="idx"
                    :style="{ width: header.width }"
                  >
                    {{ header.name }}
                  </div>
                </template>
              </div>
              <template>
                <ContentItem
                  v-for="(item, idx) in setListResult"
                  :item="item"
                  :key="idx"
                  :style="
                    idx % 2 == 1 ? 'background-color: var(--color-row)' : ''
                  "
                />
              </template>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid footer-item">
      <div class="card">
        <div class="card-body">
          <div class="row">
            <div class="col-lg-10 p-0">
              <button class="btn btn-shipping-list">
                <font-awesome-icon icon="fas fa-file" />
                印　刷
              </button>
              &emsp;
              <button class="btn btn-shipping-list">
                <font-awesome-icon icon="fas fa-file" />
                車両別配送一覧
              </button>
              &emsp;
              <button class="btn btn-shipping-list">
                <font-awesome-icon icon="fas fa-file" />
                配送伝票
              </button>
            </div>
            <div class="col-lg-2 text-right p-0">
              <button class="btn btn-back" @click="goBack()">
                <font-awesome-icon icon="fas fa-arrow-left" />
                {{ $t("button.back") }}
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import ContentItem from "./ContentItem.vue";
import moment from "moment";
export default {
  components: {
    ContentItem,
  },
  props: {
    setListResult: {
      type: Array,
    },
  },

  data() {
    return {
      isShowDetail: false,
      selectAll: null,
      contentHeight: "scroll-max-height",
    };
  },
  computed: {
    tableHeader() {
      return {
        0: {
          width: "3%",
          name: "",
        },
        1: {
          width: "8%",
          name: "出荷日", //this.$t("delivery-status.label.table.headers.ship_or_delivery_date"),
        },
        2: {
          width: "15%",
          name: "出荷倉庫", //this.$t("delivery-status.label.table.headers.status"),
        },
        3: {
          width: "10%",
          name: "ステータス", //this.$t("delivery-status.label.table.headers.shipping_course_name"),
        },
        4: {
          width: "15%",
          name: "配送コース名", //this.$t("delivery-status.label.table.headers.delivery_company"),
        },
        5: {
          width: "6%",
          name: "納品先数", //  this.$t("delivery-status.label.table.headers.vehicle_number"),
        },
        6: {
          width: "15%",
          name: "配送会社", //this.$t("delivery-status.label.table.headers.vehicle_size"),
        },
        7: {
          width: "12%",
          name: "車両番号", //this.$t("delivery-status.label.table.headers.loading_rate"),
        },
        8: {
          width: "12%",
          name: "車両サイズ",
        },
        9: {
          width: "5%",
          name: "積載率",
        },
      };
    },
  },
  methods: {
    moment,
    goBack() {
      this.$router.push({ path: "/main" });
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
    border-right: 0;
  }

  .cell {
    border-right: 1px solid #ccc;
    display: flex;
    background-color: #d9d9d9;
    justify-content: center;
    align-items: center;
  }
}

.content-item {
  .cell {
    background-color: #fff;
    border-right: 1px solid #ccc;
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .cell:first-child {
    border-left: 1px solid #ccc;
  }
}

.btn-shipping-list {
  border: 1px solid #ddd;
  display: inline-block;
  font-weight: 400;
  color: white;
  text-align: center;
  vertical-align: middle;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
  background-color: #f89039;
  padding: 0.25rem 0.75rem;
  font-size: 1rem;
  line-height: 1.5;
  border-radius: 0.25rem;
  transition: color 0.15s ease-in-out, background-color 0.15s ease-in-out,
    border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}

.btn-shipping-list:hover {
  color: white;
  background-color: #f5a462;
}

.scroll-min-height {
  max-height: 290px;
  overflow-y: auto;
}

.scroll-max-height {
  max-height: 460px;
  overflow-y: auto;
}
</style>
