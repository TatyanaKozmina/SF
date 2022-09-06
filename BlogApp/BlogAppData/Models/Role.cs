namespace BlogApp.Data.Models
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
