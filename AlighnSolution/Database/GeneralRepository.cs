using MongoDB.Driver;

namespace AlighnSolution.Database;

public class GeneralRepository<T> : IRepository<T>
{
    private IMongoClient mongoClient;
    private IMongoCollection<T> Collection;
    public GeneralRepository(IMongoClient _mongoClient, string databaseName, string collectionName)
    {
        mongoClient = _mongoClient;
        Collection = mongoClient.GetDatabase(databaseName).GetCollection<T>(collectionName);
    }
    public async Task<T> Save(T databaseObject)
    {
        await Collection.InsertOneAsync(databaseObject);
        return databaseObject;
    }

    public async Task<List<T>> SaveList(List<T> databaseObjects)
    {
        await Collection.InsertManyAsync(databaseObjects);
        return databaseObjects;
    }

    public async Task<T> Load(FilterDefinition<T> filter, FindOptions<T, T> findOptions)
    {
        var databaseObject = await (await Collection.FindAsync(filter, findOptions)).SingleAsync();
        return databaseObject;
    }

    public async Task<List<T>> LoadList(FilterDefinition<T> filter, FindOptions<T, T> findOptions)
    {
        var databaseObjects = await (await Collection.FindAsync(filter, findOptions)).ToListAsync();
        return databaseObjects;
    }

    public async Task<T> Remove(FilterDefinition<T> filter)
    {
        return await Collection.FindOneAndDeleteAsync(filter);
    }
}