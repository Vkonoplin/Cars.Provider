using MongoDB.Driver;

namespace VK.Cars.Provider.Service.WebApi.Db
{
    public class MongoDbContext
    {
        public MongoDbContext(string connectionString)
        {
            var mongoUrl = new MongoUrl(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            Db = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoDatabase Db { get; }
    }
}
