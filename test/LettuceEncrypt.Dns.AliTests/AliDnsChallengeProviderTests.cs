using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LettuceEncrypt.Dns.Ali.Tests
{
    [TestClass()]
    public class AliDnsChallengeProviderTests
    {
        [TestMethod()]
        public void AliDnsChallengeProviderTest()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var services = new ServiceCollection()
                .AddSingleton<IConfiguration>(config)
                .AddLettuceEncrypt()
                .Services
                .AddAliDnsChallengeProvider()
                .BuildServiceProvider(true);

            var options = services.GetRequiredService<IOptions<AliDnsOptions>>();
            Assert.IsNotNull(options.Value.AccessKeyId);
        }

        [TestMethod()]
        public void AddTxtRecordAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTxtRecordAsyncTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetTxtRecordTest()
        {
            Assert.Fail();
        }
    }
}
