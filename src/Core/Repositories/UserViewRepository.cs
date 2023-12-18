using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;

public class UserViewRepository : Repository<UserView>, IUserViewRepository
{
    public UserViewRepository(Database database) : base(database)
    {
    }

    public async Task<List<UserView>> SearchAsync(
        string userNameOrNovelName,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<UserView>().AsQueryable();

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

        var views = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return views;
    }
}
