using Core.Common.Class;

namespace Core.DTOs.Users;

public record struct UserFollowShort
{
    public required string Id { get; set; }
    public required UserInfo User { get; set; }
    public required NovelInfo Novel { get; set; }
}
