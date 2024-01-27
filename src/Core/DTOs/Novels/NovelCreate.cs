using Core.Common.Class;
using Core.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Novels;
public record struct NovelCreate
{
    public required string AuthorId { get; set; }
    public required string CategoryId { get; set; }
    public required string Name { get; set; }
    public string? TQName { get; set; }
    public string? TQUrl { get; set; }
    public required string Description { get; set; }
    public CategoryOfType? CategoryOT { get; set; }
    public NovelStatusType? NovelST { get; set; }
    public CurrentStatus? Status { get; set; }
    public DateTime DateCreated { get; set; }
}