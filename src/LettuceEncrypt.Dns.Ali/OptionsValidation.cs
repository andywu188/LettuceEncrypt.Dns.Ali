using Microsoft.Extensions.Options;

namespace LettuceEncrypt.Dns.Ali;

/// <summary>
/// 阿里云DNS配置验证
/// </summary>
internal class OptionsValidation : IValidateOptions<AliDnsOptions>
{
    /// <summary>
    /// 验证配置
    /// </summary>
    /// <param name="name"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public ValidateOptionsResult Validate(string? name, AliDnsOptions options)
    {
        if (string.IsNullOrEmpty(options.AccessKeyId))
        {
            return ValidateOptionsResult.Fail("AliDNS AccessKeyId is required.");
        }

        if (string.IsNullOrEmpty(options.AccessKeySecret))
        {
            return ValidateOptionsResult.Fail("AliDNS AccessKeySecret is required.");
        }
        
        if (string.IsNullOrEmpty(options.DomainName))
        {
            return ValidateOptionsResult.Fail("AliDNS DomainName is required.");
        }
        return ValidateOptionsResult.Success;
    }
}
