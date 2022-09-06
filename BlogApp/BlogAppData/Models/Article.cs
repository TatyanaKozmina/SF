namespace BlogApp.Data.Models
{
    public class Article
    {
        public Guid Id { get; set; } = Guid.NewGuid();        
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
