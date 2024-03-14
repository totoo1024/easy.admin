using Easy.Admin.Core.Enum;

namespace Easy.Admin.Core.Entities;
/// <summary>
/// 可用状态
/// </summary>
public interface IAvailability
{
    /// <summary>
    /// 可用状态
    /// </summary>
    AvailabilityStatus Status { get; set; }
}