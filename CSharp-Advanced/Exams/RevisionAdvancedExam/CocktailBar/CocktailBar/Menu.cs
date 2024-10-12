using System.Text;

namespace CocktailBar
{
    public class Menu
    {
        private int barCapacity;

        public Menu(int barCapacity)
        {
            Cocktails = new List<Cocktail>();
            this.barCapacity = barCapacity;
        }

        public List<Cocktail> Cocktails { get; }

        public int BarCapacity { get => barCapacity; }

        public void AddCocktail(Cocktail cocktail)
        {
            if (BarCapacity > Cocktails.Count())
            {
                if (!Cocktails.Any(x => x.Name == cocktail.Name))
                {
                    Cocktails.Add(cocktail);
                }
            }
        }

        public bool RemoveCocktail(string name)
        {
            Cocktail ck = Cocktails.FirstOrDefault(x => x.Name == name)!;

            if (ck != null)
            {
                Cocktails.Remove(ck);
                return true;
            }
            return false;
        }

        public Cocktail GetMostDiverse()
        {
            return Cocktails.OrderByDescending(x => x.Ingredients.Count()).FirstOrDefault()!;
        }

        public string Details(string cocktailName)
        {
            Cocktail ck = Cocktails.FirstOrDefault(x => x.Name == cocktailName)!;

            return ck.ToString();
        }

        public string GetAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("All Cocktails:");

            foreach (var item in Cocktails.OrderBy(x => x.Name))
            {
                sb.AppendLine($"{item.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}