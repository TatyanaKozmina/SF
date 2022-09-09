using BlogAppAPI.Contracts.Comments.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogAppAPI.Contracts.Comments.Requests
{
    public class AddCommentRequest
    {
        public string Text { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        public CommentUser User { get; set; }
        public CommentArticle Article { get; set; }
    }
}
