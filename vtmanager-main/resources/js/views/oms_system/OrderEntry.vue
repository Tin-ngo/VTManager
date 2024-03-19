<template>
  <section class="main-section">
    <div class="container-fluid pt-2">
      <div class="card">
        <div class="card-body">
          <div class="form-row">
            <div class="form-group col-lg-4">
              <label class="form-check-label">{{
                $t("order-entry.label.form.upload_order_data")
              }}</label>
              <div>
                <input
                  type="file"
                  class="d-none"
                  @change="onFileChange"
                  id="file"
                />
                <button class="btn btn-default" @click="openFileDialog">
                  {{ $t("order-entry.label.form.select_file") }}
                </button>
                {{ currentFileName || noNameFile }}
              </div>
            </div>
            <div class="form-group col-lg-2">
              <label class="form-check-label">{{
                $t("order-entry.label.form.import_definition")
              }}</label>
              <select class="form-control" v-model="itemNo">
                <option
                  v-for="(value, key) in captures"
                  :key="key"
                  :value="value"
                >
                  {{ key }}
                </option>
              </select>
            </div>
          </div>
          <div class="form-row">
            <div class="form-group col-lg-4">
              <button class="btn btn-default" @click="uploadFile">
                <font-awesome-icon icon="fas fa-file-upload" />&nbsp;{{
                  $t("order-entry.label.form.capture")
                }}
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid">
      <div class="card bg-condition">
        <div class="card-body">
          <div class="form-row">
            <label class="form-check-label">{{
              isErrorsData ? $t("order-entry.label.message") : ""
            }}</label>
          </div>
          <div class="row">
            <div class="w-100">
              <table class="w-100">
                <thead class="bg-header">
                  <tr class="text-center">
                    <template v-for="(header, idx) in tableHeader">
                      <td :key="idx">
                        {{ header }}
                      </td>
                    </template>
                  </tr>
                </thead>
                <tbody>
                  <tr
                    v-for="(item, index) in dataRegistration"
                    :key="`data${index}`"
                    :class="{ 'error-row': item?.isErrors }"
                  >
                    <td>{{ item["発注番号"] }}</td>
                    <td>{{ item["発注日"] }}</td>
                    <td>{{ item["納期"] }}</td>
                    <td>{{ item["納入先ｺｰﾄﾞ"] }}</td>
                    <td>{{ item["納入先名"] }}</td>
                    <td>{{ item["商品ｺｰﾄﾞ"] }}</td>
                    <td>{{ item["商品名"] }}</td>
                    <td>{{ item["ロット番号"] }}</td>
                    <td>{{ item["管理日付"] }}</td>
                    <td>{{ item["出荷予定数"] }}</td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid footer-item">
      <div class="card bg-condition">
        <div class="card-body">
          <div class="row justify-content-between">
            <button
              :class="
                !isErrorsData
                  ? 'btn btn-register'
                  : 'btn btn-warning text-white'
              "
              @click="!isErrorsData ? register() : downloadCSV()"
            >
              <font-awesome-icon
                :icon="!isErrorsData ? 'fas fa-pencil-alt' : 'fas fa-download'"
              />{{
                !isErrorsData ? $t("button.upload") : $t("button.output_error")
              }}
            </button>
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
import {
  uploadFile,
  getCaptureDefinitionDropdown,
  createOrder,
  getInfoFlagAndOverrideOrder,
  deleteOldT1Order,
} from "@/services/APIs/OMSService";

import { isEmpty } from "lodash";
import moment from "moment";

