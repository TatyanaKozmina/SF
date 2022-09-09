using System.ComponentModel.DataAnnotations;

namespace BlogAppAPI.Contracts.Comments.Requests
{
    public class PutCommentRequest
    {
        public string Text { get; set; }
    }
}
