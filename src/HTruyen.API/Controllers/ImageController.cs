using Core.DTOs.Images;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HTruyen.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly ImageService _imageService;

    public ImageController(ImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Image>> GetImage(string id)
    {
        var image = await _imageService.GetAsync(id);

        if (image == null)
            return NotFound();

        return image;
    }

    [HttpGet("image/user/{userId}")]
    public async Task<ActionResult<Image>> GetImageByUserId(string userId)
    {
        var image = await _imageService.GetImageByUserId(userId);
        if (image == null) return NotFound();

        return image;
    }

    [HttpGet("image/author/{authorId}")]
    public async Task<ActionResult<Image>> GetImageByAuthorId(string authorId)
    {
        var image = await _imageService.GetImageByAuthorId(authorId);
        if (image == null) return NotFound();

        return image;
    }

    [HttpGet("image/novel/{novelId}")]
    public async Task<ActionResult<Image>> GetImageByNovelId(string novelId)
    {
        var image = await _imageService.GetImageByNovelId(novelId);
        if (image == null) return NotFound();

        return image;
    }

    [HttpGet("image/chapter/{chapterId}")]
    public async Task<ActionResult<Image>> GetImageByChapterId(string chapterId)
    {
        var image = await _imageService.GetImageByChapterId(chapterId);
        if (image == null) return NotFound();

        return image;
    }

    [HttpPost("create-image")]
    public async Task<ActionResult> UploadImage([FromForm] ImageCreateUpdate body, IFormFile file)
    {
        try
        {
            await _imageService.CreateImageAccountAsync(body, file);
            return Ok("Image created successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPut("change-image/{id}")]
    public async Task<IActionResult> UpdateImage(string id, [FromForm] ImageCreateUpdate imageCreateUpdate, IFormFile file)
    {
        try
        {
            await _imageService.UpdateImageAccountAsync(id, imageCreateUpdate, file);
            return Ok("Image updated successfully.");
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Image not found.");
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"Bad Request: {ex.Message}");
        }
        catch (NotSupportedException ex)
        {
            return BadRequest($"Bad Request: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

}
