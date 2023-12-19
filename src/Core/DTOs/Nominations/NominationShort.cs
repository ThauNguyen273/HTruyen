using Core.Common.Class;
using Core.Common.Enums;

namespace Core.DTOs.Nominations;

public record struct NominationShort
{
    public required string Id { get; set; }
    public EvaluateType? Rating { get; set; }
    public UserInfo User { get; set; }
    public NovelInfo Novel { get; set; }
}
