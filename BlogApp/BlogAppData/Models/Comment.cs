namespace BlogApp.Data.Models
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
