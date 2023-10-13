using System.Reflection;
using MongoDB.Bson.Serialization.Attributes;

namespace AlighnSolution.Reflection;

public static class Reflection
{
    /// <summary>
    /// Gets the property of the class based on the property type which has been pointed in T2
    /// </summary>
    /// <param name="classToGetProperties"></param>
    /// <typeparam name="T">Class type which the property should be fetched for.</typeparam>
    /// <typeparam name="T2">Type of the attribute which you want to obtain</typeparam>
    /// <returns>
    /// List of PropertyInfo
    /// </returns>
    public static List<PropertyInfo> GetClassProperties<T, T2>(T classToGetProperties) where T : class where T2 : Attribute
    {
        var properties = classToGetProperties.GetType().GetProperties();
        var foundProperties = new List<PropertyInfo>();
        foreach (var property in properties)
        {
            var attributes = property.GetCustomAttributes();
            foundProperties.AddRange(from attribute in attributes where attribute.GetType().Name == typeof(T2).Name select property);
        }
        return foundProperties;
    }
}