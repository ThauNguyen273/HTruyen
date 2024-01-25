using Core.DTOs.Novels;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]

public static partial class NovelMapper
{
    public static partial NovelShort ToShortForm(Novel source);
    public static partial Novel ToEntity(NovelCreate source);
    public static partial void ToEntity(NovelUpdate source, Novel target);
    public static partial void ToEntityStatus(NovelUpdateStatus source, Novel target);
}
