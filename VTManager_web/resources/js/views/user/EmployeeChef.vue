<template>
    <div style="position: relative; height: 100vh;">
        <div class="header">
            <HeaderComponent :title="`Nhà Bếp`"/>
        </div>

        <!-- chọn phân loại -->
        <div class="category text-center">
            <div class="category-item category-item--wait" :class="indexActive == 0 ? 'category-item--active' : ''" @click="showOrder(0)">
                <div class="category-item--content">
                    Đang chờ
                </div>
            </div>
            <div class="category-item" style="width: 200px;" :class="indexActive == 1 ? 'category-item--active' : ''" @click="showOrder(1)"> <!-- -->
                <div class="category-item--content">
                    Khách đang thưởng thức
                </div>
            </div>
            <div class="category-item" style="width: 200px;" :class="indexActive == 2 ? 'category-item--active' : ''" @click="showOrder(2)"> <!-- -->
                <div class="category-item--content">
                    Món ăn
                </div>
            </div>
        </div>

        <div class="content">
            <!-- Đang chờ -->
            <div v-if="indexActive == 0" 
                class="container-fluid" 
                v-for="(item, index) in waitingOrders">
                <!-- item product -->
                <div class="row">
                    <div class="col-md-12 col-xl-12">
                        <div class="card shadow-0 border rounded-3">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-auto">
                                        <div class="bg-image hover-zoom ripple rounded ripple-surface">
                                            <img :src="'/images/menu/' + item.image" style="width: 100px; max-height: 80px;" />
                                            <a href="#!">
                                                <div class="hover-overlay">
                                                    <div class="mask" style="background-color: rgba(253, 253, 253, 0.15);">
                                                    </div>
                                                </div>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="col text-left">
                                        <h3>{{ item.productName }} x{{ item.quantity }}</h3>
                                        <div class="d-flex flex-row align-items-center mb-1">
                                            <h6 class="mb-1 me-1">{{ item.areaName }} - bàn {{ item.tableId }} - Thời gian {{ formatDate(item.dateOrder) }} {{ formatTime(item.timeOrder) }}</h6>
                                            <!-- <span class="text-danger"><s>$20.99</s></span> -->
                                        </div>
                                    </div>
                                    <div class="col-auto d-flex justify-content-end align-items-center wrap-button-confirm">
                                        <button type="button" class="btn btn-primary" @click="updateStatusOrder(item.orderId, item.tableId, item.productId, item.dateOrder, item.timeOrder, item.areaId)">
                                            Xác nhận
                                        </button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div v-if="indexActive == 1"  class="container-fluid" v-for="(item, index) in completedOrders">
                <!-- item product -->
                <div class="row">
                    <div class="col-md-12 col-xl-12">
                        <div class="card shadow-0 border rounded-3">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-auto">
                                        <div class="bg-image hover-zoom ripple rounded ripple-surface">
                                            <img :src="'/images/menu/' + item.image" style="width: 100px; max-height: 80px;" />
                                            <a href="#!">
                                                <div class="hover-overlay">
                                                    <div class="mask" style="background-color: rgba(253, 253, 253, 0.15);">
                                                    </div>
                                                </div>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="col text-left">
                                        <h3>{{ item.productName }} x{{ item.quantity }}</h3>
                                        <div class="d-flex flex-row align-items-center mb-1">
                                            <h6 class="mb-1 me-1">{{ item.areaName }} - bàn {{ item.tableId }} - Thời gian {{ formatDate(item.dateOrder) }} {{ formatTime(item.timeOrder) }}</h6>
                                            <!-- <span class="text-danger"><s>$20.99</s></span> -->
                                        </div>
                                    </div>
                                    <div class="col d-flex justify-content-end align-items-center">
                                        <span>Hoàn thành</span>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div v-if="indexActive == 2"  class="container-fluid">
                <div class="home-product">
                    <!-- <div class="grid__row">
                        <div class="product-item grid__column-2">
                            <img src="" alt="">
                        </div>
                        <div class="product-item grid__column-2">
                            eeeeee
                        </div>
                        <div class="product-item grid__column-2">
                            eeeeee
                        </div>
                        <div class="product-item grid__column-2">
                            eeeeee
                        </div>
                        <div class="product-item grid__column-2">
                            eeeeee
                        </div>
                        <div class="product-item grid__column-2">
                            eeeeee
                        </div>
                        
                    </div> -->

                    <div class="grid__row">
                        <!-- item product -->
                        <div class="product-item grid__column-2" v-for="(item, index) in productShow">
                                <div class="card" :style="item.productStatus == 1 ? 'opacity: 0.5;' : '' ">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-auto">
                                                <div class="bg-image hover-zoom ripple rounded ripple-surface">
                                                    <img :src="'/images/menu/' + item.image" style="width: 100px; max-height: 80px;" />
                                                    <a href="#!">
                                                        <div class="hover-overlay">
                                                            <div class="mask" style="background-color: rgba(253, 253, 253, 0.15);">
                                                            </div>
                                                        </div>
                                                    </a>
                                                </div>
                                            </div>
                                            <div class="col text-left">
                                                <h5 style="margin-bottom: 0;">{{ item.productName }}</h5>
                                                <span v-if="item.productStatus == 1"><i>hết nguyên liệu</i></span>
                                                <span v-else><i>Có sẵn</i></span>
                                            </div>
                                            
                                        </div>
                                    </div>
                                    <div style="margin-top: 6px;" class="wrap_button_status">
                                        <button type="button" class="btn btn-warning" @click="updateProductStatus(item.productId, 1)">Hết NL</button>
                                        <button type="button" class="btn btn-primary" @click="updateProductStatus(item.productId, 0)">Có NL</button>
                                    </div>
                                </div>
                                
                        </div>

                    </div>
                </div>
            </div>
            
        </div>
        <!-- <div class="footer" style="position: absolute; bottom: 0;">

            <button @click="logout">Chef logout</button>
        </div> -->
    <LoadingModalVue v-show="isLoading" />
    </div>
