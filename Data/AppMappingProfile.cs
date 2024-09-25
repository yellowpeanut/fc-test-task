using AutoMapper;
using fc_test_task.DTO.User;

namespace fc_test_task.Data;

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
