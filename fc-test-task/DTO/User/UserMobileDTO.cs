using System.ComponentModel.DataAnnotations;

namespace fc_test_task.DTO.User;

public class UserMobileDTO
{
    [DisplayFormat(DataFormatString = "7##########")]
    public required string PhoneNumber { get; set; }
}
