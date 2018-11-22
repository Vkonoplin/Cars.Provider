﻿using MongoDB.Driver.Core.Clusters;
using VK.Cars.Provider.Service.WebApi.Db.Entities;

namespace VK.Cars.Provider.Service.WebApi.Business.Repositories
{
    public interface IHealthCheckRepository : IRepository<HealthCheckDataEntity>
    {
        ClusterState GetClusterState();
    }
}
