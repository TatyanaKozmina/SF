using BlogApp.Data.DBContext;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Repos
{
    public class RoleRepo : IRoleRepo
    {
        private readonly BlogAppDBContext context;

        public RoleRepo(BlogAppDBContext _context)
        {
            context = _context;
        }

        public async Task Create(Role item)
        {
            await context.Roles.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task Update(Role item)
        {
            var role = await context.Roles.FindAsync(item.Id);
            if (role != null)
            {
                context.Entry(role).CurrentValues.SetValues(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(string name)
        {
            var role = await context.Roles.Where(r => r.Name == name).FirstOrDefaultAsync();
            if (role != null)
            {
                context.Roles.Remove(role);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Role>> GetAll()
        {
            return await context.Roles.ToListAsync();
        }
    }
}
