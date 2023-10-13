using MongoDB.Bson.Serialization.Attributes;

namespace AlighnSolution.Database;

public class DatabaseObject
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }

    public void InitializeDatabaseObject<T>(T databaseObject, Dictionary<Attribute, object> bindObjects) 
    {
        foreach (var keyPair in bindObjects)
        {
                        
        }
    }
    
}

