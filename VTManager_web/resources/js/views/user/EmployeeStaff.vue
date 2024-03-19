<template>
    <div style="position: relative; height: 100vh;">
        <div class="header">
            <HeaderComponent :title="`Nhân viên phục vụ`" />
        </div>
        <select class="form-select-adjust" data-size="5" style="width: 50%" v-model="selectArea">
            <option value="">Tất cả</option>
            <option v-for="(item, index) in listArea" :value="item.areaId">{{ item.areaName }}</option>
        </select>

        <div class="content">
            <div class="container-fluid">
                <div class="row" style="margin: 0 4px;">
                    <!-- item table -->
                    <div class="col-sm-4 col-md-3 col-lg-2 wrap-item" v-for="(item, index) in listTableShow">
                        <div class="item-content" @click="redirectOrder(item.tableId, item.areaId, item.orderId)">
                            <div class="item-content__wrap-notice">
                                <span class="item-content--notice-list" @click.stop="">
                                    <i class="fas fa-ellipsis-v"></i>
                                    <div class="item-content--notice-list--child">
                                        <ul class="item-content--notice-list--child__ul">
                                            <li class="item-content--notice-list--child__li" 
                                                v-if="item.status==0" @click.stop="updateStatusTable_temp(item.tableId, item.areaId, 1)" >
                                                Đặt bận
                                            </li>
                                            <li class="item-content--notice-list--child__li" 
                                            :style="flagShowNotice(item.tableId, item.areaId, 2) == true || flagShowNotice(item.tableId, item.areaId, 2) == false ? 'display:none;': ''"
                                                v-else @click.stop="updateStatusTable_temp(item.tableId, item.areaId, 0)" >
                                                Đặt trống
                                            </li>
                                            <li class="item-content--notice-list--child__li" 
                                                v-show="flagShowNotice(item.tableId, item.areaId, 2) == true || flagShowNotice(item.tableId, item.areaId, 2) == false" 
                                                @click.stop="showSwitchTable(item.tableId, item.areaName, item.areaId)">
                                                Chuyển bàn
                                            </li>
                                        </ul>
                                    </div>
                                </span>

                                <div class="wrap-item-content--notice">
                                    <span class="item-content--noticeX"
                                        v-show="flagShowNotice(item.tableId, item.areaId, 2) == false"
                                        @click.stop="quickShow(item.tableId, item.areaName, item.orderId, item.areaId)"><!--v-show="item.orderId" -->
                                        !
                                    </span>
                                    &ensp;
                                    <span class="item-content--noticeV"
                                        v-show="flagShowNotice(item.tableId, item.areaId, 2) == true || flagShowNotice(item.tableId, item.areaId, 2) == false"
                                        @click.stop="showPayment(item.tableId, item.areaName, item.orderId, item.areaId)"><!--v-show="flagShowNotice(item.tableId, item.areaId, 2) == true" -->
                                        <i class="fas fa-check"></i>
                                    </span>
                                </div>
                            </div>
                            <!-- <img class="item-content--img" src="/images/img_table.png" alt=""> -->
                            <div class="item-content--name">
                                {{ item.areaName }} - Bàn {{ parseInt(item.tableId, 10) }}
                            </div>
                            <div class="item-content--status"
                                :style="item.status == 1 ? ' color: #000;' : 'color: gray;'">
                                {{ showStatus(item.status) }}
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="footer" style="position: absolute; bottom: 0;">
        </div>

        <!-- popup xác nhận phục vụ -->
        <div class="popup" v-show="isShowPopup">
            <div class="popup-top">
                {{ dataPopup.areaName }} - Bàn {{ dataPopup.tableId }}
            </div>

            <div class="container-fluid popup-content">
                <div class="row" v-for="(item, index) in dataPopup.orders">
                    <div class="col-md-12 col-xl-12">
                        <div class="card shadow-0 border rounded-3">
                            <div class="card-body" style="height: 80px; padding: 10px;">
                                <div class="row">
                                    <div class="col-auto">
                                        <div class="bg-imag" style="margin: 0; padding: 0;">
                                            <img :src="'/images/menu/' + item.image" style="height: 60px;" />
                                        </div>
                                    </div>
                                    <div class="col text-left d-flex justify-content-start align-items-center product_names">
                                        <h5>{{ item.productName }} x {{ item.quantity }}</h5>
                                    </div>
                                    <div class="col-auto d-flex justify-content-start align-items-center">
                                        <span class="status-text" style="margin-left: -4px;">
                                            Trạng thái: {{ showStatusOrder(item.status) }}
                                        </span>
                                    </div>
                                    
                                    <div class="col-auto d-flex justify-content-start align-items-center" :style="item.status != 1 ? 'visibility: hidden' : ''">
                                        <button type="button" class="btn btn-primary btnConfirm"
                                                @click="updateStatusOrder(item.orderId, item.tableId, item.productId, item.areaName, item.dateOrder, item.timeOrder, item.areaId)">Phục vụ</button>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="popup-footer">
                <div class="popup-footer-btn">
                    <button class="popup-footer--back btn btn-light" @click="closePopup()">quay lại</button>
                    <button class="popup-footer--confirm btn btn-primary" @click="updateStatusOrderAll()">Xác nhận tất cả</button>
                </div>
            </div>
        </div>


        <!-- popup thanh toán -->
        <div class="popup" v-show="isShowPayment">
            <div class="popup-top">
                {{ dataPopupPayment.areaName }} - Bàn {{ dataPopupPayment.tableId }}
            </div>

            <div class="container-fluid popup-content popup-content__payment">

                <div class="row" v-for="(item, index) in dataPopupPayment.orders">
                   
                    <div class="col-md-12 col-xl-12">
                        <div class="card shadow-0 border rounded-3">
                            <div class="card-body" style="height: 80px; padding: 10px;">
                                <div class="row">
                                    <div class="col col-bg-image" style="display: flex; justify-content: flex-start; align-items: center; padding-left: 0;">
                                        <div class="bg-imag poup-payment__product-img" style="margin: 0; padding: 0;">
                                            <img :src="'/images/menu/' + item.image" style="height: 60px;" />
                                        </div>
                                        &ensp;
                                        <div class="poup-payment__product-name--wrap">
                                            <h5 class="poup-payment__product-name">{{ item.productName }}</h5>
                                        </div>
                                        &ensp;
                                        
                                        <h5 class="poup-payment__product-quantity">x{{ item.quantity }}</h5>
                                    </div>
                                    <div class="col d-flex justify-content-end align-items-center popup-payment__price">
                                        {{ formatNum(item.unitPrice) + ` x ` + item.quantity }}
                                        {{ ` = ` + formatNum(item.unitPrice * item.quantity) }}
                                        <br>
                                        
                                        (VAT {{ item['vatValue%'] }}%) Tổng: 
                                        {{ formatNum((item.unitPrice * item.quantity) + (item.unitPrice * item.quantity) * item['vatValue%'] / 100) }}
                                    </div>
                                    <div class="col popup-payment__status">
                                        {{ showStatusOrder(item.status) }}
                                        <button v-if="item.status == 0" type="button" class="btn btn-delete popup-payment__btnDelete"
                                        @click="deleteProductInOrder(item.ownerId, item.orderId, item.tableId, item.productId, item.dateOrder, item.timeOrder, item.areaId, item.areaName)">
                                            Xóa
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="popup-footer-top">
                <h5>Tổng tiền: {{ formatNum(dataPopupPayment.totalPrice) }}</h5>
            </div>
            <div class="popup-footer">
                <div class="popup-footer-btn">
                    <button class="popup-footer--back btn btn-light" @click="closePopup()">quay lại</button>
                    <button class="popup-footer--confirm btn btn-primary" @click="updateStatusPaid()"
                        style="margin-right: 15px;">Xác nhận đã thanh toán</button>
                </div>
            </div>
        </div>


        <!-- popup chuyển bàn -->
        <div class="popup" v-show="isShowPopupSwitchTables">
            <div class="popup-top">
                Danh sách bàn
            </div>

            <div class="container-fluid popup-content">
                
                <div class="popup-switch-table__wrap">

                    <div class="popup-switch-table__wrap__content" v-for="(itemArea, indexArea) in listArea">
                        <h5 class="popup-switch-table__wrap__content--areaname" >{{ itemArea.areaName }}</h5>
                        <div class="popup-switch-table__wrap__content--table" v-for="(itemTable, indexTable) in filterTablePopup(itemArea.areaId)" :style="itemTable.status == 1 ? 'opacity: 0.5; pointer-events: none; user-select: none;' : '' ">
                            <div @click="setDataSwitchTable(itemTable.tableId, itemTable.areaId, itemTable.areaName)" class="popup-switch-table__wrap__content--table--text" >{{ itemTable.tableId }}</div>
                        </div>
                    </div>
                    
                </div>

            </div>
            <div class="popup-footer">
                <div class="popup-footer-top">
                    {{ dataPopupSwitchTable.areaName }} - {{ dataPopupSwitchTable.tableId }} 
                    <i class="fas fa-caret-right" style="margin: 0 10px;"></i> 
                    {{ dataPopupSwitchTable.areaName2 }} - {{ dataPopupSwitchTable.tableId2 }} 
                </div>
                <div class="popup-footer-btn">
                    <button class="popup-footer--back btn btn-light" @click="closePopup()">quay lại</button>
                    <button class="popup-footer--confirm btn btn-primary" @click="switchTable()">Xác nhận</button>
                </div>
            </div>
        </div>


        <LoadingModalVue v-show="isLoading" />
    </div>
