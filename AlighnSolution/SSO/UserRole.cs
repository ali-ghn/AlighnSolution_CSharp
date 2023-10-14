using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;
using AlighnSolution.Database;
using MongoDB.Bson.Serialization.Attributes;

namespace AlighnSolution.SSO;

public class UserRole : MongoRole<string> 
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.String)]
    public string UserRoleId {get; set;}
    public string Name {get; set;}
    [Attributes.DateTimeTimestamp]
    public DateTime CreatedAt {get; set;}
    [Attributes.DateTimeTimestamp]
    public DateTime UpdatedAt {get; set;}
    [Attributes.Activation]
    public bool IsActive {get; set;}
}