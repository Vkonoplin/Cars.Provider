using System.Threading.Tasks;
using MongoDB.Driver;

namespace VK.Cars.Provider.Service.WebApi.Business.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        Task<T> GetById(string id);

        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<DeleteResult> Delete(T entity);
    }
}
