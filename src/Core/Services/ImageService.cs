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

    public async Task CreateImageAccountAsync(ImageCreateUpdate create,IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file provided.No file provided.");
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            var mediaType = FormFileContants.GetMediaType(extension);

            if (string.IsNullOrEmpty(mediaType))
            {
                throw new NotSupportedException("Unsupported media type.");
            }

            var data = await GetByteArrayFromImageAsync(file);

            var image = new Image
            {
                UserId = create.UserId,
                AuthorId = create.AuthorId,
                NovelId = create.NovelId,
                ChapterId = create.ChapterId,
                MediaType = mediaType,
                Data = data,
                DateCreated = DateTime.UtcNow,
            };

            await _imageRepository.CreateAsync(image);
        } catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<Image> GetImageByUserId(string useId)
    {
        return await _imageRepository.GetImageByUserId(useId);
    }

    public async Task<Image> GetImageByAuthorId(string authorId)
    {
        return await _imageRepository.GetImageByAuthorId(authorId);
    }

    public async Task<Image> GetImageByNovelId(string novelId)
    {
        return await _imageRepository.GetImageByNovelId(novelId);
    }

    public async Task<Image> GetImageByChapterId(string chapterId)
    {
        return await _imageRepository.GetImageByChapterId(chapterId);
    }

    public async Task UpdateImageAccountAsync(string id, ImageCreateUpdate update, IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file provided.No file provided.");
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            var mediaType = FormFileContants.GetMediaType(extension);

            if (string.IsNullOrEmpty(mediaType))
            {
                throw new NotSupportedException("Unsupported media type.");
            }

            var data = await GetByteArrayFromImageAsync(file);

            var entity = await _imageRepository.GetAsync(id) ?? throw new KeyNotFoundException();

            var image = new Image
            {
                UserId = update.UserId,
                AuthorId = update.AuthorId,
                NovelId = update.NovelId,
                ChapterId = update.ChapterId,
                MediaType = mediaType,
                Data = data,
                DateUpdated = DateTime.UtcNow,
            };

            await _imageRepository.ReplaceAsync(image);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _imageRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw ex;
        }
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
