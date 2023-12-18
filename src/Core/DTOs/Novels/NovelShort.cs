using Core.Common.Class;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Novels;

public record struct NovelShort
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required AuthorInfo Author { get; set; }
}
