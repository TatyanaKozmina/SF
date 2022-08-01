using SchoolJournal.Models.DB;

namespace SchoolJournal.Data.Repos
{
    public interface IPupilRepository
    {
        Task<List<Pupil>> GetPupils(Guid id);

        Task Create(Pupil pupil);
    }
}
