using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;

public class UserFavoriteRepository : Repository<UserFavorite>, IUserFavoriteRepository
{
    public UserFavoriteRepository(Database database) : base(database)
    {
    }

    public async Task<List<UserFavorite>> SearchAsync(
        string userNameOrNovelName,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<UserFavorite>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(userNameOrNovelName))
        {
            query = query.Where(x => x.User.UserName.Contains(userNameOrNovelName) || x.Novel.NovelName.Contains(userNameOrNovelName));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.User.UserName);
        }
        else
        {
            query = query.OrderBy(p => p.User.UserName);
        }

        var favorites = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return favorites;
    }
}
