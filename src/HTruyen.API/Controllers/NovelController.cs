using Core.Common.Enums;
using Core.DTOs.Categories;
using Core.DTOs.Chapters;
using Core.DTOs.Comments;
using Core.DTOs.Nominations;
using Core.DTOs.Novels;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HTruyen.API.Controllers;

[Route("api/")]
[ApiController]
public class NovelController : ControllerBase
{
    private readonly NovelService _novelService;
    private readonly ChapterService _chapterService;
    private readonly CategoryService _categoryService;
    private readonly NominationService _nominationService;
    private readonly CommentService _commentService;
    private readonly UserViewService _userViewService;
    private readonly UserFollowService _userFollowService;
    private readonly UserFavoriteService _userFavoriteService;

    public NovelController(
        NovelService novelService, 
        ChapterService chapterService, 
        CategoryService categoryService,
        NominationService nominationService,
        CommentService commentService,
        UserViewService userViewService,
        UserFollowService userFollowService,
        UserFavoriteService userFavoriteService)
    {
        _novelService = novelService;
        _chapterService = chapterService;
        _categoryService = categoryService;
        _nominationService = nominationService;
        _commentService = commentService;
        _userViewService = userViewService;
        _userFollowService = userFollowService;
        _userFavoriteService = userFavoriteService;
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

    [HttpGet("novel/search")]
    public async Task<IEnumerable<Novel>> SearchAsync(
        [FromQuery] string? name = null,
        [FromQuery] string? categoryId = null,
        [FromQuery] CategoryOfType? categoryOfType = null,
        [FromQuery] NovelStatusType? novelStatusType = null,
        [FromQuery] CurrentStatus status = CurrentStatus.Approved,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15)
    {
        return await _novelService.SearchByManyAsync(
            name,
            categoryId,
            categoryOfType,
            novelStatusType,
            status,
            pageNumber, 
            pageSize);
    }

    [HttpGet("novel/search-status")]
    public async Task<IEnumerable<Novel>> GetNovelByStatus(
        [FromQuery] CurrentStatus status = CurrentStatus.Awaiting_Approval,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15)
    {
        return await _novelService.GetNovelByStatus(
            status,
            pageNumber,
            pageSize);
    }

    [HttpGet("novel/search-categoryOT")]
    public async Task<IEnumerable<Novel>> GetNovelByCategoryOTAsync(
        [FromQuery] CategoryOfType categoryOfType,
        [FromQuery] CurrentStatus status,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15)
    {
        return await _novelService.GetNovelByCategoryOTAsync(
            categoryOfType,
            status,
            pageNumber,
            pageSize);
    }

    [HttpGet("novel/search-category")]
    public async Task<IEnumerable<Novel>> GetNovelByCategoryAsync(
        [FromQuery] CategoryOfType categoryOfType,
        [FromQuery] string categoryId,
        [FromQuery] CurrentStatus status,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15)
    {
        return await _novelService.GetNovelByCategoryAsync(
            categoryOfType,
            categoryId,
            status,
            pageNumber,
            pageSize);
    }

    [HttpGet("novel/search-new-update")]
    public async Task<IEnumerable<Novel>> GetNovelByTimeAsync(
        [FromQuery] CurrentStatus status,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15)
    {
        return await _novelService.GetNovelByTimeAsync(status, pageNumber, pageSize);
    }

    [HttpGet("novel/count-category")]
    public async Task<uint> GetCountByCategory(
        [FromQuery] CategoryOfType categoryOfType,
        [FromQuery] string categoryId,
        [FromQuery] CurrentStatus status = CurrentStatus.Approved)
    {
        return await _novelService.GetCountByCategoryAsync(categoryOfType, categoryId, status);
    }

    [HttpGet("novel/count-all")]
    public async Task<uint> GetAllCountNovelAsync()
    {
        return await _novelService.GetAllCountAsync();
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

    [HttpGet("novel/chapters/{novelId}")]
    public async Task<ActionResult<IEnumerable<Chapter>>> GetChaptersByNovelId(string novelId)
    {
        try
        {
            var chapters = await _chapterService.GetChaptersByNovelId(novelId);

            if (chapters is null || !chapters.Any())
            {
                return NotFound();
            }

            return Ok(chapters);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("novel/comments/{novelId}")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsByNovelId(string novelId)
    {
        try
        {
            var comments = await _commentService.GetCommentsByNovelId(novelId);

            if (comments is null || !comments.Any())
            {
                return NotFound();
            }

            return Ok(comments);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
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

    [HttpPut("novel/censor-novel")]
    public async Task<IActionResult> CensorNovel(string id, [FromBody] NovelUpdateStatus body)
    {
        try
        {
            await _novelService.CensorNovel(id, body);
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

    [HttpDelete("novel/delete-chapters/{novelId}")]
    public async Task<IActionResult> DeleteChaptersByNovelIdAsync(string novelId)
    {
        try
        {
            await _chapterService.DeleteChaptersByNovelIdAsync(novelId);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return NoContent();
    }

    [HttpDelete("novel/delete-comments/{novelId}")]
    public async Task<IActionResult> DeleteCommentsByNovelIdAsync(string novelId)
    {
        try
        {
            await _commentService.DeleteCommentsByNovelIdAsync(novelId);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
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

    [HttpGet("categories-all")]
    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        var categories = await _categoryService.GetAllAsync();
        return categories;
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

    #region Nomination

    [HttpGet("nominations")]
    public async Task<IEnumerable<NominationShort>> GetNominationAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _nominationService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("nomination/{id}")]
    public async Task<ActionResult<Chapter?>> GetNominationById(string id)
    {
        var nomination = await _nominationService.GetAsync(id);
        if (nomination is null)
        {
            return NotFound();
        }

        return Ok(nomination);
    }

    [HttpPost("create-nomination")]
    public async Task<IActionResult> CreateNominationAsync([FromBody] NominationCreate body)
    {
        var newId = await _nominationService.CreateAsync(body);

        return CreatedAtAction(nameof(GetChapterById), new { id = newId }, null);
    }

    [HttpDelete("delete-nomination/{id}")]
    public async Task<IActionResult> DeleteNominationAsync(string id)
    {
        try
        {
            await _nominationService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion

    #region Comment

    [HttpGet("comments")]
    public async Task<IEnumerable<CommentShort>> GetCommentAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _commentService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("comment/{id}")]
    public async Task<ActionResult<Comment?>> GetCommentById(string id)
    {
        var comment = await _commentService.GetAsync(id);
        if (comment is null)
        {
            return NotFound();
        }

        return Ok(comment);
    }

    [HttpPost("create-comment")]
    public async Task<IActionResult> CreateCommentAsync([FromBody] CommentCreate body)
    {
        var newId = await _commentService.CreateAsync(body);
        return CreatedAtAction(nameof(GetCommentById), new { id = newId }, null);
    }

    [HttpDelete("delete-comment/{id}")]
    public async Task<IActionResult> DeleteCommentAsync(string id)
    {
        try
        {
            await _commentService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion

    #region View

    [HttpGet("novel/views/{novelId}")]
    public async Task<ActionResult<IEnumerable<UserView>>> GetViewsByNovelId(string novelId)
    {
        try
        {
            var views = await _userViewService.GetViewsByNovelId(novelId);

            if (views is null || !views.Any())
            {
                return NotFound();
            }

            return Ok(views);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("novel/delete-views/{novelId}")]
    public async Task<IActionResult> DeleteViewsByNovelIdAsync(string novelId)
    {
        try
        {
            await _userViewService.DeleteViewsByNovelIdAsync(novelId);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return NoContent();
    }

    #endregion

    #region Follow

    [HttpGet("novel/follows/{novelId}")]
    public async Task<ActionResult<IEnumerable<UserFollow>>> GetFollowsByNovelId(string novelId)
    {
        try
        {
            var chapters = await _userFollowService.GetFollowsByNovelId(novelId);

            if (chapters is null || !chapters.Any())
            {
                return NotFound();
            }

            return Ok(chapters);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("novel/delete-follows/{novelId}")]
    public async Task<IActionResult> DeleteFollowsByNovelIdAsync(string novelId)
    {
        try
        {
            await _userFollowService.DeleteFollowsByNovelIdAsync(novelId);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return NoContent();
    }

    #endregion

    #region Favorite

    [HttpGet("novel/favorites/{novelId}")]
    public async Task<ActionResult<IEnumerable<UserFavorite>>> GetFavoritesByNovelId(string novelId)
    {
        try
        {
            var favorite = await _userFavoriteService.GetFavoritesByNovelId(novelId);

            if (favorite is null || !favorite.Any())
            {
                return NotFound();
            }

            return Ok(favorite);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("novel/delete-favorites/{novelId}")]
    public async Task<IActionResult> DeleteFavoritesByNovelIdAsync(string novelId)
    {
        try
        {
            await _userFavoriteService.DeleteFavoritesByNovelIdAsync(novelId);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }

        return NoContent();
    }

    #endregion
}
