namespace LettuceEncrypt.Dns.Ali.Api.DomainRecord;

/// <summary>
/// 解析管理
/// </summary>
public class DomainRecordApi
{
    public DefaultAcsClient api { get; private set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainRecordApi"/> class.
    /// </summary>
    /// <param name="api">The API.</param>
    public DomainRecordApi(DefaultAcsClient api)
    {
        this.api = api;
    }

    /// <summary>
    /// 获取解析记录列表
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<DescribeDomainRecordsResponse> DescribeDomainRecords(DescribeDomainRecordsRequest param)
    {
        return await api.GetAsync<DescribeDomainRecordsRequest, DescribeDomainRecordsResponse>(param);
    }
        
    /// <summary>
    /// 添加解析记录
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<DefaultDomainRecordResult> AddDomainRecord(AddDomainRecordRequest param)
    {
        return await api.GetAsync<AddDomainRecordRequest, DefaultDomainRecordResult>(param);
    }

    /// <summary>
    /// 删除解析记录
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<DefaultDomainRecordResult> DeleteDomainRecord(DeleteDomainRecordRequest param)
    {
        return await api.GetAsync<DeleteDomainRecordRequest, DefaultDomainRecordResult>(param);
    }

    /// <summary>
    /// 修改解析记录
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<DefaultDomainRecordResult> UpdateDomainRecord(UpdateDomainRecordRequest param)
    {
        return await api.GetAsync<UpdateDomainRecordRequest, DefaultDomainRecordResult>(param);
    }

    /// <summary>
    /// 获取指定解析记录信息
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<DescribeDomainRecordInfoResult> DescribeDomainRecordInfo(DescribeDomainRecordInfoRequest param)
    {
        return await api.GetAsync<DescribeDomainRecordInfoRequest, DescribeDomainRecordInfoResult>(param);
    }
}
