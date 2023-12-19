namespace Core.DTOs.AuthorRanks;
public record struct RankCreateUpdate
{
    public required string Name { get; set; }
    public string? Benefit { get; set; }
}

