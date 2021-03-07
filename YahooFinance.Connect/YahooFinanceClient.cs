using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

                //	https://query1.finance.yahoo.com/v8/finance/chart/GME?symbol=GME&period1=1519884000&period2=1615080418&useYfid=true&interval=1d&includePrePost=true&events=div|split|earn&lang=en-US&region=US&crumb=y08y8mtMTNG&corsDomain=finance.yahoo.com
                var query = HttpUtility.ParseQueryString(string.Empty);
                query.Add("region", "US");
                query.Add("lang", "en-US");
                query.Add("corsDomain", "finance.yahoo.com");
                query.Add("includePrePost", "false");
                query.Add(".tsrc", "finance");
                query.Add("useYfid", "true");

                query.Add("period1", "1519884000");
                query.Add("period2", "1615080418");
                query.Add("interval", "1mo");
                query.Add("range", "5y");

                var response = await client.GetAsync($"{Url}/{symbol}?{query}");

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
