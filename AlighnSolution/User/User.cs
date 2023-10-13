using AlighnSolution.Database;
using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlighnSolution.User;

public class User : MongoUser<string>
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.String)]
    public string UserId { get; set; }
    [Attributes.DateTimeTimestamp]
    public DateTime CreatedAt { get; set; }
    [Attributes.DateTimeTimestamp]
    public DateTime UpdatedAt { get; set; }
    [Attributes.Activation]
    public bool IsActive { get; set; }
}