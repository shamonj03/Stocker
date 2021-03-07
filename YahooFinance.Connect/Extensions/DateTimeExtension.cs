using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using YahooFinance.Connect.Enums;

namespace YahooFinance.Connect.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime FromJavaScript(this int timeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timeStamp);
        }

        public static Lookback GetLookback(this string lookback)
        {
            var property = typeof(Lookback)
                .GetFields()
                .FirstOrDefault(x => x.GetCustomAttribute<DisplayAttribute>()?.Name == lookback);

            if (property == null)
                return Lookback.Invalid;

            return Enum.Parse<Lookback>(property.Name);
        }

        public static string GetString(this Lookback lookback)
        {
            return lookback.GetType()
                .GetField(lookback.ToString())
                .GetCustomAttribute<DisplayAttribute>()?.Name;
        }
    }
}