</template>

<script>

const OWNER_ID = localStorage.getItem("ownerId");
import HeaderComponent from "@/components/employeeComponents/header.vue";
import { getOrder, updateStatusOrder, getCommonEmployeeOrder, updateStatusProduct } from "@/services/APIs/Service";
import { ROUTER } from "../../constants";
import moment from 'moment';
import LoadingModalVue from "../../components/modals/LoadingModal.vue";

export default {
    components: {
        HeaderComponent,
        LoadingModalVue
    },
    data() {
        return {
            isLoading: false,
            // 0: đang chờ (đã order); 1: Đã làm
            indexActive: 0,
            orders: {},
            waitingOrders: {},
            completedOrders: {},
            productShow: [],
            
            today: moment().format('DDMMYYYY'),
            currentTime: moment().format('HHmm'),
        };
    },
    watch: {
    },
    props: {
    },
    async created() {
        this.getOrder()
        // setInterval(this.getOrder, 15000);
        this.getProducts()
    },
    async mounted() {
    },

    methods: {
        async getOrder(){
            const params = {}
            params.ownerId = OWNER_ID

            this.orders = await getOrder(params)
            this.waitingOrders = this.orders?.filter((item)=> item.status == 0)
            this.completedOrders = this.orders?.filter((item) => item.status == 1 || item.status == 2)

            const timerId = setTimeout(() => {
                if(window.location.pathname == '/employee/chef'){
                    this.getOrder();
                }else{
                    clearTimeout(timerId);
                }
            }, 10000)
        },
        async getProducts(){
            const dataFirst = await getCommonEmployeeOrder(OWNER_ID);
            this.productShow = dataFirst?.products
        },
        async updateStatusOrder(orderId, tableId, productId, dateOrder, timeOrder, areaId){
            this.isLoading = true;
            const params = {}
            params.ownerId = OWNER_ID
            params.orderId = orderId
            params.tableId = tableId
            params.productId = productId
            params.dateOrder = dateOrder
            params.timeOrder = timeOrder
            params.areaId = areaId
            params.status = 1
            const result = await updateStatusOrder(params)
            if(result == true){
                this.getOrder()
                this.$toast.success("Xác nhận thành công")
            }else{
                this.$toast.error("Xác nhận thất bại, hãy load lại trang và thử lại")
            }
            
            this.isLoading = false;
        },
        logout() {
            localStorage.clear();
            this.$router.push({ name: ROUTER.ComLogin.name });
        },
        showOrder(index){
            this.indexActive = index
            this.getProducts();
            this.getOrder();
        },
        async updateProductStatus(productId, status){
            const params = {}
            params.ownerId = OWNER_ID
            params.productId = productId
            params.productStatus = status
            const result = await updateStatusProduct(params)
            this.getProducts()
        },
        formatDate(inputDate) {
            if (inputDate) {
                const day = inputDate.slice(0, 2);
                const month = inputDate.slice(2, 4);
                const year = inputDate.slice(4);
                return `${day}/${month}/${year}`;
            }
            return "---"
        },
        formatTime(number) {
            if (number) {
                const formattedTime = moment(number, "HHmmss").format("HH:mm:ss");
                return formattedTime;
            }
            return "---"
        },
    }
}
</script>


