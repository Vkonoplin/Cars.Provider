using System.Threading.Tasks;
using VK.Cars.Provider.Service.WebApi.Db.Entities;
using VK.Cars.Provider.Service.WebApi.Infrastructure.Models;

namespace VK.Cars.Provider.Service.WebApi.Business.Contracts
{
    public interface ICarService
    {
        Task<GridResult<Car>> GetCars(int pageSize, int pageNumber);

        Task<GridResult<Car>> GetCarsByMaker(int pageSize, int pageNumber, string maker);
    }
}
