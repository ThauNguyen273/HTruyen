﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;

namespace Core.Entities
{
    public class UserFeedback : IEntity
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
        public required string Subject { get; set; }
        public required string Content { get; set; }
        public bool Status { get; set; }
    }
}
