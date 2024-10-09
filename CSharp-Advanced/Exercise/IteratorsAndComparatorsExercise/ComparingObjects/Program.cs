using System;
using System.Collections.Generic;
using System.Drawing;

namespace ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>(); 

            string command = Console.ReadLine();
            
            while (command != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person()
                { 
                    Name = tokens[0],
                    Age = int.Parse(tokens[1]),
                    Town = tokens[2]   
                };
                people.Add(person);
                command = Console.ReadLine();
            }
            int n = int.Parse(Console.ReadLine());
            Person chosenPerson = people[n - 1];
            int countOfMatches = 0;
            int numberOfNotEqualPeople = 0;
            int totalNumberOfPeople = 0;
            foreach (var item in people)
            {
                totalNumberOfPeople++;
                if(chosenPerson.CompareTo(item) == 0)
                {
                    countOfMatches++;
                }
                else
                {
                    numberOfNotEqualPeople++;
                }
            }
            if(countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {numberOfNotEqualPeople} {totalNumberOfPeople}");
            }
        }
    }
}
