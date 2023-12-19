using System.ComponentModel.DataAnnotations;

namespace Core.Common.Class;
public class CategoryInfo
{
    [Required(ErrorMessage = "CategoryId is required.")]
    public required string CategoryId { get; set; }
    [Required(ErrorMessage = "CategoryName is required.")]
    public required string CategoryName { get; set; }
}
