<template>
  <section>
    <div class="container-fluid">
      <div class="card bg-condition">
        <div class="card-body">
          <div class="row">
            <div class="w-100 wrap-scroll" :class="contentHeight">
              <div
                class="row search-result pl-2 mg-0 wrap-scroll-dispatch-title"
              >
                <label>{{ $t("label.search_results") }} </label>
              </div>
              <div
                class="text-center row-table header-row w-100 item-scroll wrap-scroll-dispatch-header"
              >
                <template v-for="(header, idx) in tableHeader">
                  <div
                    class="d-flex cell font-weight-bold bg-header"
                    :style="{ width: header.width }"
                    :key="idx"
                  >
                    {{ header.name }}
                  </div>
                </template>
              </div>
              <template>
                <ContentItem
                  :item="item"
                  v-for="(item, idx) in listSlcOmsT1Order"
                  :key="idx"
                  :style="
                    idx % 2 != 0 ? 'background-color: var(--color-row)' : ''
                  "
                />
              </template>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid footer-item">
      <div class="card bg-condition">
        <div class="card-footer">
          <div class="row">
            <div class="col-md-1">
              <button
                class="btn btn-warning text-nowrap text-white"
                style="background-color: #f89039"
                @click="exportCsv()"
              >
                <i class="fas fa-file"></i>
                {{ this.$t("button.data_output") }}
              </button>
            </div>

            <div class="col-md-11 text-right">
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
import moment from "moment";
import ContentItem from "./ContentItem.vue";
import { DATE_FORMAT_SLASH } from "@/constants";

