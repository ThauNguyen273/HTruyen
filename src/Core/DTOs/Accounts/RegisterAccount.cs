using Core.Common.Enums;

namespace Core.DTOs.Accounts;

public class RegisterAccount
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public RoleType Role { get; set; }
    public DateTime DateCreated { get; set; }
}
