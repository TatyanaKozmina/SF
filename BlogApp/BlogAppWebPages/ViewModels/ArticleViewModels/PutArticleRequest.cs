using System.ComponentModel.DataAnnotations;

namespace BlogAppWebPages.ViewModels.ArticleViewModels
{
    public class PutArticleRequest
    {
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Display(Name = "Содержание")]
        public string Body { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Дата публикации")]
        public DateTime Created { get; set; }
        [Display(Name = "Авторы")]
        public List<ArticleAuthorView> Authors { get; set; }
    }
}
