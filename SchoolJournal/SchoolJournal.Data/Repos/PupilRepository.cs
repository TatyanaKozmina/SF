using Microsoft.EntityFrameworkCore;
using SchoolJournal.Models.DB;

namespace SchoolJournal.Data.Repos
{
    public class PupilRepository : IPupilRepository
    {
        private readonly SchoolJournalDBContext _context;

        public PupilRepository(SchoolJournalDBContext context)
        {
            _context = context;
        }

        public async Task<Pupil[]> GetPupils()
        {
            return await _context.Pupils.Include(s => s.Stream).ToArrayAsync();
        }
    }
}
