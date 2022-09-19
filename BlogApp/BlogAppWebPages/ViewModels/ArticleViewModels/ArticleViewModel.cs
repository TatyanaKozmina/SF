using System.ComponentModel.DataAnnotations;

namespace BlogAppWebPages.ViewModels.ArticleViewModels
{
    public class GetArticleResponse
    {
        public List<ArticleView> Articles { get; set; }
    }

    public class ArticleView
    {
        public Guid Id { get; set; }
        [Display(Name = "Название")]
        public string Title { get; set; }
        public string Body { get; set; }
        
        [Display(Name = "Дата публикации")]
        public string Created { get; set; }
        [Display(Name = "Авторы")]
        public List<ArticleAuthorView> Authors { get; set; }
    }

    public class ArticleAuthorView
    {
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}
