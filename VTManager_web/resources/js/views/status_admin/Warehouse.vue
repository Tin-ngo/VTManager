<template>
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header d-flex justify-content-center align-items-center">
                        Đang xây dựng
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    async mounted() {
        this.$store.dispatch("auth/setTitle", this.$t("warehouse.header"));
    }
}
</script>
