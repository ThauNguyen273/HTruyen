using Core.Entities.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities;
public class Image : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string MediaType { get; set; } = string.Empty;
    public byte[]? Data { get; set; }
    public string? UserId { get; set; }
    public string? AuthorId { get; set; }
    public string? NovelId { get; set; }
    public string? ChapterId { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}
