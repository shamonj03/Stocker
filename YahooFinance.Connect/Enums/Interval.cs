using System.ComponentModel.DataAnnotations;

namespace YahooFinance.Connect.Enums
{
    public enum Interval
    {
        [Display(Name = "invalid")]
        Invalid,

        [Display(Name = "1m")]
        OneMinute,

        [Display(Name = "2m")]
        TwoMinutes,

        [Display(Name = "5m")]
        FiveMinutes,

        [Display(Name = "15m")]
        FifteenMinutes,

        [Display(Name = "30m")]
        ThirtyMinutes,

        [Display(Name = "1h")]
        OneHour,

        [Display(Name = "4h")]
        FourHour,

        [Display(Name = "1d")]
        OneDay,

        [Display(Name = "1wk")]
        OneWeek,

        [Display(Name = "1m")]
        OneMonth,

        [Display(Name = "1y")]
        OneYear,
    }
}
