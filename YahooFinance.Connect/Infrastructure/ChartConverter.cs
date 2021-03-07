using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using YahooFinance.Connect.Extensions;
using YahooFinance.Connect.Models;

namespace YahooFinance.Connect.Infrastructure
{
    public class ChartConverter : JsonConverter<QuoteHeader>
    {
        public override QuoteHeader ReadJson(JsonReader reader, Type objectType, [AllowNull] QuoteHeader existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var obj = JObject.Load(reader);

            var result = obj["chart"]?["result"]?[0];

            if (result == null)
                return null;

            var meta = result?["meta"];

            if (meta == null)
                return null;

            var header = meta.ToObject<QuoteHeader>();

            var timeStamps = (JArray) result?["timestamp"];

            if (timeStamps == null)
                return null;

            var close = (JArray) result?["indicators"]?["quote"]?[0]?["close"];
            var open = (JArray) result?["indicators"]?["quote"]?[0]?["open"];
            var low = (JArray) result?["indicators"]?["quote"]?[0]?["low"];
            var high = (JArray) result?["indicators"]?["quote"]?[0]?["high"];
            var volume = (JArray) result?["indicators"]?["quote"]?[0]?["volume"];

            var adjclose = (JArray)result?["indicators"]?["adjclose"]?[0]?["adjclose"];

            header.Lines = timeStamps.Select((x, i) =>
            new QuoteLine
            {
                TimeStamp = x.Value<int>().FromJavaScript(),
                Close = close?[i]?.Value<double>() ?? 0,
                Low = low?[i]?.Value<double>() ?? 0,
                High = high?[i]?.Value<double>() ?? 0,
                Open = open?[i]?.Value<double>() ?? 0,
                Volume = volume?[i]?.Value<double>() ?? 0,
                AdjustedClosingPrice = adjclose?[i]?.Value<double>() ?? 0

            })
            .ToList();

            return header;
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] QuoteHeader value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
