using Core.Entities.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Common.Enums;
using Core.Common.Class;

namespace Core.Entities;
public class Account : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public required string UserName { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public RoleType Role { get; set; } = RoleType.User;
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public UserWallet? Wallet { get; set; }
    public UserInfo? User { get; set; }
    public AuthorInfo? Author { get; set; }
}

