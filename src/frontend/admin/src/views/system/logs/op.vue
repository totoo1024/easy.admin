<template>
	<div class="syslogin-log-container layout-padding">
		<ProTable
			ref="tableRef"
			:request-api="SysOperationLogApi.page"
			:columns="columns"
			:tool-button="false"
			:page-sizes="[15, 30, 50]"
			:page-size="15"
		>
			<template #tools>
				<el-button v-auth="'sysoperationlog:clear'" type="primary" icon="ele-Delete" @click="onClear"> 清空日志 </el-button>
			</template>
			<template #logLevel="{ row }">
				<el-tag :type="levelColor[row.logLevel]">{{ level[row.logLevel] }}</el-tag>
			</template>
			<template #route="{ row }">
				{{ `/${row.controllerName}/${row.actionName}` }}
			</template>
			<template #action="{ row }">
				<el-button v-auth="'sysorganization:edit'" icon="ele-InfoFilled" size="small" text type="primary" @click="onDetail(row.message)">
					详情
				</el-button>
			</template>
		</ProTable>
		<el-dialog v-model="state.showDialog" title="日志详情" width="1000">
			<div v-html="state.message"></div>
		</el-dialog>
	</div>
</template>

<script setup lang="ts">
import { reactive, ref } from 'vue';
import ProTable from '/@/components/ProTable/index.vue';
import SysOperationLogApi from '/@/api/SysOperationLogApi';
import type { ColumnProps } from '/@/components/ProTable/interface';
//  table实例
const tableRef = ref<InstanceType<typeof ProTable>>();
const level = ['跟踪', '调试', '信息', '警告', '异常', '致命', '其他'];
const levelColor = ['info', 'info', 'success', 'warning', 'danger', 'danger', 'info'];
const state = reactive({
	showDialog: false,
	message: '',
});
const columns = reactive<ColumnProps[]>([
	{
		type: 'index',
		label: '序号',
		width: 60,
		fixed: true,
	},
	{
		prop: 'account',
		label: '操作人',
		search: { el: 'input' },
		width: 120,
	},
	{
		prop: 'logLevel',
		label: '日志等级',
		width: 100,
		search: {
			el: 'select',
		},
		enum: level.map((item, index) => {
			return { value: index, label: item };
		}),
	},
	{
		prop: 'description',
		label: '描述',
		width: 150,
	},
	{ prop: 'route', label: '路由', width: 200 },
	{
		prop: 'httpMethod',
		label: '请求方式',
		width: 100,
	},
	{
		prop: 'remoteIp',
		label: 'IP',
		width: 120,
	},
	{
		prop: 'location',
		label: 'IP归属地',
		width: 180,
	},
	{
		prop: 'osDescription',
		label: '客户端系统',
		width: 200,
	},
	{
		prop: 'userAgent',
		label: '浏览器',
		width: 200,
	},
	{ prop: 'elapsed', label: '耗时(ms)', width: 100 },
	{
		prop: 'exception',
		label: '异常',
	},
	{
		prop: 'createdTime',
		label: '创建时间',
		width: 160,
		fixed: 'right',
	},
	{
		prop: 'action',
		label: '操作',
		width: 80,
		fixed: 'right',
	},
]);

// 查看日志详情
const onDetail = (message: string) => {
	state.message = message.replace(/(\r\n|\r|\n)/g, '<br/>');
	state.showDialog = true;
};

// 清除日志
const onClear = async () => {
	const { succeeded } = await SysOperationLogApi.clear();
	if (succeeded) {
		tableRef.value?.reset();
	}
};
</script>

<style scoped></style>
