<template>
  <div>
    <section>
      <div class="container-fluid pt-2">
        <div class="card">
          <div class="card-body" style="min-height: 713px">
            <div class="row">
              <label class="form-check-label col-lg-12">{{
                $t("data-download.label.file_layout_definition")
              }}</label>
              <div class="col-lg-3">
                <select
                  class="form-control col-md-9"
                  v-model="fileDefined"
                  style="margin-top: 8px"
                >
                  <option value=""></option>
                  <option
                    v-for="(item, index) in selectLayoutDefine"
                    :value="item.defineNo"
                    :key="index"
                  >
                    {{ item.defineName }}
                  </option>
                  <!--発注履歴照会　データ出力-->
                </select>
              </div>
            </div>
            <div class="row">
              <div class="col-md-12">&ensp;</div>
            </div>
            <div class="row" v-show="dateClassification == 1 ? true : false">
              <label
                class="form-check-label col-lg-12"
                style="margin-bottom: 8px"
                >{{ $t("data-download.label.target_date") }}</label
              >
              <div class="date-picker-wrapper">
                <date-picker
                  format="YYYY/MM/DD"
                  class="col-md-5"
                  id="datePicker1"
                  :clearable="false"
                  v-model="targetDateFrom"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
                <label for="" class="date-range-label col-md-1 text-center"
                  >～</label
                >
                <date-picker
                  format="YYYY/MM/DD"
                  class="col-md-5"
                  id="datePicker2"
                  :clearable="false"
                  v-model="targetDateTo"
                >
                  <template v-slot:icon-calendar>
                    <font-awesome-icon icon="fas fa-calendar-alt" />
                  </template>
                </date-picker>
              </div>
            </div>
          </div>
        </div>
        <div class="card">
          <div class="card-footer">
            <div class="row">
              <div class="col-lg-6 text-nowrap">
                <button class="btn btn-default" @click="download()">
                  <font-awesome-icon icon="fas fa-download" />
                  &ensp;{{ $t("button.download") }}
                </button>
              </div>
              <div class="col-lg-6 text-right p-0">
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
    <DownloadModal
      v-show="isShowModal"
      @close="closeModal"
      @select="selectOption"
    />
  </div>
</template>

