using System.Collections.Generic;
using System.Threading.Tasks;
using VK.Cars.Provider.Service.WebApi.Infrastructure.Models;

namespace VK.Cars.Provider.Service.WebApi.Infrastructure
{
    public class BaseHealthCheckService
    {
        public async virtual Task<List<HealthCheckResult>> ExecuteHealthchecks()
        {
            return new List<HealthCheckResult> { new HealthCheckResult { Passed = true, Message = "Service is alive", CheckType = "Service" } };
        }
    }
}
