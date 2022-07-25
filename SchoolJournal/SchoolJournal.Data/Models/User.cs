namespace SchoolJournal.Models.DB
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
