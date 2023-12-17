using System.ComponentModel.DataAnnotations;

namespace Core.Common.Class;
public class CommentInfo
{
    [Required(ErrorMessage = "CommentId is required.")]
    public required string CommentId { get; set; }
    [Required(ErrorMessage = "CommentContent is required.")]
    public required string CommentContent { get; set; }
    public DateTime DateCreated { get; set; }
}