<style scoped>

.header{
    background-color: red !important;
    position: sticky;
    top: 0;
    z-index: 1;
}
.cart-body__item {
    font-size: 20px;
    padding: 16px;
}

.cart-body__item--icon {
    padding-right: 12px;
}

.cart-body__item--icon i {
    transform: translateY(2px);
}

.cart-body__item--name {
    display: inline-block;
}

.cart-body__item--quantity {
    font-size: 20px;
    padding-left: 10px;
}

.cart-body__item--price {
    float: right;
    font-size: 20px;
}

.cart-header {
    background-color: var(--color-main);
    height: 72px;
    display: flex;
    justify-content: center;
    align-items: center;
    font-size: 30px;
    font-weight: bold;
    color: #fff;
}

.cart-footer {
    position: absolute;
    bottom: 0;
    height: 80px;
    width: 100%;
    background-color: #ccc;
    display: flex;
    justify-content: center;
    align-items: center;
    font-size: 20px;
    color: #fff;
    font-weight: bold;
}

.cart {
    position: absolute;
    top: 0;
    right: 0;
    height: calc(100vh - 52px);
    background-color: white;
    width: 50%;
    z-index: 9;
    animation: fadeIn linear 0.5s;
    border-left: 10px solid #fff;
}

.main-section {
    position: relative;
    background-color: var(--color-main-bg);
    min-height: 100vh;
    width: 100%;
    overflow-x: hidden;
}

.icon-back {
    font-size: 26px;
    color: #fff !important;
    padding-right: 8px;
}

.text-title {
    background-color: var(--color-main);
    border-bottom: 1px solid #ccc;
    position: sticky;
}

.text-title a {
    color: #fff !important;
    font-size: 30px;
    font-weight: bold;
}

.wrap-item {
    height: 156px;
    width: 90%;
}

.item-content {
    position: relative;
    border: 1px solid #ccc;
    width: 100%;
    height: 100%;
    padding: 4px;
}

.item-content--img {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    width: 100%;
    max-height: 100%;
    overflow: hidden;
}

.item-content--name {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: lightgray;
    height: 34px;
    width: 100%;
    line-height: 34px;
    padding: 0 8px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
}

.category {
    width: 100%;
    overflow-x: auto;
    white-space: nowrap;
    padding: 0 4px 8px 4px;
}

.category-item {
    display: inline-block;
    background-color: #fff !important;
    width: 160px;
    height: 55px;
    margin: 8px 10px;
    border-radius: 4px;
    box-shadow: 1px 1px 4px -1px #000;
}

