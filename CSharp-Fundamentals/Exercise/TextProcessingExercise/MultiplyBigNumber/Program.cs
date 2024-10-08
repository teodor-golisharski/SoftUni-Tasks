using System;
using System.Numerics;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger firstLine = BigInteger.Parse(Console.ReadLine());
            byte secondLine = byte.Parse(Console.ReadLine());
            firstLine *= secondLine;
            Console.WriteLine(firstLine);
        }
    }
}
