using Core.DTOs.Images;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;
using Core.Repositories;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Core.Common.Constants;
using Amazon.Auth.AccessControlPolicy;

namespace Core.Services;

public class ImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<IEnumerable<ImageShort>> SearchAsync(
        string? mediaType,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _imageRepository.SearchAsync(mediaType ?? string.Empty, pagination, isDescending);

        return entities.Select(ImageMapper.ToShortForm);
    }

    public async Task<Image?> GetAsync(string id)
    {
        return await _imageRepository.GetAsync(id);
    }

    public async Task CreateImageAccountAsync(IFormFile file)
    {
        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
        var mediaType = FormFileContants.GetMediaType(extension);

        var data = await GetByteArrayFromImageAsync(file);

        var image = new Image
        {
            MediaType = mediaType,
            Data = data
        };

        await _imageRepository.CreateAsync(image);
    }

    private async Task<byte[]> GetByteArrayFromImageAsync(IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }

}
