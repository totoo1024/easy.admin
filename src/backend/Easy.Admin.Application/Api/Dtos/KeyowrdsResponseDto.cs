using System.Text.Json.Serialization;

namespace Easy.Admin.Application;

public class KeywordsResponseDto : BaseResponseDto
{
    /// <summary>
    /// 违规的词组或语句，数组形式
    /// </summary>
    [JsonProperty("data")]
    [JsonPropertyName("data")]
    public List<string> Data { get; set; }

    /// <summary>
    /// 违规内容总数
    /// </summary>
    [JsonProperty("num")]
    [JsonPropertyName("num")]
    public int Num { get; set; }
}