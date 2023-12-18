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
    public required string UserId { get; set; }
    public required UserInfo User { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public required string NovelId { get; set; }
    public required NovelInfo Novel { get; set; }
}
