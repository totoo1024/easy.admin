import { reactive } from "vue";
import http from "~/utils/http";
import type { Pagination } from "./models/pagination";
import type { PageResultTalksOutput, TalkDetailOutput } from "./models";

class TalksApi {
  /**
   * 说说列表
   * @param query 查询参数
   * @returns
   */
  list = (query: Ref<Pagination>) => {
    return http.get<PageResultTalksOutput>("/talks", {
      query,
      watch: [query],
    });
  };

  /**
   * 说说详情信息
   * @param id 说说ID
   * @returns
   */
  talkDetail = (id: number) => {
    return http.get<TalkDetailOutput>("/talks/talkdetail", { query: { id } });
  };
}

export default new TalksApi();
