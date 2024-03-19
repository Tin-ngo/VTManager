<template>
    <div class="main-section">
        <div class="container-fluid pt-2">
            <div class="card bg-condition">
                <div class="card-body">
                    <div class="row form-group">
                        <div class="border px-2 bg-condition-icon rounded" @click="toggleSearchForm">
                            <i :class="isSearchFormOpen ? 'fas fa-regular fa-minus' : 'fas fa-regular fa-plus'"
                                class="text-white"></i>
                        </div>
                        <div class="col-lg-3 bold">
                            {{ $t("label.search_conditions") }}
                        </div>
                        <div class="col bold text-right">
                            {{ currentDateTime }}
                        </div>
                    </div>
                    <div v-show="isSearchFormOpen">
                        <div class="form-row" style="margin: 0 12px">
                            <div class="form-group col-lg-2">
                                <label class="form-check-label bold">
                                    Tên nhân viên
                                </label>
                                <input type="text" class="form-control border-custom" v-model="employeeName"/>
                            </div>

                            <div class="col d-flex justify-content-end align-items-center">
                                <button class="btn btn-search" @click="search()">
                                    <font-awesome-icon icon="fas fa-search" />
                                    {{ $t("button.search") }}
                                </button>
                            </div>
                        </div>
                        <!-- <div class="form-row" style="margin: 0 12px">
                            <div class="form-group col-lg-2">
                                <label class="form-check-label bold">
                                    {{ $t("customer-master.label.customer_code") }}
                                </label>
                                <input type="text" class="form-control border-custom"/>
                            </div>
                            <div class="form-group col-lg-2">
                                <label class="form-check-label bold">
                                    {{ $t("customer-master.label.customer_name") }}
                                </label>
                                <input type="text" class="form-control border-custom"/>
                            </div>

                            <div class="col d-flex justify-content-end align-items-center">
                                <button class="btn btn-clear mr-2" @click="clear()">
                                    <font-awesome-icon :icon="['fas', 'share']" flip="horizontal" />
                                    {{ $t("button.clear") }}
                                </button>
                                <button class="btn btn-search" @click="search()">
                                    <font-awesome-icon icon="fas fa-search" />
                                    {{ $t("button.search") }}
                                </button>
                            </div>
                        </div> -->
                    </div>
                </div>
            </div>
        </div>
        <section>
            <div class="container-fluid">
                <div class="card bg-condition"> <!-- style="height: 545px"-->
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <table style="width: 100%">
                                    <thead class="bg-header">
                                        <tr class="text-center">
                                            <template v-for="(header, idx) in $t('employee.label.table_header')">
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
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr class="text-center bg-data-parent row-hover"
                                            v-for="(employee, key) in employees" :key="key">
                                            <td class="text-center max-w360">
                                                {{ employee.employeeId }}
                                            </td>
                                            <td class="text-left max-w360">
                                                {{ employee.employeeName }}
                                            </td>
                                            <td class="text-left max-w890">
                                                {{ employee.employeeClassName }}
                                            </td>
                                            <td class="text-center max-w890">
                                                {{ formatDate(employee.birthday) }}
                                            </td>
                                            <td class="text-center max-w890">
                                                {{ formatDate(employee.startDate) }}
                                            </td>
                                            <td class="text-left max-w890 text-center">
                                                <i class="fas fa-circle"
                                                    :class="check[key] == true ? 'color-green' : 'color-gray'"></i>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container-fluid footer-item">
                <div class="card">
                    <div class="card-body row">
                        <div class="col text-right">
                            <button class="btn btn-back" @click="handleBackButton">
                                <font-awesome-icon icon="fas fa-arrow-left" />
                                {{ $t("button.back") }}
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</template>

<script>

import { getEmployees, checkWorking } from "@/services/APIs/Service";
const OWNER_ID = localStorage.getItem("ownerId");

export default {
    data() {
        return {
            isOpenedFromMenu: false,
            isSearchFormOpen: false,
            contentHeight: "scroll-max-height",
            currentDateTime: new Date().toLocaleString(),

            employeeName: null,
            employees: [],
            check: []
        };
    },
    watch: {
    },
    props: {
    },
    created() {
    },
    async mounted() {
        this.$store.dispatch("auth/setTitle", this.$t("employee.header"));

        setInterval(() => {
            this.currentDateTime = new Date().toLocaleString();
        }, 1000);

        this.search();

        for (let index = 0; index < this.employees.length; index++) {
            this.isWorking(this.employees[index].employeeId, index)
        }
    },

    methods: {
        async search() {
            const params = {}
            params.ownerId = OWNER_ID
            if(this.employeeName != null){
                params.employeeName = this.employeeName
            }
            const dataEmployees = await getEmployees(params)
            if (dataEmployees) {
                this.employees = dataEmployees
            }
            console.log('data', this.employees);
        },
        handleBackButton() {
            this.$router.push('/overview');
        },
        toggleSearchForm() {
            this.isSearchFormOpen = !this.isSearchFormOpen;
        },
        async isWorking(employeeId, index) {
            const now = new Date();
            const currentHour = now.getHours();
            const currentMinute = now.getMinutes();
            const params = {}

            params.ownerId = OWNER_ID;
            params.dateOfWeek = now.getDay() - 1;
            params.timeWorking = `${currentHour}${currentMinute}`
            params.employeeId = employeeId
            const result = await checkWorking(params);
            console.log('result status', result);
            if (result == 0) {
                this.$set(this.check, index, false);
            } else {
                console.log('true');
                this.$set(this.check, index, true);
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
    }
}
</script>

<style scoped>
thead {
    box-shadow: 0 -1px 0px #ccc, 1px 1px 0px -1px #ccc;
}

.bg-condition-icon {
    background-color: #5b9bd5;
    font-weight: bold;
}

.bold {
    font-weight: bold;
}

/** 
Content

*/

table,
thead,
th,
tr,
td {
    border: 1px solid #ccc !important;
}

.bg-data-parent {
    background-color: #fff;
    height: 35px;
}

table {
    max-height: 450px;
    overflow-y: scroll;
}

thead {
    position: sticky;
    top: 0;
    z-index: 1;
    background: white;
    /* box-shadow: 0 -10px 0px black, 1px 1px 0px -1px black; */
}

td.text-left {
    padding: 0 4px;
}

.row-hover:hover {
    background-color: #fff2cc;
}

.scroll-min-height {
    max-height: 550px;
    overflow-y: auto;
}

.scroll-max-height {
    max-height: 625px;
    overflow-y: auto;
}

.max-w360 {
    max-width: 360px;
}

.max-w890 {
    max-width: 890px;
}

.color-green {
    color: rgb(83, 190, 83) !important;
}

.color-gray {
    color: gray !important;
}
</style>