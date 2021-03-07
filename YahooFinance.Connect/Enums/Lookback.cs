using System.ComponentModel.DataAnnotations;

namespace YahooFinance.Connect.Enums
{
    public enum Lookback
    {
        [Display(Name = "invalid")]
        Invalid,

        [Display(Name = "1d")]
        OneDay,

        [Display(Name = "5d")]
        FiveDays,

        [Display(Name = "1m")]
        OneMonth,

        [Display(Name = "3m")]
        ThreeMonths,

        [Display(Name = "6m")]
        SixMonths,

        [Display(Name = "1y")]
        OneYear,

        [Display(Name = "2y")]
        TwoYears,

        [Display(Name = "5y")]
        FiveYears,

        [Display(Name = "10y")]
        TenYears,

        [Display(Name = "ytd")]
        YearToDate,

        [Display(Name = "max")]
        Max
    }
}
