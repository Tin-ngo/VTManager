<template>
  <transition name="modal-fade">
    <div class="modal-overlay">
      <div class="modal-download">
        <div class="container-fluid">
          <div class="card p-4">
            <div class="row form-group">
              <select v-model="option" class="form-control">
                <option
                  v-for="(item, index) in listOption"
                  :key="index"
                  :value="item.value"
                >
                  {{ item.name }}
                </option>
              </select>
            </div>

            <div class="row justify-content-between">
              <div class=" ">
                <button class="btn btn-default" @click="selectOption(option)">
                  <font-awesome-icon icon="fas fa-download" />
                  ダウンロード
                </button>
              </div>
              <div class="">
                <button class="btn btn-default" @click="close">
                  <font-awesome-icon icon="fas fa-close" />
                  閉じる
                </button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </transition>
</template>

<script>
export default {
  data() {
    return {
      option: 1,
      listOption: [
        {
          name: "保存（ブラウザのデフォルト保存先）",
          value: 1,
        },
        {
          name: "名前を付けて保存",
          value: 2,
        },
        {
          name: "開く",
          value: 3,
        },
      ],
    };
  },
  methods: {
    close() {
      this.$emit("close");
    },
    selectOption(option) {
      this.$emit("select", option);
      this.close();
    },
  },
};
</script>

<style scoped>
.modal-overlay {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;
  justify-content: center;
  background-color: #000000da;
  z-index: 9999;
}

.modal-download {
  background-color: white;
  margin: auto;
  padding: 20px;
  border-radius: 20px;
}

.close {
  margin: 10% 0 0 16px;
  cursor: pointer;
}

.btn-close {
  background-color: #ac003e;
  width: 150px;
  height: 40px;
  color: white;
  font-size: 14px;
  border-radius: 16px;
  margin-top: 50px;
}

.modal-fade-enter,
.modal-fade-leave-to {
  opacity: 0;
}

.modal-fade-enter-active,
.modal-fade-leave-active {
  transition: opacity 0.5s ease;
}

.btn-close {
  margin-bottom: 10px;
}
</style>
