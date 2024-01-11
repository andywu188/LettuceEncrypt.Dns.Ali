namespace LettuceEncrypt.Dns.Ali.Api;

/// <summary>
/// 解析记录列表
/// </summary>
public class DomainRecords
{
    /// <summary>
    /// 记录
    /// </summary>
    public List<RecordItem> Record { get; set; }

    public override string ToString()
    {
        return $"Count: {Record?.Count ?? 0}";
    }
}

/// <summary>
/// Record结构表
/// </summary>
public class RecordItem
{
    /// <summary>
    /// 解析记录ID
    /// </summary>
    public string RecordId { get; set; }

    /// <summary>
    /// 域名名称
    /// </summary>
    public string DomainName { get; set; }
    /// <summary>
    /// 解析记录ID
    /// </summary>
    /// <summary>
    /// 主机记录
    /// </summary>
    public string RR { get; set; }
    /// <summary>
    /// 记录类型
    /// </summary>
    public string Type { get; set; }
    /// <summary>
    /// 记录值
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// 生存时间
    /// </summary>
    public int TTL { get; set; }
    /// <summary>
    /// MX记录的优先级
    /// </summary>
    public int? Priority { get; set; }
    /// <summary>
    /// 解析线路
    /// </summary>
    public string Line { get; set; }
    /// <summary>
    /// 解析记录状态，Enable/Disable
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// 解析记录锁定状态，true/false
    /// </summary>
    public bool Locked { get; set; }

    /// <summary>
    /// 重写ToString方法，用于返回对象的字符串表示形式
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{RR}.{DomainName} {Type} {Value}";
    }
}
