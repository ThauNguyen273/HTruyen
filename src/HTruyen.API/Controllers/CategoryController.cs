using Core.DTOs.Categories;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTruyen.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryServices;

    public CategoryController(CategoryService categoryServices)
    {
        _categoryServices = categoryServices;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryShort>> Get(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _categoryServices.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Get(string id)
    {
        var category = await _categoryServices.GetAsync(id);
        if (category is null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoryCreateUpdate body)
    {
        var newId = await _categoryServices.CreateAsync(body);
        return CreatedAtAction(nameof(Get), new { id = newId }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] CategoryCreateUpdate body)
    {
        try
        {
            await _categoryServices.ReplaceAsync(id, body);
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await _categoryServices.DeleteAsync(id);
        }
        catch (KeyNotFoundException) 
        {
            return NotFound();
        }

        return NoContent() ;
    }
}