using Core.DTOs.AuthorRanks;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class RankMapper
{
    public static partial RankShort ToShortForm(Rank source);
    public static partial Rank ToEntity(RankCreateUpdate source);
    public static partial void ToEntity(RankCreateUpdate source, Rank target);
}