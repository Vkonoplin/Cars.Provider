using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace VK.Cars.Provider.Service.WebApi.Business.Repositories
{
    public interface ICarImportRepository
    {
        Task InsertDocuments(IEnumerable<BsonDocument> documents);
    }
}
