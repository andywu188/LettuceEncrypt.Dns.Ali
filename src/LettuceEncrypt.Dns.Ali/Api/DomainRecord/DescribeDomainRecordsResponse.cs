namespace LettuceEncrypt.Dns.Ali.Api.DomainRecord;

/// <summary>
/// 解析记录列表
/// </summary>
/// <seealso cref="AliDnsApiPageResult" />
public class DescribeDomainRecordsResponse: AliDnsApiPageResult
{
    /// <summary>
    /// 解析记录列表
    /// </summary>
    public DomainRecords DomainRecords { get; set; } = default!;

}
