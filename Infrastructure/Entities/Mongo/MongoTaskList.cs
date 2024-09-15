using Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Entities.Mongo;

public class MongoTaskList
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<TaskListItem> Tasks { get; set; } = [];
    public ICollection<string> SharedWithUsers { get; set; } = [];
    public string CreatedByUserId { get; set; } = null!;
    public DateTime CreatedOnUtc { get; set; }
}