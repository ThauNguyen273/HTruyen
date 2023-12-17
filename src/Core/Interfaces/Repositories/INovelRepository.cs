using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;
public interface INovelRepository : IRepository<Novel>
{
    Task<List<Novel>> SearchAsync(
    string nameOrAuthorname,
    PaginationParameters pagination,
    bool isDescending);
}
