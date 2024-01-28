using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;

public interface IUserViewRepository : IRepository<UserView>
{
    Task<List<UserView>> SearchAsync(
        string userNameOrNovelName,
        PaginationParameters pagination,
        bool isDescending);

    Task<uint> GetCountByNovelAsync(string novelId);
}
