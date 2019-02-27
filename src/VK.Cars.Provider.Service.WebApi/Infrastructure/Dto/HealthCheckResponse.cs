using System;
using System.Collections.Generic;

namespace VK.Cars.Provider.Service.WebApi.Infrastructure.Dto
{
    public class HealthCheckResponse
    {
        public bool IsOnline { get; set; }

        public List<HealthCheckResult> HealthChecks { get; set; }

        public string MachineName => Environment.MachineName;

        public string Build => Environment.GetEnvironmentVariable("BUILD_VERSION");
    }
}
