using Core.DTOs.Payments;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;

namespace Core.Services;
public class WalletService
{
    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<IEnumerable<WalletShort>> SearchAsync(
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _walletRepository.SearchAsync(pagination, isDescending);

        return entities.Select(WalletMapper.ToShortForm);
    }

    public async Task<Wallet?> GetAsync(string id)
    {
        return await _walletRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(WalletCreateUpdate create)
    {
        var entity = WalletMapper.ToEntity(create);
        entity.DateCreated = DateTime.Now;
        await _walletRepository.CreateAsync(entity);

        return entity.Id!;
    }

    public async Task ReplaceAsync(string id, WalletCreateUpdate update)
    {
        var entity = await _walletRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        WalletMapper.ToEntity(update, entity);
        await _walletRepository.ReplaceAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _walletRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }
}

