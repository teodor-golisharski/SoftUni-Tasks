using System;
using System.Collections.Generic;

namespace PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = new List<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string mainCommand = command.Split(" ")[0];
                string criterias = command.Split(" ")[1];
                string value = command.Split(" ")[2];

                if (mainCommand == "Remove")
                {
                    people.RemoveAll(GetPredicate(criterias, value));
                }
                else if (mainCommand == "Double")
                {
                    var peopleToDouble = people.FindAll(GetPredicate(criterias, value));

                    int index = people.FindIndex(GetPredicate(criterias, value));

                    if (index >= 0)
                    {
                        people.InsertRange(index, peopleToDouble);
                    }
                }

                command = Console.ReadLine();
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
        }
        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Length":
                    return s => s.Length == int.Parse(value);

                case "StartsWith":
                    return s => s.StartsWith(value);

                case "EndsWith":
                    return s => s.EndsWith(value);

                default:
                    return default(Predicate<string>);
            }
        }
    }
}
