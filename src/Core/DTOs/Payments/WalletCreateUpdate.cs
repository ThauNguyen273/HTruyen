namespace Core.DTOs.Payments;
public record struct WalletCreateUpdate
{
    public required double Balance { get; set; }
}
