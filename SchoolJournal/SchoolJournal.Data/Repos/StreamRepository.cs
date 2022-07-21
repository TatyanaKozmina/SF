using Microsoft.EntityFrameworkCore;

namespace SchoolJournal.Data.Repos
{
    public class StreamRepository : IStreamRepository
    {
        private readonly SchoolJournalDBContext _context;

        public StreamRepository(SchoolJournalDBContext context)
        {
            _context = context;
        }
        public async Task Create(Models.DB.Stream stream)
        {
            var entry = _context.Entry(stream);
            if (entry.State == EntityState.Detached)
            {
                stream.Id = Guid.NewGuid();
                await _context.Streams.AddAsync(stream);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Models.DB.Stream>> GetStreams()
        {
            return await _context.Streams.OrderByDescending(s => s.Started).ToListAsync();
        }
    }
}
