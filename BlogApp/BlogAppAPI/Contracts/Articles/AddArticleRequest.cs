using System.ComponentModel.DataAnnotations;

namespace BlogAppAPI.Contracts.Articles
{
    public class AddArticleRequest
    {
        public string Title { get; set; }
        public string Body { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; } 
        
        public List<ArticleAuthor> Authors { get; set; }
    }    
}
