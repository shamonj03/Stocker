using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using YahooFinance.Connect.Enums;
using YahooFinance.Connect.Extensions;

namespace YahooFinance.Connect.Models
{
    public class QuoteHeader
    {
        public QuoteHeader()
        {
            Lines = new List<QuoteLine>();
            validRanges = new List<string>();
        }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("exchangeName")]
        public string ExchangeName { get; set; }

        [JsonProperty("instrumentType")]
        public string InstrumentType { get; set; }

        [JsonProperty("firstTradeDate")]
        private int firstTradeDate { get; set; }

        public DateTime FirstTradeDate => firstTradeDate.FromJavaScript();

        [JsonProperty("regularMarketTime")]
        private int regularMarketTime { get; set; }

        public DateTime RegularMarketTime => regularMarketTime.FromJavaScript();

        [JsonProperty("gmtoffset")]
        public int GmtOffset { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("exchangeTimezoneName")]
        public string ExchangeTimeZoneName { get; set; }

        [JsonProperty("regularMarketPrice")]
        public double RegularMarketPrice { get; set; }

        [JsonProperty("chartPreviousClose")]
        public double ChartPreviousClose { get; set; }

        [JsonProperty("priceHint")]
        public int PriceHint { get; set; }

        [JsonProperty("currentTradingPeriod")]
        public CurrentTradingPeriod CurrentTradingPeriod { get; set; }

        [JsonProperty("dataGranularity")]
        private string dataGranularity { get; set; }

        public Lookback DataGranularity => dataGranularity.GetLookback();

        [JsonProperty("range")]
        private string range { get; set; }

        public Lookback Range => range.GetLookback();

        [JsonProperty("validRanges")]
        private List<string> validRanges { get; set; }

        public List<Lookback> ValidRanges => validRanges.Select(x => x.GetLookback()).ToList();

        public List<QuoteLine> Lines { get; set; }

        public string Error { get; set; }
    }
}
