using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split().ToList();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "3:1")
            {
                int limit = data.Count - 1;
                int startIndex = int.Parse(input[1]);
                int endIndex = int.Parse(input[2]);
                if (limit < endIndex || endIndex < 0)
                        {
                            endIndex = limit;
                        }
                        if (limit < startIndex || startIndex < 0)
                        {
                            startIndex = 0;
                        }
                switch (input[0])
                {
                    case "merge":
                        string s = string.Empty;
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            s += data[startIndex];
                            data.RemoveAt(startIndex);
                        }
                        data.Insert(startIndex, s);
                        break;

                    case "divide":
                        var dividedList = new List<string>();
                        int partitions = int.Parse(input[2]);
                        string part = data[startIndex];
                        data.RemoveAt(startIndex);
                        int parts = part.Length / partitions;
                        for (int i = 0; i < partitions; i++)
                        {
                            if (i == partitions - 1)
                            {
                                dividedList.Add(part.Substring(i * parts));
                            }
                            else
                            {
                                dividedList.Add(part.Substring(i * parts, parts));
                            }
                        }
                        data.InsertRange(startIndex, dividedList);
                        break;
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", data));
        }
    }
}
