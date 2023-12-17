using Core.Common.Class;
using Core.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Novels;
public record struct NovelUpdate
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }
    [Required(ErrorMessage = "Status is required.")]
    public NovelStatusType? Status { get; set; }
    public int ViewCount { get; set; }
    public int FollowCount { get; set; }
    public int FavoriteCount { get; set; }
    public int CommentCount { get; set; }
    public List<CategoryInfo>? Categories { get; set; }
    public List<ChapterInfo>? Chapters { get; set; }
    public List<NominationInfo>? Nominations { get; set; }
    public List<CommentInfo>? Comments { get; set; }
    public DateTime DateUpdated { get; set; }
}