export default {
  data() {
    return {
      selectedFile: null,
      formData: null,
      currentFileName: null,
      noNameFile: this.$t("order-entry.label.form.not_selected"),
      dataRegistration: [],
      captures: [],
      itemNo: [],
      isErrorsData: false,
      orderNumberDelete: [],
      itemTitle: [
        "発注番号",
        "発注日",
        "納期",
        "納入先ｺｰﾄﾞ",
        "納入先名",
        "商品ｺｰﾄﾞ",
        "商品名",
        "ロット番号",
        "管理日付",
        "出荷予定数",
      ],
      infoOverride: [],
    };
  },
  computed: {
    tableHeader() {
      return {
        0: this.$t("order-entry.label.table.headers.order_no"),
        1: this.$t("order-entry.label.table.headers.order_date"),
        2: this.$t("order-entry.label.table.headers.deadline"),
        3: this.$t("order-entry.label.table.headers.delivery_no_cd"),
        4: this.$t("order-entry.label.table.headers.delivery_to_nm"),
        5: this.$t("order-entry.label.table.headers.commodity_cd"),
        6: this.$t("order-entry.label.table.headers.commodity_nm"),
        7: this.$t("order-entry.label.table.headers.lot_no"),
        8: this.$t("order-entry.label.table.headers.expiration_date"),
        9: this.$t("order-entry.label.table.headers.shipment_qty"),
      };
    },
  },
  watch: {
    itemNo: function (nv, ov) {
      console.log({ ov, nv });
    },
  },
  async created() {
    this.captures = await getCaptureDefinitionDropdown();
  },
  mounted() {
    this.$store.dispatch("auth/setTitle", this.$t("order-entry.label.title"));
  },
  methods: {
    openFileDialog() {
      document.getElementById("file").click();
    },
    async onFileChange(event) {
      const fileInput = event.target;
      if (fileInput.files && fileInput.files[0]) {
        const file = fileInput.files[0];
        const formData = new FormData();
        formData.append("file", file);
        this.formData = formData;
        this.currentFileName = file?.name;
      }
    },
    async uploadFile() {
      if (!this.formData?.get("file")) {
        return this.$toast.error(
          "アップロードを行うファイルを選択してください。"
        );
      }
      if (!this.itemNo.length) {
        return this.$toast.error("取込定義を選択してください。");
      }
      try {
        this.isErrorsData = false;
        const result = await uploadFile(this.formData);
        this.dataRegistration = result?.data?.csvData;
        await this.checkErrors(this.dataRegistration);
      } catch (error) {
        console.log({ error });
        return this.$toast.error(error?.message);
      }
    },
    goBack() {
      this.$router.push("/main");
    },
    async register() {
      const data = this.dataRegistration.map((item) => {
        return {
          発注番号: item["発注番号"],
          締め日: this.convertDate(item["納期"]),
          納品先商品コード: item["商品ｺｰﾄﾞ"],
          納品先商品名: item["商品名"],
          伝票番号: item["ロット番号"],
          管理日付: this.convertDate(item["管理日付"]),
          出荷数: item["出荷予定数"],
          欠品数: item["出荷予定数バラ"],
          ロットナンバー: item["ロット番号"],
          出荷数: item["出荷予定数ボール"],
          納入先ｺｰﾄﾞ: item["納入先ｺｰﾄﾞ"],
          発注日: this.convertDate(item["発注日"]),
          fieldRegister: this.itemNo.map((item) => item.ＤＢ項目名),
        };
      });
      try {
        await createOrder(data);
        this.$toast.success("アップロード成功");
      } catch (error) {
        this.$toast.error(error?.message);
      }
    },
    convertDate(date) {
      return moment(date, "YYYY/MM/DD").format("YYYYMMDD");
    },
    async checkErrors(data) {
      this.infoOverride = await getInfoFlagAndOverrideOrder({
        list: "0,1,2,3,4,5,6,7,8,9",
      });
      for (const [index, item] of data.entries()) {
        data[index]["isErrors"] = false;
        const errors = this.validateDataV2(item, index);
        console.log({ errors });
        if (errors !== "") {
          data[index]["isErrors"] = true;
          this.isErrorsData = true;
        }
      }
      console.log({ orderNumberDelete: this.orderNumberDelete });
      await deleteOldT1Order({
        orderNumber: this.orderNumberDelete,
      });
    },
    isInteger(value) {
      return /^[0-9]+$/.test(value);
    },
    validateData(data, index) {
      const errors = [];
      const requiredColumns = [
        "発注番号",
        "発注日",
        "納期",
        "納入先ｺｰﾄﾞ",
        "商品ｺｰﾄﾞ",
        "商品名",
        "ロット番号",
        "管理日付",
        "出荷予定数",
        "出荷予定数ボール",
        "出荷予定数バラ",
      ];
      const numberOfShipment = parseInt(data?.["出荷予定数"]);
      const numberOfBallShipped = parseInt(data?.["出荷予定数ボール"]);
      const numberOfShipmentQuantity = parseInt(data?.["出荷予定数バラ"]);

      for (const column of requiredColumns) {
        if (isEmpty(data?.[column])) {
          errors.push(`${index}行目　<${column}>がブランクです。`);
          data.this.isErrorsData = true;
        }
      }

      const numericColumns = [
        "出荷予定数",
        "出荷予定数ボール",
        "出荷予定数バラ",
      ];
      const numericRegex = /^\d+$/;
      for (const column of numericColumns) {
        if (!numericRegex.test(data?.[column])) {
          errors.push(
            `${index}行目　<${column}>は半角数値で入力してください。`
          );
        }
      }

      const alphanumericColumns = ["納入先ｺｰﾄﾞ", "商品ｺｰﾄﾞ"];
      const alphanumericRegex = /^[a-zA-Z0-9]+$/;
      for (const column of alphanumericColumns) {
        if (!alphanumericRegex.test(data?.[column])) {
          errors.push(
            `${index}行目　<${column}>は半角英数で入力してください。`
          );
        }
      }

      const maxLengthColumns = {
        発注番号: 10,
        商品名: 50,
      };
      for (const column in maxLengthColumns) {
        const maxLength = maxLengthColumns[column];
        if (data?.[column]?.length > maxLength) {
          errors.push(`${index}行目　<${column}>　桁数オーバー。`);
        }
      }

      if (
        `${numberOfShipment},${numberOfBallShipped},${numberOfShipmentQuantity}` ===
        "0,0,0"
      ) {
        errors.push(
          `${index}行目 出荷予定数はいずれかに1以上の数を入力してください。`
        );
      }

      const dateColumns = ["発注日", "納期", "管理日付"];
      for (const column of dateColumns) {
        if (!moment(data?.[column], "YYYY/MM/DD").isValid()) {
          errors.push(
            `「${index}行目　<${column}>は日付を入力してください。」`
          );
        }
      }

      if (moment(data?.["発注日"], "YYYY/MM/DD").unix() < moment().unix()) {
        errors.push(`${index}行目　納期は本日以降の日付を入力してください。`);
      }

      return errors.length > 0 ? errors.join(";") : "";
    },
    validateDataV2(data, index) {
      console.log({ data, index });
      const errors = [];
      const findItemNo = this.itemNo.find(
        (item) => parseInt(item.列ＮＯ) === index
      );
      if (isEmpty(findItemNo)) return "";
      const columnNo = parseInt(findItemNo?.列ＮＯ);
      const column = this.itemTitle[columnNo];
      const numericRegex = /^\d+$/;
      const alphanumericRegex = /^[a-zA-Z0-9]+$/;
      const maxLength = findItemNo?.桁数 || 0;
      console.log({ findItemNo, itemNo: this.itemNo, column });
      switch (findItemNo?.必須区分) {
        case "1":
          if (isEmpty(data?.[column])) {
            errors.push(`${index}行目　<${column}>がブランクです。`);
          }
          break;
      }
      switch (findItemNo?.データチェック区分) {
        case "1":
          if (!numericRegex.test(data?.[column])) {
            errors.push(
              `${index}行目　<${column}>は半角数値で入力してください。`
            );
          }
          break;
        case "2":
          if (!moment(data?.[column], "YYYY/MM/DD").isValid()) {
            errors.push(
              `${index}行目　<${column}>は半角数値で入力してください。`
            );
          }
          break;
        case "3":
          if (!alphanumericRegex.test(data?.[column])) {
            errors.push(
              `${index}行目　<${column}>は半角英数で入力してください。`
            );
          }
          break;
      }
      if (data?.[column]?.length > maxLength) {
        errors.push(`${index}行目　<${column}>　桁数オーバー。`);
      }
      if (findItemNo?.ＤＢ項目名 === "受注番号") {
        if (parseInt(data?.[column]) < 1) {
          errors.push(
            `「${index}行目　出荷予定数はいずれかに1以上の数を入力してください。」`
          );
        }
      }
      const findInfoFlagOverride = this.infoOverride.find(
        (item) => item.受注番号 === columnNo
      );
      if (findItemNo?.ＤＢ項目名 === "受注番号" && findInfoFlagOverride) {
        if (findInfoFlagOverride?.締めフラグ === "1") {
          this.orderNumberDelete.push(columnNo);
          errors.push(`「${index}行目　締め処理が完了しています。」`);
        } else if (
          findInfoFlagOverride?.締めフラグ === "0" &&
          findInfoFlagOverride?.取込上書可否区分 === "0"
        ) {
          errors.push(`「${index}行目　上書き禁止の得意先です。」`);
        }
      }
      return errors.length > 0 ? errors.join(";") : "";
    },
    downloadCSV() {
      const headers = [
        "発注番号",
        "発注日",
        "納期",
        "納入先ｺｰﾄﾞ",
        "納入先名",
        "商品ｺｰﾄﾞ",
        "商品名",
        "ロット番号",
        "管理日付",
        "製造番号",
        "出荷予定数",
        "出荷予定数ボール",
        "出荷予定数バラ",
        "エラー",
      ];
      const csvContent = this.createCSVContent(headers, this.dataRegistration);
      const encodedUri = encodeURI(csvContent);
      const link = document.createElement("a");
      link.setAttribute("href", encodedUri);
      link.setAttribute("download", "error.csv");
      document.body.appendChild(link);

      link.click();

      document.body.removeChild(link);
    },
    createCSVContent(headers, data, option = 1) {
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

      return option === 1
        ? "data:text/csv;charset=utf-8," + csvContent.join("\n")
        : csvContent.join("\n");
    },
  },
};
</script>
<style scoped>
table,
th,
td {
  border: 1px solid #ccc !important;
  border-collapse: collapse;
}

.error-row {
  background-color: #f16a6a;
}
</style>
