using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportCar, Car>();
            this.CreateMap<Car, ExportCar>()
            .ForMember(x => x.Id,
                opt => opt.MapFrom(s => s.Id))
                .ForMember(x => x.Make,
                opt => opt.MapFrom(s => s.Make))
                .ForMember(x => x.Model,
                opt => opt.MapFrom(s => s.Model))
                .ForMember(x => x.TraveledDistance,
                opt => opt.MapFrom(s => s.TraveledDistance));
        }
    }
}
