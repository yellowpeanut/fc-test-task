using fc_test_task.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace fc_test_task.Interfaces.Helpers;

public interface IUserHelper
{
    IActionResult ValidateDataFromDevice(User user, string device);
    UserDTO MapToUserDeviceDTO(UserDTO userDTO, string device);
}