using System.Text.Json.Serialization;

namespace Easy.Admin.Application;

public class BaseResponseDto
{
    /// <summary>
    /// 状态码（200代表成功）
    /// </summary>
    [JsonProperty("code")]
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    /// 是否成功
    /// </summary>
    public bool Success => Code == 200;
}