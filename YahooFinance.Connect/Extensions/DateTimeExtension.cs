using System;

namespace YahooFinance.Connect.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime FromJavaScript(this int timeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timeStamp);
        }

        public static int ToJavaScript(this DateTime date)
        {
            return (int) (date - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }
    }
}
