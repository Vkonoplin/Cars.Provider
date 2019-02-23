using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VK.Cars.Provider.Service.WebApi.Business.Contracts;

namespace VK.Cars.Provider.Service.WebApi.Controllers
{
    [Authorize]
    [Route("/v1/car")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [SwaggerResponse((int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> GetCarsByPaging(int pageSize, int pageNumber)
        {
            var response = await _carService.GetCars(pageSize, pageNumber);
            return new OkObjectResult(response);
        }
    }
}
