﻿using Core.DTOs.Chapters;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;
using Core.Repositories;
using Core.Entities;
using Core.Common.Enums;

namespace Core.Services;

public class ChapterService
{
    private readonly IChapterRepository _chapterRepository;
    private readonly INovelRepository _novelRepository;

    public ChapterService(IChapterRepository chapterRepository, INovelRepository novelRepository)
    {
        _chapterRepository = chapterRepository;
        _novelRepository = novelRepository;
    }

    public async Task<IEnumerable<ChapterShort>> SearchAsync(
        string? name = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _chapterRepository.SearchAsync(name ?? string.Empty, pagination, isDescending);

        return entities.Select(ChapterMapper.ToShortForm);
    }

    public async Task<IEnumerable<Chapter>> GetChaptersByNovelIdAsync(
        string novelId,
        ushort pageNumber = 1,
        ushort pageSize = 15)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        return await _chapterRepository.GetChapterByNovelIdAsync(novelId, pagination);
    }

    public async Task<IEnumerable<Chapter>> GetChapterByStatusAsync(
        string novelId,
        ChapterStatus chapterStatus,
        ushort pageNumber = 1,
        ushort pageSize = 15)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        return await _chapterRepository.GetChapterByStatusAsync(novelId, chapterStatus, pagination);
    }

    public async Task<uint> GetCountByNovelAsync(
        string novelId,
        ChapterStatus chapterStatus)
    {
        return await _chapterRepository.GetCountByNovelAsync(novelId, chapterStatus);
    }

    public async Task<uint> GetAllCountAsync()
    {
        return await _chapterRepository.GetAllCountAsync();
    }

    public async Task<Chapter?> GetAsync(string id)
    {
        return await _chapterRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(ChapterCreate create)
    {
        var novel = await _novelRepository.GetAsync(create.NovelId);
        if(novel is null)
        {
            throw new KeyNotFoundException();
        }
        var chapter = ChapterMapper.ToEntity(create);
        chapter.NovelId = novel.Id!;
        chapter.ChapterStatus = ChapterStatus.Draft;
        chapter.DateCreated = DateTime.UtcNow;
        await _chapterRepository.CreateAsync(chapter);

        return chapter.Id!;
    }

    public async Task ReplaceAsync(string id, ChapterUpdate update)
    {
        var entity = await _chapterRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        ChapterMapper.ToEntity(update, entity);
        entity.DateUpdated = DateTime.UtcNow;
        await _chapterRepository.ReplaceAsync(entity); 
    }

    public async Task ReplaceAsync(string id, ChapterPost post)
    {
        var entity = await _chapterRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        ChapterMapper.ToEntityPost(post, entity);
        entity.DateUpdated = DateTime.UtcNow;
        await _chapterRepository.ReplaceAsync(entity);
    }

    public async Task ReplaceAsync(string id, ChapterVip vip)
    {
        var entity = await _chapterRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        ChapterMapper.ToEntityVip(vip, entity);
        entity.DateUpdated = DateTime.UtcNow;
        await _chapterRepository.ReplaceAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _chapterRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }

    public async Task DeleteChaptersByNovelIdAsync(string novelId)
    {
        await _chapterRepository.DeleteByFieldAsync(c => c.NovelId == novelId);
    }
}
