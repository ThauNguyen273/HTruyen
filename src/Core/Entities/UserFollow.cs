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
    public required string UserId { get; set; }
    public UserInfo? User { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public required string NovelId { get; set; }
    public NovelInfo? Novel { get; set; }
}
