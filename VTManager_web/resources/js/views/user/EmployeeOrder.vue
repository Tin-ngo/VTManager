<template>
    <section class="main-section">
        <!-- header -->
        <nav class="navbar navbar-light text-title" style="position: sticky !important; top: 0; z-index: 1;">
            <a class="navbar-brand" href="#">Bàn {{ tableId }} - {{ areaName }}</a>
            <i class="fas fa-backward icon-back" @click="goBack()"></i>
        </nav>

        <!-- chọn phân loại -->
        <div class="category">
            <div class="category-item" @click="seachCategory(null, -1)"
                :class="indexActive == -1 ? 'category-item--active' : ''"> <!-- -->
                <div class="category-item--content">
                    Tất cả
                </div>
            </div>
            <div class="category-item" v-for="(item, index) in productTypes"
                @click="seachCategory(item.productTypeId, index)"
                :class="indexActive == index ? 'category-item--active' : ''"> <!-- -->
                <div class="category-item--content">
                    {{ item.productTypeName }}
                </div>
            </div>
        </div>

        <!-- content -->
        <div class="container-fluid container-fluid-content">
            <!-- item product -->
            <div class="row" v-for="(item, index) in productShow">
                <div class="col-md-12 col-xl-12">
                    <div class="card shadow-0 border rounded-3" :style="item.productStatus == 1 ? 'opacity: 0.5; cursor: not-allowed;' : '' ">
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
                                    <h5>{{ item.productName }}</h5>
                                    <div class="d-flex flex-row align-items-center mb-1">
                                        <h4 class="mb-1 me-1">{{ formatNum(item.unitPrice) }}</h4>
                                        <!-- <span class="text-danger"><s>$20.99</s></span> -->
                                    </div>
                                </div>
                                <div v-if="item.productStatus == 1" class="col d-flex justify-content-end align-items-center wrap-button">
                                    <i>Đã hết hàng</i>
                                </div>
                                <div v-else class="col d-flex justify-content-end align-items-center wrap-button">
                                     <!-- <span class="quantity">10</span> -->
                                    <!-- <span class="icon-minus" @click="removeListOrder(item.productId)">-</span> -->

                                    <!-- <span class="icon-plus" v-if="isUpdate == false"
                                        @click="addListOrder(item.productId, item.productName, item.unitPrice)">+</span>
                                    <span class="icon-plus" v-else
                                        @click="extraListOrder(item.productId, item.productName, item.unitPrice)">+</span> -->
                                        <span class="icon-plus"
                                        @click="extraListOrder(item.productId, item.productName, item.unitPrice)">+</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <!-- footer -->
        <div class="container-fluid footer-wrap">
            <!-- item product -->
            <div class="row footer">
                <div :style="checkStatusService() == false ? '' : 'pointer-events: none; opacity: 0.5;'" class="col-lg-4 footer-cancel" @click="removeAllOrder()">
                    Hủy tất cả
                </div>
                <div v-if="isUpdate == false" class="col-lg-4 footer-ok" @click="addOrder"> <!-- v-if="isUpdate == false" -->
                    Xác nhận
                </div>
                <div v-else :style="listOrdersExtra.length <= 0 ? 'pointer-events: none; opacity: 0.5; user-select: none;' : ''" class="col-lg-4 footer-ok" @click="updateOrder">
                    Cập nhật
                </div>
                <div class="col footer-cart" @click="showCart()">
                    <span class="footer-cart--quantity">{{ countOrder }}</span>
                    <i class="fas fa-shopping-cart footer-cart--cart"></i>
                </div>
            </div>
        </div>

        <div class="cart" v-show="isShowCart">
            <div class="cart-wrap">
                <div class="cart-header">
                <i class="fas fa-shopping-cart"></i>
                &ensp;
                đang order
            </div>
            <div class="cart-body">
                <div class="cart-body__item" v-for="(item, index) in listOrders">
                    <span class="cart-body__item--icon">
                        <i class="fas fa-exclamation-circle"></i>
                    </span>
                    <span class="cart-body__item--name">{{ item.productName }}</span>
                    <span class="cart-body__item--quantity">x {{ item.quantity }}</span>
                    <div class="cart-body__item--price">
                       <div style="display: flex; justify-content: space-between;">
                        {{ formatNum(item.quantity * item.unitPrice) }}
                        <span v-if="item.status == 0" @click="updateCart(item.ownerId, item.orderId, item.tableId, item.productId, item.dateOrder, item.timeOrder, item.areaId, item.quantity)" class="icon-minus" style="margin: 0;">-</span>
                       </div>
                    </div>
                </div>

                <hr />

                <!--  đặt thêm -->
                <div class="cart-body__item" v-for="(item, index) in listOrdersExtra">
                    <span class="cart-body__item--icon">
                        <i class="fas fa-exclamation-circle"></i>
                    </span>
                    <span class="cart-body__item--name">{{ item.productName }}</span>
                    <span class="cart-body__item--quantity">x {{ item.quantity }}</span>
                    <div class="cart-body__item--price">
                        <div style="display: flex; justify-content: space-between;">
                            {{ formatNum(item.quantity * item.unitPrice) }}
                            <span v-if="item.status == 0" @click="removeListOrder(item.productId)" class="icon-minus" style="margin: 0;">-</span>
                        </div>
                    </div>
                </div>

                <!-- <div class="cart-body__item" style="background-color: var(--color-main-bg);">
                    <span class="cart-body__item--icon">
                        <i class="fas fa-exclamation-circle"></i>
                    </span>
                    <span class="cart-body__item--name">tênádasda</span>
                    <span class="cart-body__item--quantity">x 2</span>
                    <span class="cart-body__item--price">tiền</span>
                </div> -->
            </div>
            <div class="cart-footer">
                Tổng cộng: {{ formatNum(totalPrice) }}
            </div>
            </div>
        </div>

        <LoadingModalVue v-show="isLoading" />
    </section>
