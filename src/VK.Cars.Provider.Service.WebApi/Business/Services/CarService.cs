using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VK.Cars.Provider.Service.WebApi.Business.Contracts;
using VK.Cars.Provider.Service.WebApi.Db.Entities;
using VK.Cars.Provider.Service.WebApi.Infrastructure.Dto;
using VK.Cars.Provider.Service.WebApi.Models;

namespace VK.Cars.Provider.Service.WebApi.Business.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<GridResult<CarModel>> GetCars(int pageSize, int pageNumber)
        {
            var (cars, count) = await _carRepository.GetCars(pageSize, pageNumber);

            var carsModels = _mapper.Map<IList<CarModel>>(cars);

            return new GridResult<CarModel>(
                carsModels,
                new GridOptions { TotalCount = count, PageNumber = pageNumber, PageSize = pageSize });
        }

        public Task<GridResult<CarModel>> GetCarsByMaker(int pageSize, int pageNumber, string maker)
        {
            throw new System.NotImplementedException();
        }
    }
}
