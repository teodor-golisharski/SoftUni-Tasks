using System;

namespace MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            char calcOperator = char.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(Calc(a,calcOperator,b));

        }
        static double Calc(int a, char calcOperator, int b)
        {
            double result = 0;
            switch (calcOperator)
            {
                case '+': result = a + b; break;
                case '-': result = a - b; break;
                case '*': result = a * b; break;
                case '/': result = a / b; break;
            }
            return result;
        }
    }
}
