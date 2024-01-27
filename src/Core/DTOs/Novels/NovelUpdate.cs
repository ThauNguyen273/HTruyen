using Core.Common.Class;
using Core.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Novels;
public record struct NovelUpdate
{
    public string? CategoryId { get; set; }
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }
    public string? TQName { get; set; }
    public string? TQUrl { get; set; }
    public CategoryOfType? CategoryOT { get; set; }
    public NovelStatusType? NovelST { get; set; }
    public DateTime DateUpdated { get; set; }
}
