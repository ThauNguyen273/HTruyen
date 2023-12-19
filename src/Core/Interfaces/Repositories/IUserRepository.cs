using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;
public interface IUserRepository : IRepository<User>
{
    Task<List<User>> SearchAsync(
        string emailOrUsername,
        PaginationParameters pagination,
        bool isDescending);
}

