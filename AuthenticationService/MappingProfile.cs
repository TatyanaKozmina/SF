using AuthenticationService.Models;
using AutoMapper;

namespace AuthenticationService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ConstructUsing(user => new UserViewModel(user));
        }
    }
}
