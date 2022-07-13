using MVCStartApp.Models.DB;

namespace MVCStartApp.Models
{
    public interface IHistoryRepository
    {
        Task RecordHistory(string url);
        Task<History[]> GetHistory();
    }
}