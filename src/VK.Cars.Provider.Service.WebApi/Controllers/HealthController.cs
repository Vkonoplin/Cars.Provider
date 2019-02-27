using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VK.Cars.Provider.Service.WebApi.Business.Services;
using VK.Cars.Provider.Service.WebApi.Infrastructure.Dto;

namespace VK.Cars.Provider.Service.WebApi.Controllers
{
    public class HealthController : Controller
    {
        private readonly HealthCheckService _healthCheck;

        public HealthController(HealthCheckService healthCheck)
        {
            _healthCheck = healthCheck;
        }

        [HttpGet("/health")]
        public async Task<IActionResult> Health()
        {
            var healthCheckResults = await _healthCheck.ExecuteHealthchecks();
            var isOnline = healthCheckResults.All(healthCheck => healthCheck.Passed);

            var response = new HealthCheckResponse { IsOnline = isOnline, HealthChecks = healthCheckResults };

            return isOnline
                ? Ok(response)
                : new ObjectResult(response) { StatusCode = (int)HttpStatusCode.ServiceUnavailable };
        }
    }
}
