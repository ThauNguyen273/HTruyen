using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;

public class UserFeedbackRepository : Repository<UserFeedback>, IUserFeedbackRepository
{
    public UserFeedbackRepository(Database database) : base(database)
    {
    }

    public async Task<List<UserFeedback>> SearchAsync(
        string userName,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<UserFeedback>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(userName))
        {
            query = query.Where(x => x.User.UserName.Contains(userName));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.User.UserName);
        }
        else
        {
            query = query.OrderBy(p => p.User.UserName);
        }

        var feedbacks = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return feedbacks;
    }
}
