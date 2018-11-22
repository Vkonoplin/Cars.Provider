using System.Threading.Tasks;
using MongoDB.Driver;
using VK.Cars.Provider.Service.WebApi.Db;
using VK.Cars.Provider.Service.WebApi.Db.Entities;

namespace VK.Cars.Provider.Service.WebApi.Business.Repositories
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        private readonly MongoDbContext _dbContext;

        public HealthCheckRepository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HealthCheckDataEntity> Create(HealthCheckDataEntity entity)
        {
            await _dbContext.Db.GetCollection<HealthCheckDataEntity>(nameof(HealthCheckDataEntity)).InsertOneAsync(entity);

            return entity;
        }

        public async Task<DeleteResult> Delete(HealthCheckDataEntity entity)
        {
            return await _dbContext.Db.GetCollection<HealthCheckDataEntity>(nameof(HealthCheckDataEntity))
                .DeleteOneAsync(f => f.HealthCheckDataId == entity.HealthCheckDataId);
        }

        public Task<HealthCheckDataEntity> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<HealthCheckDataEntity> Update(HealthCheckDataEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
