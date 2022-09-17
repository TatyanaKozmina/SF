using BlogApp.Data.Models;
using BlogAppAPI.Contracts.Articles.Models;
using BlogAppAPI.Contracts.Articles.Requests;
using BlogAppAPI.Contracts.Articles.Responses;
using BlogAppAPI.Contracts.Comments.Models;
using BlogAppAPI.Contracts.Comments.Requests;
using BlogAppAPI.Contracts.Comments.Responses;
using BlogAppAPI.Contracts.Roles.Requests;
using BlogAppAPI.Contracts.Roles.Responses;
using BlogAppAPI.Contracts.Tags.Requests;
using BlogAppAPI.Contracts.Tags.Responses;
using BlogAppAPI.Contracts.Users.Requests;
using BlogAppAPI.Contracts.Roles.Models;

namespace BlogAppAPI
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            //Role mapping
            CreateMap<AddRoleRequest, Role>();
            CreateMap<PutRoleRequest, Role>();
            CreateMap<Role, RoleView>();

            //User mapping
            CreateMap<AddUserRequest, User>();
            CreateMap<PutUserRequest, User>();
            CreateMap<User, Contracts.Users.Responses.UserView>();
            CreateMap<User, Contracts.Users.Responses.UserRoles>();
            CreateMap<Role, Contracts.Users.Responses.RoleResp>();
            CreateMap<UserRole, Role>();

            //Article mapping
            CreateMap<AddArticleRequest, Article>();
            CreateMap<ArticleAuthor, Author>().ReverseMap();
            CreateMap<PutArticleRequest, Article>();
            CreateMap<Article, ArticleView>();

            //Comment mapping
            CreateMap<AddCommentRequest, Comment>();
            CreateMap<CommentUser, User>().ReverseMap();
            CreateMap<CommentArticle, Article>().ReverseMap();
            CreateMap<PutCommentRequest, Comment>();
            CreateMap<Comment, CommentView>();
            CreateMap<User, Contracts.Comments.Responses.UserView>();

            //Tag mapping
            CreateMap<AddTagRequest, Tag>();
            CreateMap<PutTagRequest, Tag>();
            CreateMap<Tag, TagView>();
        }
    }
}
