using Core.Common.Enums;

namespace Core.DTOs.Nominations;

public record struct NominationCreate
{
    public EvaluateType? Rating { get; set; }
    public required string Content { get; set; }
    public required string UserId { get; set; }
    public required string NovelId { get; set; }
    public DateTime DateCreated { get; set; }
}
