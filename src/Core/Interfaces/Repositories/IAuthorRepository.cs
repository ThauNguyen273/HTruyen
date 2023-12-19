using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;
namespace Core.Interfaces.Repositories;

public interface IAuthorRepository : IRepository<Author>
{
    Task<List<Author>> SearchAsync(
    string emailOrAuthorname,
    PaginationParameters pagination,
    bool isDescending);
}
