using System;

namespace EnglishNameOfTheLastDigit
{
    class Program
    {
        static string Method(int a)
        {
            switch (a)
            {
                case 1: return "one";
                case 2: return "two"; 
                case 3: return "three"; 
                case 4: return "four"; 
                case 5: return "five"; 
                case 6: return "six"; 
                case 7: return "seven"; 
                case 8: return "eight";
                case 9: return "nine";
                default: return "zero";
            }
        }
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int a = num % 10;
            Console.WriteLine(Method(a));
        }
    }
}
