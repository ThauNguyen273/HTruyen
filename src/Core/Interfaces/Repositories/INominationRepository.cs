using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;

public interface INominationRepository : IRepository<Nomination>
{
    Task<List<Nomination>> SearchAsync(
        string userName,
        PaginationParameters pagination,
        bool isDescending);
}
