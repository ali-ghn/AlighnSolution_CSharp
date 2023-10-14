using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AlighnSolution.Database;

public class DatabaseObject
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; }
    [Attributes.DateTimeTimestamp]
    public DateTime CreatedAt { get; set; }
    [Attributes.DateTimeTimestamp]
    public DateTime UpdatedAt { get; set; }
    [Attributes.Activation]
    public bool IsActive { get; set; }

    public void InitializeDatabaseObject<T>(T databaseObject, Dictionary<Attribute, object> bindObjects) 
    {
        foreach (var keyPair in bindObjects)
        {
                        
        }
    }
    
}

