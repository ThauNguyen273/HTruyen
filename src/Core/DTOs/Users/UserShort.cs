namespace Core.DTOs.Users;
public record struct UserShort
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
}

