namespace Core.DTOs.Accounts;

public record struct ChangePasswordAccount
{
    public required string OldPassword { get; set; }
    public required string NewPassword { get; set;}
    public required string ConfirmPassword { get; set;}
}
