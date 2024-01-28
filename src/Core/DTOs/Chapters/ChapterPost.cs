using Core.Common.Enums;

namespace Core.DTOs.Chapters;

public record struct ChapterPost
{
    public ChapterStatus ChapterStatus { get; set; }
}
