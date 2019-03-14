using System.Threading.Tasks;
using VK.Cars.Provider.Service.WebApi.Business.Models;
using VK.Cars.Provider.Service.WebApi.Infrastructure.Dto;

namespace VK.Cars.Provider.Service.WebApi.Business.Contracts
{
    public interface ICarService
    {
        Task<GridResult<CarModel>> GetCars(int pageSize, int pageNumber);

        Task<GridResult<CarModel>> GetCarsByMaker(int pageSize, int pageNumber, string maker);
    }
}
