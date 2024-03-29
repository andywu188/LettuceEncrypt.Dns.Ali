﻿namespace LettuceEncrypt.Dns.Ali.Api;

/// <summary>
/// 阿里云凭证提供程序接口
/// </summary>
public interface AlibabaCloudCredentialsProvider
{
    /// <summary>
    /// 获取凭证
    /// </summary>
    /// <returns></returns>
    AlibabaCloudCredentials GetCredentials();
}
