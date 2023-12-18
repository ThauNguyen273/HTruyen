using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;
public class NovelRepository : Repository<Novel>, INovelRepository
{
    public NovelRepository(Database database) : base(database)
    {
    }

    public async Task<List<Novel>> SearchAsync(
        string nameOrAuthorname,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<Novel>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(nameOrAuthorname))
        {
            query = query.Where(x => x.Name.Contains(nameOrAuthorname) || x.Author!.AuthorName.Contains(nameOrAuthorname));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.Name);
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

        var novels = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return novels;
    }

}
