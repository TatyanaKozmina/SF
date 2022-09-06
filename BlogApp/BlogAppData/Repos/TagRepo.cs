using BlogApp.Data.DBContext;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using BlogApp.Data.Queries;
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

        public async Task Delete(string text)
        {
            var item = await context.Tags.Where(t => t.Text.ToUpper() == text.ToUpper()).FirstOrDefaultAsync();
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

        public async Task Update(Tag item, UpdateTagQuery query)
        {
            var tag = await context.Tags.Where(t => t.Text.ToUpper() == item.Text.ToUpper()).FirstOrDefaultAsync();
            if (tag != null)
            {
                if (!String.IsNullOrEmpty(query.NewText))
                    tag.Text = query.NewText;
                context.Tags.Update(tag);
                await context.SaveChangesAsync();
            }
        }
    }
}
