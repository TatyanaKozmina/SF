using BlogApp.Data.DBContext;
using BlogApp.Data.IRepos;
using BlogApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly BlogAppDBContext context;

        public UserRepo(BlogAppDBContext _context)
        {
            context = _context;
        }

        public async Task Create(User item)
        {
            var role = await context.Roles.Where(r => r.Name.ToUpper() == "пользователь").FirstOrDefaultAsync();
            if (role != null) item.Roles.Add(role);
            await context.Users.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            User? item = await context.Users.FindAsync(id);
            if (item != null)
            {
                context.Users.Remove(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task<User?> Get(Guid id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<List<User>> Get()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User?> GetByEmailPassword(string email, string password)
        {
            return await context.Users.Where(u =>
            u.Email.ToUpper() == email.ToUpper() && u.Password.ToUpper() == password.ToUpper())
                .Include(u => u.Roles)
                .FirstOrDefaultAsync();
        }

        public async Task GrantRole(Guid id, string roleName)
        {
            var user = await context.Users.FindAsync(id);
            if (user != null)
            {
                var role = await context.Roles.Where(r => r.Name.ToUpper() == roleName.ToUpper()).FirstOrDefaultAsync();
                if (role != null)
                {
                    user.Roles.Add(role);
                    context.Users.Update(user);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task Update(User item)
        {
            var user = await context.Users.FindAsync(item.Id);
            if (user != null)
            {
                context.Entry(user).CurrentValues.SetValues(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
