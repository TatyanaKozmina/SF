using BlogApp.Data.Models;

namespace BlogApp.Data.IRepos
{
    public interface ICommentRepo
    {
        public Task Create(Comment item);
        public Task Update(Comment item);
        public Task Delete(Guid id);
        public Task<List<Comment>> Get();
        public Task<Comment?> Get(Guid id);
    }
}
