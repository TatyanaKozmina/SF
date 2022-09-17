using BlogAppWebPages.ViewModels.RoleViewModels;
using BlogAppWebPages.ViewModels.TagViewModels;
using BlogAppWebPages.ViewModels.UserViewModels;

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

            //UserAccount mapping
            CreateMap<ViewModels.UserAccountViewModels.LoginRequest, BlogAppAPI.Contracts.Account.Request.LoginRequest>();
            CreateMap<ViewModels.UserAccountViewModels.RegisterRequest, BlogAppAPI.Contracts.Users.Requests.AddUserRequest>();
            CreateMap<ViewModels.UserAccountViewModels.RegisterRequest, ViewModels.UserAccountViewModels.LoginRequest>();

            //User mapping
            CreateMap<BlogAppAPI.Contracts.Users.Responses.UserView, UserView>();
            CreateMap<BlogAppAPI.Contracts.Users.Responses.GetUsersReponse, GetUserResponse>();
            CreateMap<PutUserRequest, BlogAppAPI.Contracts.Users.Requests.PutUserRequest>();
            CreateMap<BlogAppAPI.Contracts.Users.Responses.UserView, PutUserRequest>();
        }
    }
}
