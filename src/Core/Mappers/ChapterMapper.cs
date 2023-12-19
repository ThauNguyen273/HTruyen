using Core.DTOs.Chapters;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class ChapterMapper
{
    public static partial ChapterShort ToShortForm(Chapter source);
    public static partial Chapter ToEntity(ChapterCreate source);
    public static partial void ToEntity(ChapterUpdate source, Chapter target);
}
