using System.ComponentModel.DataAnnotations;

namespace FcTestTask.Application.DTO.User;

public class UserDTO
{
    [MaxLength(32)]
    public string? LastName { get; set; }
    [MaxLength(32)]
    public string? FirstName { get; set; }
    [MaxLength(32)]
    public string? MiddleName { get; set; }
    public DateOnly? Birthday { get; set; }
    [DisplayFormat(DataFormatString = "#### ######")]
    public string? Passport { get; set; }
    public string? BirthAddress { get; set; }
    [DisplayFormat(DataFormatString = "7##########")]
    public string? PhoneNumber { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? RegistrationAddress { get; set; }
    public string? ResidentialAddress { get; set; }

    public UserDTO() { }
    public UserDTO(UserDTO other)
    {
        LastName = other.LastName;
        FirstName = other.FirstName;
        MiddleName = other.MiddleName;
        Birthday = other.Birthday;
        Passport = other.Passport;
        BirthAddress = other.BirthAddress;
        PhoneNumber = other.PhoneNumber;
        Email = other.Email;
        RegistrationAddress = other.RegistrationAddress;
        ResidentialAddress = other.ResidentialAddress;
    }
    public UserDTO(Domain.Users.Entities.User user)
    {
        LastName = user.LastName;
        FirstName = user.FirstName;
        MiddleName = user.MiddleName;
        Birthday = user.Birthday;
        Passport = user.Passport;
        BirthAddress = user.BirthAddress;
        PhoneNumber = user.PhoneNumber;
        Email = user.Email;
        RegistrationAddress = user.RegistrationAddress;
        ResidentialAddress = user.ResidentialAddress;
    }
    public virtual bool IsValid()
    {
        return false;
    }

    public virtual Domain.Users.Entities.User ToUser()
    {
        return new Domain.Users.Entities.User()
        {
            LastName = LastName,
            FirstName = FirstName,
            MiddleName = MiddleName,
            Birthday = Birthday,
            Passport = Passport,
            BirthAddress = BirthAddress,
            PhoneNumber = PhoneNumber,
            Email = Email,
            RegistrationAddress = RegistrationAddress,
            ResidentialAddress = ResidentialAddress
        };
    }
}
