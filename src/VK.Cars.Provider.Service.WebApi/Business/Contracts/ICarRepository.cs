using System.Collections.Generic;
using System.Threading.Tasks;
using VK.Cars.Provider.Service.WebApi.Db.Entities;

namespace VK.Cars.Provider.Service.WebApi.Business.Contracts
{
    public interface ICarRepository
    {
      Task<(IList<Car>, long)> GetCars(int pageSize, int pageNumber);
    }
}
