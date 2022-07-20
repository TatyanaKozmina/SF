using SchoolJournal.Models.DB;

namespace SchoolJournal.Data.Repos
{
    public interface IPupilRepository
    {
        Task<Pupil[]> GetPupils();
    }
}
