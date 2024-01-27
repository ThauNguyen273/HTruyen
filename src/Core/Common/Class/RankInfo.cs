using System.ComponentModel.DataAnnotations;

namespace Core.Common.Class;
public class RankInfo
{
    [Required(ErrorMessage = "RankId is required.")]
    public required string RankId { get; set; }

    [Required(ErrorMessage = "RankName is required.")]
    public required string RankName { get; set; }
}