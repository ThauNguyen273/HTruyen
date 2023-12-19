using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;
using Core.Common.Class;
using Core.Common.Enums;

namespace Core.Entities;

public class UserFeedback : IEntity
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public required string UserId { get; set; }
    public UserInfo? User { get; set; }
    public required string Subject { get; set; }
    public required string Content { get; set; }
    public CurrentStatus? Status { get; set; } = CurrentStatus.Awaiting_Approval;

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; }
}
