using System.Collections.Generic;

namespace VK.Cars.Provider.Service.WebApi.Business.Models
{
    public class CarModel
    {
        public string Id { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public string Model { get; set; }

        public List<string> BodyStyles { get; set; }
    }
}
