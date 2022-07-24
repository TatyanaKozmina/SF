using SchoolJournal.Models.DB;

namespace SchoolJournal.Data.Repos
{
    public interface IUserRepository
    {
        Task<User> GetUser(string email, string password);
        Task<User> GetUserByEmail(string email);
        Task AddUser(string email, string password);
    }
}
