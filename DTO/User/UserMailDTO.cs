using System.ComponentModel.DataAnnotations;

namespace fc_test_task.DTO.User;

public class UserMailDTO
{
    [MaxLength(32)]
    public required string FirstName { get; set; }
    [EmailAddress]
    public required string Email { get; set; }
}
