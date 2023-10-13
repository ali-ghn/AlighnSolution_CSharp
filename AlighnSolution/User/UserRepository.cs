using AlighnSolution.Database;
using DnsClient.Internal;
using AlighnSolution.Reflection;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace AlighnSolution.User;

public class UserRepository
{
    private ILogger<UserRepository> logger;
    private UserManager<User> userManager;
    private IMongoClient mongoClient;
    private IMongoCollection<User> userCollection;

    public UserRepository(ILogger<UserRepository> _logger, UserManager<User> _userManager, IMongoClient _mongoClient,
        string userDatabaseName, string userCollectionName)
    {
        logger = _logger;
        userManager = _userManager;
        mongoClient = _mongoClient;
        userCollection = mongoClient.GetDatabase(userDatabaseName).GetCollection<User>(userCollectionName);
    }

    public User SaveUser(User user)
    {
        try
        {
            
            
            userCollection.InsertOne(user);
        }
        catch (Exception e)
        {
            logger.LogInformation(e.Message);
            throw;  
        }

        return null;
    }
}