</template>

<script>

const OWNER_ID = localStorage.getItem("ownerId");
// import HeaderComponent from "../employeeComponents/header.vue";
import HeaderComponent from "@/components/employeeComponents/header.vue";
import { getTables, getTableOrders, getAreas, getOrder, updateStatusOrder, updateStatusOrders, updateStatusPaid, addBill, updateStatusTable, getCommonEmployeeStaff, deleteOrder, switchTable } from "@/services/APIs/Service";
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
            listTable: [],
            listTableShow: [],
            listArea: [],
            tableOrders: [],
            ordersAll: [],
            dataPopup: {
                tableId: null,
                areaName: null,
                orders: [],
            },
            dataPopupPayment: {
                tableId: null,
                areaName: null,
                areaId: null,
                orders: [],
                totalPrice: null,
                orderId: null,
            },
            dataPopupSwitchTable: {
                tableId: null,
                areaName: null,
                areaId: null,

                tableId2: null,
                areaName2: null,
                areaId2: null,
            },

            selectArea: '',
            isShowPopup: false,
            isShowPayment: false,
            isShowPopupSwitchTables: false,

            today: moment().format('DDMMYYYY'),
            currentTime: moment().format('HHmm'),
        };
    },
    watch: {
        selectArea(newValue, old) {
            this.filterTable(newValue)
        }
    },
    props: {
    },
    async created() {
        const areaId = this.$route.query.areaId || null
        if (areaId) {
            this.selectArea = areaId
        }


        this.getDataFirst();
    },
    async mounted() {
    },

    methods: {
        async getDataFirst() {
            const paramOrders = {}
            paramOrders.ownerId = OWNER_ID
            
            // cập nhật lại hiệu suất
            const temp = await getCommonEmployeeStaff(paramOrders)
            if(temp){
                this.listArea = temp?.areas 
                this.tableOrders = temp?.tableOrders
                this.listTable = temp?.tables
                this.listTableShow = this.listTable
                this.ordersAll = temp?.orders
            }
        },
        filterTable(areaId) {
            if (!areaId) {
                this.listTableShow = this.listTable
            } else {
                this.listTableShow = this.listTable.filter((item) => item.areaId == areaId)
            }
        },
        redirectOrder(tableId, areaId, orderId) {
            let query = {}
            query.tableId = tableId
            query.areaId = areaId
            if (orderId) {
                query.orderId = orderId
            }
            this.$router.push({
                name: 'Order',
                query
            });
        },
        showStatus(statusTable) {
            // const result = this.tableOrders.filter((item) => item.tableId == tableId)
            if (statusTable == 1) {
                return "Đang bận"
            } else {
                return "Bàn trống"
            }
        },
        showStatusOrder(status) {
            // const result = this.tableOrders.filter((item) => item.tableId == tableId)
            if (!status) {
                return "Đã order"
            } else if (status == 1) {
                return "Đã nấu"
            } else if (status == 2) {
                return "Đã phục vụ"
            }
        },
        flagShowNotice(tableId, areaId, number) {
            const productList = this.ordersAll.filter((item) => item.tableId == tableId && item.areaId == areaId)
            if (productList.length > 0) {
                const allNumsEqualNumber = productList.every(product => product.status == number);
                return allNumsEqualNumber
            } else {
                return -1
            }
        },

        async getOrderByTableId(orderId, tableId, areaId) {
            // lấy danh sách order để lọc và hiển thị popup
            const paramOrders = {}
            paramOrders.ownerId = OWNER_ID
            paramOrders.orderId = orderId
            paramOrders.tableId = tableId
            paramOrders.areaId = areaId
            this.dataPopup.orders = await getOrder(paramOrders)
            this.dataPopupPayment.orders = this.dataPopup.orders

            // this.dataPopupPayment.totalPrice = this.dataPopupPayment.orders.reduce((sum, item) => sum + (item.unitPrice * item.quantity), 0);
            this.dataPopupPayment.totalPrice = this.dataPopupPayment.orders.reduce((sum, item) => sum + ((item.unitPrice * item.quantity) + (item.unitPrice * item.quantity) * item['vatValue%'] / 100), 0);
            // this.dataPopup.orders = this.ordersAll.filter((item) => item.orderId == orderId && item.tableId == tableId)
        },
        async quickShow(tableId, areaName, orderId, areaId) {
            this.dataPopup.tableId = tableId
            this.dataPopup.areaName = areaName
            this.isShowPopup = true
            this.getOrderByTableId(orderId, tableId, areaId)
        },

        async showPayment(tableId, areaName, orderId, areaId) {
            this.dataPopupPayment.tableId = tableId
            this.dataPopupPayment.areaName = areaName
            this.dataPopupPayment.orderId = orderId
            this.dataPopupPayment.areaId = areaId
            this.isShowPayment = true
            this.getOrderByTableId(orderId, tableId, areaId)
        },
        async showSwitchTable(tableId, areaName, areaId) {
            this.dataPopupSwitchTable.tableId = tableId
            this.dataPopupSwitchTable.areaName = areaName
            this.dataPopupSwitchTable.areaId = areaId
            this.isShowPopupSwitchTables = true
        },
        filterTablePopup(areaId){
            return this.listTable.filter((item) => item.areaId == areaId)
        },
        setDataSwitchTable(tableId, areaId, areaName){
            this.dataPopupSwitchTable.areaName2 = areaName
            this.dataPopupSwitchTable.tableId2 = tableId
            this.dataPopupSwitchTable.areaId2 = areaId
        },
        async switchTable(){
            const params = {}
            params.ownerId = OWNER_ID
            params.tableId = this.dataPopupSwitchTable.tableId
            params.areaId = this.dataPopupSwitchTable.areaId
            params.tableId2 = this.dataPopupSwitchTable.tableId2
            params.areaId2 = this.dataPopupSwitchTable.areaId2
            const result = await switchTable(params)
            if(result == true){
                this.updateStatusTable_temp(this.dataPopupSwitchTable.tableId, this.dataPopupSwitchTable.areaId, 0)
                this.updateStatusTable_temp(this.dataPopupSwitchTable.tableId2, this.dataPopupSwitchTable.areaId2, 1)
            }
        },

        async updateStatusOrder(orderId, tableId, productId, areaName, dateOrder, timeOrder, areaId) {
            this.isLoading = true;
            const params = {}
            params.ownerId = OWNER_ID
            params.orderId = orderId
            params.tableId = tableId
            params.productId = productId
            params.dateOrder = dateOrder
            params.timeOrder = timeOrder
            params.areaId = areaId
            params.status = 2
            const result = await updateStatusOrder(params)
            if(result == true){
                this.$toast.success("Cập nhật thành công")
            }else{
                this.$toast.error("Cập nhật thất bại")
            }
            this.quickShow(tableId, areaName, orderId, areaId)
            this.isLoading = false;
        },
        async updateStatusOrderAll() {
            this.isLoading = true;
            const listOrderToUpdateStatus = []
            for (let index = 0; index < this.dataPopup?.orders?.length; index++) {
                if(this.dataPopup?.orders[index].status == 1){
                    const params = {}
                    params.ownerId = OWNER_ID
                    params.orderId = this.dataPopup?.orders[index].orderId
                    params.tableId = this.dataPopup?.orders[index].tableId
                    params.productId = this.dataPopup?.orders[index].productId
                    params.areaName = this.dataPopup?.orders[index].areaName
                    params.dateOrder = this.dataPopup?.orders[index].dateOrder
                    params.timeOrder = this.dataPopup?.orders[index].timeOrder
                    params.areaId = this.dataPopup?.orders[index].areaId
                    params.status = 2
                    listOrderToUpdateStatus.push(params);
                }
            }

            const result = await updateStatusOrders(listOrderToUpdateStatus)
            if(result == true){
                this.$toast.success("Cập nhật thành công")
            }else{
                this.$toast.error("Cập nhật thất bại")
            }
            const orderId = this.dataPopup?.orders[0].orderId
            const tableId = this.dataPopup?.orders[0].tableId
            const areaName = this.dataPopup?.orders[0].areaName
            const areaId = this.dataPopup?.orders[0].areaId
            this.quickShow(tableId, areaName, orderId, areaId)
            this.isLoading = false;
        },
        async updateStatusPaid() {
            this.isLoading = true;
            const params = {}
            params.ownerId = OWNER_ID
            params.orderId = this.dataPopupPayment?.orders[0]?.orderId
            params.dateOfPayment = this.today
            params.timeOfPayment = this.currentTime
            params.totalPayment = this.dataPopupPayment.totalPrice
            params.paymentType = 0 // 0 là trả tiền mặt
            const resultAddBill = await addBill(params);
            
            if(resultAddBill == true){
                const result = await updateStatusPaid(this.dataPopupPayment.orders)
                
                await this.updateStatusTable(0)
                // this.showPayment(this.dataPopupPayment.orders[0].tableId, this.dataPopupPayment.orders[0].areaName, this.dataPopupPayment.orders[0].orderId)
            }
            this.getDataFirst()
            this.isLoading = false;
            this.closePopup()
        },

        // cập nhật trạng thái bàn là đã hết khách
        async updateStatusTable(status){
            const params = {}
            params.tableId = this.dataPopupPayment?.tableId
            params.areaId = this.dataPopupPayment?.areaId
            params.ownerId = OWNER_ID
            params.status = status   // không là bàn trống, 1 là đang có khách
            const result = await updateStatusTable(params)
        },

        async updateStatusTable_temp(tableId, areaId, status){
            const params = {}
            params.tableId = tableId
            params.areaId = areaId
            params.ownerId = OWNER_ID
            params.status = status   // không là bàn trống, 1 là đang có khách
            const result = await updateStatusTable(params)
            if(result?.data?.data?.result == true){
                this.$toast.success("cập nhật thành công")
                this.getDataFirst()
            }
        },

        async deleteProductInOrder(ownerId, orderId, tableId, productId, dateOrder, timeOrder, areaId, areaName) {
            const params = {}
            params.ownerId = ownerId
            params.orderId = orderId
            params.tableId = tableId
            params.productId = productId
            params.dateOrder = dateOrder
            params.timeOrder = timeOrder
            params.areaId = areaId
            const result = await deleteOrder(params);
            if(result == 1){
                this.quickShow(tableId, areaName, orderId, areaId)
            }else{
                console.log("xóa thất bại");
            }
        },


        async closePopup() {
            this.isShowPopup = false
            this.isShowPayment = false
            this.isShowPopupSwitchTables = false
            // lấy order đầu tiên
            const paramOrders = {}
            paramOrders.ownerId = OWNER_ID
            this.ordersAll = await getOrder(paramOrders)
        },
        formatNum(number) {
            return number?.toLocaleString('en-US') + "đ"
        },
    }
}
</script>

