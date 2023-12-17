using Core.DTOs.Authors;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;

namespace Core.Services;
public class AuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IRankRepository _rankRepository;

    public AuthorService(IAuthorRepository authorRepository, IRankRepository rankRepository)
    {
        _authorRepository = authorRepository;
        _rankRepository = rankRepository;
    }

    public async Task<IEnumerable<AuthorShort>> SearchAsync(
        string? emailOrAuthorname = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _authorRepository.SearchAsync(emailOrAuthorname ?? string.Empty, pagination, isDescending);

        return entities.Select(AuthorMapper.ToShortForm);
    }

    public async Task<Author?> GetAsync(string id)
    {
        return await _authorRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(AuthorCreateUpdate create)
    {
        var rank = await _rankRepository.GetAsync(create.RankId);
        if(rank is null)
        {
            throw new KeyNotFoundException();
        }
        var author = AuthorMapper.ToEntity(create);
        author.Rank = rank;
        author.DateCreated = DateTime.Now;
        await _authorRepository.CreateAsync(author);

        return author.Id!;
    }

    public async Task ReplaceAsync(string id, AuthorCreateUpdate update)
    {
        var entity = await _authorRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        var rank = await _rankRepository.GetAsync(update.RankId);
        if (rank is null)
        {
            throw new KeyNotFoundException();
        }
        AuthorMapper.ToEntity(update, entity);
        entity.Rank = rank;
        entity.DateUpdated = DateTime.Now;
        await _authorRepository.ReplaceAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _authorRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<Rank>> GetAllRanks()
    {
        return await _rankRepository.GetAllAsync();
    }
}
