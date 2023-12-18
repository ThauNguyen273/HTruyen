using Core.Common.Class;
using Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs.Users;

public record struct UserFeedbackShort
{
    public required string Id { get; set; }
    public required UserInfo User { get; set; }
    public CurrentStatus? Status { get; set; }
    public DateTime DateCreated { get; set; }
}
