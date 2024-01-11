namespace LettuceEncrypt.Dns.Ali.Api;
public class AccessKeyCredentialProvider : AlibabaCloudCredentialsProvider
{
    private readonly BasicCredentials _accessKeyCredential;

    public AccessKeyCredentialProvider(string accessKeyId, string accessKeySecret)
    {
        _accessKeyCredential = new BasicCredentials(accessKeyId, accessKeySecret);
    }

    public AlibabaCloudCredentials GetCredentials()
    {
        return _accessKeyCredential;
    }
}
