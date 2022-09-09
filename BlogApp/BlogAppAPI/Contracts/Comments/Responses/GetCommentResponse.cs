using BlogAppAPI.Contracts.Comments.Models;

namespace BlogAppAPI.Contracts.Comments.Responses
{
    public class GetCommentResponse
    {
        public List<CommentView> Comments { get; set; }
    }

    public class CommentView
    {
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public UserView User { get; set; }
        public CommentArticle Article { get; set; }
    }

    public class UserView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
