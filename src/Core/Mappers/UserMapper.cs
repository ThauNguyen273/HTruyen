using Core.DTOs.Users;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class UserMapper
{
    public static UserShort ToShortForm(User source)
    {
        var target = new UserShort()
        {
            Id = source.Id!,
            Email = source.Email,
            UserName = source.UserName,
            DateCreated = source.DateCreated
        };

        return target;
    }
}
