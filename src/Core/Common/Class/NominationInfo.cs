using Core.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Common.Class;
public class NominationInfo
{
    [Required(ErrorMessage = "NominationId is required.")]
    public required string NominationId { get; set; }
    public EvaluateType? NominationRating { get; set; }
}