</template>
 
<script>

// this.listOrders là list đã đặt -> điều chỉnh list đã đặt là ở đây
// this.listOrdersExtra là list vừa thêm - vừa thêm mới - hay vừa thêm cập nhật - điều chỉnh đơn hàng chưa thêm vào csdl ở đây

const OWNER_ID = localStorage.getItem("ownerId");
import moment from 'moment';
import { getAreas, getProductTypes, getProducts, addOrder, getOrder, updateOrder, deleteOrder, deleteOrders, reduceQuantity, updateStatusTable, getCommonEmployeeOrder } from "@/services/APIs/Service";
import LoadingModalVue from "../../components/modals/LoadingModal.vue";

export default {
    components: {
        LoadingModalVue
    },
    data() {
        return {
            isLoading: false,
            productTypes: [],
            products: [],
            productShow: [],
            listOrders: [],
            listOrdersExtra: [],

            countOrder: 0,
            totalPrice: 0,
            indexActive: -1,
            tableId: null,
            areaId: null,
            areaName: null,
            isShowCart: false,
            today: moment().format('DDMMYYYY'),
            currentTime: moment().format('HHmmss'),

            orderId: null,  // dùng khi cập nhật
            isUpdate: false
        };
    },
    watch: {
        listOrders(newVal, oldVal) {
        }
    },
    props: {
    },
    mounted() {
    },
    async created() {
        this.tableId = this.$route.query.tableId;
        this.areaId = this.$route.query.areaId;
        // this.orderId = this.$route.query.orderId || null;
        //order
        const params = {}
        params.ownerId = OWNER_ID
        params.tableId = this.tableId
        params.areaId = this.areaId
        const temp = await getOrder(params);
        if (temp.length > 0) {
            this.orderId = temp[0]?.orderId
            this.isUpdate = true
            this.getOrder()
        }

        this.isLoading = true;
        const dataFirst = await getCommonEmployeeOrder(OWNER_ID);

        const areas = dataFirst?.areas

        this.areaName = areas.filter((item) => item.areaId == this.areaId)[0]?.areaName;

        this.productTypes = dataFirst?.product_type

        this.products = dataFirst?.products

        this.productShow = this.products

        // const areas = await getAreas(OWNER_ID);

        // this.areaName = areas.filter((item) => item.areaId == this.areaId)[0]?.areaName;

        // this.productTypes = await getProductTypes(OWNER_ID);

        // this.products = await getProducts(OWNER_ID);
        // this.productShow = this.products

        this.isLoading = false;

    },
    async mounted() {
    },

    methods: {
        async getOrder() {
            const params = {}
            params.ownerId = OWNER_ID
            params.orderId = this.orderId
            params.tableId = this.tableId
            const result = await getOrder(params);
            this.listOrders = result
            // cập nhật
            this.countOrder = this.listOrders?.reduce((total, item) => total + item.quantity, 0);
            this.totalPrice = this.listOrders?.reduce((total, item) => total + (item.unitPrice * item.quantity), 0);
        },
       
        seachCategory(productTypeId, index) {
            this.indexActive = index
            if (!productTypeId) {
                this.productShow = this.products
            } else {
                this.productShow = this.products.filter((item) => item.productTypeId == productTypeId)
            }
        },
        // async updateOrder() {
        //     if(this.listOrders.length > 0){
        //         const params = this.listOrders
        //         for (let i = 0; i < params.length; i++) {
        //             params[i].orderId = this.orderId;
        //         }
        //         const resultDelete = await updateOrder(params)
        //         console.log('resultDelete', resultDelete);
        //     }else{
        //         this.deleteOrder()
        //     }
        // },
        async updateOrder() {
            this.isLoading = true;
            if (this.listOrdersExtra.length > 0) {
                const params = this.listOrdersExtra
                for (let i = 0; i < params.length; i++) {
                    params[i].orderId = this.orderId;
                    params[i].timeOrder = moment().format('HHmmss');
                }
                const result = await addOrder(params)
                if (parseInt(result)) {
                        this.getOrder()
                        this.$toast.success("Cập nhật thành công")
                        this.listOrdersExtra = []
                    }else{
                        this.getOrder()
                        this.$toast.error("Cập nhật lỗi, hãy cập nhật lại")
                        this.listOrdersExtra = []
                    }
            } 
            // else {
            //     this.deleteOrder()
            // }
            this.isLoading = false;
        },
        updateCart(ownerId, orderId, tableId, productId, dateOrder, timeOrder, areaId, quantity){
            if(quantity <= 1){
                this.deleteOrder(ownerId, orderId, tableId, productId, dateOrder, timeOrder, areaId)
            }else{
                this.reduceQuantity(ownerId, orderId, tableId, productId, dateOrder, timeOrder, areaId, quantity)
            }
            this.getOrder()
        },
        async deleteOrder(ownerId, orderId, tableId, productId, dateOrder, timeOrder, areaId) {
            const params = {}
            params.ownerId = ownerId
            params.orderId = orderId
            params.tableId = tableId
            params.productId = productId
            params.dateOrder = dateOrder
            params.timeOrder = timeOrder
            params.areaId = areaId
            const result = await deleteOrder(params);
        },

        async reduceQuantity(ownerId, orderId, tableId, productId, dateOrder, timeOrder, areaId, quantity){
            const params = {}
            params.ownerId = ownerId
            params.orderId = orderId
            params.tableId = tableId
            params.productId = productId
            params.dateOrder = dateOrder
            params.timeOrder = timeOrder
            params.areaId = areaId
            params.quantity = quantity
            const result = await reduceQuantity(params);
        },

        async addOrder() {
            this.isLoading = true;
            try {
                // const params = this.listOrders
                const params = this.listOrdersExtra
                if (params.length > 0) {
                    
                    for (let i = 0; i < params.length; i++) {
                        params[i].timeOrder = parseInt(moment().format('HHmmss'));
                    }
                    const result = await addOrder(params)
                    if (parseInt(result)) {
                        this.orderId = result
                        this.isUpdate = true
                        // cập nhật trạng thái bàn là đã có khách
                        this.updateStatusTable(1)
                        this.$router.replace({ path: '/employee/order', query: { tableId: this.tableId, areaId: this.areaId, orderId: this.orderId } });
                        
                        this.$toast.success("Đặt hàng thành công")
                        this.getOrder()
                        this.listOrdersExtra = []
                    }else{
                        this.$toast.error("Đặt hàng không thành công")
                    }
                } else {
                    this.$toast.error("Chưa có sản phẩm nào")
                }
            } catch (error) {
                console.log('Lỗi rồi');
            }
            
            this.isLoading = false;
        },
        // cập nhật trạng thái bàn là đã có khách
        async updateStatusTable(status) {
            const params = {}
            params.tableId = this.tableId
            params.areaId = this.areaId
            params.ownerId = OWNER_ID
            params.status = status  // không là bàn trống, 1 là đang có khách
            const result = await updateStatusTable(params)
        },
        addListOrder(productId, productName, unitPrice) {
            let check = false
            if (this.listOrders.length > 0) {
                for (let i = 0; i < this.listOrders.length; i++) {
                    if (this.listOrders[i].productId == productId) {
                        this.listOrders[i].quantity += 1
                        check = true
                    }
                }
                if (check == false) {
                    const params = {}
                    params.productId = productId
                    params.quantity = 1
                    params.productName = productName
                    params.unitPrice = unitPrice
                    this.listOrders.push(params)
                }
            } else {
                const params = {}
                params.productId = productId
                params.quantity = 1
                params.productName = productName
                params.unitPrice = unitPrice
                this.listOrders.push(params)
            }

            for (let i = 0; i < this.listOrders.length; i++) {
                this.listOrders[i].ownerId = OWNER_ID;
                this.listOrders[i].tableId = this.tableId;
                this.listOrders[i].areaId = this.areaId;
                this.listOrders[i].status = 0;   // 0 là đã order
                this.listOrders[i].dateOrder = this.today
                this.listOrders[i].timeOrder = this.currentTime
                this.listOrders[i].isPaid = 0 // 0 là chưa thanh toán
            }

            this.countOrder = this.listOrders?.reduce((total, item) => total + item.quantity, 0);
            this.totalPrice = this.listOrders?.reduce((total, item) => total + (item.unitPrice * item.quantity), 0);
        },
        extraListOrder(productId, productName, unitPrice) {
            let check = false
            if (this.listOrdersExtra.length > 0) {
                for (let i = 0; i < this.listOrdersExtra.length; i++) {
                    if (this.listOrdersExtra[i].productId == productId) {
                        this.listOrdersExtra[i].quantity += 1
                        check = true
                    }
                }
                if (check == false) {
                    const params = {}
                    params.productId = productId
                    params.quantity = 1
                    params.productName = productName
                    params.unitPrice = unitPrice
                    this.listOrdersExtra.push(params)
                }
            } else {
                const params = {}
                params.productId = productId
                params.quantity = 1
                params.productName = productName
                params.unitPrice = unitPrice
                this.listOrdersExtra.push(params)
            }

            for (let i = 0; i < this.listOrdersExtra.length; i++) {
                this.listOrdersExtra[i].ownerId = OWNER_ID;
                this.listOrdersExtra[i].tableId = this.tableId;
                this.listOrdersExtra[i].areaId = this.areaId;
                this.listOrdersExtra[i].status = 0;   // 0 là đã order
                this.listOrdersExtra[i].dateOrder = this.today
                this.listOrdersExtra[i].timeOrder = this.currentTime
                this.listOrdersExtra[i].isPaid = 0 // 0 là chưa thanh toán
            }

            this.countOrder = this.listOrders?.reduce((total, item) => total + item.quantity, 0) + this.listOrdersExtra?.reduce((total, item) => total + item.quantity, 0);
            this.totalPrice = this.listOrders?.reduce((total, item) => total + (item.unitPrice * item.quantity), 0) + this.listOrdersExtra?.reduce((total, item) => total + (item.unitPrice * item.quantity), 0);
        },
        removeListOrder(productId) {
            // đã thay listOrders thành listOrdersExtra
            let check = false
            if (this.listOrdersExtra.length > 0) {
                for (let i = 0; i < this.listOrdersExtra.length; i++) {
                    if (this.listOrdersExtra[i].productId == productId) {
                        if (this.listOrdersExtra[i].quantity > 1) {
                            this.listOrdersExtra[i].quantity -= 1
                            check = true
                        } else {
                            this.listOrdersExtra = this.listOrdersExtra.filter(item => item.productId != productId);
                            check = true
                        }
                    }
                }
                if (check == false) {
                    this.listOrdersExtra = this.listOrdersExtra.filter(item => item.productId != productId);
                }
            } else {
                this.listOrdersExtra = []
            }
            this.countOrder = this.listOrders?.reduce((total, item) => total + item.quantity, 0) + this.listOrdersExtra?.reduce((total, item) => total + item.quantity, 0);
            this.totalPrice = this.listOrders?.reduce((total, item) => total + (item.unitPrice * item.quantity), 0) + this.listOrdersExtra?.reduce((total, item) => total + (item.unitPrice * item.quantity), 0);
        },

        checkStatusService(){
            // có 1 status != 0 thì là true
            const hasStatusOne = this.listOrders.some(order => order.status != 0);
            return hasStatusOne
        },
        async removeAllOrder() {
            this.listOrdersExtra = []
            if(this.listOrders.length > 0){
                const result = await deleteOrders(this.listOrders);
                if(result == true){
                    this.listOrders = []
                    this.$toast.success("Hủy đơn hàng thành công")
                    this.updateStatusTable(0)
                }else{
                    this.$toast.error("Hủy đơn hàng thất bại")
                }
            }
            this.countOrder = this.listOrders?.reduce((total, item) => total + item.quantity, 0) + this.listOrdersExtra?.reduce((total, item) => total + item.quantity, 0);
            this.totalPrice = this.listOrders?.reduce((total, item) => total + (item.unitPrice * item.quantity), 0) + this.listOrdersExtra?.reduce((total, item) => total + (item.unitPrice * item.quantity), 0);
        },
        showCart() {
            this.isShowCart = !this.isShowCart
        },

        formatNum(number) {
            return number?.toLocaleString('en-US') + " đ"
        },

        goBack() {
            this.$router.push({
                path: '/employee/staff'
            });

        }
    }
}
</script>
 
