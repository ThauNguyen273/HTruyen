﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;

namespace Core.Entities
{
    public class Chapter : IEntity
    {
        public class NovelInfo
        {
            public required string NovelId { get; set; }
            public required string NovelName { get; set; }
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public required NovelInfo Novel { get; set; }
        public required string Name { get; set; }
        public required string Content { get; set; }
        public bool IsVip { get; set; } = false;
        public double ChapterPrice { get; set; } = 0;
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
