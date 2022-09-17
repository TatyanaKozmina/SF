using BlogApp.Data.Models;

namespace BlogAppAPI.Contracts.Users.Responses
{
    public class UserRoles
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<RoleResp> Roles { get; set; } = new List<RoleResp>();
    }

    public class RoleResp
    {
        public string Name { get; set; }
    }
}
