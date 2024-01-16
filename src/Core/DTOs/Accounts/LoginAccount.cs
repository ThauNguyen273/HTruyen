using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Accounts;

public record struct LoginAccount
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}
