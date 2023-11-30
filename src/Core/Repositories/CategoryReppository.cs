
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;
public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(Database database) : base(database)
    {
    }

    public async Task<List<Category>> SearchAsync(
        string name,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<Category>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            query = query.Where(x => x.Name.Contains(name));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.Name);
        }
        else
        {
            query = query.OrderBy(p => p.Name);
        }

        var categories = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return categories;
    }
}
