using System;

namespace NumOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());
            string status = "";

            double result = 0;
            switch (c)
            {
                case '+': result = n1 + n2; break;
                case '-': result = n1 - n2; break;
                case '*': result = n1 * n2; break;
                case '/': result = (double)n1 / n2; break;
                case '%': result = (double)n1 % n2; break;
            }
            if (c == '+' || c == '-' || c == '*')
            {
                if (result % 2 == 0)
                {
                    status = "even";
                }
                else
                {
                    status = "odd";
                }
                Console.WriteLine($"{n1} {c} {n2} = {result} - {status}");
            }
            if(c=='/')
            {
                if(n2==0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{n1} {c} {n2} = {result:f2}");
                }
            }
            if (c == '%')
            {
                if (n2 == 0)
                {
                    Console.WriteLine($"Cannot divide {n1} by zero");
                }
                else
                {
                    Console.WriteLine($"{n1} {c} {n2} = {result}");
                }
            }
        }
    }
}
