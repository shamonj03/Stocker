using IEXCloud.Connect.Interfaces;
using IEXCloud.Connect.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace IEXCloud.Connect
{
    public class IEXCloudClient : IIEXCloudClient
    {
        private readonly IEXCloudClientConfiguration _configuration;

        private readonly IHttpClientFactory _httpCleintFactory;

        public IEXCloudClient(IOptions<IEXCloudClientConfiguration> configuration, IHttpClientFactory httpCleintFactory)
        {
            _configuration = configuration.Value;
            _httpCleintFactory = httpCleintFactory;
        }

        public async Task<object> GetDailyAsync(string symbol)
        {
            using(var client = _httpCleintFactory.CreateClient(_configuration.ClientName))
            {
                var response = await client.GetAsync($"{_configuration.Url}/stable/stock/{symbol}/quote?token={_configuration.ApiKey}");

                if(response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();

                    var serializer = new JsonSerializer();

                    using (var sr = new StreamReader(stream))
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        return serializer.Deserialize(jsonTextReader);
                    }
                }
            }

            return null;
        }
    }
}
