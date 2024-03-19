<template>
  <div class="container-fluid">
    <div class="wrapper">
      <div class="login" style="">
        <div class="h2 text-center">Hệ thống quản lý nhà hàng VTManager</div>
        <!-- Horizontal Form -->
        <div class="card">
          <div class="card-header text-center">LOGIN</div>
          <div class="card-body">
            <div class="form-group">
              <label class="col-lg-3 text-nowrap">USER ID</label>
              <div class="row align-items-baseline">
                <div class="col-lg-12">
                  <input
                    v-model="auth.userId"
                    type="number"
                    class="form-control border border-dark"
                    autocomplete="off"
                    autofocus
                  />
                  <span
                    v-if="errorMessage.user_id"
                    class="text-danger d-block mt-2"
                    >{{ errorMessage?.user_id }}</span
                  >
                </div>
              </div>
            </div>
            <div class="form-group">
              <label class="col-lg-3 text-nowrap">PASSWORD</label>
              <div class="row align-items-baseline">
                <div class="col-lg-12">
                  <input
                    v-model="auth.password"
                    type="password"
                    class="form-control border border-dark"
                    autocomplete="off"
                    autofocus
                  />
                  <span
                    v-if="errorMessage.password"
                    class="text-danger d-block mt-2"
                    >{{ errorMessage?.password }}</span
                  >
                </div>
              </div>
            </div>
            <div class="form-group">
              <label class="col-lg-3 text-nowrap">LANGUAGE</label>
              <select v-model="locale" class="form-control border border-dark">
                <option value=""></option>
                <option v-for="(lang, i) in langs" :key="i" :value="lang">
                  {{ lang }}
                </option>
              </select>
              <span
                v-if="errorMessage.language"
                class="text-danger d-block mt-2"
              >
                {{ errorMessage?.language }}
              </span>
            </div>
            <div class="d-flex justify-content-center align-items-baseline">
              <button
                id="submit"
                type="submit"
                class="btn btn-primary"
                @click="login"
              >
                <font-awesome-icon icon="fas fa-solid fa-right-to-bracket" />
                Đăng nhập
              </button>
            </div>
            <span
              v-if="errorMessage.messageFailure"
              class="text-center text-danger d-block mt-2"
              >{{ errorMessage?.messageFailure }}</span
            >
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { TOKEN } from "@/constants";
import { mapActions } from "vuex";
import authService from "@/services/APIs/auth";
import moment from "moment";
export default {
  data() {
    return {
      auth: {
        userId: null,
        password: null,
      },
      langs: ["Việt Nam", "Tiếng anh"],
      informations: [],
      validationErrors: {},
      errorMessage: {
        user_id: null,
        password: null,
        language: null,
        messageFailure: null,
      },
      publishStartDate: null,
      publishContent: null,
      locale: null,
    };
  },
  async created() {
    const response = await authService.information({});
    this.informations = response?.data?.data?.result;
  },
  methods: {
    moment,
    ...mapActions({
      signIn: "auth/login",
    }),
    async login() {
      const params = {
        user_id: this.auth.userId,
        password: this.auth.password,
        language: this.locale,
      };
      try {
        const response = await authService.login(params);
        this.signIn();
        localStorage.setItem(TOKEN.ACCESS_TOKEN, response?.data?.data.token);
        this.$store.dispatch(
          "auth/setLang",
          this.locale === "Tiếng anh" ? "en" : "vn"
        );
        this.$router.push({ name: "Main" });
      } catch (errors) {
        const response = errors.response;
        this.errorMessage = {};
        if (response?.status === 422) {
          this.validationErrors = response?.data?.data;
          this.errorMessageHandle();
        } else {
          this.errorMessage.messageFailure = response?.data?.message;
        }
      }
    },
    errorMessageHandle() {
      this.validationErrors.map((item) => {
        this.errorMessage[`${item.field_name}`] = item?.message;
      });
    },
  },
};
</script>

<style lang="scss" scoped>
.card-header {
  background-color: #006600;
  color: white;
}
.container-fluid {
  height: 100vh;
  .wrapper {
    width: 45%;
    margin: 100px auto;
    .login {
      margin: 0 auto;
      width: 70%;
      min-width: 500px;
    }

    .information {
      margin: 2% auto 0;

      .header-information .body-information {
        height: 200px;
        margin: 0 auto;

        min-width: 500px;
      }
    }
  }
}

.card {
  border: 1px solid black;
}

.scroll-bar {
  height: 180px;
  overflow: auto;
}
</style>
