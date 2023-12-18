using Core.Common.Class;
using Core.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.DTOs.Novels;
public record struct NovelCreate
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string AuthorId { get; set; }
    public CategoryOfType? CategoryOT { get; set; }
    public NovelStatusType? Status { get; set; }
    public required string CategoryId { get; set; }
    public bool IsVip { get; set; }
    public int ViewCount { get; set; }
    public int FollowCount { get; set; }
    public int FavoriteCount { get; set; }
    public int CommentCount { get; set; }
    /*
    public List<ChapterInfo>? Chapters { get; set; }
    public List<NominationInfo>? Nominations { get; set;}
    public List<CommentInfo>? Comments { get; set; }
    */
    public DateTime DateCreated { get; set; }
}