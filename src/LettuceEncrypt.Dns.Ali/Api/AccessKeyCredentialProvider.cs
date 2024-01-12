namespace LettuceEncrypt.Dns.Ali.Api;

/// <summary>
/// 访问密钥凭证提供程序
/// </summary>
public class AccessKeyCredentialProvider : AlibabaCloudCredentialsProvider
{
    private readonly BasicCredentials _accessKeyCredential;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="accessKeyId"></param>
    /// <param name="accessKeySecret"></param>
    public AccessKeyCredentialProvider(string accessKeyId, string accessKeySecret)
    {
        _accessKeyCredential = new BasicCredentials(accessKeyId, accessKeySecret);
    }

    /// <summary>
    /// 获取凭证
    /// </summary>
    /// <returns></returns>
    public AlibabaCloudCredentials GetCredentials()
    {
        return _accessKeyCredential;
    }
}
