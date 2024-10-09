using System;
using System.Collections.Generic;

namespace PartyReservationFilterModule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = new List<string>(Console.ReadLine().Split());

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string command = Console.ReadLine();

            while (command != "Print")
            {
                string mainCommand = command.Split(";")[0];
                string criterias = command.Split(";")[1];
                string value = command.Split(";")[2];

                if (mainCommand == "Add filter")
                {
                    filters.Add(criterias + value, GetPredicate(criterias, value));
                }
                else if (mainCommand == "Remove filter")
                {
                    filters.Remove(criterias + value);
                }

                command = Console.ReadLine();
            }

            foreach (var item in filters)
            {
                people.RemoveAll(item.Value);
            }
            Console.WriteLine(String.Join(" ", people));
        }
        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Length":
                    return s => s.Length == int.Parse(value);

                case "Starts with":
                    return s => s.StartsWith(value);

                case "Ends with":
                    return s => s.EndsWith(value);

                case "Contains":
                    return s => s.Contains(value);

                default:
                    return default(Predicate<string>);
            }
        }
    }
}
