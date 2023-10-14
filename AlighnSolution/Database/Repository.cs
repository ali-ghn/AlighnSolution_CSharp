using MongoDB.Driver;

namespace AlighnSolution.Database;



/// <summary>
/// IRepository will provide a blueprint for all the repositories which are compatible with mongodb structure.
/// </summary>
/// <typeparam name="T">Is a generic type for each repository which it wants to work with</typeparam>
public interface IGenericRepository<T>
{
    public Task<T> Save(T databaseObject);
    public Task<List<T>> SaveList(List<T> databaseObjects);
    public Task<T> Load(FilterDefinition<T> filter, FindOptions<T, T> findOptions);
    public Task<List<T>> LoadList(FilterDefinition<T> filter, FindOptions<T, T> findOptions);
    public Task<T> Remove(FilterDefinition<T> filter);
}

public class GenericGenericRepository<T> : IGenericRepository<T>
{
    private IMongoCollection<T> _collection;
    public GenericGenericRepository(IMongoClient mongoClient, string databaseName, string collectionName)
    {
        _collection = mongoClient.GetDatabase(databaseName).GetCollection<T>(collectionName);
    }
    public async Task<T> Save(T databaseObject)
    {
        await _collection.InsertOneAsync(databaseObject);
        return databaseObject;
    }

    public async Task<List<T>> SaveList(List<T> databaseObjects)
    {
        await _collection.InsertManyAsync(databaseObjects);
        return databaseObjects;
    }

    public async Task<T> Load(FilterDefinition<T> filter, FindOptions<T, T> findOptions)
    {
        var databaseObject = await (await _collection.FindAsync(filter, findOptions)).SingleAsync();
        return databaseObject;
    }

    public async Task<List<T>> LoadList(FilterDefinition<T> filter, FindOptions<T, T> findOptions)
    {
        var databaseObjects = await (await _collection.FindAsync(filter, findOptions)).ToListAsync();
        return databaseObjects;
    }

    public async Task<T> Remove(FilterDefinition<T> filter)
    {
        return await _collection.FindOneAndDeleteAsync(filter);
    }
}