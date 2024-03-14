namespace Easy.Admin.Application.Blog.Dtos;

public class TalksPageQueryInput : Pagination
{
    /// <summary>
    /// 关键词
    /// </summary>
    public string Keyword { get; set; }
}