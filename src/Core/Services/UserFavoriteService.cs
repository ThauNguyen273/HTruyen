using Core.Common.Class;
using Core.DTOs.Users;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories;
using Core.Repositories.Parameters;

namespace Core.Services;

public class UserFavoriteService
{
    private readonly IUserFavoriteRepository _userFavoriteRepository;
    private readonly IUserRepository _userRepository;
    private readonly INovelRepository _novelRepository;

    public UserFavoriteService(
        IUserFavoriteRepository userFavoriteRepository,
        IUserRepository userRepository,
        INovelRepository novelRepository)
    {
        _userFavoriteRepository = userFavoriteRepository;
        _userRepository = userRepository;
        _novelRepository = novelRepository;
    }

    public async Task<IEnumerable<UserFavoriteShort>> SearchAsync(
        string? userNameOrNovelName = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _userFavoriteRepository.SearchAsync(userNameOrNovelName ?? string.Empty, pagination, isDescending);

        return entities.Select(UserFavoriteMapper.ToShortForm);
    }

    public async Task<IEnumerable<UserFavorite>> GetFavoritesByNovelId(string novelId)
    {
        return await _userFavoriteRepository.GetByFieldAsync(f => f.NovelId == novelId);
    }

    public async Task<uint> GetCountByNovelAsync(string novelId)
    {
        return await _userFavoriteRepository.GetCountByNovelAsync(novelId);
    }

    public async Task<uint> GetAllCountAsync()
    {
        return await _userFavoriteRepository.GetAllCountAsync();
    }

    public async Task<UserFavorite?> GetAsync(string id)
    {
        return await _userFavoriteRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(UserFavoriteCreate create)
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

        var favorite = UserFavoriteMapper.ToEntity(create);
        favorite.User = userInfo;
        favorite.Novel = novelInfo;
        await _userFavoriteRepository.CreateAsync(favorite);

        return favorite.Id!;
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _userFavoriteRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }

    public async Task DeleteFavoritesByNovelIdAsync(string novelId)
    {
        await _userFavoriteRepository.DeleteByFieldAsync(f => f.NovelId == novelId);
    }
}
