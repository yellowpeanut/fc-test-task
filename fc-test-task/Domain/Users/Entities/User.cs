using FcTestTask.Domain.Users.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace FcTestTask.Domain.Users.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    //public FullName? FullName { get; set; }
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

    public override bool Equals(object? obj)
    {
        return obj is User user &&
               Id == user.Id &&
               LastName == user.LastName &&
               FirstName == user.FirstName &&
               MiddleName == user.MiddleName &&
               EqualityComparer<DateOnly?>.Default.Equals(Birthday, user.Birthday) &&
               Passport == user.Passport &&
               BirthAddress == user.BirthAddress &&
               PhoneNumber == user.PhoneNumber &&
               Email == user.Email &&
               RegistrationAddress == user.RegistrationAddress &&
               ResidentialAddress == user.ResidentialAddress;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Passport, PhoneNumber, Email);
    }
}
