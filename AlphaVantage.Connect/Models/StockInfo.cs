using Newtonsoft.Json;

namespace AlphaVantage.Connect.Models
{
    public class StockInfo
    {
        [JsonProperty("1. open")]
        public float Open { get; set; }

        [JsonProperty("4. close")]
        public float Close { get; set; }

        [JsonProperty("2. high")]
        public float High { get; set; }

        [JsonProperty("3. low")]
        public float Low { get; set; }

        [JsonProperty("5. volume")]
        public float Volume { get; set; }
    }
}
