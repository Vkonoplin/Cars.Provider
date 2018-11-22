using Microsoft.Extensions.DependencyInjection;
using VK.Cars.Provider.Service.WebApi.Db;

namespace VK.Cars.Provider.Service.WebApi.Infrastructure
{
    public static class ServiceExtentions
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new MongoDbContext(connectionString));
            return services;
        }
    }
}
