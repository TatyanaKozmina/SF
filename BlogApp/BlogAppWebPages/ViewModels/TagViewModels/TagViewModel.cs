using System.ComponentModel.DataAnnotations;

namespace BlogAppWebPages.ViewModels.TagViewModels
{
    public class GetTagResponse
    {
        public List<TagView> Tags { get; set; }
    }

    public class TagView
    {
        public Guid Id { get; set; }
        [Display(Name = "Тэг")]
        public string Text { get; set; }
    }
}
