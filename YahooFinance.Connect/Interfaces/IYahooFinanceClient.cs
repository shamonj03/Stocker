using System.Threading.Tasks;
using YahooFinance.Connect.Models;

namespace YahooFinance.Connect.Interfaces
{
    public interface IYahooFinanceClient
    {
        Task<QuoteHeader> GetDailyAsync(string symbol);
    }
}
