using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using VK.Cars.Provider.Service.WebApi.Db.Entities;

namespace VK.Cars.Provider.Service.WebApi.Business.Contracts
{
    public interface ICarImportRepository
    {
        Task InsertDocuments(IEnumerable<BsonDocument> documents);

        Task InsertDataSource(ImportDataSource doc);

        Task<IEnumerable<ImportDataSource>> GetImportDataSource();
    }
}
