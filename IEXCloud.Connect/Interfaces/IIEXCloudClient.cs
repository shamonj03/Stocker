using System.Threading.Tasks;

namespace IEXCloud.Connect.Interfaces
{
    public interface IIEXCloudClient
    {
        Task<object> GetDailyAsync(string symbol);
    }
}
