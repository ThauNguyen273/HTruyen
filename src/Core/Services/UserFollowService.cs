using Core.DTOs.Users;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;
using Core.Repositories;

namespace Core.Services;

public class UserFollowService
{
    private readonly IUserFollowRepository _userFollowRepository;
    private readonly IUserRepository _userRepository;
    private readonly INovelRepository _novelRepository;

    public UserFollowService(
        IUserFollowRepository userFollowRepository, 
        IUserRepository userRepository, 
        INovelRepository novelRepository)
    {
        _userFollowRepository = userFollowRepository;
        _userRepository = userRepository;
        _novelRepository = novelRepository;
    }

    public async Task<IEnumerable<UserFollowShort>> SearchAsync(
        string? userNameOrNovelName = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _userFollowRepository.SearchAsync(userNameOrNovelName ?? string.Empty, pagination, isDescending);

        return entities.Select(UserFollowMapper.ToShortForm);
    }

    public async Task<IEnumerable<UserFollow>> GetFollowsByNovelId(string novelId)
    {
        return await _userFollowRepository.GetByFieldAsync(f => f.NovelId == novelId);
    }

    public async Task<UserFollow?> GetAsync(string id)
    {
        return await _userFollowRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(UserFollowCreate create)
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

        var follow = UserFollowMapper.ToEntity(create);
        follow.UserId = user.Id!;
        follow.NovelId = novel.Id!;
        await _userFollowRepository.CreateAsync(follow);

        return follow.Id!;
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _userFollowRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }

    public async Task DeleteFollowsByNovelIdAsync(string novelId)
    {
        await _userFollowRepository.DeleteByFieldAsync(v => v.NovelId == novelId);
    }
}
