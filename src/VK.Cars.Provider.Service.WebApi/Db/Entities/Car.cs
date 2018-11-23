using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VK.Cars.Provider.Service.WebApi.Db.Entities
{
    public class Car
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public string Model { get; set; }
    }
}
