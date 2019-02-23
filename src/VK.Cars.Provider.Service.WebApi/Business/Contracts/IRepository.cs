using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace VK.Cars.Provider.Service.WebApi.Business.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        Task<T> GetById(ObjectId id);

        Task<T> Create(T entity);

        Task<UpdateResult> Update(T entity);

        Task<DeleteResult> Delete(T entity);
    }
}
