import { defineConfig } from "vite";
import laravel from "laravel-vite-plugin";
import vue from "@vitejs/plugin-vue2";
import { fileURLToPath, URL } from "node:url";

export default defineConfig({
    base: "./",
    plugins: [
        laravel({
            input: ["resources/sass/app.scss", "resources/js/main.js"],
            refresh: true,
        }),
        vue({
            template: {
                transformAssetUrls: {
                    base: null,
                    includeAbsolute: false,
                },
            },
        }),
    ],
    resolve: {
        alias: {
            vue: "vue/dist/vue.esm.js",
            "@": fileURLToPath(new URL("./resources/js", import.meta.url)),
            "~": fileURLToPath(new URL("./node_modules", import.meta.url)),
        },
    },
    build: {
        emptyOutDir: true,
        manifest: true,
        rollupOptions: {
            input: {
                main: "./resources/js/main.js",
            },
            output: {
                manualChunks: {},
            },
        },
    },
});
