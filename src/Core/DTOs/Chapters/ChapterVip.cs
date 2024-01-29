namespace Core.DTOs.Chapters;

public record struct ChapterVip
{
    public bool IsVip { get; set; }
    public double ChapterPrice { get; set; }
}
