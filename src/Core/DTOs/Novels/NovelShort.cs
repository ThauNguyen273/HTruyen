using Core.Common.Class;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Novels;

public record struct NovelShort
{
    [Required(ErrorMessage = "NovelId is required.")]
    public string Id { get; set; }
    [Required(ErrorMessage = "NovelName is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Author is required.")]
    public AuthorInfo Author { get; set; }
}