<style scoped>
.popup {
    position: absolute;
    top: 5%;
    left: 10%;
    right: 10%;
    bottom: 10%;
    background-color: var(--color-main);
    z-index: 10;
}

.popup-top {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    height: 50px;
    background-color: var(--color-main-bg);
    display: flex;
    justify-content: center;
    align-items: center;
    font-size: 26px;
    font-weight: bold;
}

.popup-content {
    position: absolute;
    top: 70px;
    height: 83%;
    overflow: auto;
}

.popup-content__payment{
    height: 78% !important;
    padding-bottom: 40px;
}

.popup-footer-top {
    position: absolute;
    bottom: 50px;
    left: 0;
    right: 0;
    height: 50px;
    background-color: #fff;
    border-top: 1px solid lightgray;
    display: flex;
    justify-content: center;
    align-items: center;
}

.popup-footer {
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    height: 50px;
    background-color: var(--color-main-bg);
    display: flex;
    justify-content: center;
    align-items: center;
}

.popup-footer-btn {
    position: relative;
    height: 100%;
    width: 100%;
}

.popup-footer--confirm {
    position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    left: 50%;
    margin: 0 !important;
    border-radius: 0 !important;
    line-height: 16px;
}

.popup-footer--back {
    position: absolute;
    top: 0;
    bottom: 0;
    left: 0;
    right: 50%;
    border-radius: 0 !important;
}

