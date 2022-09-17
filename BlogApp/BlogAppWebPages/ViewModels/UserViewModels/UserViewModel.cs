using System.ComponentModel.DataAnnotations;

namespace BlogAppWebPages.ViewModels.UserViewModels
{
    public class GetUserResponse
    {
        public List<UserView> Users { get; set; }
    }

    public class UserView
    {
        public Guid Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
