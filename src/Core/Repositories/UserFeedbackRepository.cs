using Core.Common.Enums;
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
        string nameOrEmail,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<UserFeedback>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(nameOrEmail))
        {
            query = query.Where(x => x.Name.Contains(nameOrEmail));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.Name);
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

        var feedbacks = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return feedbacks;
    }

    public async Task<IEnumerable<UserFeedback>> GetFeedbackByStatusAsync(
        CurrentStatus? status,
        PaginationParameters pagination)
    {
        var filter = Builders<UserFeedback>.Filter.Eq(x => x.Status, status);

        var chapters = await Database.Collection<UserFeedback>()
            .Find(filter)
            .SortByDescending(x => x.DateCreated)
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Limit(pagination.PageSize)
            .ToListAsync();

        return chapters;
    }

}
