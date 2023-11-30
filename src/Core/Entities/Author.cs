using Core.Entities.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities
{
    public class Author : IEntity
    {
        public class AuthorRank
        {
            public required string AuthorLevelId { get; set; }
            public required string AuthorLevelName { get; set; }
        }
        public class UserInfo
        {
            public required string UserId { get; set; }
            public required string UserFullName { get; set;}
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required string Name { get; set; }
        public required UserInfo User { get; set; }
        public byte[]? Avatar { get; set; }
        public string? AvatarUrl { get; set; }
        public string? AnotherName { get; set; }
        public int YearOfBirth { get; set; }
        public string? Description { get; set; }
        public required AuthorRank Rank { get; set; }
        public ushort NovelCreateCount { get; set; }
        public uint ChapterCreateCount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
