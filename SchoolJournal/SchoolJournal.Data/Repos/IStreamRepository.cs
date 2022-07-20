namespace SchoolJournal.Data.Repos
{
    public interface IStreamRepository
    {
        Task<Models.DB.Stream[]> GetStreams();

        Task AddStream(Models.DB.Stream stream);
    }
}
