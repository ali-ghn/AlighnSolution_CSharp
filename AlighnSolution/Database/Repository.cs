using MongoDB.Driver;

namespace AlighnSolution.Database;

/// <summary>
/// IRepository will provide a blueprint for all the repositories which are compatible with mongodb structure.
/// </summary>
/// <typeparam name="T">Is a generic type for each repository which it wants to work with</typeparam>
public interface IRepository<T>
{
    public Task<T> Save(T databaseObject);
    public Task<List<T>> SaveList(List<T> databaseObjects);
    public Task<T> Load(FilterDefinition<T> filter, FindOptions<T, T> findOptions);
    public Task<List<T>> LoadList(FilterDefinition<T> filter, FindOptions<T, T> findOptions);
    public Task<T> Remove(FilterDefinition<T> filter);
}