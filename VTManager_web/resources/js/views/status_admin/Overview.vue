<template>
    <section class="main-section">
        <div class="container-fluid pt-2">
            <div class="row justify-content-center">
                <div class="col-md-12">
                    <div class="card bg-condition">
                        <ul class="nav justify-content-start" style="padding: 10px; margin-top: 16px;">
                            <li class="nav-item" @click="setActive(-1, null)" :class="{ active: -1 === activeIndex }">
                                <a class="nav-link" href="#">Tất cả</a>
                            </li>
                            <li class="nav-item" v-for="(item, index) in areas" :class="{ active: index === activeIndex }"
                                @click="setActive(index, item.areaId)">
                                <a class="nav-link" href="#">{{ item.areaName }}</a>
                            </li>
                        </ul>

                        <!-- <div class="content">
                        <table class="table">
                            <thead>
                                <template v-for="(header, idx) in $t('overview.label.table_header')">
                                    <td :key="idx" :style="idx == 0
                                        ? 'width: 10% !important;'
                                        : idx == 1
                                            ? 'width: 20% !important;'
                                            : idx == 2
                                                ? 'width: 20% !important;'
                                                : idx == 3
                                                    ? 'width: 20% !important;'
                                                    : idx == 4
                                                        ? 'width: 20% !important;'
                                                        : idx == 5
                                                            ? 'width: 10% !important;'
                                                            : ''
                                        ">
                                        {{ header }}
                                    </td>
                                </template>
                            </thead>
                            <tbody>
                                <tr v-for="(item, index) in tableOrders">
                                    <th scope="row">{{ index + 1 }}</th>
                                    <td>{{ item.tableId }}</td>
                                    <td>{{ item.areaName }}</td>
                                    <td>
                                        {{ formatDate(item?.dateOrder) }} {{ formatTime(item?.timeOrder) }}
                                    </td>
                                    <td>{{ showStatusOrder(item.statusOrder) }}</td>
                                    <td>{{ item.statusTableJoin }}</td>
                                    <td>
                                        <button class="btn btn-create">
                                            <font-awesome-icon icon="fa-solid fa-pencil" />
                                            {{ $t("button.create") }}
                                        </button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div> -->
                        <div class="card-body">
                            <div class="wrap-scroll" style="max-height: 660px;">
                                <!-- <div class="search-result pl-2 w-100 mg-0 item-scroll"
                                    style="border: 1px solid #ccc; line-height: 32px; height: 34px">
                                    <label style="margin-bottom: 0" class="wrap-scroll-dispatch-title">{{
                                        $t("label.search_results") }}</label>
                                </div> -->
                                <div
                                    class="text-center row-table header-row w-100 item-scroll wrap-scroll-dispatch-header d-flex">
                                    <template v-for="(header, idx) in tableHeader">
                                        <div :style="{
                                            width: header.width,
                                            background: '#ccc',
                                            color: 'black',
                                            'border-color': 'white',
                                        }" :key="idx"
                                            :class="'cell align-items-center header-color d-flex justify-content-center bg-header'">
                                            {{ header.name }}
                                        </div>
                                    </template>
                                </div>
                                <template>
                                    <!-- ccontent -->
                                    <div v-for="(item, index) in tableOrdersShow" :key="index"
                                        style="border-bottom: 1px solid #ccc;">
                                        <div :id="'parent-' + index" class="row-table w-100 text-center data-parent d-flex"
                                            :style="item.statusTable == 0 ? 'background-color: var(--color-row)' : 'background-color: var(--color-row-active);'">
                                            <!-- :class="isShowDetail[index] ? 'bg-item' : ''" -->
                                            <div style="width: 10%; color: blue" @click="showDetailData(index)">
                                                <!-- <i :class="isShowDetail[index] ? 'fas fa-chevron-up' : 'fas fa-chevron-down'"></i> -->
                                                <i :id="'icon-' + index" :class="'fas fa-chevron-up'"></i>
                                            </div>

                                            <div class="cell" style="width: 20%; cursor: pointer;">
                                                {{ item.tableId }}
                                            </div>
                                            <div class="cell" style="width: 20%">
                                                {{ item.areaName }}
                                            </div>
                                            <div class="cell" style="width: 20%">
                                                {{ formatDate(item?.dateOrder) }} {{ formatTime(item?.timeOrder) }}
                                            </div>
                                            <div style="width: 10%">
                                                {{ showStatusTable(item.statusTable) }}
                                            </div>
                                            <div style="width: 10%;">
                                                {{ showStatusJoinTable(item.statusTableJoin) }}
                                            </div>
                                            <div style="width: 10%;">
                                                {{ item.maxCapacity }}
                                            </div>
                                        </div>


                                        <div :id="'children-' + index" class="wrap-children"
                                            style="margin-left: 11%; margin-right: 26.5%; display: none;">
                                            <div class="d-flex row-table-child w-100">
                                                <template v-for="(header, idx) in tableHeaderChild">
                                                    <div class="d-inline-block cell border-custom font-weight-bold"
                                                        style="font-size: 14px; border: none" :style="{
                                                            width: header.width,
                                                            'text-align': 'center',
                                                        }" :key="idx">
                                                        {{ header.name }}
                                                    </div>
                                                </template>
                                            </div>
                                            <div class="d-flex row-table-child"
                                                style="border-top: 1px solid var(--color-border);"
                                                v-for="(itemChildren, indexChildren) in filterChildren(item.tableId)">
                                                <div class="cell-sub" style="width: 10%">
                                                    {{ itemChildren?.tableId }}
                                                </div>
                                                <div class="cell-sub" style="width: 10%">
                                                    {{ itemChildren?.productId }}
                                                </div>
                                                <div class="cell-sub" style="width: 20%">
                                                    {{ itemChildren?.productName }}
                                                </div>
                                                <div class="cell-sub" style="width: 10%">
                                                    {{ itemChildren?.quantity }}
                                                </div>
                                                <div class="cell-sub" style="width: 20%">
                                                    {{ formatMoney(itemChildren?.unitPrice) }}
                                                </div>
                                                <div class="cell-sub" style="width: 20%">
                                                    {{ showStatusOrder(itemChildren.statusOrder) }}
                                                </div>
                                                <div class="cell-sub" style="width: 10%">
                                                    {{ formatMoney((itemChildren?.unitPrice * itemChildren?.quantity)) }}
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </template>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>

