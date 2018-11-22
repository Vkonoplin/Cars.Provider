using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using VK.Cars.Provider.Service.WebApi.Infrastructure.Models;

namespace VK.Cars.Provider.Service.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostConfig = new HostOptions();

            var path = Directory.GetCurrentDirectory();
            var configRoot = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
                .AddEnvironmentVariables()
                .Build();
            configRoot.Bind(hostConfig);

            CreateWebHostBuilder(args, hostConfig)

                .Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args, HostOptions hostConfig) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls(hostConfig.Host)
                .UseStartup<Startup>();
    }
}
