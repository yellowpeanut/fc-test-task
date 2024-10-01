using System.ComponentModel.DataAnnotations;

namespace FcTestTask.Application.DTO.User;

public class UserWebDTO
{
    [MaxLength(32)]
    public required string LastName { get; set; }
    [MaxLength(32)]
    public required string FirstName { get; set; }
    [MaxLength(32)]
    public required string MiddleName { get; set; }

    public required DateOnly Birthday { get; set; }
    [DisplayFormat(DataFormatString = "#### ######")]
    public required string Passport { get; set; }
    public required string BirthAddress { get; set; }
    [DisplayFormat(DataFormatString = "7##########")]
    public required string PhoneNumber { get; set; }
    public required string RegistrationAddress { get; set; }
}
