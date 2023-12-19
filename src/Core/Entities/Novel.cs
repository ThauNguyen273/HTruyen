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

    [BsonRequired]
    public string Name { get; set; } = string.Empty;

    [BsonRequired]
    public string Description { get; set; } = string.Empty;
    public CategoryOfType? CategoryOT { get; set; }
    public bool IsVip { get; set; }
    public NovelStatusType? Status { get; set; } = NovelStatusType.Continue;

    [BsonRepresentation(BsonType.ObjectId)]
    public string CategoryId { get; set; } = string.Empty;
    public CategoryInfo? Category { get; set; }
    public int ViewCount { get; set; } = 0;
    public int FollowCount { get; set; } = 0;
    public int FavoriteCount { get; set; } = 0;
    public int CommentCount { get; set; } = 0;
    public List<ChapterInfo>? Chapters { get; set; }
    public List<NominationInfo>? Nominations { get; set; }
    public List<CommentInfo>? Comments { get; set;}

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateCreated { get; set; }

    [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
    public DateTime DateUpdated { get; set; }
}
