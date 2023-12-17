using Core.DTOs.Categories;
using Core.DTOs.Chapters;
using Core.DTOs.Novels;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HTruyen.API.Controllers;

[Route("api/")]
[ApiController]
public class NovelController : ControllerBase
{
    private readonly NovelService _novelService;
    private readonly ChapterService _chapterService;
    private readonly CategoryService _categoryService;

    public NovelController(
        NovelService novelService, 
        ChapterService chapterService, 
        CategoryService categoryService)
    {
        _novelService = novelService;
        _chapterService = chapterService;
        _categoryService = categoryService;
    }

    #region Novel

    [HttpGet("novels")]
    public async Task<IEnumerable<NovelShort>> GetNovelAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _novelService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("novel/{id}")]
    public async Task<ActionResult<Novel?>> GetNovelById(string id)
    {
        var novel = await _novelService.GetAsync(id);
        if(novel is null)
        {
            return NotFound();
        }

        return Ok(novel);
    }

    [HttpPost("create-novel")]
    public async Task<IActionResult> CreateNovelAsync([FromBody] NovelCreate body)
    {
        var newId = await _novelService.CreateAsync(body);

        return CreatedAtAction(nameof(GetNovelById), new {id =  newId}, null);
    }

    [HttpPut("edit-novel/{id}")]
    public async Task<IActionResult> EditNovelAsync(string id, [FromBody] NovelUpdate body)
    {
        try
        {
            await _novelService.ReplaceAsync(id, body);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return NoContent();
    }

    [HttpDelete("delete-novel/{id}")]
    public async Task<IActionResult> DeleteNovelAsync(string id)
    {
        try
        {
            await _novelService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion

    #region Chapter

    [HttpGet("chapters")]
    public async Task<IEnumerable<ChapterShort>> GetChapterAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _chapterService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("chapter/{id}")]
    public async Task<ActionResult<Chapter?>> GetChapterById(string id)
    {
        var chapter = await _chapterService.GetAsync(id);
        if (chapter is null)
        {
            return NotFound();
        }

        return Ok(chapter);
    }

    [HttpPost("create-chapter")]
    public async Task<IActionResult> CreateChapterAsync([FromBody] ChapterCreate body)
    {
        var newId = await _chapterService.CreateAsync(body);

        return CreatedAtAction(nameof(GetChapterById), new { id = newId }, null);
    }

    [HttpPut("edit-chapter/{id}")]
    public async Task<IActionResult> EditChapterAsync(string id, [FromBody] ChapterUpdate body)
    {
        try
        {
            await _chapterService.ReplaceAsync(id, body);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return NoContent();
    }

    [HttpDelete("delete-chapter/{id}")]
    public async Task<IActionResult> DeleteChapterAsync(string id)
    {
        try
        {
            await _chapterService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion

    #region Category

    [HttpGet("categories")]
    public async Task<IEnumerable<CategoryShort>> GetCategoryAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _categoryService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("category/{id}")]
    public async Task<ActionResult<Category>> GetCategoryById(string id)
    {
        var category = await _categoryService.GetAsync(id);
        if (category is null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost("create-category")]
    public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryCreateUpdate body)
    {
        var newId = await _categoryService.CreateAsync(body);
        return CreatedAtAction(nameof(GetCategoryById), new { id = newId }, null);
    }

    [HttpPut("edit-category/{id}")]
    public async Task<IActionResult> EditCategoryAsync(string id, [FromBody] CategoryCreateUpdate body)
    {
        try
        {
            await _categoryService.ReplaceAsync(id, body);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return NoContent();
    }

    [HttpDelete("delete-category/{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(string id)
    {
        try
        {
            await _categoryService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion
}
