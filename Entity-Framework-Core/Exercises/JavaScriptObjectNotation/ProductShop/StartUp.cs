using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //string result = ImportUsers(context, ReadJson("users.json"));
            //string result1 = ImportProducts(context, ReadJson("products.json"));
            //string result2 = ImportCategories(context, ReadJson("categories.json"));
            //string result3 = ImportCategoryProducts(context, ReadJson("categories-products.json"));
            //string result4 = GetProductsInRange(context);
            //string result5 = GetSoldProducts(context);
            //string result6 = GetCategoriesByProductsCount(context);
            string result7 = GetUsersWithProducts(context);
            Console.WriteLine(result7);
        }

        public static string ReadJson(string file)
        {
            string path = @"../../../Datasets/";
            return File.ReadAllText(path + file);
        }

        //Problem 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = SetMapper();

            var users =
                JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();
            foreach (var userDto in users!)
            {
                User user = mapper.Map<User>(userDto);

                validUsers.Add(user);
            }
            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = SetMapper();

            var products =
                JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> validProducts = new HashSet<Product>();
            foreach (var productDto in products!)
            {
                Product product = mapper.Map<Product>(productDto);

                validProducts.Add(product);
            }
            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return $"Successfully imported {validProducts.Count}";
        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = SetMapper();

            var categories =
                JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> validCategories = new HashSet<Category>();
            foreach (var categoryDto in categories!)
            {
                Category category = mapper.Map<Category>(categoryDto);

                if (category.Name != null)
                {
                    validCategories.Add(category);
                }
            }
            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = SetMapper();

            var categoriesProducts =
                JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> validCategoriesProducts = new HashSet<CategoryProduct>();
            foreach (var categoryProductDto in categoriesProducts!)
            {
                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);

                validCategoriesProducts.Add(categoryProduct);

            }
            context.CategoriesProducts.AddRange(validCategoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoriesProducts.Count}";
        }

        //Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            //var products = context.Products
            //    .Where(p => p.Price >= 500 && p.Price <= 1000)
            //    .OrderBy(p => p.Price)
            //    .Select(p => new
            //    { 
            //        name = p.Name,
            //        price = p.Price,
            //        seller = p.Seller.FirstName + " " + p.Seller.LastName
            //    })
            //    .ToArray();

            IMapper mapper = SetMapper();

            ExportProductInRangeDto[] productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(productDtos, Formatting.Indented);

        }

        //Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            IMapper mapper = SetMapper();

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(u => u.BuyerId != null)
                        .Select(x => new
                        {
                            name = x.Name,
                            price = x.Price,
                            buyerFirstName = x.Buyer.FirstName,
                            buyerLastName = x.Buyer.LastName
                        })
                        .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(users, Formatting.Indented);
        }

        //Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IMapper mapper = SetMapper();

            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count())
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count(),
                    averagePrice = $"{c.CategoriesProducts.Average(x => x.Product.Price):f2}",
                    totalRevenue = $"{c.CategoriesProducts.Sum(x => x.Product.Price):f2}"
                })
                .ToArray();

            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        //Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    // UserDTO
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        // ProductWrapperDTO
                        Count = u.ProductsSold
                            .Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                // ProductDTO
                                p.Name,
                                p.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .AsNoTracking()
                .ToArray();

            var userWrapperDto = new
            {
                UsersCount = users.Length,
                Users = users
            };

            return JsonConvert.SerializeObject(userWrapperDto,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };
        }

        private static IMapper SetMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));
        }
    }
}