using Application.Dtos;
using AutoMapper;
using Model;

namespace Application.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<RegisterInput, User>();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
