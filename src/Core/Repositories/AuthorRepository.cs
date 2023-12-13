using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;
public  class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(Database database) : base(database)
    {
    }

    public async Task<List<Author>> SearchAsync(
        string emailOrAuthorname,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<Author>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(emailOrAuthorname))
        {
            query = query.Where(x => x.Name.Contains(emailOrAuthorname) || x.Email.Contains(emailOrAuthorname));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.Name);
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

        var authors = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return authors;
    }
}
