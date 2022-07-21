namespace SchoolJournal.Data.Repos
{
    public interface IStreamRepository
    {
        Task<List<Models.DB.Stream>> GetStreams();

        Task AddStream(Models.DB.Stream stream);
    }
}
