using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;
public interface IWalletRepository : IRepository<Wallet>
{
    Task<List<Wallet>> SearchAsync(
        PaginationParameters pagination,
        bool isDescending);
}

