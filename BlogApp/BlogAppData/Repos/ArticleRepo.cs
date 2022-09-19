using BlogApp.Data.Comparers;
using BlogApp.Data.DBContext;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Repos
{
    public class ArticleRepo : IArticleRepo
    {
        private readonly BlogAppDBContext context;

        public ArticleRepo(BlogAppDBContext _context)
        {
            context = _context;
        }

        public async Task Create(Article item)
        {
            var authorsToLoadFromDB = item.Authors.Intersect(context.Authors, new AuthorComparer()).ToList();

            item.Authors.RemoveAll(AuthorExists);
            foreach (var auth in authorsToLoadFromDB)
            {
                var author = context.Authors.Where(a => a.FirstName.ToUpper() == auth.FirstName.ToUpper() &&
                                                        a.LastName.ToUpper() == auth.LastName.ToUpper()).FirstOrDefault();
                if (author != null)
                    item.Authors.Add(author);
            }

            await context.Articles.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            Article? item = await context.Articles.FindAsync(id);
            if (item != null)
            {
                context.Articles.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Article>> Get()
        {
            return await context.Articles.Include(a => a.Authors).ToListAsync();
        }

        public async Task<Article> Get(Guid id)
        {
            return await context.Articles.FindAsync(id);
        }

        public async Task Update(Article item)
        {
            var article = await context.Articles.FindAsync(item.Id);
            if (article != null)
            {
                context.Entry(article).CurrentValues.SetValues(item);
                await context.SaveChangesAsync();
            }
        }

        private bool AuthorExists(Author item)
        {
            return context.Authors.Where(a => a.FirstName.ToUpper() == item.FirstName.ToUpper() &&
                a.LastName.ToUpper() == item.LastName.ToUpper()).Any();
        }
    }
}
