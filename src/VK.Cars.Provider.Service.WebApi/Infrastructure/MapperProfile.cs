using AutoMapper;
using VK.Cars.Provider.Service.WebApi.Business.Models;
using VK.Cars.Provider.Service.WebApi.Db.Entities;

namespace VK.Cars.Provider.Service.WebApi.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Car, CarModel>()
                .ForMember(model => model.Id, opt => opt.MapFrom(r => r.Id.ToString()));
        }
    }
}
