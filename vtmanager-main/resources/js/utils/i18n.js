import en from "@/locales/en.json";
import vn from "@/locales/vn.json";
import Vue from "vue";
import VueI18n from "vue-i18n";

Vue.use(VueI18n);

export default new VueI18n({
  locale: localStorage.getItem("appLanguage") || import.meta.env.VITE_APP_I18N_LOCALE,
  fallbackLocale: import.meta.env.VITE_APP_I18N_FALLBACK_LOCALE || "en",
  messages: {
    en,
    vn,
  },
});
