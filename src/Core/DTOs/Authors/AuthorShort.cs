namespace Core.DTOs.Authors;

public record struct AuthorShort
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
}
