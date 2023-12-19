using Core.DTOs.Novels;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;
using Core.Entities;
using Core.Common.Class;
using System.ComponentModel.Design;
using Core.Repositories;

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
        novel.Status = Common.Enums.NovelStatusType.Continue;
        novel.Category = categoryInfo;
        novel.IsVip = false;
        novel.DateCreated = DateTime.Now;
        await _novelRepository.CreateAsync(novel);
        
        return novel.Id!;
    }

    public async Task ReplaceAsync(string id, NovelUpdate update)
    {
        var novel = await _novelRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        
        // Cập nhật các thuộc tính dựa trên update
        novel.Name = update.Name;
        novel.Description = update.Description;
        novel.Status = update.Status;
        novel.ViewCount = update.ViewCount;
        novel.FollowCount = update.FollowCount;
        novel.FavoriteCount = update.FavoriteCount;
        novel.CommentCount = update.CommentCount;
        novel.Chapters = update.Chapters;
        novel.Nominations = update.Nominations;
        novel.Comments = update.Comments;
        novel.DateUpdated = DateTime.Now;

        // Cập nhật các thực thể liên quan
        UpdateRelatedEntities(novel, update);

        // Thay thế tiểu thuyết hiện có
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

    private void UpdateRelatedEntities(Novel novel, NovelUpdate update)
    {
        if(update.Chapters != null)
        {
            foreach(var  chapterInfo in update.Chapters)
            {
                var chater = novel.Chapters?.FirstOrDefault(c => c.ChapterId == chapterInfo.ChapterId);
                if(chater != null)
                {
                    chater.ChapterId = chapterInfo.ChapterId;
                    chater.ChapterName = chapterInfo.ChapterName;
                }
            }
        }

        if(update.Nominations != null)
        {
            foreach(var nominationInfo in update.Nominations)
            {
                var nomination = novel.Nominations?.FirstOrDefault(n => n.NominationId == nominationInfo.NominationId);
                if(nomination != null)
                {
                    nomination.NominationId = nominationInfo.NominationId;
                    nomination.NominationRating = nominationInfo.NominationRating;
                }
            }
        }

        if(update.Comments != null)
        {
            foreach(var commentInfo in update.Comments)
            {
                var comment = novel.Comments?.FirstOrDefault(c => c.CommentId == commentInfo.CommentId);
                if(comment != null)
                {
                    comment.CommentId = commentInfo.CommentId;
                    comment.CommentContent = commentInfo.CommentContent;
                }
            }
        }
    }
}
