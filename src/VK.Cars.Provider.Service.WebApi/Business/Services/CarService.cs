using System.Threading.Tasks;
using VK.Cars.Provider.Service.WebApi.Business.Contracts;
using VK.Cars.Provider.Service.WebApi.Db.Entities;
using VK.Cars.Provider.Service.WebApi.Infrastructure.Models;

namespace VK.Cars.Provider.Service.WebApi.Business.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<GridResult<Car>> GetCars(int pageSize, int pageNumber)
        {
            var (cars, count) = await _carRepository.GetCars(pageSize, pageNumber);

            return new GridResult<Car>(
                cars,
                new GridOptions { TotalCount = count, PageNumber = pageNumber, PageSize = pageSize });
        }

        public Task<GridResult<Car>> GetCarsByMaker(int pageSize, int pageNumber, string maker)
        {
            throw new System.NotImplementedException();
        }
    }
}
