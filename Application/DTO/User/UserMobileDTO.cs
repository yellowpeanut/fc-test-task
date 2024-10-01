using System.ComponentModel.DataAnnotations;

namespace FcTestTask.Application.DTO.User;

public class UserMobileDTO
{
    [DisplayFormat(DataFormatString = "7##########")]
    public required string PhoneNumber { get; set; }
}
