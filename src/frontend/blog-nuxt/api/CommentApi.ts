import type { PageResultCommentOutput } from "./models/page-result-comment-output";
import http from "~/utils/http";
import type { CommentPageQueryInput } from "./models/comment-page-query-input";
import type { AddCommentInput, PageResultReplyOutput } from "./models";

class CommentApi {
  /**
   * 评论或者留言列表
   * @param params
   * @returns
   */
  list = (query: Ref<CommentPageQueryInput>) => {
    return http.get<PageResultCommentOutput>("/comment?r=" + Math.random(), {
      query,
      watch: [query],
    });
  };

  /**
   *
   * @param params 回复分页查询
   * @returns
   */
  replyList = (query: CommentPageQueryInput) => {
    return http.get<PageResultReplyOutput>("/comment/replylist", { query });
  };

  /**
   *
   * @param data 评论、回复
   * @returns
   */
  add = (data: AddCommentInput) => {
    return http.post("/comment", data);
  };

  /**
   * 点赞
   * @param id 对象ID
   * @returns
   */
  praise = (id: number) => {
    return http.post<boolean>("/comment/praise", { id });
  };
}

export default new CommentApi();
