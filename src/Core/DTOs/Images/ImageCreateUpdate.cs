namespace Core.DTOs.Images;

public record struct ImageCreateUpdate
{
    public required string MediaType { get; set; }
    public byte[]? Data { get; set; }
}
