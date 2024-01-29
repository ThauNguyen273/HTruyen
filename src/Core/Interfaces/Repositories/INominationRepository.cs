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

    Task<uint> GetCountByNovelAsync(string novelId);

    Task<IEnumerable<Nomination>> GetNominationByNovelIdAsync(
        string novelId,
        PaginationParameters pagination);
}
