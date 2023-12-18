using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Chapters;

public record struct ChapterUpdate
{
    public required string Name { get; set; }
    public required string Content { get; set; }
    public bool IsVip { get; set; }
    public double ChapterPrice { get; set; }
    public DateTime DateUpdated { get; set; }
}
