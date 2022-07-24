using SchoolJournal.Models.DB;
using Microsoft.EntityFrameworkCore;


namespace SchoolJournal.Data.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly SchoolJournalDBContext _context;
        public UserRepository(SchoolJournalDBContext context)
        {
            _context = context;
        }

        public async Task AddUser(string email, string password)
        {
            User user = new User();
            user.Id = Guid.NewGuid();
            user.Email = email;
            user.Password = password;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string email, string password)
        {
            return await _context.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }
    }
}
