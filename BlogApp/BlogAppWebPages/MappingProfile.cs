using BlogAppWebPages.ViewModels.RoleViewModels;
using BlogAppWebPages.ViewModels.TagViewModels;

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

            //Tag mapping
            CreateMap<BlogAppAPI.Contracts.Tags.Responses.TagView, TagView>();
            CreateMap<BlogAppAPI.Contracts.Tags.Responses.GetTagResponse, GetTagResponse>();
            CreateMap<TagView, BlogAppAPI.Contracts.Tags.Requests.PutTagRequest>();
            CreateMap<AddTagRequest, BlogAppAPI.Contracts.Tags.Requests.AddTagRequest>();
        }
    }
}
