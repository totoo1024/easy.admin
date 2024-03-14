using Furion.RemoteRequest.Extensions;

namespace Easy.Admin.Application;

/// <summary>
/// 第三方API调用
/// </summary>
public class ApiService : IScoped
{
    private const string BaseUrl = "https://api.wer.plus";

    /// <summary>
    /// 检查 文本内容是否包含违禁词
    /// </summary>
    /// <param name="content">内容</param>
    /// <returns></returns>
    public async Task<bool> Keywords([FromQuery] string content)
    {
        try
        {
            var dto = await $"{BaseUrl}/api/min".SetQueries(new { t = content }).GetAsAsync<KeywordsResponseDto>();
            return dto.Success && dto.Num > 0;

        }
        catch (Exception e)
        {
            return false;
        }
    }
}