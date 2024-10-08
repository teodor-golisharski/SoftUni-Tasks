using System;

namespace ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int stName = input.IndexOf('@');
                int endName = input.IndexOf('|');
                int length = endName - stName - 1;
                string name = input.Substring(stName + 1, length);
                int stAge = input.IndexOf('#');
                int endAge = input.IndexOf('*');
                int lenghtAge = endAge - stAge - 1;
                string age = input.Substring(stAge + 1, lenghtAge);
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
