using Core.DTOs.Payments;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class WalletMapper
{
    public static partial WalletShort ToShortForm(Wallet source);
    public static partial Wallet ToEntity(WalletCreateUpdate source);
    public static partial void ToEntity(WalletCreateUpdate source, Wallet target);
}

