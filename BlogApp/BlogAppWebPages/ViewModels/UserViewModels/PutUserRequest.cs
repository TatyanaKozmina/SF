using System.ComponentModel.DataAnnotations;

namespace BlogAppWebPages.ViewModels.UserViewModels
{
    public class PutUserRequest
    {
        public Guid Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

    }
}
