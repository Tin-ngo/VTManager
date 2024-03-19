<template>
  <div class="container-fluid">
    <div class="wrapper">
      <div class="login" style="">
        <div class="h2 text-center">Hệ thống quản lý nhà hàng VTManager</div>
        <!-- Horizontal Form -->
        <div class="card">
          <div class="card-header text-center">LOGIN</div>
          <div class="card-body">

            <div class="form-group" :class="{ disabled: isDisabled }">
              <div class="form-group">
                <label class="col-lg-3 text-nowrap">USER ID</label>
                <div class="row align-items-baseline">
                  <div class="col-lg-12">
                    <input v-model="auth.userId" type="number" class="form-control border border-dark" autocomplete="off"
                       />
                    <span v-if="errorMessage.user_id" class="text-danger d-block mt-2">{{ errorMessage?.user_id }}</span>
                  </div>
                </div>
              </div>
              <div class="form-group">
                <label class="col-lg-3 text-nowrap">PASSWORD</label>
                <div class="row align-items-baseline">
                  <div class="col-lg-12">
                    <input v-model="auth.password" type="password" class="form-control border border-dark"
                      autocomplete="off"  />
                    <span v-if="errorMessage.password" class="text-danger d-block mt-2">{{ errorMessage?.password }}</span>
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
                <span v-if="errorMessage.language" class="text-danger d-block mt-2">
                  {{ errorMessage?.language }}
                </span>
              </div>
            <div class="d-flex justify-content-center align-items-baseline">
              <button id="submit" type="submit" class="btn btn-primary" @click="login">
                <font-awesome-icon icon="fas fa-solid fa-right-to-bracket" />
                Đăng nhập
              </button>
            </div>
            <span v-if="errorMessage.messageFailure" class="text-center text-danger d-block mt-2">{{
              errorMessage?.messageFailure }}</span>
            </div>
          </div>
        </div>
      </div>
    </div>
    <LoadingModalVue v-show="isLoading" />
  </div>
</template>

<script>
import { TOKEN } from "@/constants";
import { mapActions } from "vuex";
import authService from "@/services/APIs/auth";
import moment from "moment";
import LoadingModalVue from "../../components/modals/LoadingModal.vue";
export default {
  components: {
    LoadingModalVue
  },
  data() {
    return {
      isLoading: false,
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
      locale: "Việt Nam",
      isDisabled: false,
    };
  },
  async created() {
  },
  watch: {
  },
  methods: {
    moment,
    ...mapActions({
      signIn: "auth/login",
    }),
    async login() {
      this.isLoading = true;
      await this.loginAdmin()
      this.isLoading = false;
    },
    async loginAdmin(){
      const params = {
        user_id: this.auth.userId,
        password: this.auth.password,
        language: this.locale,
      };
      try {
        const response = await authService.login(params);
        localStorage.setItem(TOKEN.ACCESS_TOKEN, response?.data?.data.token);
        localStorage.setItem("ownerId", (response?.data?.data?.user?.ownerId).toString());
        localStorage.setItem("user", JSON.stringify(response?.data?.data?.user));
        console.log('ownerId', localStorage.getItem('ownerId'));
        await this.signIn();
        await this.$store.dispatch(
          "auth/setLang",
          this.locale === "Tiếng anh" ? "en" : "vn"
        );
        console.log('response', response);
        // await this.$router.push({ name: "Overview" });
        await this.$router.push({ name: "EmployeeHome" });

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

.disabled, .disabled input{
  color: lightgray !important;
  pointer-events: none;
  user-select: none;
}
.disabled input, .disabled select{
  border: 1px solid #ccc !important;
}
.disabled button{
  border: none !important;
  background-color: lightgray;
}



/* laptop - PC */
@media(min-width: 1350px){
  .wrapper {
    width: 30% !important;
  }
} 

/* laptop - PC */
@media(min-width: 1100px) and (max-width: 1350px){
  .wrapper {
    width: 45% !important;
  }
}  

/* tablet */
@media(min-width: 740px) and (max-width: 1100px){
  .wrapper {
    width: 80% !important;
  }
} 

/* mobile */
@media(max-width: 740px) {  
  .wrapper {
    width: 100% !important;
  }
} 



</style>
