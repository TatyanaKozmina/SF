using System.ComponentModel.DataAnnotations;

namespace BlogAppWebPages.ViewModels.UserAccountViewModels
{
    public class RegisterRequest
    {
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Пароль повторный")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
