using BlogAppWebPages.ViewModels.RoleViewModels;

namespace BlogAppWebPages
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            //Role mapping
            CreateMap<BlogAppAPI.Contracts.Roles.Responses.RoleView, RoleView>();
            CreateMap<BlogAppAPI.Contracts.Roles.Responses.GetRolesResponse, GetRolesResponse>();
            CreateMap<RoleView, BlogAppAPI.Contracts.Roles.Requests.PutRoleRequest>();
            CreateMap<AddRoleRequest, BlogAppAPI.Contracts.Roles.Requests.AddRoleRequest>();
        }
    }
}
