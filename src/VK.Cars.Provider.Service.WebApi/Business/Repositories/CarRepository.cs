using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using VK.Cars.Provider.Service.WebApi.Business.Contracts;
using VK.Cars.Provider.Service.WebApi.Db;
using VK.Cars.Provider.Service.WebApi.Db.Entities;

namespace VK.Cars.Provider.Service.WebApi.Business.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly MongoDbContext _dbContext;

        public CarRepository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IList<Car>, long)> GetCars(int pageSize, int pageNumber)
        {
            var query = _dbContext.Db.GetCollection<Car>(nameof(Car)).Find(_ => true).SortByDescending(p => p.Id);

            var totalCountTask = await _dbContext.Db.GetCollection<Car>(nameof(Car)).EstimatedDocumentCountAsync();

            var itemsTask = await query.Skip((pageNumber * pageSize) - pageSize).Limit(pageSize).ToListAsync();

            return (itemsTask, totalCountTask);
        }
    }
}
