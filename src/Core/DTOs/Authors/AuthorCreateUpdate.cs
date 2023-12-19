using Core.Common.Class;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Authors;
public record struct AuthorCreateUpdate
{
    public required string Email { get; set; }
    public required string Name { get; set; }
    public string? AnotherName { get; set; }
    public string? Description { get; set; }
    public string? RankId { get; set; }
    public ushort NovelCreateCount { get; set; }
    public uint ChapterCreateCount { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
