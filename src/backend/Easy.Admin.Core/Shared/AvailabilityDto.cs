using Easy.Admin.Core.Enum;

namespace Easy.Admin.Core.Shared;

public class AvailabilityDto : KeyDto
{
    /// <summary>
    /// 状态
    /// </summary>
    public AvailabilityStatus Status { get; set; }
}