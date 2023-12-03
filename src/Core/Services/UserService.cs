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
}
    

