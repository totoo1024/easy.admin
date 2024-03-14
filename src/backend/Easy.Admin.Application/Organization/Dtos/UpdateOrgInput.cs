namespace Easy.Admin.Application.Organization.Dtos;

public class UpdateOrgInput : AddOrgInput
{
    /// <summary>
    /// 部门Id
    /// </summary>
    public long Id { get; set; }
}