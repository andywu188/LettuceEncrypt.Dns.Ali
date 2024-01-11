namespace LettuceEncrypt.Dns.Ali.Api;

/// <summary>
/// 基本凭证
/// </summary>
public class BasicCredentials : AlibabaCloudCredentials
{
    private readonly string _accessKeyId;
    private readonly string _accessKeySecret;

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

    public string GetAccessKeyId()
    {
        return _accessKeyId;
    }

    public string GetAccessKeySecret()
    {
        return _accessKeySecret;
    }
}
