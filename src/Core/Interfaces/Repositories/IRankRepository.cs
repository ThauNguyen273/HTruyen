using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;
public interface IRankRepository : IRepository<Rank>
{
    Task<List<Rank>> SearchAsync(
        string name,
        PaginationParameters pagination,
        bool isDescending);
}
