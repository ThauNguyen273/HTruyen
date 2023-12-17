using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Chapters;

public record struct ChapterShort
{
    [Required(ErrorMessage = "ChapterId is required.")]
    public string Id { get; set; }
    [Required(ErrorMessage = "ChapterName is required.")]
    public string Name { get; set; }
}
