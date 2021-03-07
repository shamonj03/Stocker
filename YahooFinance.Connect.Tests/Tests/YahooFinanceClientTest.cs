using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;
using YahooFinance.Connect.Enums;
using YahooFinance.Connect.Extensions;

namespace YahooFinance.Connect.Tests.Tests
{
    public class YahooFinanceClientTest : IClassFixture<YahooFinanceClientFixture>
    {
        private ServiceProvider _serviceProvider;

        public YahooFinanceClientTest(YahooFinanceClientFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public async Task Test()
        {
            var client = _serviceProvider.GetRequiredService<YahooFinanceClient>();

            var result = await client.GetDailyAsync("GME");

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(Lookback.OneMinute, "1m")]
        public void Lookback_Convert_To_String_Test(Lookback lookback, string expected)
        {
            var actual = lookback.GetString();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Lookback.OneMinute, "1m")]
        public void String_Convert_To_LookBack_Test(Lookback expected, string lookback)
        {
            var actual = lookback.GetLookback();

            Assert.Equal(expected, actual);
        }
    }
}
