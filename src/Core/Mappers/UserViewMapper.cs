using Core.DTOs.Users;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class UserViewMapper
{
    public static partial UserViewShort ToShortForm(UserView source);
    public static partial UserView ToEntity(UserViewCreateUpdate source);
    public static partial void ToEntity(UserViewCreateUpdate source, UserView target);
}