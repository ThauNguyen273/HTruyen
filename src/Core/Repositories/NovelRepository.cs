using Core.Common.Enums;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Bson;
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

    public async Task<IEnumerable<Novel>> GetNovelByAuthorIdAsync(
        string authorId,
        PaginationParameters pagination)
    {
        var filter = Builders<Novel>.Filter.Eq(x => x.AuthorId, authorId);

        var novels = await Database.Collection<Novel>()
            .Find(filter)
            .SortByDescending(x => x.DateUpdated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return novels;
    }

    public async Task<IEnumerable<Novel>> GetNovelByStatus(
        CurrentStatus status,
        PaginationParameters pagination)
    {
        var filter = Builders<Novel>.Filter.Eq(x => x.Status, status);

        var novels = await Database.Collection<Novel>()
            .Find(filter)
            .SortByDescending(x => x.DateUpdated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return novels;
    }

    public async Task<IEnumerable<Novel>> GetNovelByCategoryOTAsync(
        CategoryOfType? categoryOfType,
        CurrentStatus status,
        PaginationParameters pagination)
    {
        var filterBuilder = Builders<Novel>.Filter;
        var filters = new List<FilterDefinition<Novel>>();

        if (categoryOfType != null) 
        {
            filters.Add(filterBuilder.Eq(x => x.CategoryOT, categoryOfType));
        }

        if (status != 0)
        {
            filters.Add(filterBuilder.Eq(x => x.Status, status));
        }

        var combineFilter = filterBuilder.And(filters);

        var novels = await Database.Collection<Novel>()
            .Find(combineFilter)
            .SortByDescending(x => x.DateUpdated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return novels;
    }

    public async Task<IEnumerable<Novel>> GetNovelByCategoryAsync(
        CategoryOfType? categoryOfType, 
        string categoryId,
        CurrentStatus status,
        PaginationParameters pagination)
    {
        var filterBuilder = Builders<Novel>.Filter;
        var filters = new List<FilterDefinition<Novel>>();

        if (categoryOfType != null)
        {
            filters.Add(filterBuilder.Eq(x => x.CategoryOT, categoryOfType));
        }

        if (!string.IsNullOrEmpty(categoryId))
        {
            filters.Add(filterBuilder.Eq(x => x.CategoryId, categoryId));
        }

        if (status != 0)
        {
            filters.Add(filterBuilder.Eq(x => x.Status, status));
        }

        var combineFilter = filterBuilder.And(filters);

        var novels = await Database.Collection<Novel>()
            .Find(combineFilter)
            .SortByDescending(x => x.DateUpdated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return novels;

    }

    public async Task<IEnumerable<Novel>> GetNovelByAuthorAsync(
        string authorId,
        CurrentStatus status,
        PaginationParameters pagination)
    {
        var filterBuilder = Builders<Novel>.Filter;
        var filters = new List<FilterDefinition<Novel>>();

        if (!string.IsNullOrEmpty(authorId))
        {
            filters.Add(filterBuilder.Eq(x => x.AuthorId, authorId));
        }

        if (status != 0)
        {
            filters.Add(filterBuilder.Eq(x => x.Status, status));
        }

        var combineFilter = filterBuilder.And(filters);

        var novels = await Database.Collection<Novel>()
            .Find(combineFilter)
            .SortByDescending(x => x.DateUpdated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return novels;
    }

    public async Task<IEnumerable<Novel>> SearchNovelByManyAsync(
        string? name,
        string? categoryId,
        CategoryOfType? categoryOfType,
        NovelStatusType? novelStatusType,
        CurrentStatus? status, 
        PaginationParameters pagination)
    {
        var filterBuilder = Builders<Novel>.Filter;
        var filter = filterBuilder.Empty;

        if (!string.IsNullOrEmpty(name))
        {
            filter &= filterBuilder.Regex(x => x.Name, new BsonRegularExpression(name, "i"));
        }

        if (!string.IsNullOrEmpty(categoryId))
        {
            filter &= filterBuilder.Eq(x => x.CategoryId, categoryId);
        }

        if (categoryOfType.HasValue)
        {
            filter &= filterBuilder.Eq(x => x.CategoryOT, categoryOfType.Value);
        }

        if (novelStatusType.HasValue)
        {
            filter &= filterBuilder.Eq(x => x.NovelST, novelStatusType.Value);
        }

        if (status.HasValue)
        {
            filter &= filterBuilder.Eq(x => x.Status, status.Value);
        }

        var novels = await Database.Collection<Novel>()
            .Find(filter)
            .SortByDescending(x => x.DateUpdated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return novels;
    }

    public async Task<IEnumerable<Novel>> GetNovelByTimeAsync(
        CurrentStatus status,
        PaginationParameters pagination)
    {
        var currentTime = DateTime.UtcNow;

        var timeFrame = TimeSpan.FromDays(1);
        var startTime = currentTime - timeFrame;

        var filterBuilder = Builders<Novel>.Filter;
        var timeFilter = filterBuilder.Gte(x => x.DateUpdated, startTime) & filterBuilder.Lte(x => x.DateUpdated, currentTime);
        var statusFilter = filterBuilder.Eq(x => x.Status, status);

        var filter = timeFilter & statusFilter;

        var novels = await Database.Collection<Novel>()
            .Find(filter)
            .SortByDescending(x => x.DateUpdated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return novels;
    }

    public async Task<uint> GetCountByCategoryAsync(
        CategoryOfType categoryOfType,
        string categoryId,
        CurrentStatus status)
    {
        var filterBuilder = Builders<Novel>.Filter;
        var categoryFilter = filterBuilder.Eq(x => x.CategoryOT, categoryOfType) & filterBuilder.Eq(x => x.CategoryId, categoryId);
        var statusFilter = filterBuilder.Eq(x => x.Status, status);

        var filter = categoryFilter & statusFilter;

        var count = await Database.Collection<Novel>()
            .CountDocumentsAsync(filter);

        return Convert.ToUInt32(count);
    }

}
