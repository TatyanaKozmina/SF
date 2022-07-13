using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.DB;

namespace MVCStartApp.Models
{
    public class HistoryRepository : IHistoryRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public HistoryRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task RecordHistory(string url)
        {
            History history = new History();
            history.Id = Guid.NewGuid();
            history.Date = DateTime.Now;
            history.Url = url;

            //// Запись данных о запросе в базу
            var entry = _context.Entry(history);
            if (entry.State == EntityState.Detached)
                await _context.HistoryRecords.AddAsync(history);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<History[]> GetHistory()
        {
            return await _context.HistoryRecords.ToArrayAsync();
        }
    }
}
