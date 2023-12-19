namespace Core.DTOs.Comments;

public record struct CommentCreate
{
    public required string UserId { get; set; }
    public required string NovelId { get; set; }
    public required string Content { get; set; }
    public DateTime DateCreated { get; set; }
}
