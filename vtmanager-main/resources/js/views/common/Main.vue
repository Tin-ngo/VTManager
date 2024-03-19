<template>
  <div>
    <section id="schedule-day">
      <div class="container-fluid pt-4">
        <h5>{{ $t("main.label.title.caution") }}</h5>
        <div class="card">
          <div class="card-body">
            <div class="row">
              <label class="text-danger" v-if="isShowMessageValid">
                <font-awesome-icon icon="fas fa-exclamation-triangle" />
                前日以前の未確定データが残っています。
              </label>
            </div>
          </div>
        </div>
        <h5>{{ $t("main.label.title.warehouse_information") }}</h5>
        <div class="card">
          <div class="card-body scroll">
            <div
              class="row"
              v-for="(item, index) in scheduleReceivings"
              :key="index"
              @click="getLinkScheduleToday"
              :class="item?.入荷確定フラグ == 1 ? 'text-gray' : ''"
            >
              <label class="col-lg-2">本日の入荷予定</label>
              <u class="col-lg-10"
                >{{ item?.入荷予定時刻 }} &nbsp;&nbsp;&nbsp;{{
                  item?.仕入先名
                }}</u
              >
            </div>
            <div
              class="row"
              v-for="(item, index) in scheduleInstocks"
              :key="index"
            >
              <label class="col-lg-2">本日の出荷予定</label>
              <div class="col-lg-10">
                <u @click="getLinkShippingToday" :key="`schedule${index}}`"
                  >19:00 &nbsp;&nbsp;&nbsp;{{ item?.得意先名１ }}　×　{{
                    item?.出荷伝票番号
                  }}
                </u>
              </div>
            </div>
            <div class="row">
              <label class="col-lg-2">在庫データ最終取込日時</label>
              <label class="col-lg-10"
                >{{ formatDateTime(infWareHouse?.アップロード日時) }}　{{
                  infWareHouse?.倉庫名
                }}
              </label>
            </div>

            <!-- <div
              class="row form-group text-gray"
              v-for="(item, idx) in scheduleReceivings"
              :key="`a-${idx}`"
            >
              <label class="col-lg-1 ">入荷予定</label>
              <label class="col-lg-1 ">{{
                convertTime(item?.入荷予定時刻)
              }}</label>
              <label class="col-lg-2 ">{{
                item?.仕入先名
              }}</label>
            </div>
            <div
              class="row text-gray"
              v-for="(item, idx) in scheduleInstocks"
              :key="`b-${idx}`"
            >
              <label class="col-lg-1 ">出荷予定</label>
              <label class="col-lg-1 ">{{
                moment(item?.出荷予定日).format("YYYY/MM/DD")
              }}</label>
              <label class="col-lg-6 ">{{
                item?.得意先名１
              }}</label>
              <label class="col-lg-2 ">{{
                item?.出荷伝票番号
              }}</label>
            </div> -->
          </div>
        </div>
        <h5>{{ $t("main.label.title.information") }}</h5>
        <div class="card scroll-bar">
          <div class="card-body">
            <div class="wrap-content">
              <div
                class="row form-group"
                v-for="(item, idx) in getInformation"
                :key="idx"
              >
                <label class="col-lg-2">{{
                  moment(item?.掲載開始日).format("YYYY/MM/DD")
                }}</label>
                <u class="col-lg-10">{{ item?.表題 }}</u>
              </div>
            </div>
          </div>
        </div>

        <h5>{{ $t("main.label.title.operating_instruction") }}</h5>
        <div class="card scroll-bar">
          <div class="card-body">
            <div class="wrap-content">
              <div
                class="row form-group"
                v-for="(item, idx) in operatingInstructions"
                :key="idx"
              >
                <label class="col-lg-2"
                  ><font-awesome-icon
                    icon="fas fa-file-pdf"
                    class="text-danger"
                  />
                  {{ item?.表題 }}
                </label>
                <label for=""> ({{ fileSizes[idx] }})</label>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>