export default {
  components: {
    ContentItem,
  },
  props: {
    listSlcOmsT1Order: {
      type: Array,
    },
  },
  data() {
    return {
      isShowDetail: false,
      checkBoxChild: "",
      estimateShippingDate: null,
      deadline: null,
      contentHeight: "scroll-max-height",
    };
  },
  async created() {},
  computed: {
    tableHeader() {
      return {
        0: {
          width: "2%",
          name: "",
        },
        1: {
          width: "7%",
          name: this.$t("order-history.label.table.headers.order_number"),
        },
        2: {
          width: "6%",
          //order_no
          name: this.$t("order-history.label.table.headers.order_no"),
        },
        3: {
          width: "7%",
          //customer
          name: this.$t("order-history.label.table.headers.status"),
        },

        4: {
          width: "13%",
          name: this.$t("order-history.label.table.headers.customer_name"),
        },
        5: {
          width: "9%",
          name: this.$t("order-history.label.table.headers.delivery_code"),
        },
        6: {
          width: "15%",
          name: this.$t("order-history.label.table.headers.delivery_name"),
        },
        7: {
          width: "25%",
          name: this.$t("order-history.label.table.headers.shipping_address"),
        },
        8: {
          width: "10%",
          name: this.$t("order-history.label.table.headers.number_item"),
        },
        9: {
          width: "7%",
          name: this.$t("order-history.label.table.headers.total_quanlity"),
        },
      };
    },
    setHeaderColor() {
      return {
        backgroundColor: "#2F75B5",
      };
    },
  },

  methods: {
    moment,
    showDetailData() {
      this.isShowDetail = !this.isShowDetail;
    },
    redirectToDownloadScreen() {
      this.$router.push({ path: "/data-download" });
    },
    goBack() {
      this.$router.push("/main");
    },
    handleHeightContent() {
      this.contentHeight =
        this.contentHeight == "scroll-max-height"
          ? "scroll-min-height"
          : "scroll-max-height";
    },
    exportCsv() {
      const data = [];
      if (this.listSlcOmsT1Order.length > 0) {
        this.listSlcOmsT1Order.forEach((item) => {
          item.forEach((child, index) => {
            const subData = {
              発注番号: child?.denpyono,
              受注No: child?.orderno,
              ステータス: child?.status_name,
              得意先: child?.nhsakicd,
              配送先ｺｰﾄﾞ: child?.nhsaki_name1,
              納入先名: child?.nhsaki_ad1,
              納入先住所: item?.denpyono,
              明細数: item?.countDenpyono,
              数量合計: child?.count_ship_num1,
              index: index + 1,
              ステータス: child?.status_name,
              商品コード: child?.itemcd,
              商品名: child?.item_name,
              ロットNo: child?.lotno,
              管理日付:
                moment(child?.symlmt).format(DATE_FORMAT_SLASH) ==
                "Invalid date"
                  ? ""
                  : moment(child?.symlmt).format(DATE_FORMAT_SLASH),
              発注数: child?.order_num1,
              入数: child?.irisu,
              入荷予定数: child?.ship_num1,
              仕入価格: `¥${child?.sell_amount}`,
              倉庫: child?.warehouse_name,
              出荷日:
                moment(child?.ship_date).format(DATE_FORMAT_SLASH) ==
                "Invalid date"
                  ? ""
                  : moment(child?.ship_date).format(DATE_FORMAT_SLASH),
              納期:
                moment(child?.納品予定日).format(DATE_FORMAT_SLASH) ==
                "Invalid date"
                  ? ""
                  : moment(child?.納品予定日).format(DATE_FORMAT_SLASH),
              配送完了日:
                moment(child?.delivery_completion_date).format(
                  DATE_FORMAT_SLASH
                ) == "Invalid date"
                  ? ""
                  : moment(child?.delivery_completion_date).format(
                      DATE_FORMAT_SLASH
                    ),
              配送No: child?.ship_document_num,
            };
            data.push(subData);
          });
        });
        const headers = [
          "発注番号",
          "受注No",
          "ステータス",
          "得意先",
          "配送先ｺｰﾄﾞ",
          "納入先名",
          "納入先住所",
          "明細数",
          "数量合計",
          "index",
          "ステータス",
          "商品コード",
          "商品名",
          "ロットNo",
          "管理日付",
          "発注数",
          "入数",
          "入荷予定数",
          "仕入価格",
          "倉庫",
          "出荷日",
          "納期",
          "配送完了日",
          "配送No",
        ];

        const csvContent = this.createCSVContent(headers, data);
        console.log("save");
        const encodedUri = encodeURI(csvContent);
        const link = document.createElement("a");
        link.setAttribute("href", encodedUri);
        link.setAttribute("download", "data.csv");
        document.body.appendChild(link);

        link.click();

        document.body.removeChild(link);
      } else {
        this.$toast.error("まだ出力データがありません");
      }
    },
    createCSVContent(headers, data) {
      const csvContent = [];
      csvContent.push(headers.join(","));

      data.forEach((item, index) => {
        const row = headers.map((header) => {
          const value = item[header.toLowerCase()];
          if (header === "エラー") return this.validateData(item, index);

          if (typeof value === "string" && value.includes(",")) {
            return `"${value}"`;
          }
          return value;
        });

        csvContent.push(row.join(","));
      });

      return "data:text/csv;charset=utf-8," + csvContent.join("\n");
    },
  },
};
</script>

<style scoped>
.table {
  background-color: #fff;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  overflow: hidden;
  width: 80%;
  max-width: 800px;
}

.row-table {
  display: flex;
  border-bottom: 1px solid #ccc;
  border: 1px solid #ccc;
  border-right: 0;
  background-color: #d9d9d9;
}

.cell {
  border-right: 1px solid #ccc;
}

.search-result {
  border: 1px solid #ccc;
  border-bottom: 0;
}

.btn-back {
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

.btn-back:hover {
  color: #212529;
  background-color: #e9ecef;
}
.card-footer {
  background-color: #fff;
  border-radius: 0.25rem;
}

.mg-0 {
  margin: 0;
}
.mg-0 label {
  margin: 4px;
}

.scroll-min-height {
  max-height: 385px;
  overflow-y: auto;
}

.scroll-max-height {
  max-height: 615px;
  overflow-y: auto;
}
</style>
