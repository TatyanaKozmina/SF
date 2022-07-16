namespace AuthenticationService.Models
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User? GetByLogin(string login);
    }
}
