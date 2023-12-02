namespace Core.DTOs.Payments;
public record struct WalletShort
{
    public required string Id { get; set; }
    public DateTime DateCreated { get; set; }
}

