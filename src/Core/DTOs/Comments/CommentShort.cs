using Core.Common.Class;

namespace Core.DTOs.Comments;

public record struct CommentShort
{
    public required string Id { get; set; }
    public required UserInfo User { get; set; }
    public required NovelInfo Novel { get; set; }
    public required string Content { get; set; }
    public DateTime DateCreated { get; set; }
}
