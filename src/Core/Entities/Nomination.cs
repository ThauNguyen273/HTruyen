using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;
using Core.Common.Enums;
using Core.Common.Class;

namespace Core.Entities
{
    public class Nomination : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public EvaluateType? Rating { get; set; }
        public required string Content { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public required string UserId { get; set; }
        public UserInfo? User { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public required string NovelId { get; set; }
        public NovelInfo? Novel { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateCreated { get; set; }
    }
}