<script>
import DownloadModal from "@/components/modals/DownloadModal.vue";
import { getOrderHistory } from "@/services/APIs/OMSService";
import moment from "moment";
export default {
  components: {
    DownloadModal,
  },
  data() {
    return {
      isShowModal: false,
      listOrder: [],
      fileDefined: null,
      targetDateTo: null, //this.targetDateTo = moment(this.targetDateTo).format("YYYYMMDD");
      targetDateFrom: null, //this.targetDateFrom = moment(this.targetDateFrom).format("YYYYMMDD");

      //datatest
      selectLayoutDefine: null, //dropdown
      dateClassification: 1, // 1 search where date, #1 skip form date  / "0" Hide "1" Display
      dateUseClassification: 1, // "1".Order date "2".Shipping date "3".Delivery date   - remaining from 00000000 to 99999999
      orderDateFrom: "00000000",
      orderDateTo: "99999999",
      shippingDateFrom: "00000000",
      shippingDateTo: "99999999",
      delliveryDateFrom: "00000000",
      delivaeryDateTo: "99999999",
    };
  },
  async created() {
    this.$store.dispatch("auth/setTitle", this.$t("data-download.label.title"));
    this.listOrder = await getOrderHistory({});
    this.selectLayoutDefine = [
      {
        defineNo: 1,
        defineName: "定義名1",
      },
      {
        defineNo: 2,
        defineName: "定義名2",
      },
    ];
    this.searchCalssificationDate();
  },
  methods: {
    searchCalssificationDate() {
      if (this.dateUseClassification == 1) {
        this.orderDateFrom = moment(this.targetDateFrom).format("YYYYMMDD");
        this.orderDateTo = moment(this.targetDateTo).format("YYYYMMDD");
      } else if (this.dateUseClassification == 2) {
        this.shippingDateFrom = moment(this.targetDateFrom).format("YYYYMMDD");
        this.shippingDateTo = moment(this.targetDateTo).format("YYYYMMDD");
      } else if (this.dateUseClassification == 3) {
        this.delliveryDateFrom = moment(this.targetDateFrom).format("YYYYMMDD");
        this.delivaeryDateTo = moment(this.targetDateTo).format("YYYYMMDD");
      }
    },
    download() {
      if (this.fileDefined == 1) {
        this.isShowModal = true;
      }
    },
    closeModal() {
      this.isShowModal = false;
    },
    async selectOption(option) {
      const data = this.listOrder;
      const headers = [
        "発注番号",
        "受注No",
        "得意先",
        "納入先ｺｰﾄﾞ",
        "納入先名",
        "納入先住所",
        "明細数",
        "数量合計",
      ];
      const headerChilds = [
        "    ",
        "ステータス",
        "商品コード",
        "商品名",
        "ロットNo",
        "管理日付",
        "発注数",
        "入数",
        "納入数",
        "価格",
        "倉庫",
        "出荷予定日",
        "納期",
        "配送No",
      ];

      const csvContent = this.createCSVContent(
        headers,
        data,
        option,
        headerChilds
      );
      const blob = new Blob([csvContent], {
        type: "text/csv;charset=utf-8;",
      });
      switch (option) {
        case 1:
          console.log("save");
          const encodedUri = encodeURI(csvContent);
          const link = document.createElement("a");
          link.setAttribute("href", encodedUri);
          link.setAttribute("download", "data.csv");
          document.body.appendChild(link);

          link.click();

          document.body.removeChild(link);
          break;
        case 2:
          console.log("saveAs");

          window
            .showSaveFilePicker({ suggestedName: `data.csv` })
            .then((fileHandle) => fileHandle.createWritable())
            .then((stream) => {
              stream.write(blob);
              stream.close();
            })
            .then(() => {
              const tempUrl = window.URL.createObjectURL(blob);
              const tempLink = document.createElement("a");
              tempLink.href = tempUrl;
              tempLink.setAttribute("download", `data.csv`);
              document.body.appendChild(tempLink);
              tempLink.style.display = "none";
              tempLink.click();
              setTimeout(() => {
                document.body.removeChild(tempLink);
                window.URL.revokeObjectURL(tempUrl);
              }, 100);
            })
            .catch((err) => console.log("SaveFile aborted"));
          break;
        case 3:
          console.log("open");
          break;
        default:
          break;
      }
    },
    createCSVContent(headers, data, option = 1, headerChilds) {
      console.log(123);
      const csvContent = [];
      csvContent.push(headers.join(","));

      data.forEach((item) => {
        const rowParent =
          item?.denpyono +
          "," +
          item?.order_no +
          "," +
          item?.tokuisaki_nm +
          "," +
          item?.nhsaki_cd +
          "," +
          this.subString(item?.nhsaki_name1 + "" + item?.nhsaki_name2) +
          "," +
          this.subString(item?.nhsaki_ad1 + " " + item?.nhsaki_ad2) +
          "," +
          ",";
        csvContent.push(rowParent);
        csvContent.push(headerChilds.join(","));
        const rowChilds =
          "  " +
          item?.meisai_no +
          "," +
          "statusname" +
          "," +
          item?.item_cd +
          "," +
          item?.nhsaki_item_name +
          "," +
          item?.lot_no +
          "," +
          moment(item?.symlmt).format("YYYY/MM/DD") +
          "," +
          item.order_num1 +
          "," +
          item.irisu +
          "," +
          item.ship_num1 +
          "," +
          item.irisu +
          "," +
          item.sell_amount +
          "," +
          "branch_name" +
          "," +
          moment(item?.ship_date).format("YYYY/MM/DD") +
          "," +
          moment(item?.delivery_date).format("YYYY/MM/DD");
        csvContent.push(rowChilds);
      });

      return option === 1
        ? "data:text/csv;charset=utf-8," + csvContent.join("\n")
        : csvContent.join("\n");
    },
    subString(string) {
      return string.length <= 40 ? string : string.slice(1, 40);
    },
    goBack() {
      this.$router.push({
        path: "/main",
      });
    },
  },
};
</script>

<style>
.card-footer {
  background-color: #fff;
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

label {
  font-weight: bold;
}
</style>
