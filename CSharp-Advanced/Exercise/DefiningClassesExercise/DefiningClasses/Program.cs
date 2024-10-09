using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string command = Console.ReadLine();

            while (command != "Tournament")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = new Trainer(trainerName);
                if (trainers.Any(x => x.Name == trainer.Name))
                {
                    foreach (var item in trainers)
                    {
                        if(item.Name == trainer.Name)
                        {
                            item.PokemonCollection.Add(pokemon);
                        }
                    }
                }
                else
                {
                    trainer.PokemonCollection = new List<Pokemon>();
                    trainer.PokemonCollection.Add(pokemon);
                    trainers.Add(trainer);
                }

                command = Console.ReadLine();
            }
            string secondCommand = Console.ReadLine();

            while (secondCommand != "End")
            {
                foreach (var item in trainers)
                {
                    item.Checker(secondCommand);
                }
                secondCommand = Console.ReadLine();
            }
            foreach (var item in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine(item);
            }
        }
    }
}
