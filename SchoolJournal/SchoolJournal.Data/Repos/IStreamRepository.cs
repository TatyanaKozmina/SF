namespace SchoolJournal.Data.Repos
{
    public interface IStreamRepository
    {
        Task<List<Models.DB.Stream>> GetStreams();

        Task Create(Models.DB.Stream stream);
    }
}
