using AlphaVantage.Connect.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace AlphaVantage.Connect.Tests.Tests
{
    public class AlphaVantageClientTest : IClassFixture<AlphaVantageClientFixture>
    {
        private ServiceProvider _serviceProvider;

        public AlphaVantageClientTest(AlphaVantageClientFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task Test()
        {
            var client = _serviceProvider.GetRequiredService<IAlphaVantageClient>();

            var result = await client.GetDailyAsync("GME");

            Assert.NotNull(result);
        }
    }
}
