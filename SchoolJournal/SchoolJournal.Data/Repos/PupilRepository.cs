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

        public async Task Create(Pupil pupil)
        {
            pupil.Stream = _context.Streams.Where(s => s.Id == pupil.StreamId).FirstOrDefault();
            pupil.Id = Guid.NewGuid();
            await _context.Pupils.AddAsync(pupil);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pupil>> GetPupils(Guid streamId)
        {
            return await _context.Pupils
                .Where(p => p.StreamId == streamId)
                .Include(p => p.Stream).ToListAsync();
        }
    }
}
