namespace Boardgames.DataProcessor
{
    using AutoMapper;
    using Boardgames.Data;
    using Boardgames.DataProcessor.ExportDto;
    using Boardgames.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            
            XmlHelper xmlHelper = new XmlHelper();

            ExportCreatorDto[] creatorsDto = context.Creators
                .Where(c => c.Boardgames.Any())
                .ToArray()
                .Select(c => new ExportCreatorDto()
                {
                    CreatorName = $"{c.FirstName} {c.LastName}",
                    BoardgamesCount = c.Boardgames.Count,
                    //Boardgames:
                    //<BoardgameName>Bohnanza: The Duel</BoardgameName>
                    //< BoardgameYearPublished>2019</BoardgameYearPublished>

                    Boardgames = c.Boardgames
                    .Select(b => new ExportBoardgameDto()
                    {
                        BoardgameName = b.Name,
                        BoardgameYearPublished = b.YearPublished
                    })
                    .OrderBy(b => b.BoardgameName)
                    .ToArray()
                })
                .OrderByDescending(s => s.BoardgamesCount)
                .ThenBy(s => s.CreatorName)
            .ToArray();

            return xmlHelper.Serialize(creatorsDto, "Creators");

        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Include(s => s.BoardgamesSellers)
                .ThenInclude(sb => sb.Boardgame)
                .ToArray()
                .Where(s => s.BoardgamesSellers.Any(sb => sb.Boardgame.YearPublished >= year && sb.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,

                    //boardgames
                    Boardgames = s.BoardgamesSellers
                    .Where(sb => sb.Boardgame.YearPublished >= year && sb.Boardgame.Rating <= rating)
                    .Select(sb => new
                    {
                        Name = sb.Boardgame.Name,
                        Rating = sb.Boardgame.Rating,
                        Mechanics = sb.Boardgame.Mechanics,
                        Category = sb.Boardgame.CategoryType.ToString()
                    })
                    .OrderByDescending(b => b.Rating)
                    .ThenBy(b => b.Name)
                    .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);

        }
    }
}