using AlphaVantage.Connect.Interfaces;
using AlphaVantage.Connect.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlphaVantage.Connect
{
    public class AlphaVantageClient : IAlphaVantageClient
    {
        private readonly AlphaVantageClientConfiguration _configuration;

        private readonly IHttpClientFactory _httpCleintFactory;

        public AlphaVantageClient(IOptions<AlphaVantageClientConfiguration> configuration, IHttpClientFactory httpCleintFactory)
        {
            _configuration = configuration.Value;
            _httpCleintFactory = httpCleintFactory;
        }

        public async Task<TimeSeriesDaily> GetDailyAsync(string symbol)
        {
            using(var client = _httpCleintFactory.CreateClient(_configuration.ClientName))
            {
                var response = await client.GetAsync($"{_configuration.Url}/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={_configuration.ApiKey}");

                if(response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();

                    var serializer = new JsonSerializer();

                    using (var sr = new StreamReader(stream))
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        return serializer.Deserialize<TimeSeriesDaily>(jsonTextReader);
                    }
                }
            }

            return null;
        }
    }
}
