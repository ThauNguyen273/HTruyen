using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;
public interface ICategoryRepository : IRepository<Category>
{
    Task<List<Category>> SearchAsync(
        string name,
        PaginationParameters pagination,
        bool isDescending);
}