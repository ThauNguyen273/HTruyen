using Core.DTOs.Novels;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;
using Core.Entities;
using Core.Common.Class;
using Core.Common.Enums;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Services;
public class NovelService
{
    private readonly INovelRepository _novelRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly ICategoryRepository _categoryRepository;

    public NovelService(
        INovelRepository novelRepository, 
        IAuthorRepository authorRepository, 
        ICategoryRepository categoryRepository)
    {
        _novelRepository = novelRepository;
        _authorRepository = authorRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<NovelShort>> SearchAsync(
        string? nameOrAuthorname = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _novelRepository.SearchAsync(nameOrAuthorname ?? string.Empty, pagination, isDescending);

        return entities.Select(NovelMapper.ToShortForm);
    }

    public async Task<IEnumerable<Novel>> GetNovelByStatus(
        CurrentStatus status,
        ushort pageNumber = 1,
        ushort pageSize = 15)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        return await _novelRepository.GetNovelByStatus(status, pagination);
    }

    public async Task<IEnumerable<Novel>> GetNovelByCategoryOTAsync(
        CategoryOfType categoryOfType,
        CurrentStatus status,
        ushort pageNumber = 1,
        ushort pageSize = 15)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        return await _novelRepository.GetNovelByCategoryOTAsync(categoryOfType, status,pagination);
    }

    public async Task<IEnumerable<Novel>> GetNovelByCategoryAsync(
        CategoryOfType categoryOfType, 
        string categoryId,
        CurrentStatus status,
        ushort pageNumber = 1,
        ushort pageSize = 15)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        return await _novelRepository.GetNovelByCategoryAsync(categoryOfType, categoryId, status, pagination);
    }

    public async Task<IEnumerable<Novel>> SearchByManyAsync(
        string? name,
        string? categoryId,
        CategoryOfType? categoryOfType,
        NovelStatusType? novelStatusType,
        CurrentStatus status,
        ushort pageNumber = 1,
        ushort pageSize = 15)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        return await _novelRepository.SearchNovelByManyAsync(
            name, 
            categoryId, 
            categoryOfType, 
            novelStatusType, 
            status,
            pagination);
    }

    public async Task<IEnumerable<Novel>> GetNovelByTimeAsync(
        CurrentStatus status,
        ushort pageNumber = 1,
        ushort pageSize = 15)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        return await _novelRepository.GetNovelByTimeAsync(status, pagination);
    }

    public async Task<uint> GetCountByCategoryAsync(
        CategoryOfType categoryOfType,
        string categoryId,
        CurrentStatus status = CurrentStatus.Approved)
    {
        return await _novelRepository.GetCountByCategoryAsync(categoryOfType, categoryId, status);
    }

    public async Task<uint> GetAllCountAsync()
    {
        return await _novelRepository.GetAllCountAsync();
    }

    public async Task<Novel?> GetAsync(string id)
    {
        return await _novelRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(NovelCreate create)
    {
        var author = await _authorRepository.GetAsync(create.AuthorId);
        if (author is null)
        {
            throw new KeyNotFoundException();
        }

        var category = await _categoryRepository.GetAsync(create.CategoryId);
        if (category is null)
        {
            throw new KeyNotFoundException();
        }

        var authorInfo = new AuthorInfo
        {
            AuthorId = author.Id!,
            AuthorName = author.Name
        };

        var categoryInfo = new CategoryInfo
        {
            CategoryId = category.Id!,
            CategoryName = category.Name
        };

        var novel = NovelMapper.ToEntity(create);
        novel.Author = authorInfo;
        novel.Category = categoryInfo;
        novel.MetalTitle = ConvertNameToMetalTitle(create.Name);
        novel.NovelST = Common.Enums.NovelStatusType.Continue;
        novel.Status = Common.Enums.CurrentStatus.Awaiting_Approval;
        novel.DateCreated = DateTime.UtcNow;
        await _novelRepository.CreateAsync(novel);
        
        return novel.Id!;
    }

    public async Task ReplaceAsync(string id, NovelUpdate update)
    {
        var novel = await _novelRepository.GetAsync(id) ?? throw new KeyNotFoundException();

        var category = await _categoryRepository.GetAsync(update.CategoryId!) ?? throw new KeyNotFoundException();
        var categoryInfo = new CategoryInfo
        {
            CategoryId = category.Id!,
            CategoryName = category.Name
        };

        NovelMapper.ToEntity(update, novel);
        novel.Category = categoryInfo;
        novel.MetalTitle = ConvertNameToMetalTitle(update.Name);
        novel.DateUpdated = DateTime.UtcNow;
        await _novelRepository.ReplaceAsync(novel);
    }

    public async Task CensorNovel(string id, NovelUpdateStatus status)
    {
        var novel = await _novelRepository.GetAsync(id) ?? throw new KeyNotFoundException();

        NovelMapper.ToEntityStatus(status, novel);
        novel.DateUpdated = DateTime.UtcNow;
        await _novelRepository.ReplaceAsync(novel);
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _novelRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }

    private string ConvertNameToMetalTitle(string name)
    {
        string withoutPunctuation = RemoveSpecialCharacters(RemoveDiacritics(name));
        string metalTitle = withoutPunctuation.Replace(" ", "-").ToLower();

        return metalTitle;
    }

    private string RemoveSpecialCharacters(string text)
    {
        return Regex.Replace(text, "[^a-zA-Z0-9]", "");
    }

    private string RemoveDiacritics(string text)
    {
        // Dùng bảng mã Unicode để loại bỏ dấu thanh
        string normalizedString = text.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char c in normalizedString)
        {
            // Bỏ qua các ký tự dấu thanh
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString();
    }
}
