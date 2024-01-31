using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Chapters;

public record struct ChapterShort
{
    public required string Id { get; set; }
    public string ChapterNunber { get; set; }
    public required string Name { get; set; }
}
