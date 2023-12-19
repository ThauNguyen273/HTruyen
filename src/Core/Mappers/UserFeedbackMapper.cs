using Core.DTOs.Users;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class UserFeedbackMapper
{
    public static partial UserFeedbackShort ToShortForm(UserFeedback source);
    public static partial UserFeedback ToEntity(UserFeedbackCreate source);
}