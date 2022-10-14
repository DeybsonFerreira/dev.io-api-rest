using app.Api.Models;
using app.Business.Models;
using app.Business.Models.Dto;
using app.Business.Models.Input;
using app.Business.Models.Output;
using AutoMapper;

namespace app.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Login, LoginModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<NaturalPerson, NaturalPersonInput>().ReverseMap();
            CreateMap<NaturalPerson, NaturalPersonOutput>().ReverseMap();

            CreateMap<NaturalPerson, LegalPersonInput>().ReverseMap();
            CreateMap<NaturalPerson, LegalPersonOutput>().ReverseMap();

        }
    }
}