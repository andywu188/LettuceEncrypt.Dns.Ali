namespace LettuceEncrypt.Dns.Ali.Api.DomainRecord;

/// <summary>
/// 修改解析记录请求参数
/// </summary>
/// <seealso cref="AddDomainRecordRequest" />
public class UpdateDomainRecordRequest : AddDomainRecordRequest
{
    /// <summary>
    /// 操作接口名，系统规定参数
    /// </summary>
    public override string Action => "UpdateDomainRecord";

    /// <summary>
    /// 解析记录的ID
    /// </summary>
    public string RecordId { get; set; } = default!;

}
