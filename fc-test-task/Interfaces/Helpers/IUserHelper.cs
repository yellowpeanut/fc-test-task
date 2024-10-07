using FcTestTask.Domain.Users.Entities;
using FcTestTask.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace FcTestTask.Interfaces.Helpers;

public interface IUserHelper
{
    IActionResult ValidateDataFromDevice(User user, string device);
    UserDTO MapToUserDeviceDTO(UserDTO userDTO, string device);
}