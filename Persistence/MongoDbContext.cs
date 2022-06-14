using Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Persistence
{
    public class MongoDbContext
    {

        private readonly IMongoDatabase _database;
        public IMongoCollection<Location> Locations => _database.GetCollection<Location>("Locations");

        public MongoDbContext(IConfiguration configuration)
        {

            var settings = MongoClientSettings.FromConnectionString(configuration.GetSection("ConnectionStrings")["MongoDBSettings"]);
            _database = new MongoClient(settings).GetDatabase(configuration.GetSection("ConnectionStrings")["MongoDBName"]);

        }

    }
}