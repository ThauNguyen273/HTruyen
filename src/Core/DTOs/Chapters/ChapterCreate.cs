using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Chapters;

public record struct ChapterCreate
{
    public string ChapterNumber { get; set; }
    public required string Name { get; set; }
    public required string Content { get; set; }
    public required string NovelId { get; set; }
    public DateTime DateCreated { get; set; }
}
