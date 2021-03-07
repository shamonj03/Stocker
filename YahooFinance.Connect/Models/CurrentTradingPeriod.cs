using Newtonsoft.Json;

namespace YahooFinance.Connect.Models
{
    public class CurrentTradingPeriod
    {
        [JsonProperty("pre")]
        public TradingPeriod Pre { get; set; }

        [JsonProperty("Regular")]
        public TradingPeriod Regular { get; set; }

        [JsonProperty("post")]
        public TradingPeriod Post { get; set; }
    }
}
