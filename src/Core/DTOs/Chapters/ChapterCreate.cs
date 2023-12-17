using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Chapters;

public record struct ChapterCreate
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; }
    [Required(ErrorMessage = "NovelId is required.")]
    public string NovelId { get; set; }
    public DateTime DateCreated { get; set; }
}
