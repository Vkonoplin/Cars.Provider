using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VK.Cars.Provider.Service.WebApi.Db.Entities
{
    public class HealthCheckDataEntity
    {
        [BsonId]
        public ObjectId HealthCheckDataId { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime UpdateDate { get; set; }
    }
}
