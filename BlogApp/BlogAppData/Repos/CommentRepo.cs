using BlogApp.Data.DBContext;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Repos
{
    public class CommentRepo : ICommentRepo
    {
        private readonly BlogAppDBContext context;

        public CommentRepo(BlogAppDBContext _context)
        {
            context = _context;
        }

        public async Task Create(Comment item)
        {
            var user = await context.Users.Where(u => u.Email == item.User.Email).FirstOrDefaultAsync();
            if (user == null) return;
            item.User = user;
            var article = await context.Articles.Where(a => a.Title == item.Article.Title).FirstOrDefaultAsync();
            if (article == null) return;
            item.Article = article;
            await context.Comments.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var item = await context.Comments.FindAsync(id);
            if (item != null)
            {
                context.Comments.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Comment>> Get()
        {
            return await context.Comments.Include(c => c.User).Include(c => c.Article).ToListAsync();
        }

        public async Task<Comment?> Get(Guid id)
        {
            return await context.Comments.Where(c => c.Id == id).Include(c => c.User).Include(c => c.Article).FirstOrDefaultAsync();
        }

        public async Task Update(Comment item)
        {
            var comment = await context.Comments.FindAsync(item.Id);
            if (comment != null)
            {
                context.Entry(comment).Property(c => c.Text).CurrentValue = item.Text;
                await context.SaveChangesAsync();
            }
        }
    }
}
