using Core.Common.Class;
using Core.Common.Constants;
using Core.DTOs.Users;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;

namespace Core.Services;
public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IImageRepository _imageRepository;

    public UserService(IUserRepository userRepository, IImageRepository imageRepository)
    {
        _userRepository = userRepository;
        _imageRepository = imageRepository;
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
        entity.DateCreated = DateTime.UtcNow;
        entity.DateUpdated = DateTime.UtcNow;
        await _userRepository.CreateAsync(entity);

        #region Created Image

        var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data/Content/default_avatar.jpg");
        var imageDefault = File.ReadAllBytes(imagePath);

        var extension = Path.GetExtension(imagePath);
        var mediaType = FormFileContants.GetMediaType(extension);

        var image = new Image
        {
            MediaType = mediaType,
            Data = imageDefault
        };
        await _imageRepository.CreateAsync(image);

        var imageId = await _imageRepository.GetAsync(image.Id!);
        if (imageId == null)
        {
            throw new KeyNotFoundException();
        }
        var imageInfo = new ImageInfo 
        {
            ImageId = image.Id!,
            ImageMediaType = image.MediaType,
            ImageData = image.Data
        };

        entity.ImageId = imageId.Id;
        entity.Image = imageInfo;
        await _userRepository.UpdateAsync(entity);

        #endregion

        return entity.Id!;
    }

    public async Task ReplaceAsync(string id, UserCreateUpdate update)
    {
        var entity = await _userRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        UserMapper.ToEntity(update, entity);
        entity.DateUpdated = DateTime.UtcNow;
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
    

