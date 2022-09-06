namespace BlogApp.Data.Models
{
    public class Author
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
