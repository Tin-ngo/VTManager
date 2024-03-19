<template>
  <transition name="modal-fade">
    <div class="modal-overlay">
      <font-awesome-icon
        class="loading-icon"
        :icon="['fas', 'spinner']"
        spin-pulse
      />
    </div>
  </transition>
</template>

<script>
export default {
  data() {
    return {};
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

.modal-fade-enter,
.modal-fade-leave-to {
  opacity: 0;
}

.modal-fade-enter-active,
.modal-fade-leave-active {
  transition: opacity 0.5s ease;
}
.loading-icon {
  color: #fff;
  width: 50px;
  height: 50px;
  margin: auto;
  display: block;
}
</style>
