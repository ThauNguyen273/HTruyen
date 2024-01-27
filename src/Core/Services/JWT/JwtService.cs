using Amazon.Runtime;
using Core.Common.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class JwtService
{
    private readonly IConfiguration _configuration;
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly double _expiresInHours;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
        _key = _configuration["Jwt:Key"];
        _issuer = _configuration["Jwt:Issuer"];
        _audience = _configuration["Jwt:Audience"];
        _expiresInHours = Convert.ToDouble(_configuration["Jwt:ExpiresInHours"]);

        if (string.IsNullOrEmpty(_key) || string.IsNullOrEmpty(_issuer) || _expiresInHours <= 0)
        {
            throw new ArgumentException("Invalid JWT configuration");
        }
    }

    public string GenerateToken(string accountId, RoleType role, bool rememberMe)
    {
        var keyBytes = Encoding.UTF8.GetBytes(_key);
        var credentials = new SigningCredentials(
          new SymmetricSecurityKey(keyBytes),
          SecurityAlgorithms.HmacSha256
        );

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, accountId),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
            new Claim("role", role.ToString()),
            new Claim("rememberMe", rememberMe.ToString())
        };

        var token = new JwtSecurityToken(
          _issuer,
          _audience,
          claims,
          expires: DateTime.UtcNow.AddHours(_expiresInHours),
          signingCredentials: credentials
        );;

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GetAccountIdFromToken(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentException("Token is null or empty");
        }

        var handler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtToken;

        try
        {
            jwtToken = handler.ReadJwtToken(token);
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Token is invalid");
        }

        var accountIdClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "sub");
        if (accountIdClaim == null)
        {
            throw new InvalidOperationException("Token does not contain an accountId claim");
        }

        return accountIdClaim.Value;
    }

    public string GetRoleFromToken(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentException("Token is null or empty");
        }

        var handler = new JwtSecurityTokenHandler();
        JwtSecurityToken jwtToken;

        try
        {
            jwtToken = handler.ReadJwtToken(token);
        }
        catch (ArgumentException)
        {
            throw new ArgumentException("Token is invalid");
        }

        var roleClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "role");
        if (roleClaim == null)
        {
            throw new InvalidOperationException("Token does not contain a role claim");
        }

        return roleClaim.Value;
    }

    public bool VerifyToken(string token, out string accountId)
    {
        accountId = null;

        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentException("Empty JWT token");
        }

        try
        {
            var keyBytes = Encoding.UTF8.GetBytes(_key);
            var handler = new JwtSecurityTokenHandler();
            var validationParams = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = _issuer,

                ValidateAudience = true,
                ValidAudience = _audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
            };

            var principal = handler.ValidateToken(token, validationParams, out var validatedToken);

            if (principal != null)
            {
                accountId = GetAccountIdFromToken(token);
                return true;
            }
        }
        catch (SecurityTokenValidationException ex)
        {
            Console.WriteLine($"Token validation error: {ex.Message}");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error verifying token: {ex.Message}");
            return false;
        }
        return false;
    }
}
