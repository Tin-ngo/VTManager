<template>
    <div style="position: relative; height: 100vh;">
        <div class="nav-top">
            <span style="padding: 0 16px; font-size: 16px;">{{ employeeName }} - {{ employeeClassName }}</span>
            <form class="adjust-padding form-inline my-2 my-lg-0 adjust-icon" @click="logout">
                <font-awesome-icon icon="fas fa-sign-out-alt fa-lg" />
            </form>
        </div>

        <div class="container-fluid wrap">
            <div class="row" style="background-color: var(--color-main); color: #fff;">
                <div class="col-md-12 d-flex justify-content-center align-items-center" style="margin-top: 20px;">
                    <h2 class="title">Nhân Viên Trong Quán</h2>
                </div>
                <div class="col-md-12 d-flex justify-content-center align-items-center" style="margin-bottom: 20px;">
                    <h6>Bạn là?</h6>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 d-flex justify-content-center align-items-center hover" @click="redirectStaff()">
                    <h5>Nhân viên phục vụ</h5>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 d-flex justify-content-center align-items-center hover" @click="redirectChef()">
                    <h5>Nhân viên bếp</h5>
                </div>
            </div>
        </div>

        <LoadingModalVue v-show="isLoading" />
    </div>
</template>

<script>

const OWNER_ID = localStorage.getItem("ownerId");
import { ROUTER } from "../../constants";
import LoadingModalVue from "../../components/modals/LoadingModal.vue";

export default {
    components: {
        LoadingModalVue,
    },
    data() {
        return {
            isLoading: false,
            employeeName: null,
            employeeClassName: null,
        };
    },
    watch: {
    },
    props: {
    },
    async created() {
        let employeeInfor = await JSON.parse(localStorage.getItem("user"))
        
        this.employeeName = employeeInfor?.employeeName
        if(employeeInfor?.employeeClassId == 1){
            this.employeeClassName = "Nhân viên phục vụ"
        }else if(employeeInfor?.employeeClassId == 2){
            this.employeeClassName = "Nhân viên bếp"
        }
    },
    async mounted() {
    },

    methods: {
        redirectStaff() {
            this.$router.push('/employee/staff');
        },
        redirectChef() {
            this.$router.push('/employee/chef');
        },
        logout() {
            localStorage.clear();
            window.location.reload();
        },
    }
}
</script>


<style scoped>
.wrap {
    height: auto;
    width: auto;
    position: absolute;
    top: 15%;
    right: 30%;
    left: 30%;
    border: 1px solid var(--color-main);
}

.hover {
    height: 130px;
    cursor: pointer;
    box-shadow: 0px 0px 8px -1px var(--color-main);
}

.hover:hover {
    box-shadow: 0px 0px 8px -1px red;
}

.nav-top {
    height: 50px;
    width: 100%;
    display: flex;
    align-items: center;
    justify-content: end;
    padding: 0 25px;
    font-size: 30px;
    color: #000;
}
/* laptop - PC */
@media(min-width: 1024px) {
    .wrap {
        height: auto;
        width: auto;
        position: absolute;
        top: 15%;
        right: 30%;
        left: 30%;
        border: 1px solid var(--color-main);
    }
}  

/* tablet */
@media(min-width: 740px) and (max-width: 1023px){
    .wrap {
        height: auto;
        width: auto;
        position: absolute;
        top: 10%;
        right: 20%;
        left: 20%;
        border: 1px solid var(--color-main);
    }
} 

/* mobile */
@media(max-width: 740px) {
    .wrap {
        height: auto;
        width: auto;
        position: absolute;
        top: 10%;
        right: 10%;
        left: 10%;
        border: 1px solid var(--color-main);
    }
    h2.title{
        font-size: 25px;
    }
} 

</style>