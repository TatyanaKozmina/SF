using System.ComponentModel.DataAnnotations;

namespace BlogAppAPI.Contracts.Articles.Requests
{
    public class PutArticleRequest
    {
        public string Title { get; set; }
        public string Body { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
    }
}
