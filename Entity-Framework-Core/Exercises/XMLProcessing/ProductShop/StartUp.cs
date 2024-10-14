using ProductShop.Data;
using ProductShop.DTOs.Import;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            return "";
        }
    }
}