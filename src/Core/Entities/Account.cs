using Core.Entities.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Common.Enums;
using Core.Common.Class;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class Account : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRequired]
    public string Name { get; set; } = string.Empty;

    [BsonRequired]
    public string Password { get; set; } = string.Empty;

    [BsonRequired]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public RoleType? Role { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? WalletId { get; set; }
    public WalletInfo? Wallet { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UserId { get; set; }
    public UserInfo? User { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? AuthorId { get; set; }
    public AuthorInfo? Author { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateUpdated { get; set; }
}

