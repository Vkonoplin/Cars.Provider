using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VK.Cars.Provider.Service.WebApi.Db.Entities
{
    public class ImportDataSource
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Source { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Date { get; set; }
    }
}
