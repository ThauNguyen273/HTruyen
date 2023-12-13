using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;
using Core.Common.Class;

namespace Core.Entities
{
    public class Transaction : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required UserInfo UserId { get; set; }
        public required string TransactionType { get; set; }
        public double Amount { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
