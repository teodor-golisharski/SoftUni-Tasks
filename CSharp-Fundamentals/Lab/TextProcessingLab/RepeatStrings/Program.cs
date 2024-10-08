using System;

namespace RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            foreach (var item in arr)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write(item);
                }
            }
        }
    }
}
