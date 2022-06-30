using FirstApp;

namespace FirstApp
{
    public class UserRepository
    {
        private static AppContext db;

        public UserRepository(AppContext context)
        {
            db = context;
        }

        public User? GetById(int id)
        {
            return db.Users.FirstOrDefault(user => user.Id == id);
        }

        public User? GetByName(string name)
        {
            return db.Users.FirstOrDefault(user => user.Name == name);
        }

        public List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        async public void AddUserAsync(User user)
        {
            await db.AddAsync(user);
            await db.SaveChangesAsync();
        }

        async public void DeleteUserAsync(User user)
        {
            db.Remove(user);
            await db.SaveChangesAsync();
        }

        async public void ChangeName(int id, string name)
        {
            var user = db.Users.FirstOrDefault(user => user.Id == id);
            user.Name = name;
            await db.SaveChangesAsync();
        }
    }
}
