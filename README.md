<h1>
<img src="./logo.png" width="42" height="42"/>
LettuceEncrypt.Dns.Ali
</h1>

[![Build Status][ci-badge]][ci]
[![NuGet][nuget-badge] ![NuGet Downloads][nuget-download-badge]][nuget]

[ci]: https://github.com/andywu188/LettuceEncrypt.Dns.Ali/actions?query=workflow%3ACI+branch%3Amain
[ci-badge]: https://github.com/andywu188/LettuceEncrypt.Dns.Ali/workflows/CI/badge.svg
[nuget]: https://www.nuget.org/packages/LettuceEncrypt.Dns.Ali/
[nuget-badge]: https://img.shields.io/nuget/v/LettuceEncrypt.Dns.Ali.svg?style=flat-square
[nuget-download-badge]: https://img.shields.io/nuget/dt/LettuceEncrypt.Dns.Ali?style=flat-square
[ACME]: https://en.wikipedia.org/wiki/Automated_Certificate_Management_Environment
[Let's Encrypt]: https://letsencrypt.org/


基于LettuceEncrypt，使用阿里云域名DNS验证，为 ASP.NET Core Web 应用程序，自动生成HTTPS通配符域名证书，并且在到期前，自动续签。

启用后，您的web服务器将在启动过程中**自动**使用DNS验证，并生成HTTPS证书。

然后，它将Kestrel配置为此证书用于所有HTTPS流量。

## 用法

使用NuGet（[请参阅此处的详细信息][nuget-url]）将此包安装到您的项目中。

API的主要用法是调用 `IServiceCollection.AddAliDnsChallengeProvider`。

```csharp
using Microsoft.Extensions.DependencyInjection;
using LettuceEncrypt;
using LettuceEncrypt.Dns.Ali;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLettuceEncrypt();
        services.AddAliDnsChallengeProvider();
    }
}
```

相关参数配置，通常通过appsettings.json文件进行设置，也可以在AddAliDnsChallengeProvider方法的参数中指定配置项值。

```jsonc
// appsettings.json
{
    "LettuceEncrypt": {
        // 将其设置为自动接受证书颁发机构的服务条款。
        // 如果您没有在配置中设置此项，则每当应用程序启动时都需要按“y”
        "AcceptTermsOfService": true,
        
        // 指定使用DNS验证
        "AllowedChallengeTypes": "Dns01",
        
        // 指定到期前几天自动续签，TimeSpan类型格式
        "RenewDaysInAdvance": "3.00:00:00",

        // 您必须至少指定一个域名
        "DomainNames": [ "example.com", "www.example.com" ],

        // 您必须指定一个电子邮件地址才能向证书颁发机构注册
        "EmailAddress": "it-admin@example.com"
    },
    // 阿里云接口访问凭证
    "AliDns": {

        "AccessKeyId": "",

        "AccessKeySecret": "",

        "DomainName": "example.com"
    }
}
```
