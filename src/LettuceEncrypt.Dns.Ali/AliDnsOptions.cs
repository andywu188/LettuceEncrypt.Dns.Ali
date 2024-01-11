
namespace LettuceEncrypt.Dns.Ali;

/// <summary>
/// 阿里云DNS配置
/// </summary>
public class AliDnsOptions
{
    /// <summary>
    /// 访问ID
    /// </summary>
    public string? AccessKeyId { get; set; }
    /// <summary>
    /// 密钥
    /// </summary>
    public string? AccessKeySecret { get; set; }
    /// <summary>
    /// 区域
    /// </summary>
    public string? RegionId { get; set; }
    /// <summary>
    /// 域名
    /// </summary>
    public string? DomainName { get; set; }
}
