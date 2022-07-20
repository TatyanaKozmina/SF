using Microsoft.EntityFrameworkCore;
using SchoolJournal.Models.DB;

namespace SchoolJournal.Data.Repos
{
    public class JournalRecordRepository : IJournalRecordRepository
    {
        private readonly SchoolJournalDBContext _context;

        public JournalRecordRepository(SchoolJournalDBContext context)
        {
            _context = context;
        }

        public async Task<JournalRecord[]> GetJournalRecords()
        {
            return await _context.JournalRecords.Include(p => p.Pupil).ToArrayAsync();
        }
    }
}
