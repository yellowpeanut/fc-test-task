using FcTestTask.Data.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FcTestTask.Application.FilterAttributes;

public class HasDeviceHeaderAttribute : ActionFilterAttribute
{

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        string? device = context.HttpContext.Request.Headers["x-Device"];
        if (string.IsNullOrEmpty(device))
        {
            context.Result = new BadRequestObjectResult("Request must have 'x-Device' header");
        }
        else if (!Devices.ListAll.Contains(device))
        {
            context.Result = new BadRequestObjectResult("The specified x-Device is not valid");
        }

        base.OnActionExecuting(context);
    }
}
