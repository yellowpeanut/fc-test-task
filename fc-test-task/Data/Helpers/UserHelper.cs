using AutoMapper;
using FcTestTask.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using FcTestTask.Domain.Users.Entities;
using FcTestTask.Application.Interfaces.Helpers;
using FcTestTask.Application.DTO.User;

namespace FcTestTask.Data.Helpers;

public class UserHelper : IUserHelper
{
    private readonly IMapper _mapper;

    public UserHelper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IActionResult ValidateDataFromDevice(User user, string device)
    {
        try
        {
            if (device == Devices.MAIL)
            {
                _mapper.Map<User, UserMailDTO>(user);
                return new OkResult();
            }
            if (device == Devices.MOBILE)
            {
                _mapper.Map<User, UserMobileDTO>(user);
                return new OkResult();
            }
            if (device == Devices.WEB)
            {
                _mapper.Map<User, UserWebDTO>(user);
                return new OkResult();
            }
        }
        catch (AutoMapperMappingException ex)
        {
            return new BadRequestObjectResult(ex);
        }

        return new BadRequestResult();
    }

    public UserDTO MapToUserDeviceDTO(UserDTO userDTO, string device)
    {
        switch (device)
        {
            case Devices.MAIL:
                return new UserMailDTO(userDTO);
            case Devices.MOBILE:
                return new UserMobileDTO(userDTO);
            case Devices.WEB:
                return new UserWebDTO(userDTO);
        }
        return userDTO;
    }
}
