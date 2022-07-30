using SchoolJournal.Models.DB;

namespace SchoolJournal.Data.Repos
{
    public interface IPupilRepository
    {
        Task<List<Pupil>> GetPupils(Guid streamId);

        Task Create(Pupil pupil, Guid streamId);
    }
}
