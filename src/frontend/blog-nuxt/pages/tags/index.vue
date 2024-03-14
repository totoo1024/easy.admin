<template>
  <!-- banner -->
  <div class="tag-banner banner" :style="cover">
    <h1 class="banner-title">标签</h1>
  </div>
  <!-- 标签列表 -->
  <v-card class="blog-container">
    <div class="tag-cloud-title">标签 - {{ tags?.data?.length }}</div>
    <div class="tag-cloud">
      <a
        :style="{ 'font-size': Math.floor(Math.random() * 10) + 18 + 'px' }"
        v-for="item of tags?.data"
        :key="item.id"
        :href="'/tags/' + item.id"
      >
        {{ item.name }}
      </a>
    </div>
  </v-card>
</template>

<script setup lang="ts">
import ArticleApi from "~/api/ArticleApi";
import AppApi from "~/api/AppApi";

const [{ data: tags }, { data: site }] = await Promise.all([
  ArticleApi.tags(),
  AppApi.info(),
]);

// 封面图
const cover = computed(() => {
  const arr = site.value?.data?.covers?.tag ?? ["/cover/tag.png"];
  const url = arr[randomNumber(0, arr.length - 1)];
  return "background: url(" + url + ") center center / cover no-repeat";
});

useSeoMeta({
  title: "标签-" + site.value?.data?.site?.siteName,
  description: site.value?.data?.site?.description,
  keywords: site.value?.data?.site?.keyword,
});
useHead({
  link: [{ rel: "icon", href: site.value?.data?.site?.logo ?? "" }],
});
</script>

<style scoped lang="scss">
.tag-banner {
  // background: url(https://www.static.talkxj.com/73lleo.png) center center /
  //   cover no-repeat;
  background-color: #49b1f5;
}
.tag-cloud-title {
  line-height: 2;
  font-size: 36px;
  text-align: center;
}
@media (max-width: 759px) {
  .tag-cloud-title {
    font-size: 25px;
  }
}
.tag-cloud {
  text-align: center;
  a {
    color: #616161;
    display: inline-block;
    text-decoration: none;
    padding: 0 8px;
    line-height: 2;
    transition: all 0.3s;
  }
  a:hover {
    color: #03a9f4 !important;
    transform: scale(1.1);
  }
}
</style>
