namespace Core.DTOs.Users;

public record struct UserViewCreateUpdate
{
    public required string UserId { get; set; }
    public required string NovelId { get; set; }
    public required string ChapterId { get; set; }
}
