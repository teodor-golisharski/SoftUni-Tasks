using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];

            int start = 1;
            
            int end = 100;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    array[i] = ReadNumber(start, end);

                    if (array[i] <= start || array[i] > 100)
                    {
                        throw new ArgumentOutOfRangeException($"Your number is not in range {start} - {end}!");
                    }
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                    continue;
                }
                catch(ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {start} - {end}!");
                    i--;
                    continue;
                }
                start = array[i];
            }
            Console.WriteLine(String.Join(", ", array));
        }
        static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num;
            while(!int.TryParse(input, out num))
            {
                throw new FormatException("Invalid Number!");
            }

            return num;
        }
    }
}
