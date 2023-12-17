using Core.Common.Class;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Authors;
public record struct AuthorCreateUpdate
{
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    public string AnotherName { get; set; }

    public string Description { get; set; }

    [Required(ErrorMessage = "RankId is required.")]
    public string RankId { get; set; }

    [Required(ErrorMessage = "NovelCreateCount is required.")]
    public ushort NovelCreateCount { get; set; }

    [Required(ErrorMessage = "ChapterCreateCount is required.")]
    public uint ChapterCreateCount { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
