using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;
using Core.DTOs.Users;
using Core.Entities;
using Core.Repositories;
using Core.DTOs.Chapters;
using Core.Common.Class;

namespace Core.Services;

public class UserViewService
{
    private readonly IUserViewRepository _userViewRepository;
    private readonly IUserRepository _userRepository;
    private readonly INovelRepository _novelRepository;
    private readonly IChapterRepository _chapterRepository;

    public UserViewService(
        IUserViewRepository userViewRepository,
        IUserRepository userRepository,
        INovelRepository novelRepository,
        IChapterRepository chapterRepository)
    {
        _userViewRepository = userViewRepository;
        _userRepository = userRepository;
        _novelRepository = novelRepository;
        _chapterRepository = chapterRepository;
    }

    public async Task<IEnumerable<UserViewShort>> SearchAsync(
        string? userNameOrNovelName = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _userViewRepository.SearchAsync(userNameOrNovelName ?? string.Empty, pagination, isDescending);

        return entities.Select(UserViewMapper.ToShortForm);
    }

    public async Task<IEnumerable<UserView>> GetViewsByNovelId(string novelId)
    {
        return await _userViewRepository.GetByFieldAsync(v => v.NovelId == novelId);
    }

    public async Task<UserView?> GetAsync(string id)
    {
        return await _userViewRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(UserViewCreateUpdate create)
    {
        var user = await _userRepository.GetAsync(create.UserId);
        if (user is null)
        {
            throw new KeyNotFoundException();
        }

        var novel = await _novelRepository.GetAsync(create.NovelId);
        if (novel is null)
        {
            throw new KeyNotFoundException();
        }

        var chapter = await _chapterRepository.GetAsync(create.ChapterId);
        if (chapter is null)
        {
            throw new KeyNotFoundException();
        }

        var userInfo = new UserInfo
        {
            UserId = user.Id!,
            UserName = user.Name
        };
        var novelInfo = new NovelInfo
        {
            NovelId = novel.Id!,
            NovelName = novel.Name
        };
        var chapterInfo = new ChapterInfo
        {
            ChapterId = chapter.Id!,
            ChapterName = chapter.Name
        };

        var view = UserViewMapper.ToEntity(create);
        view.User = userInfo;
        view.Novel = novelInfo;
        view.Chapter = chapterInfo;
        await _userViewRepository.CreateAsync(view);

        return view.Id!;
    }

    public async Task ReplaceAsync(string id, UserViewCreateUpdate update)
    {
        var entity = await _userViewRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        var user = await _userRepository.GetAsync(update.UserId);
        if (user is null)
        {
            throw new KeyNotFoundException();
        }

        var novel = await _novelRepository.GetAsync(update.NovelId);
        if (novel is null)
        {
            throw new KeyNotFoundException();
        }

        var chapter = await _chapterRepository.GetAsync(update.ChapterId);
        if (chapter is null)
        {
            throw new KeyNotFoundException();
        }

        var userInfo = new UserInfo
        {
            UserId = user.Id!,
            UserName = user.Name
        };
        var novelInfo = new NovelInfo
        {
            NovelId = novel.Id!,
            NovelName = novel.Name
        };
        var chapterInfo = new ChapterInfo
        {
            ChapterId = chapter.Id!,
            ChapterName = chapter.Name
        };

        UserViewMapper.ToEntity(update, entity);
        entity.User = userInfo;
        entity.Novel = novelInfo;
        entity.Chapter = chapterInfo;
        await _userViewRepository.ReplaceAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _userViewRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }

    public async Task DeleteViewsByNovelIdAsync(string novelId)
    {
        await _userViewRepository.DeleteByFieldAsync(v => v.NovelId == novelId);
    }
}