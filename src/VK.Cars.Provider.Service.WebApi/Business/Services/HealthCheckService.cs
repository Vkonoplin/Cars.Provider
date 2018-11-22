using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Clusters;
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

            ClusterState databaseState;

            try
            {
                databaseState = _healthCheckRepository.GetClusterState();
            }
            catch (Exception)
            {
                databaseState = ClusterState.Disconnected;
            }

            if (databaseState == ClusterState.Connected)
            {
                result.Add(new HealthCheckResult
                {
                    Passed = true,
                    CheckType = CheckType,
                    Message = "Database is alive"
                });

                result.AddRange(await TestCRUD());
            }
            else
            {
                result.Add(new HealthCheckResult
                {
                    Passed = false,
                    CheckType = CheckType,
                    Message = "Failed to connect to MongoDB"
                });
            }

            return result;
        }

        private async Task<List<HealthCheckResult>> TestCRUD()
        {
            var healthChecks = new List<HealthCheckResult>();
            var testData = new HealthCheckDataEntity();
            bool success = true;

            try
            {
                testData = await _healthCheckRepository.Create(testData);
            }
            catch (Exception)
            {
                healthChecks.Add(new HealthCheckResult
                {
                    Passed = false,
                    CheckType = CheckType,
                    Message = "Create command test failed"
                });
                success = false;
            }

            try
            {
                testData.UpdateDate = DateTime.UtcNow;
                await _healthCheckRepository.Update(testData);
            }
            catch (Exception)
            {
                healthChecks.Add(new HealthCheckResult
                {
                    Passed = false,
                    CheckType = CheckType,
                    Message = "Update command test failed"
                });
                success = false;
            }

            try
            {
                await _healthCheckRepository.GetById(testData.HealthCheckDataId);
            }
            catch (Exception)
            {
                healthChecks.Add(new HealthCheckResult
                {
                    Passed = false,
                    CheckType = CheckType,
                    Message = "Get By Id command test failed"
                });
                success = false;
            }

            if (success)
            {
                healthChecks.Add(
                    new HealthCheckResult()
                    {
                        CheckType = CheckType,
                        Message =
                            $"Database is alive.The entity with Id={testData.HealthCheckDataId.ToString()} was created at {testData.UpdateDate}",
                        Passed = true
                    });
            }

            return healthChecks;
        }
    }
}
