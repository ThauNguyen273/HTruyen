using Core.DTOs.Accounts;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class AccountMapper
{
    public static partial AccountShort ToShortForm(Account source);
    public static Account ToEntity(RegisterAccount source)
    {
        var account = new Account
        {
            Name = source.Name,
            Email = source.Email,
            Password = source.Password,
            Role = source.Role
        };
        return account;
    }
}
