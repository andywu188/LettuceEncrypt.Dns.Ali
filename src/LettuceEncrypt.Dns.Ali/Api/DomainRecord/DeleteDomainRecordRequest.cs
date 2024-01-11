namespace LettuceEncrypt.Dns.Ali.Api.DomainRecord;

/// <summary>
/// 删除解析记录请求参数
/// </summary>
/// <seealso cref="IAliDnsApiParam" />
public class DeleteDomainRecordRequest : IAliDnsApiParam
{
    /// <summary>
    /// 操作接口名，系统规定参数
    /// </summary>
    public string Action => "DeleteDomainRecord";

    /// <summary>
    /// 解析记录的ID，此参数在添加解析时会返回，在获取域名解析列表时会返回
    /// </summary>
    public string RecordId { get; set; }

}
