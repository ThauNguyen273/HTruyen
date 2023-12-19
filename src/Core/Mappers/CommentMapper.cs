using Core.DTOs.Comments;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class CommentMapper
{
    public static partial CommentShort ToShortForm(Comment source);
    public static partial Comment ToEntity(CommentCreate source);
}
