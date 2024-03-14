namespace Easy.Admin.Application.Client.Dtos;

public class TalkDetailOutput : TalksOutput
{
    /// <summary>
    /// 是否允许评论
    /// </summary>
    public bool IsAllowComments { get; set; }
}