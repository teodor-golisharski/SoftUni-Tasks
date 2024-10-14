using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string inputXmlSupplier = File.ReadAllText("../../../Datasets/suppliers.xml");
            //string inputXmlPart = File.ReadAllText("../../../Datasets/parts.xml");
            //string inputXmlCar = File.ReadAllText("../../../Datasets/cars.xml");
            //string inputXmlCustomer = File.ReadAllText("../../../Datasets/customers.xml");
            //string inputXmlSale = File.ReadAllText("../../../Datasets/sales.xml");

            //Console.WriteLine(ImportSuppliers(context, inputXmlSupplier));
            //Console.WriteLine(ImportParts(context, inputXmlPart));
            //Console.WriteLine(ImportCars(context, inputXmlCar));
            //Console.WriteLine(ImportCustomers(context, inputXmlCustomer));
            //Console.WriteLine(ImportSales(context, inputXmlSale));

            Console.WriteLine(GetTotalSalesByCustomer(context));
        }

        //Problem 09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();
            ImportSupplierDto[] supplierDtos =
                xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();
            foreach (ImportSupplierDto item in supplierDtos)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    continue;
                }

                //Manual mapping without AutoMapper
                //Supplier supplier = new Supplier()
                //{
                //    Name = item.Name,
                //    IsImporter = item.IsImporter
                //};


                //AutoMapper
                Supplier supplier = mapper.Map<Supplier>(item);

                //Fill validSuppliers
                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count()}";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            HashSet<int> SuppliersIds = context.Suppliers.Select(x => x.Id).ToHashSet();

            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();
            ImportPartDto[] partDtos =
                xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = new HashSet<Part>();
            foreach (ImportPartDto item in partDtos)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    continue;
                }
                if (!SuppliersIds.Contains(item.SupplierId))
                {
                    continue;
                }

                //Manual mapping without AutoMapper
                //Supplier supplier = new Supplier()
                //{
                //    Name = item.Name,
                //    IsImporter = item.IsImporter
                //};


                //AutoMapper
                Part part = mapper.Map<Part>(item);

                //Fill validSuppliers
                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count()}";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCarDto[] carDtos =
                xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> validCars = new HashSet<Car>();
            foreach (ImportCarDto carDto in carDtos)
            {
                if (string.IsNullOrEmpty(carDto.Make) ||
                    string.IsNullOrEmpty(carDto.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carDto);

                foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDto.PartId))
                    {
                        continue;
                    }

                    PartCar carPart = new PartCar()
                    {
                        PartId = partDto.PartId
                    };
                    car.PartsCars.Add(carPart);
                }

                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();
            ImportCustomerDto[] customerDtos =
                xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> validCustomers = new HashSet<Customer>();
            foreach (ImportCustomerDto item in customerDtos)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    continue;
                }

                //Manual mapping without AutoMapper
                Customer customer = new Customer()
                {
                    Name = item.Name,
                    BirthDate = item.BirthDate,
                    IsYoungDriver = item.IsYoungDriver,
                };

                //Fill validSuppliers
                validCustomers.Add(customer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count()}";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper xmlHelper = new XmlHelper();
            ImportSaleDto[] saleDtos =
                xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            ICollection<Sale> validSales = new HashSet<Sale>();
            ICollection<int> dbCarIds = context.Cars.Select(c => c.Id).ToArray();
            foreach (ImportSaleDto item in saleDtos)
            {
                if (!item.CarId.HasValue ||
                    dbCarIds.All(id => id != item.CarId.Value))
                {
                    continue;
                }
                //AutoMapper
                Sale sale = mapper.Map<Sale>(item);

                //Fill validSuppliers
                validSales.Add(sale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count()}";
        }

        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();

            ExportCarDto[] cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return helper.Serialize<ExportCarDto[]>(cars, "cars");
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();

            ExportCarBmwDto[] cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportCarBmwDto>(mapper.ConfigurationProvider)
                .ToArray();

            return helper.Serialize<ExportCarBmwDto[]>(cars, "cars");
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();

            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportSupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            return helper.Serialize<ExportSupplierDto[]>(suppliers, "suppliers");
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper helper = new XmlHelper();

            var cars = context
                .Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarQuery17Dto>(mapper.ConfigurationProvider)
                .ToArray();

            return helper.Serialize<ExportCarQuery17Dto[]>(cars, "cars");
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();

            XmlHelper helper = new XmlHelper();

            var customers = context
                .Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new ExportCustomerDto
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(s => s.Car.PartsCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            return helper.Serialize(customers, "customers");
        }

        //Mapper
        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}