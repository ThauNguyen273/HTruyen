using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;
using Core.Common.Enums;
using Core.Common.Class;

namespace Core.Entities;
public class Novel : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string AuthorId { get; set; } = string.Empty;
    public AuthorInfo? Author { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string CategoryId { get; set; } = string.Empty;
    public CategoryInfo? Category { get; set; }

    [BsonRequired]
    public string Name { get; set; } = string.Empty;
    public string MetalTitle { get; set; } = string.Empty;

    [BsonRequired]
    public string Description { get; set; } = string.Empty;
    
    public string? TQName { get; set; }
    public string? TQUrl { get; set; }
    public CategoryOfType? CategoryOT { get; set; }
    public NovelStatusType? NovelST { get; set; } = NovelStatusType.Continue;

    public CurrentStatus? Status { get; set; } = CurrentStatus.Awaiting_Approval;

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateUpdated { get; set; }
}
