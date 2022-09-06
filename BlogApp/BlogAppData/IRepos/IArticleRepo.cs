using BlogApp.Data.Models;

namespace BlogApp.Data.IRepos
{
    public interface IArticleRepo
    {
        public Task Create(Article item);
        public Task Update(Article item);
        public Task Delete(Guid id);
        public Task<List<Article>> Get();
        public Task<List<Article>> Get(Guid authorid);
    }
}
