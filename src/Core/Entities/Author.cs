using Core.Common.Class;
using Core.Entities.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities;
public class Author : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRequired]
    public string Email { get; set; } = string.Empty;

    [BsonRequired]
    public string Name { get; set; } = string.Empty;

    public string? AnotherName { get; set; }

    public string? Description { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? RankId { get; set; }

    [BsonIgnoreIfNull]
    public Rank? Rank { get; set; }

    public ushort NovelCreateCount { get; set; }

    public uint ChapterCreateCount { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime? DateUpdated { get; set; }
}
