using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;
using Core.Common.Class;

namespace Core.Entities
{
    public class Comment : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required UserInfo User { get; set; }
        public required NovelInfo Novel { get; set; }
        public required string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
