using Core.Common.Class;
using Core.Common.Enums;
using Core.Entities.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;
public class User : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(60)]
    public string Name { get; set; } = string.Empty;
    [StringLength(256)]
    public string? Address { get; set; }
    [StringLength(256)]
    public string? Description { get; set; }
    public GenderType? Gender { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}


