using BlogAppAPI.Contracts.Articles.Models;
using System.ComponentModel.DataAnnotations;

namespace BlogAppAPI.Contracts.Articles.Responses
{
    public class GetArticlesResponse
    {
        public List<ArticleView> Articles { get; set; }
    }

    public class ArticleView
    {
        public string Title { get; set; }
        public string Body { get; set; }
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }
        public List<ArticleAuthor> Authors { get; set; }
    }
}
