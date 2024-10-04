using System.ComponentModel.DataAnnotations;

namespace fc_test_task.Queries.User;

public class UserFindQuery
{
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    [DisplayFormat(DataFormatString = "7##########")]
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}
