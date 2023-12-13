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
        public required UserInfo User { get; set; }
        public required NovelInfo Novel { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
