namespace Easy.Admin.Application.Config.Dtos;

public class UpdateCustomConfigInput : AddCustomConfigInput
{
    /// <summary>
    /// 配置id
    /// </summary>
    public long Id { get; set; }
}