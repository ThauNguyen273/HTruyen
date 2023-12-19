using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(Database database) : base(database)
    {
    }

    public async Task<List<User>> SearchAsync(
        string emailOrUsername,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<User>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(emailOrUsername))
        {
            query = query.Where(x => x.Name.Contains(emailOrUsername) || x.Email.Contains(emailOrUsername));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.Name);
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

        var users = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return users;
    }
}

