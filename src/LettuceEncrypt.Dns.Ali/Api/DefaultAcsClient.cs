using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using LettuceEncrypt.Dns.Ali.Api.DomainRecord;

namespace LettuceEncrypt.Dns.Ali.Api;

/// <summary>
/// 阿里云DNS Api
/// 参见 https://help.aliyun.com/document_detail/29739.html
/// </summary>
public class DefaultAcsClient : IDisposable
{
    private const string VERSION = "2015-01-09";
    private const string SIGNATURE_METHOD = "HMAC-SHA1";
    private const string SIGNATURE_VERSION = "1.0";
    private const string BASE_URL = "https://alidns.aliyuncs.com";
    /// <summary>
    /// 访问ID
    /// </summary>
    public string AccessId { get; set; }
    /// <summary>
    /// 访问密钥
    /// </summary>
    public string AccessKey { get; set; }

    private HttpClient? _client;

    /// <summary>
    /// 解析管理接口
    /// </summary>
    /// <value>
    /// The domain record.
    /// </value>
    public DomainRecordApi DomainRecord { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DefaultAcsClient"/> class.
    /// </summary>
    /// <param name="credentialsProvider"></param>
    public DefaultAcsClient(AlibabaCloudCredentialsProvider credentialsProvider)
    {
        AccessId = credentialsProvider.GetCredentials().GetAccessKeyId();
        AccessKey = credentialsProvider.GetCredentials().GetAccessKeySecret();
        _client = new HttpClient();
        _client.BaseAddress = new Uri(BASE_URL);
        _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        DomainRecord = new DomainRecordApi(this);
    }

    /// <summary>
    /// Gets the asynchronous.
    /// </summary>
    /// <typeparam name="TParam">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public async Task<TResult> GetAsync<TParam, TResult>(TParam param)
        where TParam : class, IAliDnsApiParam
        where TResult : IAliDnsApiResult
    {

        var dir = GetParams(param);
        var query = BuildQuery(dir);
        var signature = GetSignature(HttpVerbs.GET, query);

        query = $"?Signature={signature}&{query}";
        var resp = await _client.GetAsync(query);
        var json = await resp.Content.ReadAsStringAsync();
        var r = Newtonsoft.Json.JsonConvert.DeserializeObject<TResult>(json);
        return r;

    }

    /// <summary>
    /// 将参数模型转换为字段
    /// </summary>
    /// <typeparam name="TParam"></typeparam>
    /// <param name="param">The parameter.</param>
    /// <returns></returns>
    public SortedDictionary<string, string> GetParams<TParam>(TParam param)
        where TParam : class
    {
        var dic = new SortedDictionary<string, string>(StringComparer.Ordinal)
        {
            ["Format"] = "JSON",
            ["Version"] = VERSION,
            ["AccessKeyId"] = AccessId,
            ["SignatureMethod"] = SIGNATURE_METHOD,
            ["Timestamp"] = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
            ["SignatureVersion"] = SIGNATURE_VERSION,
            ["SignatureNonce"] = Guid.NewGuid().ToString(),
        };
        if (param != null)
        {
            foreach (var property in param.GetType().GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public))
            {
                var value = property.GetValue(param)?.ToString();
                if (string.IsNullOrEmpty(value))
                    continue;
                dic.Add(property.Name, value);
            }
        }

        return dic;
    }

    /// <summary>
    /// Gets the signature.
    /// </summary>
    /// <param name="httpVerb">The HTTP verb.</param>
    /// <param name="query">The query.</param>
    /// <returns></returns>
    private string GetSignature(HttpVerbs httpVerb, string query)
    {
        string toSign = $"{httpVerb}&%2F&{UrlEncode(query)}";
        string signature = SignString(AccessKey + "&", toSign);
        signature = UrlEncode(signature);
        return signature;
    }


    /// <summary>
    /// 签名字符串
    /// </summary>
    /// <param name="accessKey">The access secret.</param>
    /// <param name="str">The source.</param>
    /// <returns></returns>
    public static string SignString(string accessKey, string str)
    {
        using (HMACSHA1 algorithm = new HMACSHA1(Encoding.UTF8.GetBytes(accessKey)))
        {
            return Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(str)));
        }
    }

    /// <summary>
    /// 构造Url Query 部分
    /// </summary>
    /// <param name="dic">The dic.</param>
    /// <returns></returns>
    public static string BuildQuery(SortedDictionary<string, string> dic)
    {
        var sb = new StringBuilder();
        foreach (KeyValuePair<String, String> kvp in dic) //系统参数
        {
            sb.Append($"&{UrlEncode(kvp.Key)}={UrlEncode(kvp.Value)}");
        }
        return sb.ToString().Substring(1);
    }

    /// <summary>
    /// 阿里云规定的URL编码
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static string UrlEncode(string value)
    {
        return Regex.Replace(WebUtility.UrlEncode(value).Replace("+", "%20").Replace("*", "%2A").Replace("%7E", "~"), @"%[a-f\d]{2}", m => m.Value.ToUpper());
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        _client?.Dispose();
        _client = null;
    }
}

/// <summary>
/// HTTP方法
/// </summary>
public enum HttpVerbs
{
    /// <summary>
    /// Get方法
    /// </summary>
    GET,
    /// <summary>
    /// Post方法
    /// </summary>
    POST
}
