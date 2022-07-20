using Microsoft.EntityFrameworkCore;

namespace SchoolJournal.Data.Repos
{
    internal class StreamRepository : IStreamRepository
    {
        private readonly SchoolJournalDBContext _context;

        public StreamRepository(SchoolJournalDBContext context)
        {
            _context = context;
        }
        public async Task AddStream(Models.DB.Stream stream)
        {
            var entry = _context.Entry(stream);
            if (entry.State == EntityState.Detached)
                await _context.Streams.AddAsync(stream);

            await _context.SaveChangesAsync();
        }

        public async Task<Models.DB.Stream[]> GetStreams()
        {
            return await _context.Streams.ToArrayAsync();
        }
    }
}
