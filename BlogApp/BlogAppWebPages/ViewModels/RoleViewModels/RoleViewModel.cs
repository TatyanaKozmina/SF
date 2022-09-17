using System.ComponentModel.DataAnnotations;

namespace BlogAppWebPages.ViewModels.RoleViewModels
{
    public class GetRolesResponse
    {
        public List<RoleView> Roles { get; set; }
    }

    public class RoleView
    {
        public Guid Id { get; set; }
        [Display(Name = "Название роли")]
        public string Name { get; set; }
        [Display(Name = "Описание роли")]
        public string Description { get; set; }
    }
}
