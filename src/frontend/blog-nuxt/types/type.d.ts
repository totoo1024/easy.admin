// api统一返回结果
declare interface ApiResult<T = any> {
  /**
   * 业务状态码
   */
  statusCode: number;
  /**
   * 是否成功
   */
  succeeded: boolean;
  /**
   * 错误消息
   */
  errors?: string;
  /**
   * 结果
   */
  data?: T;

  /**
   * 扩展值
   */
  extras?: any;

  /**
   * 时间戳
   */
  timestamp: number;
}

// declare module "markdown-it-sub";
// declare module "markdown-it-sup";
// declare module "markdown-it-mark";
// declare module "markdown-it-abbr";
// declare module "markdown-it-container";
// declare module "markdown-it-deflist";
// declare module "markdown-it-emoji";
// declare module "markdown-it-footnote";
// declare module "markdown-it-ins";
// declare module "markdown-it-task-lists";
// declare module "markdown-it-katex-external";
