using Core.DTOs.Authors;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class AuthorMapper
{
    public static partial AuthorShort ToShortForm(Author source);
    public static partial Author ToEntity(AuthorCreateUpdate source);
    public static partial void ToEntity(AuthorCreateUpdate update, Author target);

}
