<template>
  <section>
    <div class="container-fluid">
      <div class="card bg-condition" :class="contentHeight">
        <div class="card-body">
          <div class="row border-common pl-2">
            <label>{{ $t("label.search_results") }} </label>
          </div>

          <div class="row">
            <div class="w-100" :class="contentHeight">
              <table class="w-100">
                <thead class="bg-header">
                  <tr class="text-center">
                    <template v-for="(header, idx) in tableHeader">
                      <td :key="idx" v-if="idx == 0" style="width: 30px">
                        <input type="checkbox" v-model="checkAll" />
                      </td>
                      <td
                        v-else
                        :key="idx"
                        :style="
                          idx == 1
                            ? 'width: 200px !important;'
                            : idx == 2
                            ? 'width: 500px !important;'
                            : idx == 3
                            ? 'width: 100px !important;'
                            : idx == 4
                            ? 'width: 100px !important;'
                            : idx == 5
                            ? 'width: 200px !important;'
                            : idx == 6
                            ? 'width: 100px !important;'
                            : ''
                        "
                      >
                        {{ header }}
                      </td>
                    </template>
                  </tr>
                </thead>
                <tbody>
                  <tr
                    class="text-center bg-data-parent row-hover"
                    v-for="(item, index) in listProducts"
                    :key="index"
                  >
                    <td>
                      <input
                        type="checkbox"
                        class="w-100"
                        v-model="item.checked"
                      />
                    </td>
                    <td>
                      {{ item.item_code }}
                    </td>
                    <td>{{ item.item_name }}</td>
                    <td>{{ item.capacity }}</td>
                    <td>{{ item.qty_of_case }}</td>
                    <td>{{ item.gtin_code }}</td>
                    <td>
                      <font-awesome-icon
                        icon="fa-solid fa-pen-to-square"
                        style="font-size: 18px"
                        @click="getProductDetails(item?.item_code)"
                      />
                    </td>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="container-fluid footer-item">
      <div class="card">
        <div class="card-body">
          <div class="row">
            <button
              class="btn btn-create mr-3 text-nowrap"
              @click="registerNew()"
            >
              <i class="fas fa-pencil-alt"></i>&nbsp;{{ $t("button.create") }}
            </button>
            <button class="btn btn-delete text-nowrap" @click="deleteProduct()">
              <i class="fas fa-pencil-alt"></i>&nbsp;{{ $t("button.delete") }}
            </button>
            <button class="btn btn-back ml-auto" @click="goBack()">
              <i class="fas fa-arrow-left"></i>&nbsp;{{ $t("button.back") }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
import { getProducts, deleteProducts } from "@/services/APIs/MSTService.js";
export default {
  props: {
    listSlcMst04Product: {
      type: Array,
      default: function () {
        return [];
      },
    },
  },
  data() {
    return {
      listProducts: [],
      isShowDetail: false,
      checkBoxChild: "",
      estimateShippingDate: null,
      deadline: null,
      checkAll: false,
      contentHeight: "scroll-max-height",
    };
  },
  watch: {
    listSlcMst04Product: {
      handler(newVal) {
        this.listProducts = [...newVal];
      },
      immediate: true,
    },
    checkAll() {
      this.listProducts = this.listProducts.map((item) => ({
        ...item,
        checked: this.checkAll,
      }));
    },
  },
  async created() {},
  computed: {
    setHeaderColor() {
      return {
        backgroundColor: "#D9D9D9",
      };
    },
    tableHeader() {
      return {
        0: "",
        1: this.$t("commodity-master.label.table.headers.commodity_cd"),
        2: this.$t("commodity-master.label.table.headers.commodity_nm"),
        3: this.$t("commodity-master.label.table.headers.volume"),
        4: this.$t("commodity-master.label.table.headers.quantity"),
        5: this.$t("commodity-master.label.table.headers.gtin"),
        6: "",
      };
    },
  },
  methods: {
    showDetailData() {
      this.isShowDetail = !this.isShowDetail;
    },
    goBack() {
      this.$router.push({ path: "/main" });
    },
    registerNew() {
      this.$router.push({ path: "/product-master-maintenance" });
    },
    async deleteProduct() {
      this.$emit("messageError", "");

      const productDelete = this.listProducts.filter(
        (item) => item.checked == true
      );
      const deleteIds = productDelete.map((item) => item.item_code);

      try {
        const resultDelete = await deleteProducts(deleteIds);
        if (resultDelete && resultDelete?.data.status != 404) {
          this.$toast.success(resultDelete?.data.message);

          // window.location.reload()
          this.listProducts = await getProducts({});
          if (this.listProducts) {
            this.listProducts = this.listProducts?.map((item) => ({
              ...item,
              checked: false,
            }));
          }
        } else {
          this.$emit("messageError", resultDelete?.data.message);
          this.listProducts = this.listProducts?.map((item) => ({
            ...item,
            checked: false,
          }));
          this.listProducts = await getProducts({});
          if (this.listProducts) {
            this.listProducts = this.listProducts?.map((item) => ({
              ...item,
              checked: false,
            }));
          }
        }
      } catch (error) {
        console.log("Error Delete");
      }

      this.listProducts = this.listProducts.map((item) => ({
        ...item,
        checked: false,
      }));
    },
    getProductDetails(id) {
      this.$router.push({
        path: "/product-master-maintenance",
        query: {
          productCode: id,
        },
      });
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

<style scoped>
.table-responsive {
  /* height: 430px; */
}
.bg-data-parent {
  background-color: #fff;
  height: 35px;
}

table {
  max-height: 450px;
  overflow-y: scroll;
}

thead {
  position: sticky;
  top: 0;
  z-index: 1;
  background: white;
}

.row-hover:hover {
  background-color: #fff2cc;
}

.scroll-min-height {
  max-height: 550px;
  overflow-y: auto;
}

.scroll-max-height {
  max-height: 625px;
  overflow-y: auto;
}
</style>
