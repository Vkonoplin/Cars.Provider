using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using VK.Cars.Provider.Service.WebApi.Business.Contracts;
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

        public async Task<HealthCheckDataEntity> GetById(ObjectId id)
        {
            return await _dbContext.Db.GetCollection<HealthCheckDataEntity>(nameof(HealthCheckDataEntity))
                .Find(f => f.HealthCheckDataId == id).FirstAsync();
        }

        public async Task<UpdateResult> Update(HealthCheckDataEntity entity)
        {
            var update = Builders<HealthCheckDataEntity>.Update.Set(x => x.UpdateDate, entity.UpdateDate);

            return await _dbContext.Db.GetCollection<HealthCheckDataEntity>(nameof(HealthCheckDataEntity))
                .UpdateOneAsync(f => f.HealthCheckDataId == entity.HealthCheckDataId, update);
        }

        public ClusterState GetClusterState()
        {
            return _dbContext.Db.Client.Cluster.Description.State;
        }
    }
}
