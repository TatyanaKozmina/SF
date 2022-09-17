using BlogApp.Data.DBContext;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Repos
{
    public class TagRepo : ITagRepo
    {
        private readonly BlogAppDBContext context;

        public TagRepo(BlogAppDBContext _context)
        {
            context = _context;
        }

        public async Task Create(Tag item)
        {
            if (!context.Tags.Where(t => t.Text.ToUpper() == item.Text.ToUpper()).Any())
            {
                await context.Tags.AddAsync(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var item = await context.Tags.FindAsync(id);
            if (item != null)
            {
                context.Tags.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Tag>> Get()
        {
            return await context.Tags.ToListAsync();
        }

        public async Task<Tag?> Get(Guid id)
        {
            return await context.Tags.FindAsync(id);
        }

        public async Task Update(Tag item)
        {
            var tag = await context.Tags.FindAsync(item.Id);
            if (tag != null)
            {
                context.Entry(tag).CurrentValues.SetValues(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
