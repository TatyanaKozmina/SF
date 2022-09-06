using BlogApp.Data.Models;
using BlogApp.Data.Queries;

namespace BlogApp.Data.IRepos
{
    public interface ITagRepo
    {
        public Task Create(Tag item);
        public Task Update(Tag item, UpdateTagQuery query);
        public Task Delete(string text);
        public Task<List<Tag>> Get();
        public Task<Tag?> Get(Guid id);
    }
}
