using Microsoft.Extensions.DependencyInjection;

namespace YahooFinance.Connect.Tests
{
    public class YahooFinanceClientFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public YahooFinanceClientFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddHttpClient();
            serviceCollection.AddScoped<YahooFinanceClient, YahooFinanceClient>();

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
