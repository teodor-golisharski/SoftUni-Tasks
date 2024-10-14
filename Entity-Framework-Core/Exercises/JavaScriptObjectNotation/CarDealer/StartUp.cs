using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string result1 = ImportSuppliers(context, ReadJson("suppliers.json"));
            //string result2 = ImportParts(context, ReadJson("parts.json"));
            //string result3 = ImportCars(context, ReadJson("cars.json"));
            //string result4 = ImportCustomers(context, ReadJson("customers.json"));
            //string result5 = ImportSales(context, ReadJson("sales.json"));

            string result = GetCarsWithTheirListOfParts(context);
            Console.WriteLine(result);
        }
        

        //Read Json
        public static string ReadJson(string file)
        {
            string path = @"../../../Datasets/";
            return File.ReadAllText(path + file);
        }


        //Problem 9 - checked
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers!);
            context.SaveChanges();

            return $"Successfully imported {suppliers!.Count()}.";
        }

        //Problem 10 - checked
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            HashSet<int> suppliersIds = context.Suppliers.Select(x => x.Id).ToHashSet();

            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)!
                .Where(x => suppliersIds.Contains(x.SupplierId))
                .ToList();

            context.Parts.AddRange(parts!);
            context.SaveChanges();

            return $"Successfully imported {parts!.Count()}.";
        }

        //Problem 11 - checked
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            HashSet<int> partsIds = context.Parts.Select(x => x.Id).ToHashSet();

            var carsData = JsonConvert.DeserializeObject<ImportCar[]>(inputJson)!
                .Where(x => x.PartsId
                    .All(x => partsIds.Contains(x)));

            IMapper mapper = SetMapper();

            var cars = carsData.ToDictionary(x => x, y => mapper.Map<Car>(y));
            var carParts = carsData.SelectMany(carData =>
            {
                var car = cars[carData];

                return carData.PartsId.Select(partId => new PartCar()
                {
                    Car = car,
                    PartId = partId
                });
            });

            context.Cars.AddRange(cars.Values);
            context.PartsCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Problem 12 - checked
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers!);
            context.SaveChanges();

            return $"Successfully imported {customers!.Count()}.";
        }

        //Problem 13 - checked
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            //The MERGE statement conflicted with the FOREIGN KEY constraint "FK_Sales_Customers_CustomerId". The conflict occurred in database "CarDealer", table "dbo.Customers", column 'Id'.
            //The statement has been terminated.
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales!);
            context.SaveChanges();

            return $"Successfully imported {sales!.Count()}.";
        }

        //Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new 
                { 
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        //Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            using (context)
            {
                var cars = context.Cars
                    .Where(c => c.Make == "Toyota")
                    .OrderBy(m => m.Model)
                    .ThenByDescending(d => d.TraveledDistance)
                    .Select(s => new { Id = s.Id, Make = s.Make, Model = s.Model, TravelledDistance = s.TraveledDistance })
                    .ToList();

                var settings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented
                };

                return JsonConvert.SerializeObject(cars, settings);
            }
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count()
                })
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = $"{pc.Part.Price:F2}"
                    }).ToArray(),
                }).ToArray();

            var jsonFile = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return jsonFile;
        }

        private static IMapper SetMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
        }
    }
}