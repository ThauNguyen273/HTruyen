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
    public required AuthorInfo Author { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public CategoryOfType? CategoryOT { get; set; }
    public bool IsVip { get; set; } = false;
    public NovelStatusType? Status { get; set; } = NovelStatusType.Continue;
    public string? Thumbnail { get; set; }
    public int ViewCount { get; set; } = 0;
    public int FollowCount { get; set; } = 0;
    public int FavoriteCount { get; set; } = 0;
    public int CommentCount { get; set; } = 0;
    public List<ChapterInfo>? Chapters { get; set; }
    public List<NominationInfo>? Nominations { get; set; }
    public List<CommentInfo>? Comments { get; set;}
    public DateTime DateCreated { get; set; }
}
