namespace BlogApp.Data.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }        
        public string Password { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}