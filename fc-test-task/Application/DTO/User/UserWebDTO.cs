using System.ComponentModel.DataAnnotations;

namespace FcTestTask.Application.DTO.User;

public class UserWebDTO : UserDTO
{
    public UserWebDTO(UserDTO userDTO) : base(userDTO)
    {
    }

    public override bool IsValid()
    {
        if (String.IsNullOrEmpty(FirstName) || FirstName.Length > 32)
        {
            return false;
        }
        if (String.IsNullOrEmpty(LastName) || LastName.Length > 32)
        {
            return false;
        }
        if (String.IsNullOrEmpty(MiddleName) || MiddleName.Length > 32)
        {
            return false;
        }
        if (String.IsNullOrEmpty(Passport) || Passport.Length != 11)
        {
            return false;
        }
        if (String.IsNullOrEmpty(BirthAddress))
        {
            return false;
        }
        if (String.IsNullOrEmpty(PhoneNumber) || PhoneNumber.Length != 11 || !PhoneNumber.StartsWith('7'))
        {
            return false;
        }
        if (String.IsNullOrEmpty(RegistrationAddress))
        {
            return false;
        }
        return true;
    }
}
