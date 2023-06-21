using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int[] DNA = new int[n];
            int dnaSum = 0;
            int dnaCount = -1;
            int dnaIndex = -1;
            int samples = 0;

            int counter = 0;

            while (input != "Clone them!")
            {
                counter++;
                int[] currDna = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int currCount = 0;
                int currStartIndex = 0;
                int currEndIndex = 0;
                int currDnaSum = 0;
                bool best = false;

                int count = 0;
                for (int i = 0; i < currDna.Length; i++)
                {
                    if (currDna[i] != 1)
                    {
                        count = 0;
                        continue;
                    }
                    count++;
                    if (count > currCount)
                    {
                        currCount = count;
                        currEndIndex = i;
                    }
                }
                currStartIndex = currEndIndex - currCount + 1;
                currDnaSum = currDna.Sum();
                if (currCount > dnaCount)
                {
                    best = true;
                }
                else if (currCount == dnaCount)
                {
                    if (currStartIndex < dnaIndex)
                    {
                        best = true;
                    }
                    else if (currStartIndex == dnaIndex)
                    {
                        if (currDnaSum > dnaSum)
                        {
                            best = true;
                        }
                    }
                }
                
                if(best)
                {
                    DNA = currDna;
                    dnaCount = currCount;
                    dnaIndex = currStartIndex;
                    dnaSum = currDnaSum;
                    samples = counter;
                }
                input = Console.ReadLine();


            }
            Console.WriteLine($"Best DNA sample {samples} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}
