<template>
	<div class="syslogin-log-container layout-padding">
		<ProTable ref="tableRef" :request-api="SysSigninLogApi.page" :columns="columns" :tool-button="false" :page-sizes="[15, 30, 50]" :page-size="15" />
	</div>
</template>

<script setup lang="ts">
import { reactive } from 'vue';
import ProTable from '/@/components/ProTable/index.vue';
import SysSigninLogApi from '/@/api/SysSigninLogApi';
// import { auths } from '/@/utils/authFunction';
import type { ColumnProps } from '/@/components/ProTable/interface';
const columns = reactive<ColumnProps[]>([
	{
		type: 'index',
		label: '序号',
		width: 60,
	},
	{
		prop: 'account',
		label: '用户名',
		search: { el: 'input' },
		width: 150,
	},
	{
		prop: 'remoteIp',
		label: 'IP',
		width: 150,
	},
	{
		prop: 'location',
		label: 'IP归属地',
	},
	{
		prop: 'osDescription',
		label: '客户端系统',
	},
	{
		prop: 'userAgent',
		label: '浏览器',
	},
	{
		prop: 'message',
		label: '消息',
		search: { el: 'input', key: 'keyword' },
	},
	{
		prop: 'createdTime',
		label: '登录时间',
		width: 180,
	},
]);
</script>

<style scoped></style>
