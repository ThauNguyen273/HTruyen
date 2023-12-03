using Core.Entities;

namespace Core.DTOs.Users;
public record struct UserCreate
{
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string WalletId { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public byte[]? Avatar { get; set; }
    public GenderType? Gender { get; set; }
    public bool IsVip { get; set; }
    public bool IsAuthor { get; set; }
    public bool IsAdmin { get; set; }
}

