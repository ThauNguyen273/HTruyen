using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Chapters;

public record struct ChapterUpdate
{
    public string ChapterNumber { get; set; }
    public required string Name { get; set; }
    public required string Content { get; set; }
    public DateTime DateUpdated { get; set; }
}
