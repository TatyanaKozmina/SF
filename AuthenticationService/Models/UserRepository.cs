namespace AuthenticationService.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users;

        public UserRepository()
        {
            users = new List<User>();
            users.Add(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Elena",
                LastName = "Meshkova",
                Login = "emeshkova",
                Password = "32443dgdh",
                Email = "emeshkova@gmail.com",
                Role = new Role() { Id = 1, Name = "Пользователь"}
            });
            users.Add(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Max",
                LastName = "Stein",
                Login = "mstein",
                Password = "4645y4y56uyh",
                Email = "mstein@gmail.com",
                Role = new Role() { Id = 2, Name = "Администратор" }
            });
            users.Add(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Li",
                LastName = "Zintao",
                Login = "lzintao",
                Password = "vcbe5t465y6",
                Email = "lzintao@gmail.com",
                Role = new Role() { Id = 1, Name = "Пользователь" }
            });
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User? GetByLogin(string login)
        {
            return users.Where(user => user.Login == login).FirstOrDefault();
        }
    }
}
