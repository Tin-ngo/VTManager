<template>
    <section>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="#">{{ title }}</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="adjust-padding nav-item active " @click="navigateToEmployeeHome">
                        <a class="nav-link">Home</a>
                    </li>
                </ul>
                <!-- <form class="adjust-padding form-inline my-2 my-lg-0 adjust-icon" @click="logout">
                    <font-awesome-icon icon="fas fa-sign-out-alt fa-lg" />
                </form> -->
            </div>
        </nav>
    </section>
</template>

<script>

const OWNER_ID = localStorage.getItem("ownerId");
import { ROUTER } from "../../constants";

export default {
    data() {
        return {

        };
    },
    watch: {
    },
    props: {
        title: {
            type: String
        }
    },
    created() {
    },
    async mounted() {
    },

    methods: {
        logout() {
            localStorage.clear();
            this.$router.push({ name: ROUTER.ComLogin.name });
        },
        navigateToEmployeeHome() {
            this.$router.push("/employee");
        }
    }
}
</script>

<style scoped>
.adjust-icon {
    font-size: 26px !important;
    cursor: pointer;
}

.adjust-padding {
    padding: 0 20px !important;
}

.nav-item{
    cursor: pointer;
}


</style>