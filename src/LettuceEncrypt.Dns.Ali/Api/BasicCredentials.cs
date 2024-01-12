namespace LettuceEncrypt.Dns.Ali.Api;

/// <summary>
/// 基本凭证
/// </summary>
public class BasicCredentials : AlibabaCloudCredentials
{
    private readonly string _accessKeyId;
    private readonly string _accessKeySecret;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="accessKeyId"></param>
    /// <param name="accessKeySecret"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public BasicCredentials(string accessKeyId, string accessKeySecret)
    {
        if (accessKeyId == null)
        {
            throw new ArgumentOutOfRangeException("Access key ID cannot be null.");
        }

        if (accessKeySecret == null)
        {
            throw new ArgumentOutOfRangeException("Access key secret cannot be null.");
        }

        this._accessKeyId = accessKeyId;
        this._accessKeySecret = accessKeySecret;
    }

    /// <summary>
    /// 获取访问密钥ID
    /// </summary>
    /// <returns></returns>
    public string GetAccessKeyId()
    {
        return _accessKeyId;
    }

    /// <summary>
    /// 获取访问密钥
    /// </summary>
    /// <returns></returns>
    public string GetAccessKeySecret()
    {
        return _accessKeySecret;
    }
}
