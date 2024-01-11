// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
namespace LettuceEncrypt.Dns.Ali.Api;

/// <summary>
/// 阿里云凭证
/// </summary>
public interface AlibabaCloudCredentials
{
    /// <summary>
    /// 获取访问密钥ID
    /// </summary>
    /// <returns></returns>
    string GetAccessKeyId();
    /// <summary>
    /// 获取访问密钥
    /// </summary>
    /// <returns></returns>
    string GetAccessKeySecret();
}
