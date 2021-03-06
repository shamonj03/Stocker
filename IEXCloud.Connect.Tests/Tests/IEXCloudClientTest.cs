using IEXCloud.Connect.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace IEXCloud.Connect.Tests.Tests
{
    public class IEXCloudClientTest : IClassFixture<IEXCloudClientFixture>
    {
        private ServiceProvider _serviceProvider;

        public IEXCloudClientTest(IEXCloudClientFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task Test()
        {
            var client = _serviceProvider.GetRequiredService<IIEXCloudClient>();

            var result = await client.GetDailyAsync("GME");

            Assert.NotNull(result);
        }
    }
}
