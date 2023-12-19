using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;

public interface IUserFavoriteRepository : IRepository<UserFavorite>
{
    Task<List<UserFavorite>> SearchAsync(
        string userNameOrNovelName,
        PaginationParameters pagination,
        bool isDescending);
}
