using MongoDB.Bson.Serialization.Attributes;
using NUnit.Framework;

namespace AlighnSolution.Reflection.Tests;

public class TestGetClassPropertyId
{
    [Test]
    public void Test_GetClassPropertyId()
    {
        var propertyInfo01 = Reflection.GetClassProperties<User.User, BsonIdAttribute>(new User.User());
        foreach (var property in propertyInfo01)
        {
            Console.WriteLine(property);
        }
    }
}