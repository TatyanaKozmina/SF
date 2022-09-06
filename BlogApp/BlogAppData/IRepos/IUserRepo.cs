using BlogApp.Data.Models;

namespace BlogApp.Data.IRepos
{
    public interface IUserRepo
    {
        public Task Create(User item);
        public Task Update(User item);
        public Task Delete(Guid id);
        public Task<User?> Get(Guid id);
        public Task<List<User>> Get();
        public Task GrantRole(Guid id, string roleName);
        public Task<User?> GetByEmailPassword(string email, string password);
    }
}
