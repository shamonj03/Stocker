using Newtonsoft.Json;
using System;
using YahooFinance.Connect.Extensions;

namespace YahooFinance.Connect.Models
{
    public class TradingPeriod
    {
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("start")]
        private int start { get; set; }

        public DateTime Start => start.FromJavaScript();

        [JsonProperty("end")]
        private int end { get; set; }

        private DateTime End => end.FromJavaScript();

        [JsonProperty("gmtoffset")]
        public int GmtOffset { get; set; }
    }
}
