using MVCStartApp.Models.DB;

namespace MVCStartApp.Models
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
