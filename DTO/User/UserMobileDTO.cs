﻿namespace fc_test_task.DTO.User;

public class UserMobileDTO : UserDTO
{
    public UserMobileDTO(UserDTO userDTO) : base(userDTO)
    {
    }

    public override bool IsValid()
    {
        if (String.IsNullOrEmpty(PhoneNumber) || PhoneNumber.Length != 11 || !PhoneNumber.StartsWith('7'))
        {
            return false;
        }
        return true;
    }
}
