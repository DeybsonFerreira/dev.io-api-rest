using app.Api.Models;
using app.Business.Models;
using AutoMapper;

namespace app.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Login, LoginModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}