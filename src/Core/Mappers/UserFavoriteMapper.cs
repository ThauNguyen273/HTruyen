using Core.DTOs.Users;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class UserFavoriteMapper
{
    public static partial UserFavoriteShort ToShortForm(UserFavorite source);
    public static partial UserFavorite ToEntity(UserFavoriteCreate source);
}