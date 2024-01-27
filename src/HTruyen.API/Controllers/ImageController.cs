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

    [HttpPost("create-image")]
    public async Task<ActionResult> UploadImage(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            await _imageService.CreateImageAccountAsync(file);

            return Ok("Image uploaded successfully."); // Adjust the response as needed
        }
        catch (Exception ex)
        {
            // Handle exceptions, log, or return an appropriate error response
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}
