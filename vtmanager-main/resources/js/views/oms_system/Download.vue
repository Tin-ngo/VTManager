<template>
  <div>
    <section>
      <div class="container-fluid pt-2">
        <div class="card">
          <div class="card-body">
            <div class="row">
              <label class="form-check-label col-lg-1"
                >ファイルレイアウト定義
              </label>
              <div class="col-lg-2">
                <select class="form-control" v-model="fileDefined">
                  <option value=""></option>
                  <option value="1">発注履歴照会　データ出力</option>
                </select>
              </div>
              <div class="col-lg-1 text-nowrap">
                <button class="btn btn-default" @click="download()">
                  <font-awesome-icon icon="fas fa-download" />
                  ダウンロード
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
    };
  },
  async created() {
    this.$store.dispatch("auth/setTitle", "データダウンロード");
    this.listOrder = await getOrderHistory({});
  },
  methods: {
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
  },
};
</script>
