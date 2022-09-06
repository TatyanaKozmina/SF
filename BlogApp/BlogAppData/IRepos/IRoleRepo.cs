
using BlogApp.Data.Models;

namespace BlogApp.Data.IRepos
{
    public interface IRoleRepo
    {
        public Task Create(Role item);
        public Task Update(Role item);
        public Task Delete(string name);
        public Task<List<Role>> GetAll();
    }
}
