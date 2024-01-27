namespace Core.DTOs.Accounts;

public record struct AccountShort
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }

}
