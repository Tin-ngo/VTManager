<template>
  <div class="container-fluid pt-2">
    <div class="d-flex justify-content-center align-items-center text-danger">
      <div class="h6">{{ messageError }}</div>
    </div>
    <div class="card bg-condition">
      <div class="card-body">
        <div class="row form-group">
          <div
            class="border px-2 bg-condition-icon rounded"
            @click="handleHiddenCondition"
          >
            <i
              :class="
                isCollapsed
                  ? 'fas fa-regular fa-minus'
                  : 'fas fa-regular fa-plus'
              "
              class="text-white"
            ></i>
          </div>
          <div class="col-lg-9">
            {{ $t("label.search_conditions") }}
          </div>
        </div>
        <div v-show="isCollapsed">
          <div class="form-row">
            <div class="form-group col-lg-1">
              <label class="form-check-label">{{
                $t("commodity-master.label.form.commodity_cd")
              }}</label>
              <input
                type="text"
                class="form-control border-custom"
                id="productCode"
                v-model="productCd"
              />
            </div>

            <div class="form-group col-lg-2">
              <label class="form-check-label">{{
                $t("commodity-master.label.form.commodity_nm")
              }}</label>
              <input
                type="text"
                class="form-control border-custom"
                id="productName"
                v-model="productName"
              />
            </div>

            <div class="col d-flex justify-content-end align-items-center">
              <button class="btn btn-clear mr-2" @click="clear()">
                <font-awesome-icon icon="fas fa-rotate-left" />クリア
              </button>
              <button class="btn btn-search" @click="search()">
                <font-awesome-icon icon="fas fa-search" />
                検索
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

import { getProducts } from "@/services/APIs/MSTService.js";

export default {
  data() {
    return {
      products: [],
      productCd: null,
      productName: null,
      isCollapsed: false,
      searchResults: [],
      messageError: ""
    };
  },
  async mounted() {
    this.search();
  },
  async created(){
  },
  methods: {
    handleHiddenCondition() {
      this.isCollapsed = !this.isCollapsed;
      this.$emit("toggleCondition");
    },
    clear() {
      this.productCd = null;
      this.productName = null;
      this.messageError = ""
      this.search();
    },
    async search() {
      const params = {}
      try{
        this.products = await getProducts(params)
        if(this.products){
          this.products = this.products?.map(item => ({ ...item, checked: false }));
        }
      } catch (error) {}

      this.messageError = ""

      this.searchResults = this.products?.filter((item) => {
        const productCD =
          !this.productCd || item?.item_code.includes(this.productCd);
        const productName =
          !this.productName || item?.item_name.includes(this.productName);
        return productCD && productName;
      });

      this.$emit("search", this.searchResults);
    },
    setMessageError(Error){
      this.messageError = Error
    }
  },
};
</script>

<style>
label{
  font-weight: bold;
}
</style>