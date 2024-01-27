using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;

public interface IImageRepository : IRepository<Image>
{
    Task<List<Image>> SearchAsync(
        string mediaType,
        PaginationParameters pagination,
        bool isDescending);
}
