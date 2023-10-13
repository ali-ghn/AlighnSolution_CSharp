using MongoDB.Driver;

namespace AlighnSolution.Database;

/// <summary>
/// IRepository will provide a blueprint for all the repositories which are compatible with mongodb structure.
/// </summary>
/// <typeparam name="T">Is a generic type for each repository which it wants to work with</typeparam>
public interface IRepository<T>
{
    public T Save(T databaseObject);
    public List<T> SaveList(List<T> databaseObjects);
    public T Load(FilterDefinition<T> filter);
    public T LoadList(FilterDefinition<T> filter, FindOptions<T, T> findOptions);
    public T Remove(FilterDefinition<T> filter);
    public T RemoveActivation(FilterDefinition<T> filter);
}