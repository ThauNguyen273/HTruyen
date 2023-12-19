using System.ComponentModel.DataAnnotations;

namespace Core.Common.Class;
public class AuthorInfo
{
    [Required(ErrorMessage = "AuthorId is required.")]
    public required string AuthorId { get; set; }
    [Required(ErrorMessage = "AuthorName is required.")]
    public required string AuthorName { get; set; }
}