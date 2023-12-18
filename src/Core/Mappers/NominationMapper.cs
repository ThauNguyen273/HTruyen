using Core.DTOs.Nominations;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class NominationMapper
{
    public static partial NominationShort ToShortForm(Nomination source);
    public static partial Nomination ToEntity(NominationCreate source);
}