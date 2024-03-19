<template>
  <div>
    <div class="container-fluid content">
      <div class="card">
        <div class="card-body">
          <div class="form-row search">
            <div class="form-group col-lg-2 search__group">
              <label class="mr-1 d-flex align-items-center"
                >{{
                  $t(
                    "delivery-completion-report.label.form.delivery_completion_date"
                  )
                }}
                <span class="badge badge-danger" style="margin-bottom: 5px"
                  >必须</span
                >
              </label>
              <date-picker
                format="MM/DD"
                id="datePicker1"
                :clearable="false"
                class="search__group--date"
              >
                <template v-slot:icon-calendar>
                  <font-awesome-icon icon="fas fa-calendar-alt" />
                </template>
              </date-picker>
            </div>
          </div>

          <div class="table-item form-group">
            <div class="row-table text-center w-100">
              <template v-for="(header, idx) in tableHeader">
                <div
                  class="cell font-weight-bold bg-header"
                  :style="{ width: header.width }"
                  :key="idx"
                >
                  {{ header.name }}
                </div>
              </template>
            </div>
            <template>
              <ContentItem
                v-for="(item, idx) in setListResult"
                :key="idx"
                :item="item"
              />
            </template>
            <div class="d-flex mt-4 form-group">
              <div class="col-lg-2">
                <button class="btn btn-register">
                  <font-awesome-icon icon="fas fa-pencil-alt" />&nbsp;{{
                    $t("button.confirm")
                  }}
                </button>
              </div>
              <div class="col-lg-2">
                <button class="btn btn-clear">
                  <font-awesome-icon
                    :icon="['fas', 'share']"
                    flip="horizontal"
                  />&nbsp;{{ $t("button.reset") }}
                </button>
              </div>
            </div>
          </div>

          <div class="table-item form-group">
            <div class="row-table text-center w-100">
              <template v-for="(header, idx) in tableHeader">
                <div
                  class="cell font-weight-bold bg-header"
                  :style="{ width: header.width }"
                  :key="idx"
                >
                  {{ header.name }}
                </div>
              </template>
            </div>

            <template>
              <ContentItemSecond
                v-for="(item, idx) in setListResult"
                :key="idx"
                :item2="item"
              />
            </template>
          </div>
        </div>
      </div>

      <div class="card">
        <div class="card-body">
          <div class="row justify-content-end">
            <button class="btn btn-back" @click="goBack()">
              <font-awesome-icon icon="fas fa-arrow-left" />{{
                $t("button.back")
              }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ContentItem from "./ContentItem.vue";
import ContentItemSecond from "./ContentItemSecond.vue";

export default {
  components: {
    ContentItem,
    ContentItemSecond,
  },
  props: {
    setListResult: {
      type: Array,
    },
  },
  data() {
    return {};
  },
  computed: {
    tableHeader() {
      return {
        0: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.headers.delivery_course_name"
          ),
        },
        1: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.headers.vehicle_number"
          ),
        },
        2: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.headers.vehicle_size"
          ),
        },
        3: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.headers.ship_or_delivery_date"
          ),
        },
        4: {
          width: "25%",
          name: this.$t(
            "delivery-completion-report.label.table.headers.customer"
          ),
        },
        5: {
          width: "5%",
          name: this.$t(
            "delivery-completion-report.label.table.headers.total_number"
          ),
        },
        6: {
          width: "10%",
          name: this.$t(
            "delivery-completion-report.label.table.headers.number_delivery_destination"
          ),
        },
        7: {
          width: "15%",
          name: this.$t(
            "delivery-completion-report.label.table.headers.slip_issue_date"
          ),
        },
      };
    },
  },
  methods: {
    goBack() {
      this.$router.push({ path: "/main" });
    },
  },
};
</script>
<style lang="scss">
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

  .table-item {
    width: 70%;
  }

  .content-item {
    .cell {
      background-color: white;
    }
  }
}
</style>
