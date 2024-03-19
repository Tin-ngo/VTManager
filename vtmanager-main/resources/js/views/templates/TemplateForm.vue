<template>
  <section class="main-section">
    <FormulateForm
      class="ml-4"
      v-model="formValues"
      @submit="handleSubmit"
      name="test"
    >
      <FormulateInput
        input-class="form-control col-4"
        name="名前"
        label="名前"
        error-behavior="submit"
      />
      <FormulateInput
        input-class="form-control col-4"
        errors-class="error-message"
        label-class=""
        element-class=""
        wrapper-class=""
        help-class=""
        name="Eメール"
        label="Eメール"
        error-behavior="submit"
      />
      <FormulateInput
        input-class="form-control col-4"
        name="ユーザー名"
        label="ユーザー名"
        error-behavior="submit"
      />
      <FormulateInput
        type="select"
        name="state"
        label="State"
        input-class="form-control col-4"
        :options="{ VA: 'Virginia', CA: 'California', NY: 'New York' }"
      />
      <FormulateInput
        name="check"
        type="checkbox"
        label="This is a single checkbox"
      />
      <FormulateInput
        name="radio"
        :options="{
          first: 'First',
          second: 'Second',
          third: 'Third',
          fourth: 'Fourth',
        }"
        type="radio"
        label="This is a label for all the options"
      />
      <FormulateInput
        label="How long do you think you’ll live?"
        type="range"
        name="range"
        min="0"
        max="100"
        value="45"
        validation="required|min:10|max:90"
        error-behavior="live"
      />
      <FormulateInput
        type="date"
        name="sample"
        label="Sample date input"
        placeholder="Sample date placeholder"
        help="Sample date help text"
        validation="required|after:2019-01-01"
        min="2018-12-01"
        max="2025-01-01"
        error-behavior="submit"
      />
      <FormulateInput
        class="mt-2"
        input-class="btn btn-create"
        type="submit"
        label="検索"
      />
    </FormulateForm>
  </section>
</template>

<script>
export default {
  data() {
    return {
      formValues: {},
      inputErrors: {},
      formErrors: [],
    };
  },
  methods: {
    async handleSubmit(...params) {
      // try {
      //   const res = await this.$axios.post('/login')
      //   this.$cookie.setToken(res.data.token) // do some auth
      // } catch (err) {
      //   // here's where things get nasty
      //   if (err.response && err.response.status) {
      //     switch (err.response.status) {
      //       case 422:
      //         this.inputErrors = err.response.data.errors // assign field errors
      //         this.formErrors = err.response.data.message
      //         return
      //       case 401:
      //         this.$cookie.removeToken()
      //         return
      //       // ... add lots more cases of bad things that can happen here
      //     }
      //   }
      this.formErrors = [
        "Sorry, an unexpected error occurred. Please try again soon..",
      ];
      // }
      this.inputErrors = {
        名前: "必須 Errors",
      };
      this.$formulate.handle(
        {
          inputErrors: this.inputErrors,
          formErrors: this.formErrors,
        },
        "test"
      );
    },
  },
};
</script>

<style scoped="scss">
.custom-name-input-class {
}

.error-message {
  color: red;
}
</style>
