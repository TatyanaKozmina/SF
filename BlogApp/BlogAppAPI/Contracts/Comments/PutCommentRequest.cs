using System.ComponentModel.DataAnnotations;

namespace BlogAppAPI.Contracts.Comments
{
    public class PutCommentRequest
    {
        public string Text { get; set; }
    }
}