.adjust-icon {
    font-size: 26px !important;
    margin-right: 20px;
}

.wrap-item {
    height: 200px;
    width: 90%;
    margin: 10px 0;
}

.wrap-item:hover {
    box-shadow: 0px 0px 1px 1px #000;
}

.item-content {
    position: relative;
    width: 100%;
    height: 100%;
    padding: 4px;
    background-color: var(--color-main-bg);
    cursor: pointer;
}

.item-content__wrap-notice{
    position: absolute; 
    top: 4px; 
    right: 0;
    left: 0;
    padding: 0 4px; 
    display: flex; 
    justify-content: space-around; 
    width: 100%;
}
.wrap-item-content--notice{
    width: 85%;
    display: flex;
    justify-content: flex-end;
}
.item-content--noticeX {
    z-index: 9;
    color: #fff;
    font-weight: bold;
    font-size: 20px !important;
    background-color: red;
    padding: 0 12px;
    border-radius: 50%;
}

.item-content--noticeV {
    z-index: 9;
    color: #fff;
    font-weight: bold;
    width: 30px;
    height: 30px;
    font-size: 16px !important;
    background-color: rgb(74, 198, 74);
    padding: 0 12px;
    border-radius: 50%;
    display: flex;
    justify-content: center;
    align-items: center;
}

