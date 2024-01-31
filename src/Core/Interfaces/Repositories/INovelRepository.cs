using Core.Common.Enums;
using Core.Entities;
using Core.Interfaces.Repositories.Bases;
using Core.Repositories.Parameters;

namespace Core.Interfaces.Repositories;
public interface INovelRepository : IRepository<Novel>
{
    Task<List<Novel>> SearchAsync(
    string nameOrAuthorname,
    PaginationParameters pagination,
    bool isDescending);

    Task<IEnumerable<Novel>> GetNovelByAuthorIdAsync(
        string authorId,
        PaginationParameters pagination);

    Task<IEnumerable<Novel>> GetNovelByStatus(
        CurrentStatus status,
        PaginationParameters pagination);

    Task<IEnumerable<Novel>> GetNovelByCategoryOTAsync(
        CategoryOfType? categoryOfType,
        CurrentStatus status,
        PaginationParameters pagination);

    Task<IEnumerable<Novel>> GetNovelByCategoryAsync(
        CategoryOfType? categoryOfType,
        string categoryId,
        CurrentStatus status,
        PaginationParameters pagination);

    Task<IEnumerable<Novel>> GetNovelByAuthorAsync(
        string authorId,
        CurrentStatus status,
        PaginationParameters pagination);

    Task<IEnumerable<Novel>> SearchNovelByManyAsync(
        string? name,
        string? categoryId,
        CategoryOfType? categoryOfType,
        NovelStatusType? novelStatusType,
        CurrentStatus? status,
        PaginationParameters pagination);

    Task<uint> GetCountByCategoryAsync(
        CategoryOfType categoryOfType,
        string categoryId,
        CurrentStatus status);

    Task<IEnumerable<Novel>> GetNovelByTimeAsync(
        CurrentStatus status,
        PaginationParameters pagination);
}
