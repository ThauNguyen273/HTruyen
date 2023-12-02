using Core.DTOs.AuthorRanks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;

namespace Core.Services;
public class RankService
{
    private readonly IRankRepository _rankRepository;

    public RankService(IRankRepository rankRepository)
    {
        _rankRepository = rankRepository;
    }

    public async Task<IEnumerable<RankShort>> SearchAsync(
        string? name = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _rankRepository.SearchAsync(name ?? string.Empty , pagination, isDescending);

        return entities.Select(RankMapper.ToShortForm);
    }

    public async Task<Rank?> GetAsync(string id)
    {
        return await _rankRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(RankCreateUpdate create)
    {
        var entity = RankMapper.ToEntity(create);
        entity.DateCreated = DateTime.Now;
        entity.DateUpdated = DateTime.Now;
        await _rankRepository.CreateAsync(entity);

        return entity.Id!;
    }

    public async Task ReplaceAsync(string id, RankCreateUpdate update)
    {
        var entity = await _rankRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        RankMapper.ToEntity(update, entity);
        entity.DateUpdated = DateTime.Now;
        await _rankRepository.ReplaceAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _rankRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }
}
