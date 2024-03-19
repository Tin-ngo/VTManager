<template>
  <section class="main-section">
    <div class="container-fluid pt-2">
      <div class="card">
        <div class="card-body">
          <div class="form-row form-group">
            <div class="form-group col-lg-3">
              <label class="d-flex align-items-center">
                {{ $t("vehicle-maintenance.label.shipping_company_name") }}
                <span class="badge badge-danger" style="margin-bottom: 5px">
                  必须
                </span>
              </label>
              <div class="d-flex">
                <select class="form-control" v-model="shipCompanyName">
                  <option value=""></option>
                  <option value="1">配送会社名_1</option>
                  <option value="2">配送会社名_2</option>
                </select>
              </div>
            </div>
          </div>
          <div class="form-row form-group">
            <div class="form-group col-lg-2">
              <label class="d-flex align-items-center">
                {{ $t("vehicle-maintenance.label.vehicle_number") }}
                <span class="badge badge-danger" style="margin-bottom: 5px">
                  必须
                </span>
              </label>
              <div class="d-flex">
                <input
                  type="text"
                  class="form-control"
                  v-model="vehicleNumber"
                />
              </div>
            </div>
          </div>
          <div class="form-row form-group">
            <div class="form-group col-lg-1">
              <label class="d-flex align-items-center">
                {{ $t("vehicle-maintenance.label.vehicle_size") }}
                <span class="badge badge-danger" style="margin-bottom: 5px">
                  必须
                </span>
              </label>
              <div class="d-flex">
                <select class="form-control" v-model="vehicleSize">
                  <option value=""></option>
                  <option value="1">車両サイズ_1</option>
                  <option value="2">車両サイズ_2</option>
                </select>
              </div>
            </div>
          </div>
          <div class="form-row form-group">
            <div class="form-group col-lg-1">
              <label class="d-flex align-items-center">
                {{ $t("vehicle-maintenance.label.vehicle_classification") }}
                <span class="badge badge-danger" style="margin-bottom: 5px">
                  必须
                </span>
              </label>
              <div class="d-flex">
                <select class="form-control" v-model="vehicleClassification">
                  <option value=""></option>
                  <option value="1">車両サイズ_1</option>
                  <option value="2">車両サイズ_2</option>
                </select>
              </div>
            </div>
          </div>
          <div class="form-row form-group">
            <div class="form-group col-lg-2">
              <label class="d-flex align-items-center">
                {{ $t("vehicle-maintenance.label.maximum_loading_capacity") }}
                <span class="badge badge-danger" style="margin-bottom: 5px">
                  必须
                </span>
              </label>
              <div class="row col-lg-8">
                <div class="d-flex align-items-baseline">
                  <input
                    type="text"
                    class="form-control"
                    v-model="maximumLoadingCapacity"
                  />
                  <label class="ml-4">kg</label>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="container-fluid footer-item">
      <div class="card">
        <div class="card-body">
          <div class="row justify-content-between">
            <button class="btn btn-register">
              <font-awesome-icon icon="fas fa-pencil-alt" />&nbsp;{{
                $t("button.register")
              }}
            </button>
            <button class="btn btn-back" @click="goBack()">
              <font-awesome-icon icon="fas fa-arrow-left" />&nbsp;{{
                $t("button.back")
              }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { TmsVehicleMaintenance } from "../../constants/router";

export default {
  data() {
    return {
      shipCompanyName: null,
      vehicleNumber: null,
      vehicleSize: null,
      vehicleClassification: null,
      maximumLoadingCapacity: "123,456,789",
    };
  },
  mounted() {
    this.$store.dispatch("auth/setTitle", TmsVehicleMaintenance);
  },

  methods: {
    goBack() {
      this.$router.push({ path: "/main" });
    },
  },
};
</script>
