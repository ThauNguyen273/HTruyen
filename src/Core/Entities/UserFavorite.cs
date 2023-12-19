using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;
using Core.Common.Class;

namespace Core.Entities;

public class UserFavorite : IEntity
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
