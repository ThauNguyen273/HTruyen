using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;

public interface IUserFollowRepository : IRepository<UserFollow>
{
    Task<List<UserFollow>> SearchAsync(
        string userNameOrNovelName,
        PaginationParameters pagination,
        bool isDescending);
}
