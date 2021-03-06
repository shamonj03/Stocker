using AlphaVantage.Connect.Models;
using System.Threading.Tasks;

namespace AlphaVantage.Connect.Interfaces
{
    public interface IAlphaVantageClient
    {
        Task<TimeSeriesDaily> GetDailyAsync(string symbol);
    }
}
