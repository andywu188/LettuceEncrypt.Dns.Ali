namespace LettuceEncrypt.Dns.Ali.Api.DomainRecord;

/// <summary>
/// 默认返回结果
/// </summary>
/// <seealso cref="AliDnsApiBaseResult" />
public class DefaultDomainRecordResult : AliDnsApiBaseResult
{
    /// <summary>
    /// 解析记录的ID
    /// </summary>
    public string RecordId { get; set; }
        
}
