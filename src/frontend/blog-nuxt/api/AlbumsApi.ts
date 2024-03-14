import http from "~/utils/http";
import type { PageResultAlbumsOutput, PageResultPictureOutput } from "./models";
import type { Pagination } from "./models/pagination";

class AlbumsApi {
  /**
   * 相册分页查询
   * @returns
   */
  list = (query: Ref<Pagination>) => {
    return http.get<PageResultAlbumsOutput>("/albums", {
      query,
      watch: [query],
    });
  };

  /**
   * 相册下的图片
   * @returns
   */
  pictures = (
    query: Ref<{
      pageNo: number;
      pageSize: number;
      albumId?: number;
    }>
  ) => {
    return http.get<PageResultPictureOutput>("/albums/pictures", {
      query,
      watch: [query],
    });
  };
}

export default new AlbumsApi();
