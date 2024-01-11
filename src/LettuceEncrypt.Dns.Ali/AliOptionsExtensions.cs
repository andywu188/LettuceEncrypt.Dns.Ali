using LettuceEncrypt.Acme;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace LettuceEncrypt.Dns.Ali;

/// <summary>
/// 阿里云DNS配置扩展
/// </summary>
public static class AliOptionsExtensions
{
    /// <summary>
    /// 添加阿里云DNS配置
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddAliDnsChallengeProvider(this IServiceCollection services)
        => services.AddAliDnsChallengeProvider(_ => { });

    /// <summary>
    /// 添加阿里云DNS配置
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configure">自定义阿里云DNS配置信息</param>
    /// <returns></returns>
    public static IServiceCollection AddAliDnsChallengeProvider(this IServiceCollection services, Action<AliDnsOptions> configure)
    {
        services.TryAddEnumerable(ServiceDescriptor.Singleton<IValidateOptions<AliDnsOptions>, OptionsValidation>());

        services.Replace(
            new ServiceDescriptor(
                typeof(IDnsChallengeProvider),
                typeof(AliDnsChallengeProvider),
                ServiceLifetime.Singleton));
        services.AddSingleton<IConfigureOptions<AliDnsOptions>>(s =>
        {
            var config = s.GetService<IConfiguration?>();
            return new ConfigureOptions<AliDnsOptions>(options => config?.Bind("AliDns", options));
        });

        services.AddOptions<AliDnsOptions>().Configure(configure).ValidateDataAnnotations();
        return services;
    }

}
