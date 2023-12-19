using Microsoft.AspNetCore.Http;
using Core.Common.Enums;
using Core.Entities;
using System.Web;

namespace Core.DTOs.Users;
public record struct UserCreateUpdate
{
    public required string Email { get; set; }
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? Description { get; set; }
    public GenderType? Gender { get; set; }

}