.item-content--notice-list {
    position: relative;

    z-index: 9;
    font-weight: bold;
    font-size: 20px !important;
    background-color: #fff;
    color: #000;
    padding: 0 12px;
    border-radius: 50%;
}
.item-content--notice-list:hover .item-content--notice-list--child{
    display: block;
}
.item-content--notice-list--child{
    display: none;
    background-color: #fff; 
    width: 120px; 
    position: absolute; 
    top: 100%; 
    left: 0;
    box-shadow: 0px 0px 2px rgba(0, 0, 0, 0.5);
}

.item-content--notice-list--child__ul{
    margin: 0;
    margin-top: 12px;
    padding: 0;
    font-size: 14px;
    font-weight: 500;
}
.item-content--notice-list--child__li{
    list-style: none;
    padding: 4px 8px;
}
.item-content--notice-list--child__li:hover{
    background-color: #ccc;
}


.popup-switch-table__wrap{
    background-color: #fff;
    padding-bottom: 10px; 
    padding-top: 10px; 
    margin-bottom: 80px;
}
.popup-switch-table__wrap__content{
    margin-bottom: 16px;
}
.popup-switch-table__wrap__content--areaname{
    display: inline-block; 
    padding: 4px 16px;
}
.popup-switch-table__wrap__content--table{
    display: inline-block; 
    background-color: #ccc; 
    margin: 4px 4px;
    cursor: pointer;
}
.popup-switch-table__wrap__content--table:hover{
    background-color: lightgray;
}

