using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;
public class WalletRepository : Repository<Wallet>, IWalletRepository
{
    public WalletRepository(Database database) : base(database)
    {
    }

    public async Task<List<Wallet>> SearchAsync(
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<Wallet>().AsQueryable();


        if (isDescending)
        {
            query = query.OrderByDescending(p => p.DateCreated);
        }
        else
        {
            query = query.OrderBy(p => p.DateCreated);
        }

        var categories = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return categories;
    }
}
