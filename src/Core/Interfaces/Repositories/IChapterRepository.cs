using Core.Common.Enums;
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

    Task<IEnumerable<Chapter>> GetChapterByNovelSAndtatusAsync(
        string novelId,
        ChapterStatus? chapterStatus,
        PaginationParameters pagination);

    Task<IEnumerable<Chapter>> GetChapterByNovelIdAsync(
        string novelId,
        PaginationParameters pagination);

    Task<Chapter> GetChapterByStatusAsync(
        string chapterId,
        ChapterStatus chapterStatus);

    Task<uint> GetCountByNovelAsync(
        string novelId,
        ChapterStatus chapterStatus);
}