<style scoped>

.cart-body{
    height: 83%;
    overflow: auto;
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
    width: 145px !important;
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

.cart{
    width: 100%;
    background-color: red !important;
}
.cart-wrap {
    position: fixed;
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
.wrap-button span{
    cursor: pointer;
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
    cursor: pointer;
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
    cursor: pointer;
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

.container-fluid-content{
    padding-top: 6px; 
    min-height: calc(100vh - 208px);
}

/* laptop - PC */
@media(max-width: 991px){
    .footer-cart{
        height: 32px;
        background-color: #fff;
    }
    .footer-cart--cart{
        font-size: 20px;
    }
    .footer-cart--quantity{
        right: calc(50% - 29px);
        height: 17px;
        width: 18px;
    }
    .container-fluid-content{
        padding-top: 6px; 
        min-height: calc(100vh - 231px);
    }
    .cart-wrap{
        width: 70% !important;
        height: calc(100vh - 33px);
    }

    .category-item {
        width: 135px;
        height: 35px;
    }
    .cart-body__item--quantity{
        font-size: 14px;
    }
    .cart-body__item--name{
        font-size: 14px;
    }
    .cart-body__item--price{
        font-size: 14px;
    }
} 

/* small */
@media(max-width: 500px){
    .text-left h5, .text-left h4 {
        font-size: 15px !important;
    }
} 

/* small */
@media(max-width: 360px){
    img{
        width: 75px !important;
    }
    .cart-wrap{
        width: 90% !important;
        height: calc(100vh - 33px);
    }
} 

</style>