using System.Text;

namespace CocktailBar
{
    public class Cocktail
    {
        private string _name;
        private decimal _price;
        private double _volume;
        private List<string> _ingredients;

        public Cocktail(string name, decimal price, double volume, string ingredients)
        {
            _ingredients = ingredients.Split(", ").ToList();
            _name = name;
            _price = price;
            _volume = volume;
        }

        public string Name { get => _name; }
        public decimal Price { get => _price; }
        public double Volume { get => _volume; }
        public List<string> Ingredients { get => _ingredients; }

        public override string ToString() 
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name}, Price: {Price:F2} BGN, Volume: {Volume} ml");
            sb.AppendLine($"Ingredients: {string.Join(", ", Ingredients)}");

            return sb.ToString().TrimEnd();
        }
    }
}
