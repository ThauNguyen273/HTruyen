using System.ComponentModel.DataAnnotations;

namespace Core.Common.Class;
public class ChapterInfo
{
    [Required(ErrorMessage = "ChapterId is required.")]
    public required string ChapterId { get; set; }
    [Required(ErrorMessage = "ChapterName is required.")]
    public required string ChapterName { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