.popup-switch-table__wrap__content--table--text{
    padding: 4px 8px;
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
    left: 0;
    top: 25%;
    right: 0;
    width: 100%;
    line-height: 34px;
    padding: 0 8px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    display: flex;
    justify-content: center;
    align-items: center;
    font-size: 30px;
    font-weight: bold;
    color: var(--color-main);
}

.item-content--status {
    position: absolute;
    left: 0;
    top: 50%;
    right: 0;
    width: 100%;
    line-height: 34px;
    padding: 0 8px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    display: flex;
    justify-content: center;
    align-items: center;
    font-size: 30px;
    font-weight: bold;
    color: var(--color-main);
}

.form-select-adjust {
    border: 1px solid #ccc;
    height: 100%;
    padding: 0 4px 0 4px;
    width: 100%;
    outline: none;
    height: 40px;
}

.popup-payment__status{
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: flex-end;
}

.popup-payment__status button{
    width: fit-content;
}


/* laptop - PC */
@media(min-width: 1350px){
    .item-content--status, .item-content--name{
        font-size: 30px;
    }
} 

/* laptop - PC */
@media(min-width: 1100px) and (max-width: 1350px){
    .item-content--status, .item-content--name{
        font-size: 25px;
    }
}  

/* tablet */
@media(min-width: 740px) and (max-width: 1100px){
    .item-content--status, .item-content--name{
        font-size: 20px;
    }
    .popup-top {
        font-size: 23px;
    }
    .poup-payment__product-img img{
        display: none;
    }
} 

