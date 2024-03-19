<template>
  <section class="content-order main-section">
    <div class="container-fluid pt-2">
      <div class="d-flex justify-content-center align-items-center text-danger">
        <div class="h6">{{ messageError }}</div>
      </div>
      <div class="card">
        <div class="card-body">
          <div class="form-group">
            <label class="d-flex align-items-center">
              {{ $t("delivery-destination-maintenance.label.form.customer") }}
              <span class="badge badge-danger" style="margin-bottom: 5px">
                必须
              </span>
            </label>
            <div class="col-sm-3 px-0">
              <select
                name=""
                class="form-control col-lg-5"
                v-model="customerCd"
                ref="customerCd"
              >
                <option value="0"></option>
                <option
                  v-for="(item, idx) in customers"
                  :key="idx"
                  :value="item?.得意先コード"
                >
                  {{ item?.得意先名称 }}
                </option>
              </select>
            </div>
          </div>
          <div class="form-group">
            <label class="d-flex align-items-center">
              {{
                $t("delivery-destination-maintenance.label.form.delivery_cd")
              }}
              <span class="badge badge-danger" style="margin-bottom: 5px">
                必须
              </span>
            </label>
            <div class="col-lg-3 px-0">
              <input
                type="text"
                class="form-control col-lg-8"
                v-model="deliveryCd"
                ref="deliveryCd"
              />
            </div>
          </div>
          <div class="form-group">
            <label class="d-flex align-items-center">
              {{
                $t("delivery-destination-maintenance.label.form.delivery_name")
              }}
              <span class="badge badge-danger" style="margin-bottom: 5px">
                必须
              </span>
            </label>
            <input
              type="text"
              class="form-control col-lg-7"
              v-model="deliveryName1"
              ref="deliveryName1"
            />
            <input
              type="text"
              class="form-control col-lg-7 mt-2"
              v-model="deliveryName2"
              ref="deliveryName2"
            />
          </div>
          <div class="form-group">
            <label class="d-flex align-items-center">
              {{
                $t(
                  "delivery-destination-maintenance.label.form.delivery_address"
                )
              }}
              <span class="badge badge-danger" style="margin-bottom: 5px">
                必须
              </span>
            </label>
            <input
              type="text"
              class="form-control col-lg-7"
              v-model="deliveryAddress1"
              ref="deliveryAddress1"
            />
            <input
              type="text"
              class="form-control col-lg-7 mt-2"
              v-model="deliveryAddress2"
              ref="deliveryAddress2"
            />
          </div>
          <div class="form-group">
            <label class="">{{
              $t("delivery-destination-maintenance.label.form.telephone_number")
            }}</label>
            <div class="col-lg-3 px-0">
              <input
                type="text"
                class="form-control col-lg-8"
                v-model="telephoneNumber"
                ref="telephoneNumber"
              />
            </div>
          </div>
          <div class="form-group">
            <label class="d-flex align-items-center">
              {{
                $t(
                  "delivery-destination-maintenance.label.form.delivery_lead_time"
                )
              }}
              <span class="badge badge-danger" style="margin-bottom: 5px">
                必须
              </span>
            </label>
            <div class="col-lg-1 px-0">
              <input
                type="text"
                class="form-control col-lg-8 text-right mb-0"
                v-model="deliveryLeadTime"
                ref="deliveryLeadTime"
              />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid footer-item">
      <div class="card">
        <div class="card-body d-flex">
          <button
            class="btn-register btn"
            @click="!rules ? register() : update()"
          >
            <font-awesome-icon icon="fas fa-pencil-alt" />&nbsp;{{
              !rules ? $t("button.register") : $t("button.update")
            }}
          </button>
          <button class="btn btn-back ml-auto" @click="goBack()">
            <font-awesome-icon icon="fas fa-arrow-left" />
            &nbsp;{{ $t("button.back") }}
          </button>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { ROUTER } from "../../constants";
