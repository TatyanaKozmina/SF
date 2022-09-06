using System.ComponentModel.DataAnnotations;

namespace BlogAppAPI.Contracts.Comments
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
