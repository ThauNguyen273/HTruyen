using Core.DTOs.Users;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class UserFollowMapper
{
    public static partial UserFollowShort ToShortForm(UserFollow source);
    public static partial UserFollow ToEntity(UserFollowCreate source);
}
