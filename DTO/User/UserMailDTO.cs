using System.Net.Mail;

namespace fc_test_task.DTO.User;

public class UserMailDTO : UserDTO
{
    public UserMailDTO(UserDTO userDTO) : base(userDTO)
    {
    }

    public override bool IsValid()
    {
        if (String.IsNullOrEmpty(FirstName) || FirstName.Length > 32)
        {
            return false;
        }
        if (String.IsNullOrEmpty(Email) || !MailAddress.TryCreate(Email, out _))
        {
            return false;
        }
        return true;
    }
}
