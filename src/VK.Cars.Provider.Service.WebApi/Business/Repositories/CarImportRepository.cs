using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using VK.Cars.Provider.Service.WebApi.Db;
using VK.Cars.Provider.Service.WebApi.Db.Entities;

namespace VK.Cars.Provider.Service.WebApi.Business.Repositories
{
    public class CarImportRepository : ICarImportRepository
    {
        private readonly MongoDbContext _dbContext;

        public CarImportRepository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InsertDocuments(IEnumerable<BsonDocument> documents)
        {
            await _dbContext.Db.GetCollection<BsonDocument>(nameof(Car)).InsertManyAsync(documents);
        }
    }
}
