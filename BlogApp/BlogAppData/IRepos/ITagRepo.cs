using BlogApp.Data.Models;

namespace BlogApp.Data.IRepos
{
    public interface ITagRepo
    {
        public Task Create(Tag item);
        public Task Update(Tag item);
        public Task Delete(Guid id);
        public Task<List<Tag>> Get();
        public Task<Tag?> Get(Guid id);
    }
}
