using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using VK.Cars.Provider.Service.WebApi.Business.Repositories;

namespace VK.Cars.Provider.Service.WebApi.Business.Services
{
    public class CarImportService : ICarImportService
    {
        private readonly ICarImportRepository _carImportRepository;

        public CarImportService(ICarImportRepository carImportRepository)
        {
            _carImportRepository = carImportRepository;
        }

        public async Task ImportCars(IHostingEnvironment en)
        {
            var path = Path.Combine(en.WebRootPath, "data");
            var files = Directory.EnumerateFiles(path);
            var file = files.Last();
            var text = File.ReadAllText(file);
            var docs = BsonSerializer.Deserialize<BsonArray>(text).Select(p => p.AsBsonDocument).ToList();
            await _carImportRepository.InsertDocuments(docs);
        }
    }
}
