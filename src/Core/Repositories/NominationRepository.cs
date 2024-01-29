using Core.Common.Enums;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;

public class NominationRepository : Repository<Nomination>, INominationRepository
{
    public NominationRepository(Database database) : base(database)
    {
    }

    public async Task<List<Nomination>> SearchAsync(
        string userName,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<Nomination>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(userName))
        {
            query = query.Where(x => x.User!.UserName.Contains(userName));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.User!.UserName);
        }
        else
        {
            query = query.OrderBy(p => p.User!.UserName);
        }

        var nominations = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return nominations;
    }

    public async Task<IEnumerable<Nomination>> GetNominationByNovelIdAsync(
        string novelId,
        PaginationParameters pagination)
    {
        var filter = Builders<Nomination>.Filter.Eq(x => x.NovelId, novelId);

        var nominations = await Database.Collection<Nomination>()
            .Find(filter)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return nominations;
    }

    public async Task<uint> GetCountByNovelAsync(string novelId)
    {
        var filterBuilder = Builders<Nomination>.Filter;
        var novelFilter = filterBuilder.Eq(x => x.NovelId, novelId);

        var count = await Database.Collection<Nomination>()
            .CountDocumentsAsync(novelFilter);

        return Convert.ToUInt32(count);
    }
}
