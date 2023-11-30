using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;

namespace Core.Entities
{
    public class Transaction : IEntity
    {
        public class UserInfo
        {
            public required string UserId { get; set; }
            public required string UserFullName { get; set; }
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required UserInfo User { get; set; }
        public required string TransactionType { get; set; }
        public double Amount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
