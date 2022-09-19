using System.ComponentModel.DataAnnotations;

namespace BlogAppWebPages.ViewModels.ArticleViewModels
{
    public class AddArticleRequest
    {
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Содержание")]
        public string Body { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата публикации")]
        public DateTime Created { get; set; }        
    }
}
