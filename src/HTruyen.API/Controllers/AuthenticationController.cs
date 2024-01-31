using Core.DTOs.Accounts;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HTruyen.API.Controllers;

[Route("api/")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    #region Service Declaration

    private readonly AccountService _accountService;
    private readonly TokenCacheService _tokenCacheService;
    private readonly JwtService _jwtService;

    public AuthenticationController(
        AccountService accountService,
        TokenCacheService tokenCacheService,
        JwtService jwtService)
    {
        _accountService = accountService;
        _tokenCacheService = tokenCacheService;
        _jwtService = jwtService;
    }

    #endregion

    #region Authentication

    [HttpGet("auth/get-role")]
    public IActionResult GetRole(string token)
    {
        try
        {
            var role = _jwtService.GetRoleFromToken(token);
            return Ok(new { Role = role });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("auth/get-account-role")]
    public IActionResult GetAccountId(string token)
    {
        try
        {
            var accountId = _jwtService.GetAccountIdFromToken(token);
            return Ok(new { AccountId = accountId });
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("auth/register")]
    public async Task<IActionResult> Register([FromBody] RegisterAccount body)
    {
        try
        {
            var accountId = await _accountService.RegisterAsync(body);
            return CreatedAtAction(nameof(GetAccountById), new { id = accountId }, null);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("auth/login")]
    public async Task<IActionResult> Login([FromBody] LoginAccount body)
    {
        try
        {
            var token = await _accountService.LoginAsync(body);
            return Ok(new { Token = token });
        }
        catch (InvalidOperationException)
        {
            return Unauthorized();
        }
    }

    [HttpPost("change-password/{id}")]
    public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordAccount changePassword)
    {
        try
        {
            await _accountService.ChangePasswordAsync(id, changePassword);
            return Ok(new { Message = "Password changed successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpPost("auth/logout")]
    public IActionResult Logout([FromBody] LogoutAccount body)
    {
        try
        {
            var accountId = _jwtService.GetAccountIdFromToken(body.Token);
            var isValid = _jwtService.VerifyToken(body.Token, out accountId);
            if (!isValid)
            {
                return NotFound();
            }
            _tokenCacheService.RemoveToken(accountId);

            return Ok(new { Message = "Logout successful" });
            //return Ok(accountId);
        }
        catch (SecurityTokenException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    #endregion

    #region Account 

    [HttpGet("auth/accounts")]
    public async Task<IEnumerable<AccountShort>> GetAuthorAsync(
        [FromQuery] string? search = null,
        [FromQuery] ushort pageNumber = 1,
        [FromQuery] ushort pageSize = 15,
        [FromQuery] bool isDescending = false)
    {
        return await _accountService.SearchAsync(search, pageNumber, pageSize, isDescending);
    }

    [HttpGet("auth/account/{id}")]
    public async Task<ActionResult<Account>> GetAccountById(string id)
    {
        var account = await _accountService.GetAsync(id);
        if(account is null) 
        {
            return NotFound();
        }

        return Ok(account);
    }

    [HttpDelete("auth/delete-account/{id}")]
    public async Task<IActionResult> DeleteAccountAsync(string id)
    {
        try
        {
            await _accountService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    #endregion
}
