using Core.Common.Enums;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;
public class ChapterRepository : Repository<Chapter>, IChapterRepository
{
    public ChapterRepository(Database database) : base(database)
    {
    }

    public async Task<List<Chapter>> SearchAsync(
        string name,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<Chapter>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.Name);
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

        var chapters = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return chapters;
    }

    public async Task<IEnumerable<Chapter>> GetChapterByNovelIdAsync(
        string novelId, 
        PaginationParameters pagination)
    {
        var filter = Builders<Chapter>.Filter.Eq(x => x.NovelId, novelId);

        var chapters = await Database.Collection<Chapter>()
            .Find(filter)
            .SortByDescending(x => x.DateUpdated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return chapters;
    }

    public async Task<IEnumerable<Chapter>> GetChapterByStatusAsync(
        string novelId, 
        ChapterStatus? chapterStatus,
        PaginationParameters pagination)
    {
        var filterBuilder = Builders<Chapter>.Filter;
        var filters = new List<FilterDefinition<Chapter>>();

        if (!string.IsNullOrEmpty(novelId))
        {
            filters.Add(filterBuilder.Eq(x => x.NovelId, novelId));
        }

        if (chapterStatus != null)
        {
            filters.Add(filterBuilder.Eq(x => x.ChapterStatus, chapterStatus));
        }

        var combineFilter = filterBuilder.And(filters);

        var chapters = await Database.Collection<Chapter>()
            .Find(combineFilter)
            .SortByDescending(x => x.DateUpdated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return chapters;
    }

    public async Task<uint> GetCountByNovelAsync(
        string novelId,
        ChapterStatus chapterStatus)
    {
        var filterBuilder = Builders<Chapter>.Filter;
        var novelFilter = filterBuilder.Eq(x => x.NovelId, novelId);
        var statusFilter = filterBuilder.Eq(x => x.ChapterStatus, chapterStatus);

        var filter = novelFilter & statusFilter;

        var count = await Database.Collection<Chapter>()
            .CountDocumentsAsync(filter);

        return Convert.ToUInt32(count);
    }
}
