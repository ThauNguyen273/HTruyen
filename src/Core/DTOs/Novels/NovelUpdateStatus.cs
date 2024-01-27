using Core.Common.Enums;

namespace Core.DTOs.Novels;

public record struct NovelUpdateStatus
{
    public CurrentStatus? Status { get; set; }
}
