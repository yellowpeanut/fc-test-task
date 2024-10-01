using FcTestTask.Domain.Users.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FcTestTask.Application.Interfaces.Helpers;

public interface IUserHelper
{
    IActionResult ValidateDataFromDevice(User user, string device);
}