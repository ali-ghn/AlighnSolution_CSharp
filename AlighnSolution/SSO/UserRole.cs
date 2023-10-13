using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlighnSolution.SSO;

public class UserRole : MongoRole<string> 
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.String)]
    public string UserRoleId {get; set;}
    public string Name {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public bool IsActive {get; set;}
}