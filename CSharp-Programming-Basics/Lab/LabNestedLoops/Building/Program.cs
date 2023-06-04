using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
            string s = "";
            for (int i = floors; i >= 1; i--)
            {
                for (int j = 0; j < rooms; j++)
                {
                    if (i % 2 == 0 && i != floors)
                    {
                        s += "O" + i + j;
                    }
                    else if (i == floors)
                    {
                        s += "L" + i + j;
                    }
                    else
                    {
                        s += "A" + i + j;
                    }
                    Console.Write(s+ " ");
                    s = "";
                }
                Console.WriteLine(s + " ");
            }
        }
    }
}
