using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<int> set = new HashSet<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Func<int, HashSet<int>, List<int>> func = (n, set) =>
            {
                List<int> result = new List<int>();
                for (int i = 1; i <= n; i++)
                {
                    bool flag = true;
                    foreach (var item in set)
                    {
                        if (i % item != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if(flag)
                    {
                        result.Add(i);
                    }
                }
                return result;
            };

            List<int> result = func(n, set);
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
