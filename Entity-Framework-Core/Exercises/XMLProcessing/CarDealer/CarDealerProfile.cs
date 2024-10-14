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
            //Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(x => x.Count, opt => opt.MapFrom(s => s.Parts.Count()));

            //Part
            this.CreateMap<ImportPartDto, Part>();
            this.CreateMap<Part, ExportPartsQuery17Dto>();

            //Car
            this.CreateMap<ImportCarDto, Car>()
               .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, ExportCarBmwDto>();
            this.CreateMap<Car, ExportCarQuery17Dto>()
                .ForMember(d => d.Parts,
                    opt => opt.MapFrom(s =>
                        s.PartsCars
                            .Select(pc => pc.Part)
                            .OrderByDescending(p => p.Price)
                            .ToArray()));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>()
                .ForMember(d => d.CarId,
                    opt => opt.MapFrom(s => s.CarId));

            //Customer
            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.Name));
            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.BoughtCars, opt => opt.MapFrom(s => s.Sales.Count));
            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.SpentMoney, opt => opt.MapFrom(x => x.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price))));
        }
    }
}
