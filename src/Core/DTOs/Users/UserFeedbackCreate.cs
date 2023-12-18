using Core.Common.Enums;

namespace Core.DTOs.Users;

public record struct UserFeedbackCreate
{
    public required string UserId { get; set; }
    public required string Subject { get; set; }
    public required string Content { get; set; }
    public CurrentStatus? Status { get; set; }
    public DateTime DateCreated { get; set; }

}