/* mobile */
@media(max-width: 740px) {
    .item-content--status, .item-content--name{
        font-size: 15px;
    }

    .bg-imag, .col-bg-image{
        display: none;
    }
    .popup-payment__prdname{
        -webkit-flex: 0 0 22.333333% !important;
    }
    .popup-top {
        font-size: 20px;
    }

    .product_names h5{
        font-size: 15px;
    }
    .status-text{
        font-size: 10px;
    }
    .btnConfirm{
        font-size: 10px;
        padding: 2px;
    }
    .wrap-item {
        height: 100px;
        width: 50%;
    }
    .card-body{
        height: 60px !important;
    }
    .popup-payment__prdname{
        display: flex;
        flex-direction: column;
        justify-content: center;
    }
    .popup-payment__prdname h5{
        font-size: 12px;
        margin-bottom: 0;
    }
    .popup-payment__status{
        font-size: 12px;
        flex-direction: column;
    }
    .popup-payment__btnDelete{
        font-size: 12px;
        padding: 2px;
        width: 100%;
    }
    .popup-payment__price{
        font-size: 10px;
    }
    .col{
        padding-right: 0 !important;
    }

    .poup-payment__product-name{
        -webkit-flex-grow: 0 !important;
        font-size: 12px;
        overflow: hidden;
    }

    .poup-payment__product-quantity{
        font-size: 12px;
    }

    .poup-payment__product-img img{
        display: none;
    }
    .popup-payment__price{
        -webkit-flex-grow: 2 !important;
    }
    .poup-payment__product-name--wrap{
        display: flex;
        align-items: center;
        height: 40px; 
        overflow-x: hidden !important; 
        text-overflow: ellipsis;
    }
} 


</style>