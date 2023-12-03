using Core.Entities;

namespace Core.DTOs.Users;
public record struct UserUpdate
{
    public required string Password { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public byte[]? Avatar { get; set; }
    public GenderType? Gender { get; set; }
    public bool? IsVip { get; set; }
    public bool? IsAuthor { get; set; }
    public bool? IsAdmin { get; set;}
}


