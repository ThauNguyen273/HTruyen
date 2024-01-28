using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;
using Core.Common.Class;
using Core.Common.Enums;

namespace Core.Entities;

public class Chapter : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRequired]
    public string Name { get; set; } = string.Empty;

    [BsonRequired]
    public string Content { get; set; } = string.Empty;

    public bool IsVip { get; set; }

    public double ChapterPrice { get; set; } = 0;

    [BsonRepresentation(BsonType.ObjectId)]
    public string NovelId { get; set; } = string.Empty;
    public ChapterStatus ChapterStatus { get; set; } = ChapterStatus.Draft;

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateUpdated { get; set; }
}
