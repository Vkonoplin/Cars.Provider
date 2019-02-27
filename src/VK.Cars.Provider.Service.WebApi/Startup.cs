using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using VK.Cars.Provider.Service.WebApi.Business.Contracts;
using VK.Cars.Provider.Service.WebApi.Business.Repositories;
using VK.Cars.Provider.Service.WebApi.Business.Services;
using VK.Cars.Provider.Service.WebApi.Infrastructure;

namespace VK.Cars.Provider.Service.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("MongoDB");

            services.AddMongoDb(connectionString);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Cars Provider API Service",
                    Version = "v1"
                });
                c.AddSecurityDefinition(
                    "Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "Please enter JWT with Bearer into field",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    {
                        "Bearer", Enumerable.Empty<string>()
                    }
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAllOrigins",
                    builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });

            services.AddAuthentication(sharedOptions =>
                {
                    sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddAzureAdBewarer(options => Configuration.Bind("AzureAd", options));

            services.AddSingleton(x => new MapperConfiguration(config => { config.AddProfile<MapperProfile>(); }).CreateMapper());

            services.AddOptions();

            services.AddTransient<HealthCheckService>();
            services.AddTransient<IHealthCheckRepository, HealthCheckRepository>();

            services.AddSingleton<ICarImportRepository, CarImportRepository>();
            services.AddSingleton<ICarImportService, CarImportService>();

            services.AddSingleton<ICarRepository, CarRepository>();
            services.AddSingleton<ICarService, CarService>();

            services.AddMvc(options => { options.Filters.Add<ExceptionFilter>(); }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manifest API");
            });

            app.UseCors("AllowAllOrigins");
            app.UseAuthentication();

            app.UseMvc();

            app.ApplicationServices.GetService<ICarImportService>().ImportCars(env);
        }
    }
}
