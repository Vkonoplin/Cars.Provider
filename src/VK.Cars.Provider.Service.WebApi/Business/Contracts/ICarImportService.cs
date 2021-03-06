﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace VK.Cars.Provider.Service.WebApi.Business.Contracts
{
    public interface ICarImportService
    {
        Task ImportCars(IHostingEnvironment en);
    }
}
