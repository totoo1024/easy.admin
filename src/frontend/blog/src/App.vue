<template>
  <v-app :theme="theme">
    <!-- 导航栏 -->
    <TopNavBar />
    <!-- 侧边导航栏 -->
    <SideNavBar />
    <v-main> <router-view :key="key" /> </v-main>
    <!-- 脚部 -->
    <Footer v-if="route.name !== 'message'" />
    <!-- 返回顶部 -->
    <BackTop />
  </v-app>
</template>

<script setup lang="ts">
import { useRoute } from "vue-router";
import { storeToRefs } from "pinia";
import TopNavBar from "./components/layout/TopNavBar.vue";
import SideNavBar from "./components/layout/SideNavBar.vue";
import Footer from "./components/layout/Footer.vue";
import BackTop from "./components/BackTop.vue";
import { useThemeSettingStore } from "./stores/themeSetting";
import { computed, watch } from "vue";
import { useAuth } from "./stores/auth";
const authStore = useAuth();
const { theme } = storeToRefs(useThemeSettingStore());
const route = useRoute();
const key = computed(() => {
  return route.fullPath + Math.random();
});
const code = computed(() => {
  return (route.query?.code as string) || (route.params?.code as string);
});
//解决刷新后，code丢失的问题
watch(code, async () => {
  if (code.value) {
    // 第三方授权登录（QQ）
    await authStore.login(code.value);
  }
});
</script>
