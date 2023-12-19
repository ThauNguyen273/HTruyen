namespace Core.DTOs.Users;

public record struct UserFollowCreate
{
    public required string UserId { get; set; }
    public required string NovelId { get; set; }
}
