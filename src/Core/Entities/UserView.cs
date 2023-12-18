﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Core.Entities.Interfaces;
using Core.Common.Class;

namespace Core.Entities;

public class UserView : IEntity
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public required string UserId { get; set; }
    public UserInfo? User { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public required string NovelId { get; set; }
    public  NovelInfo? Novel { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public required string ChapterId { get; set; }
    public  ChapterInfo? Chapter { get; set; }
}
