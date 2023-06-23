using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch(type)
            {
                case "int":
                    int a = int.Parse(Console.ReadLine());
                    int b = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(a,b));
                    break;
                case "char":
                    char ac = char.Parse(Console.ReadLine());
                    char bc = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(ac, bc));
                    break;
                case "string":
                    string ast = Console.ReadLine();
                    string bs = Console.ReadLine();
                    Console.WriteLine(GetMax(ast, bs));
                    break;
            }
        }
        static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }
        static char GetMax(char a, char b)
        {
            if ((int)a > (int)b)
            {
                return a;
            }
            return b;
        }
        static string GetMax(string a, string b)
        {
            int result = a.CompareTo(b);
            if(result>0)
            {
                return a;
            }
            return b;
        }
    }
}
