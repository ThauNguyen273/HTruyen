using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Chapters;

public record struct ChapterUpdate
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; }
    public bool IsVip { get; set; }
    public double ChapterPrice { get; set; }
    public DateTime DateUpdated { get; set; }
}
