using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int badges;

        public int Badges
        {
            get { return badges; }
            set { badges = value; }
        }

        private List<Pokemon> pokemonCollection;

        public List<Pokemon> PokemonCollection
        {
            get { return pokemonCollection; }
            set { pokemonCollection = value; }
        }
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
        }
        public void Checker(string type)
        {
            bool flag = pokemonCollection.Any(x => x.Element == type);
            if (flag)
            {
                badges++;
            }
            else
            {
                pokemonCollection.ForEach(x => x.Health -= 10);
                pokemonCollection.RemoveAll(x => x.Health <= 0);
            }
        }

        public override string ToString()
        {
            return $"{name} {badges} {pokemonCollection.Count}";
        }
    }
}
