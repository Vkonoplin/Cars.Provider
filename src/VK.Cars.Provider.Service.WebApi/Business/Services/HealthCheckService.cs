using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VK.Cars.Provider.Service.WebApi.Business.Repositories;
using VK.Cars.Provider.Service.WebApi.Db.Entities;
using VK.Cars.Provider.Service.WebApi.Infrastructure;
using VK.Cars.Provider.Service.WebApi.Infrastructure.Models;

namespace VK.Cars.Provider.Service.WebApi.Business.Services
{
    public class HealthCheckService : BaseHealthCheckService
    {
        private const string CheckType = "MongoDb";
        private readonly IHealthCheckRepository _healthCheckRepository;

        public HealthCheckService(IHealthCheckRepository healthCheckRepository)
        {
            _healthCheckRepository = healthCheckRepository;
        }

        public override async Task<List<HealthCheckResult>> ExecuteHealthchecks()
        {
            var result = await base.ExecuteHealthchecks();
            var testData =
                new HealthCheckDataEntity() { UpdateDate = DateTime.UtcNow };

            await _healthCheckRepository.Create(testData);

            return result;
        }
    }
}
