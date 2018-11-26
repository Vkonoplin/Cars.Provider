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
            var dataSource = await _carImportRepository.GetImportDataSource();

            var path = Path.Combine(en.WebRootPath, "data");
            var files = Directory.EnumerateFiles(path);

            foreach (var file in files)
            {
                if (!dataSource.Any(r => r.Source == "json_data_car_1.json"))
                {
                    await Task.Factory.StartNew(() =>
                    {
                        var text = File.ReadAllText(file);
                        var docs = BsonSerializer.Deserialize<BsonArray>(text).Select(p => p.AsBsonDocument).ToList();
                         _carImportRepository.InsertDocuments(docs);
                    });
                }
            }
        }
    }
}
