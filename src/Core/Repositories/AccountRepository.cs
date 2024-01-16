using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;

public class AccountRepository : Repository<Account>, IAccountRepository
{
    public AccountRepository(Database database) : base(database)
    {
    }

    public async Task<List<Account>> SearchAsync(
        string emailOrName,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<Account>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(emailOrName))
        {
            query = query.Where(x => x.Name.Contains(emailOrName) || x.Email.Contains(emailOrName));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.Name);
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

        var accounts = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return accounts;
    }
}
