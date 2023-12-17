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

    public NovelService(INovelRepository novelRepository, IAuthorRepository authorRepository)
    {
        _novelRepository = novelRepository;
        _authorRepository = authorRepository;
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
        if(author is null)
        {
            throw new KeyNotFoundException();
        }

        var authorInfo = new AuthorInfo
        {
            AuthorId = author.Id!,
            AuthorName = author.Name
        };

        var novel = NovelMapper.ToEntity(create);
        novel.Author = authorInfo;
        novel.Status = Common.Enums.NovelStatusType.Continue;
        novel.IsVip = false;
        novel.DateCreated = DateTime.Now;
        await _novelRepository.CreateAsync(novel);
        /*
        if(create.Categories != null)
        {
            foreach (var categoryInfo in create.Categories)
            {
                var category = new CategoryInfo
                {
                    CategoryId = categoryInfo.CategoryId,
                    CategoryName = categoryInfo.CategoryName
                };

                novel.Categories ??= new List<CategoryInfo>();
                novel.Categories.Add(category);
            }
        }

        if(create.Chapters != null)
        {
            foreach(var chapterInfo in create.Chapters)
            {
                var chapter = new ChapterInfo
                {
                    ChapterId = chapterInfo.ChapterId,
                    ChapterName = chapterInfo.ChapterName,
                    DateCreated = DateTime.Now
                };

                novel.Chapters ??= new List<ChapterInfo>();
                novel.Chapters.Add(chapter);
            }
        }

        if(create.Nominations != null)
        {
            foreach(var nominationInfo in create.Nominations)
            {
                var nomination = new NominationInfo
                {
                    NominationId = nominationInfo.NominationId,
                    NominationRating = nominationInfo.NominationRating
                };

                novel.Nominations ??= new List<NominationInfo>();
                novel.Nominations.Add(nomination);
            }
        }

        if(create.Comments != null)
        {
            foreach (var commentInfo in create.Comments)
            {
                var comment = new CommentInfo
                {
                    CommentId = commentInfo.CommentId,
                    CommentContent = commentInfo.CommentContent,
                    DateCreated = DateTime.Now
                };
                
                novel.Comments ??= new List<CommentInfo>();
                novel.Comments.Add(comment);
            }
        }

        await _novelRepository.ReplaceAsync(novel.Id!, novel);
        */
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
        novel.Categories = update.Categories;
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
        if(update.Categories != null)
        {
            foreach(var categoryInfo in update.Categories)
            {
                var category = novel.Categories?.FirstOrDefault(c => c.CategoryId == categoryInfo.CategoryId);
                if(category != null)
                {
                    category.CategoryId = categoryInfo.CategoryId;
                    category.CategoryName = categoryInfo.CategoryName;
                }
            }
        }

        if(update.Chapters != null)
        {
            foreach(var  chapterInfo in update.Chapters)
            {
                var chater = novel.Chapters?.FirstOrDefault(c => c.ChapterId == chapterInfo.ChapterId);
                if(chater != null)
                {
                    chater.ChapterId = chapterInfo.ChapterId;
                    chater.ChapterName = chapterInfo.ChapterName;
                    chater.DateUpdated = DateTime.Now;
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
