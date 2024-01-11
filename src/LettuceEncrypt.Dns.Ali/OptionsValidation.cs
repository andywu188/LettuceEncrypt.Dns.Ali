using Microsoft.Extensions.Options;

namespace LettuceEncrypt.Dns.Ali;

/// <summary>
/// 阿里云DNS配置验证
/// </summary>
internal class OptionsValidation : IValidateOptions<AliDnsOptions>
{
    public ValidateOptionsResult Validate(string name, AliDnsOptions options)
    {
        if (string.IsNullOrEmpty(options.AccessKeyId))
        {
            return ValidateOptionsResult.Fail("AliDNS AccessKeyId is required.");
        }

        if (string.IsNullOrEmpty(options.AccessKeySecret))
        {
            return ValidateOptionsResult.Fail("AliDNS AccessKeySecret is required.");
        }

        if (string.IsNullOrEmpty(options.RegionId))
        {
            return ValidateOptionsResult.Fail("AliDNS RegionId is required.");
        }

        if (string.IsNullOrEmpty(options.DomainName))
        {
            return ValidateOptionsResult.Fail("AliDNS DomainName is required.");
        }
        return ValidateOptionsResult.Success;
    }
}
