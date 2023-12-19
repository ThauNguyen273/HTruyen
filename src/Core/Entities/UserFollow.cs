using Core.Common.Class;
using Core.Entities.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities;

public class UserFollow : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; } = string.Empty;
    public UserInfo? User { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string NovelId { get; set; } = string.Empty;
    public NovelInfo? Novel { get; set; }
}