import { getCustomerByID } from "@/services/APIs/OMSService";
import { create, update } from "@/services/APIs/MSTService";
export default {
  data() {
    return {
      customerCd: null,
      deliveryCd: null,
      deliveryName1: null,
      deliveryName2: null,
      deliveryAddress1: null,
      deliveryAddress2: null,
      telephoneNumber: null,
      deliveryLeadTime: null,
      customers: [],
      warehouseCd: 1,
      rules: false,
      router: ROUTER,
      messageError: "",
    };
  },
  async created() {
    this.customers = await getCustomerByID();
  },
  async mounted() {
    this.$store.dispatch(
      "auth/setTitle",
      this.$t("delivery-destination-maintenance.label.title")
    );
    if (this.$route.query.delivery_cd) {
      this.deliveryCd = this.$route.query.delivery_cd;
      this.rules = true;
    }
    if (this.$route.query.customer_cd) {
      this.customerCd = this.$route.query.customer_cd;
      this.rules = true;
    }
    if (this.$route.query.delivery_name1) {
      this.deliveryName1 = this.$route.query.delivery_name1;
    }
    if (this.$route.query.delivery_name2) {
      this.deliveryName2 = this.$route.query.delivery_name2;
    }
    if (this.$route.query.delivery_address1) {
      this.deliveryAddress1 = this.$route.query.delivery_address1;
    }
    if (this.$route.query.delivery_address2) {
      this.deliveryAddress2 = this.$route.query.delivery_address2;
    }
    if (this.$route.query.delivery_telno) {
      this.telephoneNumber = this.$route.query.delivery_telno;
    }
    if (this.$route.query.delivery_lead_time) {
      this.deliveryLeadTime = this.$route.query.delivery_lead_time;
    }
  },
  methods: {
    validateForm() {},
    async register() {
      const bodies = {
        deliveryCd: this.deliveryCd,
        customerCd: this.customerCd,
        deliveryName1: this.deliveryName1,
        deliveryName2: this.deliveryName2,
        deliveryAddress1: this.deliveryAddress1,
        deliveryAddress2: this.deliveryAddress2,
        telephoneNumber: this.telephoneNumber,
        deliveryLeadTime: this.deliveryLeadTime,
      };
      try {
        const res = await create(bodies);
        if (!res.errors) {
          this.$toast.success(this.$t("label.regis_successfull"));
          this.messageError = "";
        } else {
          const errorFields = [
            "deliveryCd",
            "customerCd",
            "deliveryName1",
            "deliveryName2",
            "deliveryAddress1",
            "deliveryAddress2",
            "deliveryLeadTime",
          ];

          for (const field of errorFields) {
            if (res?.errors?.[field]) {
              this.messageError = res.errors[field][0];
              this.$refs[field].focus();
              return;
            }
          }
        }
      } catch (error) {}
    },

    async update() {
      const bodies = {
        deliveryCd: this.deliveryCd,
        customerCd: this.customerCd,
        deliveryName1: this.deliveryName1,
        deliveryName2: this.deliveryName2,
        deliveryAddress1: this.deliveryAddress1,
        deliveryAddress2: this.deliveryAddress2,
        telephoneNumber: this.telephoneNumber,
        deliveryLeadTime: this.deliveryLeadTime,
      };
      const key = `${this.deliveryCd}-${this.customerCd}`;
      try {
        const result = await update(key, bodies);
        if (!result.errors) {
          this.$toast.success(this.$t("label.update_successfull"));
          this.messageError = "";
        } else {
          const errorFields = [
            "deliveryCd",
            "customerCd",
            "deliveryName1",
            "deliveryName2",
            "deliveryAddress1",
            "deliveryAddress2",
            "deliveryLeadTime",
          ];

          for (const field of errorFields) {
            if (result?.errors?.[field]) {
              this.messageError = result.errors[field][0];
              this.$refs[field].focus();
              return;
            }
          }
        }
      } catch (error) {
        console.log(error);
      }
    },
    goBack() {
      this.$router.push({
        path: this.router?.MSTDeliveryDestination?.path,
      });
    },
  },
};
</script>

<style>
.form-check-label {
  margin-bottom: 5px;
}

#label-required {
  border-radius: 4px;
  height: 18px;
}
</style>