.category-item--active {
    box-shadow: 1px 1px 2px 4px var(--color-main);
}

.category-item--content {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100%;
    width: 100%;
    cursor: pointer;
}

/* content */
.content-item {
    height: 50px;
    margin: 10px 0;
    padding: 0;
    background-color: red;
    display: flex;
    justify-content: space-around;
}

.content-item--img {
    height: 20px;
    overflow: hidden;
    padding: 0;
    margin: 0;
}

.quantity {
    color: #000;
    font-size: 20px;
    font-weight: bold;
    padding: 0 10px;
    margin-right: 10px;
}

.icon-minus {
    color: #fff;
    font-size: 20px;
    font-weight: bold;
    padding: 0 13px;
    margin-right: 10px;
    border-radius: 4px;
    background-color: red;
    display: flex;
    justify-content: center;
    align-items: center;
}

.icon-plus {
    color: #fff;
    font-size: 20px;
    font-weight: bold;
    padding: 0 10px;
    margin-right: 10px;
    border-radius: 4px;
    background-color: #00bc8c;
    display: flex;
    justify-content: center;
    align-items: center;
}

.footer-wrap {
    padding-top: 6px;
    position: sticky;
    bottom: 0;
}

.footer {
    position: sticky;
    bottom: 0;
    background-color: #fff;
    height: 50px;
    box-shadow: 0 0 6px 0px #ccc;
    font-size: 20px;
    font-weight: bold;
}

.footer>div {
    display: flex;
    justify-content: center;
    align-items: center;
}

.footer-cancel {
    background-color: lightgray;
    border: 1px solid lightgray;
    color: gray;
}

.footer-ok {
    background-color: #00bc8c;
    color: #fff;
}

.footer-cart {
    position: relative;
    background-color: transparent;
    font-size: 36px;
    color: var(--color-main);
}

.footer-cart--quantity {
    color: #fff;
    font-size: 10px;
    display: flex;
    justify-content: center;
    align-items: center;
    position: absolute;
    top: 0px;
    right: calc(50% - 40px);
    background-color: red;
    height: 24px;
    width: 26px;
    border-radius: 50%;
}

.wrap_button_status {
    margin-left: 20px;
    margin-bottom: 10px;
}
.wrap_button_status .btn{
    font-size: 12px;
    padding: 4px 8px;
    margin-right: 8px;
    width: 55px;
    float: left;
}


/* LIST PRODUCT */

.grid__row {
    display: flex;
    flex-wrap: wrap;
    margin-left: -5px;
    margin-right: -5px;
}
.grid__column-2 {
    padding-left: 5px;
    padding-right: 5px;
    /* 100% / 5 = 20% */
    width: 16.666%;
}

.card{
    height: 140px;
    display: flex;
    justify-content: center;
}


@media(min-width: 1160px) and (max-width: 1725px) {

    .grid__column-2 {
        width: 20%;
    }
} 

@media(min-width: 1100px) and (max-width: 1159px) {
    .grid__column-2 {
        width: 25%;
    }
} 


@media(max-width: 1099px) {
    .grid__column-2 {
        width: 33.33%;
    }
} 

@media(max-width: 775px){
    .grid__column-2 {
        width: 33.33%;
    }
} 
@media(max-width: 690px){
    .grid__column-2 {
        width: 50%;
    }
} 
@media(max-width: 445px){
    .grid__column-2 {
        width: 100%;
    }
} 

@media(max-width: 634px) {
    .text-left h3{
        font-size: 20px;
    }
    .text-left div h6{
        font-size: 12px;
    }
} 

@media(max-width: 530px) {
    .text-left h3{
        font-size: 16px;
    }
    .text-left div h6{
        font-size: 10px;
    }

    button.btn-primary{
        font-size: 10px;
    }
    .category-item--wait {
        width: 120px !important;
    }
}



</style>