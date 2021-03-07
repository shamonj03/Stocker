using System;

namespace YahooFinance.Connect.Models
{
    public class QuoteLine
    {
        public DateTime TimeStamp { get; set; }

        public double Low { get; set; }

        public double High { get; set; }

        public double Open { get; set; }

        public double Close { get; set; }

        public double Volume { get; set; }

        public double AdjustedClosingPrice { get; set; }
    }
}
