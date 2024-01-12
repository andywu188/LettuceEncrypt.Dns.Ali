namespace LettuceEncrypt.Dns.Ali.Api.DomainRecord;

/// <summary>
/// 解析管理
/// </summary>
public class DomainRecordApi
{
    private DefaultAcsClient _api { get; set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainRecordApi"/> class.
    /// </summary>
    /// <param name="api">The API.</param>
    public DomainRecordApi(DefaultAcsClient api)
    {
        this._api = api;
    }

    /// <summary>
    /// 获取解析记录列表
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<DescribeDomainRecordsResponse> DescribeDomainRecords(DescribeDomainRecordsRequest param)
    {
        return await _api.GetAsync<DescribeDomainRecordsRequest, DescribeDomainRecordsResponse>(param);
    }
        
    /// <summary>
    /// 添加解析记录
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<DefaultDomainRecordResult> AddDomainRecord(AddDomainRecordRequest param)
    {
        return await _api.GetAsync<AddDomainRecordRequest, DefaultDomainRecordResult>(param);
    }

    /// <summary>
    /// 删除解析记录
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<DefaultDomainRecordResult> DeleteDomainRecord(DeleteDomainRecordRequest param)
    {
        return await _api.GetAsync<DeleteDomainRecordRequest, DefaultDomainRecordResult>(param);
    }

    /// <summary>
    /// 修改解析记录
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<DefaultDomainRecordResult> UpdateDomainRecord(UpdateDomainRecordRequest param)
    {
        return await _api.GetAsync<UpdateDomainRecordRequest, DefaultDomainRecordResult>(param);
    }

    /// <summary>
    /// 获取指定解析记录信息
    /// </summary>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<DescribeDomainRecordInfoResult> DescribeDomainRecordInfo(DescribeDomainRecordInfoRequest param)
    {
        return await _api.GetAsync<DescribeDomainRecordInfoRequest, DescribeDomainRecordInfoResult>(param);
    }
}