<script>
import moment from "moment";
import { getDailySchedule } from "@/services/APIs/COMService";
import { convertTime } from "@/utils/helper";
export default {
  components: {},
  data() {
    return {
      estimateArrivalTime: null,
      supplierName: null,
      scheduleReceivings: [],
      scheduleInstocks: [],
      operatingInstructions: [],
      getInformation: [],
      infWareHouse: [],
      infCreditCustomer: [],
      totalOrderNum: null,
      isShowMessageValid: false,
      fileSizes: [],
    };
  },
  mounted() {
    this.$store.dispatch("auth/setTitle", this.$t("main.label.header"));
  },
  async created() {
    await this.getContentSchedule();
  },
  methods: {
    moment,
    convertTime,
    async getContentSchedule() {
      const res = await getDailySchedule();
      console.log("res ", res);
      this.scheduleReceivings = res?.data?.receivings;
      this.scheduleInstocks = res?.data?.instocks;
      this.getInformation = res?.data?.getInformation;
      this.operatingInstructions = res?.data?.operatingInstructions;
      this.isShowMessageValid = res?.data?.isValidMessage;
      this.infWareHouse = res?.data?.wareHouseInfor;
      this.infCreditCustomer = res?.data?.creaditInfor;
      this.totalOrderNum = res?.data.sumOrderInMonth["total_order_number"];
      if (
        this.infCreditCustomer[0]?.与信限度額 /
          this.infCreditCustomer[0]?.入金サイト <=
        this.totalOrderNum
      ) {
        this.isShowMessageValid = true;
      }

      for (let index = 0; index < this.operatingInstructions.length; index++) {
        this.operatingInstructions[index].fileSize = await this.getFileSize(
          this.operatingInstructions[index].資料ＵＲＬ.toString()
        );
        this.fileSizes.push(
          await this.getFileSize(
            this.operatingInstructions[index].資料ＵＲＬ.toString()
          )
        );
      }
    },
    formatDateTime(str) {
      var date = new Date(str);
      var day = date.getDate();
      var month = date.getMonth() + 1;
      var year = date.getFullYear();
      var hour = date.getHours();
      var minute = date.getMinutes().toString().padStart(2, "0");
      var newDate = null;
      if (
        isNaN(date) ||
        isNaN(day) ||
        isNaN(month) ||
        isNaN(year) ||
        isNaN(hour) ||
        isNaN(minute)
      ) {
        newDate = "";
      } else {
        newDate = `${year}/${month < 10 ? "0" : ""}${month}/${
          day < 10 ? "0" : ""
        }${day} ${hour}:${minute}`;
      }
      return newDate;
    },
    getLinkScheduleToday() {
      console.log("当日の入荷予定一覧画面");
      this.$router.push("/schedule-arrival-list");
    },
    getLinkShippingToday() {
      console.log("出荷予定一覧_得意先別");
      this.$router.push("/shipping-schedule-list-customer");
    },

    getFileName(filePath) {
      const newSilfePath = filePath.replace(/\\/g, "/");
      const parts = newSilfePath.split("/");
      return parts[parts.length - 1];
    },

    async getFileSize(Url) {
      try {
        const pdfUrl = "http://127.0.0.1:8000/" + this.getFileName(Url);
        const response = await axios.get(pdfUrl, {
          responseType: "arraybuffer",
        });
        const data = response.data;
        const fileSizeInBytes = data.byteLength;

        let fileSize = null;

        if (fileSizeInBytes >= 1048576) {
          fileSize = (fileSizeInBytes / 1048576).toFixed(2) + " MB";
        } else if (fileSizeInBytes >= 1024) {
          fileSize = (fileSizeInBytes / 1024).toFixed(2) + " KB";
        } else {
          fileSize = fileSizeInBytes + " bytes";
        }
        return fileSize;
      } catch (error) {
        throw error;
      }
    },
  },
};
</script>

<style scoped>
#schedule-day .card {
  border: 1px solid #5b9bd5;
}

#schedule-day .container-fluid {
  padding-left: 15px;
  padding-right: 15px;
}

.scroll {
  max-height: 160px;
  overflow-y: auto;
}

.scroll-bar {
  height: 160px;
  overflow-y: auto;
}
</style>
