using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;

public interface IAccountRepository : IRepository<Account>
{
    Task<List<Account>> SearchAsync(
    string emailOrName,
    PaginationParameters pagination,
    bool isDescending);
}
