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

    Task<Image> GetImageByUserId(string userId);

    Task<Image> GetImageByAuthorId(string authorId);

    Task<Image> GetImageByNovelId(string novelId);

    Task<Image> GetImageByChapterId(string chapterId);
}
