<template>
  <section class="content-header">
    <div class="container-fluid">
      <div class="row mb-2 m-0">
        <div class="col-sm-6">
          <h1 class="font-weight-bold">{{ title }}</h1>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
export default {
  props: {
    title: {
      type: String,
      required: true
    }
  }
};
</script>
