namespace VK.Cars.Provider.Service.WebApi.Infrastructure.Models
{
    public class HealthCheckResult
    {
        public string Message { get; set; }

        public string CheckType { get; set; }

        public bool Passed { get; set; }
    }
}
