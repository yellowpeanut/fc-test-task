using Microsoft.AspNetCore.Mvc;

namespace fc_test_task.Interfaces.Helpers;

public interface IUserHelper
{
    IActionResult ValidateDataFromDevice(User user, string device);
}