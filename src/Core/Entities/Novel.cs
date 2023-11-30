using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;

namespace Core.Entities
{
    public class Novel : IEntity
    {
        public enum CategoryOfType { Translate, Convert, Creative }
        public enum NovelStatus { Continue, Complete, Drop }
        public class CategoryInfo
        {
            public required string CategoryId { get; set; }
            public required string CategoryName { get; set; }
        }
        public class AuthorInfo
        {
            public required string AuthorId { get; set; }
            public required string AuthorName { get; set;}
        }
        public class ChapterInfo
        {
            public required string ChapterId { get; set; }
            public required string ChapterName { get; set; }
        }
        public class NominationInfo
        {
            public required string NominationId { get; set; }
            public required string NominationRating { get; set; }
            public required string NominationContent { get; set; }
        }
        public class CommentInfo
        {
            public required string CommentId { get; set; }
            public required string CommentContent { get; set;}
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required AuthorInfo Author { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public CategoryOfType? CategoryOT { get; set; }
        public bool IsVip { get; set; } = false;
        public NovelStatus? Status { get; set; } = NovelStatus.Continue;
        public string? Thumbnail { get; set; }
        public int ViewCount { get; set; } = 0;
        public int FollowCount { get; set; } = 0;
        public int FavoriteCount { get; set; } = 0;
        public int CommentCount { get; set; } = 0;
        public required List<ChapterInfo> Chapters { get; set; }
        public required List<NominationInfo> Nominations { get; set; }
        public required List<CommentInfo> Comments { get; set;}
        public DateTime DateCreated { get; set; }
    }
}
