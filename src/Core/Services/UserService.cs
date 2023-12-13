using Core.DTOs.Users;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;

namespace Core.Services;
public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserShort>> SearchAsync(
        string? emailOrUsername = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _userRepository.SearchAsync(emailOrUsername ?? string.Empty, pagination, isDescending);

        return entities.Select(UserMapper.ToShortForm);
    }

    public async Task<User?> GetAsync(string id)
    {
        return await _userRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(UserCreateUpdate create)
    {
        var entity = UserMapper.ToEntity(create);
        entity.DateCreated = DateTime.Now;
        entity.DateUpdated = DateTime.Now;
        await _userRepository.CreateAsync(entity);

        return entity.Id!;
    }

    public async Task ReplaceAsync(string id, UserCreateUpdate update)
    {
        var entity = await _userRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        UserMapper.ToEntity(update, entity);
        entity.DateUpdated = DateTime.Now;
        await _userRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _userRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
    }

}
    

