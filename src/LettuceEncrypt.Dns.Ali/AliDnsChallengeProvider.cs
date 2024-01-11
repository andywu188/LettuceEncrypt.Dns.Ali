using LettuceEncrypt.Acme;
using Microsoft.Extensions.Logging;
using LettuceEncrypt.Dns.Ali.Api;
using LettuceEncrypt.Dns.Ali.Api.DomainRecord;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LettuceEncrypt.Dns.Ali;

/// <summary>
/// 阿里云DNS API实现
/// </summary>
internal class AliDnsChallengeProvider : IDnsChallengeProvider
{
    private readonly AliDnsOptions _options;
    private readonly ILogger _logger;
    public AliDnsChallengeProvider(IOptions<AliDnsOptions> options, ILogger<AliDnsChallengeProvider> logger)
    {
        this._logger = logger;
        this._options = options.Value;
    }


    public async Task<DnsTxtRecordContext> AddTxtRecordAsync(string domainName, string txt, CancellationToken ct = new CancellationToken())
    {
        var provider = new AccessKeyCredentialProvider(_options.AccessKeyId, _options.AccessKeySecret);
        DefaultAcsClient client = new DefaultAcsClient(provider);
        var RR = domainName.Replace($".{_options.DomainName}", string.Empty);
        var record = await GetTxtRecord(client, _options.DomainName, RR);
        if (record != null)
        {
            var request = new UpdateDomainRecordRequest();
            request.RecordId = record.RecordId;
            request.DomainName = record.DomainName;
            request.RR = record.RR;
            request.Type = record.Type;
            request.Value = txt;
            request.TTL = record.TTL;
            request.Priority = record.Priority;
            request.Line = record.Line;
                
            try
            {
                var result = await client.GetAsync<UpdateDomainRecordRequest, AliDnsApiBaseResult>(request);
                _logger.LogInformation($"update dns completed. http response content: {JsonConvert.SerializeObject(result, Formatting.None)}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"update dns record error. {ex.Message}");
            }
        }
        else
        {
            var request = new AddDomainRecordRequest();
            request.DomainName = _options.DomainName;
            request.RR = RR;
            request.Type = "TXT";
            request.Value = txt;
            request.TTL = 600;

            try
            {
                var result = await client.GetAsync<AddDomainRecordRequest, DefaultDomainRecordResult>(request);
                _logger.LogInformation($"add dns completed. http response content: {JsonConvert.SerializeObject(result, Formatting.None)}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"add dns record error. {ex.Message}");
            }
        }
        return new DnsTxtRecordContext(domainName, txt);
    }

    public async Task RemoveTxtRecordAsync(DnsTxtRecordContext context, CancellationToken ct = new())
    {
        var provider = new AccessKeyCredentialProvider(_options.AccessKeyId, _options.AccessKeySecret);
        DefaultAcsClient client = new DefaultAcsClient(provider);

        var RR = context.DomainName.Replace($".{_options.DomainName}", string.Empty);
        var record = await GetTxtRecord(client, _options.DomainName, RR);
        if (record != null)
        {
            var request = new DeleteDomainRecordRequest();
            request.RecordId = record.RecordId;
            try
            {
                var response = client.GetAsync<DeleteDomainRecordRequest, AliDnsApiBaseResult>(request);
                var result = response.Result;
                _logger.LogInformation($"delete dns completed. http response content: {JsonConvert.SerializeObject(result, Formatting.None)}");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"delete dns record error. {ex.Message}");
            }
        }
        return;
    }

    /// <summary>
    /// 获取指定主域名指定前缀的TXT记录
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootDomainName">主域名</param>
    /// <param name="RR">前缀</param>
    /// <returns></returns>
    public async Task<RecordItem?> GetTxtRecord(DefaultAcsClient client, string rootDomainName, string RR)
    {
        DescribeDomainRecordsRequest request = new DescribeDomainRecordsRequest();
        request.DomainName = rootDomainName;
        request.TypeKeyWord = "TXT";
        request.RRKeyWord = RR;
        try
        {
            var response = await client.GetAsync<DescribeDomainRecordsRequest, DescribeDomainRecordsResponse>(request);
            if (response.DomainRecords.Record.Count > 0)
            {
                return response.DomainRecords.Record.FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"get dns record error. {ex.Message}");
        }
        return null;
    }

}
