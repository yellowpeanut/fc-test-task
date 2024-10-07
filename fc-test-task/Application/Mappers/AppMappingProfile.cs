using AutoMapper;
using FcTestTask.Application.DTO.User;
using FcTestTask.Domain.Users.Entities;

namespace FcTestTask.Application.Mappers;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<User, UserMailDTO>();
        CreateMap<User, UserMailDTO>().ReverseMap();
        CreateMap<User, UserMobileDTO>();
        CreateMap<User, UserMobileDTO>().ReverseMap();
        CreateMap<User, UserWebDTO>();
        CreateMap<User, UserWebDTO>().ReverseMap();
    }
}
