using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;
using Core.DTOs.Nominations;
using Core.Entities;
using Core.Common.Class;

namespace Core.Services;

public class NominationService
{
    private readonly INominationRepository _nominationRepository;
    private readonly IUserRepository _userRepository;
    private readonly INovelRepository _novelRepository;

    public NominationService(
        INominationRepository nominationRepository, 
        IUserRepository userRepository, 
        INovelRepository novelRepository)
    {
        _nominationRepository = nominationRepository;
        _userRepository = userRepository;
        _novelRepository = novelRepository;
    }

    public async Task<IEnumerable<NominationShort>> SearchAsync(
        string? userNameOrNovelName = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _nominationRepository.SearchAsync(userNameOrNovelName ?? string.Empty, pagination, isDescending);

        return entities.Select(NominationMapper.ToShortForm);
    }

    public async Task<IEnumerable<Nomination>> GetNominationsByNovelId(string novelId)
    {
        return await _nominationRepository.GetByFieldAsync(n => n.NovelId == novelId);
    }

    public async Task<IEnumerable<Nomination>> GetNominationByNovelIdAsync(
        string novelId,
        ushort pageNumber = 1,
        ushort pageSize = 15)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        return await _nominationRepository.GetNominationByNovelIdAsync(novelId, pagination);
    }

    public async Task<uint> GetCountByNovelAsync(string novelId)
    {
        return await _nominationRepository.GetCountByNovelAsync(novelId);
    }

    public async Task<uint> GetAllCountAsync()
    {
        return await _nominationRepository.GetAllCountAsync();
    }

    public async Task<List<Nomination>> GetAllAsync()
    {
        return await _nominationRepository.GetAllAsync();
    }

    public async Task<Nomination?> GetAsync(string id)
    {
        return await _nominationRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(NominationCreate create)
    {
        var user = await _userRepository.GetAsync(create.UserId!);
        if (user is null)
        {
            throw new KeyNotFoundException();
        }
        var novel = await _novelRepository.GetAsync(create.NovelId!);
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

        var nomination = NominationMapper.ToEntity(create);
        nomination.User = userInfo;
        nomination.Novel = novelInfo;
        nomination.DateCreated = DateTime.Now;
        await _nominationRepository.CreateAsync(nomination);

        return nomination.Id!;
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _nominationRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }

    public async Task DeleteNominationsByNovelIdAsync(string novelId)
    {
        await _nominationRepository.DeleteByFieldAsync(n => n.NovelId == novelId);
    }
}
