using Core.DTOs.Users;
using Core.Entities;
using Riok.Mapperly.Abstractions;
using MongoDB.Bson;

namespace Core.Mappers;
[Mapper]
public static partial class UserMapper
{
    public static UserShort ToShortForm(User source)
    {
        return new UserShort
        {
            Id = source.Id!,
            Email = source.Email,
            Name = source.Name
        };
    }
    public static partial User ToEntity(UserCreateUpdate source);
    public static partial void ToEntity(UserCreateUpdate source, User target);

}
