using Core.Common.Class;
using Core.Entities.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Image : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string MediaType { get; set; } = string.Empty;
        public byte[]? Data { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? UserId { get; set; }
        public UserInfo? User { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? AuthorId { get; set; }
        public AuthorInfo? Author { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? NovelId { get; set; }
        public AuthorInfo? Novel { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? ChapterId { get; set; }
        public AuthorInfo? Chapter { get; set; }
    }
}
