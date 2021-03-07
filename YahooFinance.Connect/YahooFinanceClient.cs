using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using YahooFinance.Connect.Infrastructure;
using YahooFinance.Connect.Interfaces;
using YahooFinance.Connect.Models;

namespace YahooFinance.Connect
{
    public class YahooFinanceClient : IYahooFinanceClient
    {
        public const string ClientName = "YahhoFinanceClient";

        public const string Url = "https://query1.finance.yahoo.com/v8/finance/chart";

        private readonly IHttpClientFactory _httpCleintFactory;

        public YahooFinanceClient(IHttpClientFactory httpCleintFactory)
        {
            _httpCleintFactory = httpCleintFactory;
        }

        public async Task<QuoteHeader> GetDailyAsync(string symbol)
        {
            using(var client = _httpCleintFactory.CreateClient(ClientName))
            {
                var response = await client.GetAsync($"{Url}/{symbol}?region=US&lang=en-US&includePrePost=false&interval=1mo&useYfid=true&range=5y&corsDomain=finance.yahoo.com&.tsrc=finance");

                if (!response.IsSuccessStatusCode)
                    response.EnsureSuccessStatusCode();
                else
                {
                    var stream = await response.Content.ReadAsStreamAsync();

                    var serializer = new JsonSerializer();
                    serializer.Converters.Add(new ChartConverter());

                    using (var sr = new StreamReader(stream))
                    using (var jsonTextReader = new JsonTextReader(sr))
                        return serializer.Deserialize<QuoteHeader>(jsonTextReader);
                }
            }

            return null;
        }
    }
}
