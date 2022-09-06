using BlogApp.Data.Models;
using BlogAppAPI.Contracts.Articles;
using BlogAppAPI.Contracts.Comments;
using BlogAppAPI.Contracts.Roles;
using BlogAppAPI.Contracts.Tags;
using BlogAppAPI.Contracts.Users;

namespace BlogAppAPI.Contracts
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
            CreateMap<User, Users.UserView>();

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
            CreateMap<User, Comments.UserView>();

            //Tag mapping
            CreateMap<AddTagRequest, Tag>();
            CreateMap<PutTagRequest, Tag>();
        }
    }
}
