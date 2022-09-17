using System.ComponentModel.DataAnnotations;

namespace BlogAppWebPages.ViewModels.UserAccountViewModels
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
