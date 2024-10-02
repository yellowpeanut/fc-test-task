using AutoMapper;
using fc_test_task.Data.Enums;
using fc_test_task.DTO.User;
using fc_test_task.Interfaces.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace fc_test_task.Helpers;

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
