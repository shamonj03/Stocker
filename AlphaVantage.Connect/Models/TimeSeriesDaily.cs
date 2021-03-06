using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AlphaVantage.Connect.Models
{
    public class TimeSeriesDaily
    {
        [JsonProperty("Meta Data")]
        public object MetaData { get; set; }

        [JsonProperty("Time Series (Daily)")]
        public Dictionary<DateTime, StockInfo> Data { get; set; }
    }
}
