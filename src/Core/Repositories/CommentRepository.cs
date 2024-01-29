using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;

public class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(Database database) : base(database)
    {
    }

    public async Task<List<Comment>> SearchAsync(
        string userNameOrNovelName,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<Comment>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(userNameOrNovelName))
        {
            query = query.Where(x => x.User!.UserName.Contains(userNameOrNovelName) || x.Novel!.NovelName.Contains(userNameOrNovelName));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.User!.UserName);
        }
        else
        {
            query = query.OrderBy(p => p.User!.UserName);
        }

        var comments = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return comments;
    }

    public async Task<IEnumerable<Comment>> GetCommentByNovelIdAsync(
        string novelId,
        PaginationParameters pagination)
    {
        var filter = Builders<Comment>.Filter.Eq(x => x.NovelId, novelId);

        var comments = await Database.Collection<Comment>()
            .Find(filter)
            .SortByDescending(x => x.DateCreated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return comments;
    }

    public async Task<uint> GetCountByNovelAsync(string novelId)
    {
        var filterBuilder = Builders<Comment>.Filter;
        var novelFilter = filterBuilder.Eq(x => x.NovelId, novelId);

        var count = await Database.Collection<Comment>()
            .CountDocumentsAsync(novelFilter);

        return Convert.ToUInt32(count);
    }
}