<script>

import _ from "lodash";
import { getAreas, getTables, getOrders, getTableOrders, getCommonOrders } from "@/services/APIs/Service";
const OWNER_ID = localStorage.getItem("ownerId");

export default {
    computed: {
        tableHeader() {
            return {
                0: {
                    width: "10%",
                    name: this.$t("overview.label.table_header.0"),
                },
                1: {
                    width: "20%",
                    name: this.$t("overview.label.table_header.1"),
                },
                2: {
                    width: "20%",
                    name: this.$t("overview.label.table_header.2"),
                },
                3: {
                    width: "20%",
                    name: this.$t("overview.label.table_header.3"),
                },
                4: {
                    width: "10%",
                    name: this.$t("overview.label.table_header.4"),
                },
                5: {
                    width: "10%",
                    name: this.$t("overview.label.table_header.5"),
                },
                6: {
                    width: "10%",
                    name: this.$t("overview.label.table_header.6"),
                }
            };
        },
        tableHeaderChild() {
            return {
                0: {
                    width: "10%",
                    name: "Id bàn",
                },
                1: {
                    width: "10%",
                    name: 'id Product',
                },
                2: {
                    width: "20%",
                    name: 'product name',
                },
                3: {
                    width: "10%",
                    name: 'quantity',
                },
                4: {
                    width: "20%",
                    name: 'Unit Price',
                },
                5: {
                    width: "20%",
                    name: 'Status',
                },
                6: {
                    width: "10%",
                    name: 'Total Price',
                },
            };
        },
    },
    data() {
        return {
            areas: null,
            tables: null,
            tableOrders: null,
            tableOrdersUnique: null,
            tableOrdersShow: null,
            orders: null,

            activeIndex: -1,
            currentAreaId: null,
        };
    },

    watch: {},
    async created() {
    },

    async mounted() {
        console.log('ownerIds', OWNER_ID);
        this.$store.dispatch("auth/setTitle", this.$t("overview.header"));
        await this.getFirst();
        // setInterval(this.loadTableOrders, 10000);
        this.loadTableOrders()
    },
    methods: {
        async getFirst() {
            [this.areas, this.tables, this.orders, this.tableOrders] = await Promise.all([
                getAreas(OWNER_ID),
                getTables(OWNER_ID),
                getOrders(OWNER_ID),
                getTableOrders(OWNER_ID)
            ]);

            // lấy duy nhất tableId
            this.tableOrdersUnique = await this.tableOrders.filter((item, index, self) => {
                return self.findIndex((other) => other.tableId === item.tableId) === index;
            });

            this.tableOrdersShow = this.tableOrdersUnique

            if (this.currentAreaId !== null) {
                this.tableOrdersShow = this.tableOrdersUnique.filter((item) => item.areaId === this.currentAreaId)
            }

            // console.log('this.areas', this.areas);
            // console.log('this.tables', this.tables);
            // console.log('this.orders', this.orders);
            // console.log('this.tableOrders', this.tableOrders);
            // console.log('this.tableOrdersShow', this.tableOrdersShow);
        },
        async loadTableOrders() {
            const resultCommonOrders = await getCommonOrders(OWNER_ID)
            this.tableOrders = resultCommonOrders?.tableOrders
            // lấy danh sách order để lọc
            this.orders = resultCommonOrders?.orders

            // lấy duy nhất tableId
            this.tableOrdersUnique = await this.tableOrders.filter((item, index, self) => {
                return self.findIndex((other) => other.tableId === item.tableId) === index;
            });
            this.tableOrdersShow = this.tableOrdersUnique
            if (this.currentAreaId !== null) {
                this.tableOrdersShow = this.tableOrdersUnique.filter((item) => item.areaId === this.currentAreaId)
            }

            const timerId = setTimeout(() => {
                if(window.location.pathname == '/overview'){
                    console.log('tiếp tục overview');
                    this.loadTableOrders();
                }else{
                    console.log('clear overview');
                    clearTimeout(timerId);
                }
            }, 10000)

        },
        filterChildren(tableId) {
            return this.tableOrders.filter((item) => item.tableId === tableId && item.productId !== null)
        },
        showDetailData(index) {
            const itemElementChildren = document.getElementById("children-" + index);
            const itemElementParent = document.getElementById("parent-" + index);
            const itemElementParentIcon = document.getElementById("icon-" + index);
            if (itemElementChildren.classList.contains("show")) {
                itemElementChildren.classList.remove("show");
                itemElementParent.classList.remove("row-cliked");
                itemElementParentIcon.className = ''
                itemElementParentIcon.classList.add("fas", "fa-chevron-up");
            } else {
                itemElementChildren.classList.add("show");
                itemElementParent.classList.add("row-cliked");
                itemElementParentIcon.className = ''
                itemElementParentIcon.classList.add("fas", "fa-chevron-down");
            }
        },
        setActive(index, areaId) {
            this.currentAreaId = areaId
            console.log('sd');
            this.activeIndex = index;
            if (index == -1) {
                this.tableOrdersShow = this.tableOrdersUnique
            } else {
                this.tableOrdersShow = this.tableOrdersUnique.filter((item) => item.areaId === this.currentAreaId)
            }
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
                const timeString = number.toString();
                const hours = timeString.slice(0, 2);
                const minutes = timeString.slice(2);
                return `${hours}:${minutes}`;
            }
            return "---"
        },
        showStatusOrder(status) {
            if (status !== null) {
                if (status == 0) {
                    return "Đã Order"
                } else if (status == 1) {
                    return "Bếp đã nấu"
                } else if (status == 2) {
                    return "Đã phục vụ"
                }
            }
        },
        showStatusTable(status) {
            if (status !== null) {
                if (status == 0) {
                    return "Bàn trống"
                } else if (status == 1) {
                    return "Đã có khách"
                }
            }
        },
        showStatusJoinTable(status) {
            if (status !== null) {
                return "Có ghép"
            }
            return "Không ghép"
        },
        formatMoney(price) {
            if (price != null) {
                return price.toLocaleString('en-US') + "$";
            }
            return ""
        }
    }
}
</script>


<style scoped>
.nav-item {
    font-weight: bold;
    font-size: 20px;
    padding: 0 40px;
}

.active {
    box-shadow: 0px 3px 4px -2px #000;
}

.wrap-scroll {
    height: 100%;
    overflow-y: auto;
    position: relative;
}

.wrap-scroll-dispatch-title {
    position: sticky;
    top: 0;
    background-color: white;
}

.wrap-scroll-dispatch-header {
    position: sticky;
    top: 0 !important;
}

.show {
    display: block !important;
}

.row-cliked {
    background-color: #679ad4;
}

.row-table div {
    height: calc(var(--height-row) + 10px);
    line-height: var(--height-row);
    display: flex;
    justify-content: center;
    align-items: center;
}

.row-table-child div {
    height: var(--height-row);
    line-height: var(--height-row);
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 0 4px;
}
</style>