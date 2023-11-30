using Core.Entities.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities
{
    public class UserFollow : IEntity
    {
        public class UserInfo
        {
            public required string UserId { get; set; }
            public required string UserFullName { get; set; }
        }
        public class NovelInfo
        {
            public required string NovelId { get; set; }
            public required string NovelName { get; set; }
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required UserInfo User { get; set; }
        public required NovelInfo Novel { get; set; }
    }
}
