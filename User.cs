﻿using System.ComponentModel.DataAnnotations;

namespace fc_test_task;

public class User
{
    [Key]
    public int Id { get; set; }
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
}
