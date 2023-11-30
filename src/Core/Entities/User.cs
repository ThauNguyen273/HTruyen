using Core.Entities.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities
{
    public class User : IEntity
    {
        public enum GenderType { Male, Female, LGBT }
        public class UserWallet
        {
            public required string WalletId { get; set; }
            public double Balance  { get; set; }
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required string FullName { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public byte[]? Avatar { get; set; }
        public GenderType? Gender { get; set; }
        public bool IsVip { get; set; }
        public required UserWallet Wallet { get; set; }
        public bool IsAuthor { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
