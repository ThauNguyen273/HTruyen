using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;
public interface IChapterRepository : IRepository<Chapter>
{
    Task<List<Chapter>> SearchAsync(
    string name,
    PaginationParameters pagination,
    bool isDescending);
}
