using AlighnSolution.Database;
using DnsClient.Internal;
using AlighnSolution.Reflection;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace AlighnSolution.User;

public class UserRepository
{
    private ILogger<UserRepository> logger;
    private UserManager<User> userManager;

    public UserRepository(ILogger<UserRepository> _logger, UserManager<User> _userManager,
        string userDatabaseName, string userCollectionName)
    {
        logger = _logger;
        userManager = _userManager;
    }
}