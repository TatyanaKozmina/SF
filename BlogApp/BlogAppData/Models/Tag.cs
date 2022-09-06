namespace BlogApp.Data.Models
{
    public class Tag
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; }
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
