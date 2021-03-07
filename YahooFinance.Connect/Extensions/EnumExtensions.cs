using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace YahooFinance.Connect.Extensions
{
    public static class EnumExtensions
    {
        public static T GetEnumFromDisplayName<T>(this string lookback)
            where T : struct
        {
            var field = typeof(T)
                .GetFields()
                .FirstOrDefault(x => x.GetCustomAttribute<DisplayAttribute>()?.Name == lookback);

            return field == null ? default : Enum.Parse<T>(field.Name);
        }

        public static string GetDisplayNameFromEnum<T>(this T lookback)
            where T : struct
        {
            return typeof(T)
                .GetField(lookback.ToString())?
                .GetCustomAttribute<DisplayAttribute>()?.Name;
        }
    }
}
