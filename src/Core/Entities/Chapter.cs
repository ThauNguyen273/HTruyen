using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;
using Core.Common.Enums;

namespace Core.Entities;

public class Chapter : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string NovelId { get; set; } = string.Empty;

    [BsonRequired]
    public string ChapterNumber { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string MetalTitle { get; set; } = string.Empty;

    [BsonRequired]
    public string Content { get; set; } = string.Empty;

    public bool IsVip { get; set; }

    public double ChapterPrice { get; set; } = 0;
    public ChapterStatus ChapterStatus { get; set; } = ChapterStatus.Draft;

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateUpdated { get; set; }
}
