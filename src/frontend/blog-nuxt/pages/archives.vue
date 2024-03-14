<template>
  <div>
    <!-- banner -->
    <div class="banner" :style="cover">
      <h1 class="banner-title">归档</h1>
    </div>
    <!-- 归档列表 -->
    <v-card class="blog-container">
      <timeline>
        <timeline-title>
          目前共计{{ articles?.data?.total ?? 0 }}篇文章，继续加油
        </timeline-title>
        <timeline-item v-for="item of articles?.data?.rows" :key="item.id">
          <v-card style="padding: 20px 20px">
            <!-- 日期 -->
            <div class="time">{{ item.publishTime }}</div>
            <!-- 文章标题 -->
            <a
              :href="'/articles/' + item.id"
              style="color: #666; text-decoration: none"
              :title="item.title!"
            >
              {{ item.title }}
            </a>
          </v-card>
        </timeline-item>
      </timeline>
      <!-- 分页按钮 -->
      <v-pagination
        v-if="(articles?.data?.pages ?? 0) > 1"
        size="x-small"
        :length="articles?.data?.pages"
        active-color="#00C4B6"
        v-model="pager.pageNo"
        :total-visible="3"
        variant="elevated"
      ></v-pagination>
    </v-card>
  </div>
</template>

<script setup lang="ts">
// 文档：https://github.com/xiaojieajie/vue3-cute-timeline
// import "vue3-cute-component/dist/style.css";
// import { Timeline, TimelineTitle, TimelineItem } from "vue3-cute-component";
import type { Pagination } from "~/api/models/pagination";
import ArticleApi from "~/api/ArticleApi";
import AppApi from "~/api/AppApi";
const pager = ref<Pagination>({
  pageNo: 1,
  pageSize: 10,
});

const [{ data: articles }, { data: site }] = await Promise.all([
  ArticleApi.list(pager),
  AppApi.info(),
]);

watch(
  () => pager.value.pageNo,
  () => {
    setTimeout(() => {
      window.scrollTo({
        behavior: "smooth",
        top: 0,
      });
    }, 200);
  }
);

// 封面图
const cover = computed(() => {
  const arr = site.value?.data?.covers?.archives ?? ["archives.jpg"];
  const url = arr[randomNumber(0, arr.length - 1)];
  return "background: url(" + url + ") center center / cover no-repeat";
});

useSeoMeta({
  title: "归档-" + site.value?.data?.site?.siteName,
  description: site.value?.data?.site?.description,
  keywords: site.value?.data?.site?.keyword,
});
useHead({
  link: [{ rel: "icon", href: site.value?.data?.site?.logo ?? "" }],
});
</script>

<style scoped>
.time {
  font-size: 0.75rem;
  color: #555;
  margin-right: 1rem;
}
</style>
