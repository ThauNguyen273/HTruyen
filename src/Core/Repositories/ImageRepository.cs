using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Repositories.Bases;
using Core.Repositories.Parameters;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Repositories;

public class ImageRepository : Repository<Image>, IImageRepository
{
    public ImageRepository(Database database) : base(database)
    {
    }

    public async Task<List<Image>> SearchAsync(
        string mediaType,
        PaginationParameters pagination,
        bool isDescending)
    {
        var query = Database.Collection<Image>().AsQueryable();

        if (!string.IsNullOrWhiteSpace(mediaType))
        {
            query = query.Where(x => x.MediaType.Contains(mediaType));
        }

        if (isDescending)
        {
            query = query.OrderByDescending(p => p.MediaType);
        }
        else
        {
            query = query.OrderBy(p => p.MediaType);
        }

        var images = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ToListAsync();

        return images;
    }
}
