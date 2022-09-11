
using BlogApp.Data.Models;

namespace BlogApp.Data.IRepos
{
    public interface IRoleRepo
    {
        public Task Create(Role item);
        public Task Update(Role item);
        public Task Delete(Guid id);
        public Task<List<Role>> Get();
        public Task<Role> GetById(Guid id);
    }
}
