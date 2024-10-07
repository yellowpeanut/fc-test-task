using System.ComponentModel.DataAnnotations;

namespace FcTestTask.Domain.Users.ValueObjects;

public class FullName
{
    [MaxLength(32)]
    public string? LastName { get; init; }
    [MaxLength(32)]
    public string? FirstName { get; init; }
    [MaxLength(32)]
    public string? MiddleName { get; init; }
}
