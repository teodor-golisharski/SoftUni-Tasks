using System;
using System.Linq;
using System.Collections.Generic;

namespace ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split();
            bool flag = false; ;
            while (input[0] != "end")
            {
                switch (input[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(input[1]));
                        flag = true;
                        break;

                    case "Remove":
                        numbers.Remove(int.Parse(input[1]));
                        flag = true;
                        break;

                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(input[1]));
                        flag = true;
                        break;

                    case "Insert":
                        numbers.Insert(int.Parse(input[2]), int.Parse(input[1]));
                        flag = true;
                        break;

                    case "Contains":
                        if (numbers.Contains(int.Parse(input[1])))
                        {
                            Console.WriteLine("Yes");
                        }
                        else
                        {
                            Console.WriteLine("No such number");
                        }
                        break;

                    case "PrintEven":
                        PrintEven(numbers);
                        break;

                    case "PrintOdd":
                        PrintOdd(numbers);
                        break;

                    case "GetSum":
                        Console.WriteLine(numbers.Sum());
                        break;

                    case "Filter":
                        int cond = int.Parse(input[2]);
                        Filter(input[1], cond, numbers);
                        break;
                }
                input = Console.ReadLine().Split();
            }
            if (flag)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
        static void PrintEven(List<int> numbers)
        {
            string s = string.Empty;
            foreach (var item in numbers)
            {
                if (item % 2 == 0)
                {
                    s += item + " ";
                }
            }
            Console.WriteLine(string.Join(" ", s));
        }
        static void PrintOdd(List<int> numbers)
        {
            string s = string.Empty;
            foreach (var item in numbers)
            {
                if (item % 2 != 0)
                {
                    s += item + " ";
                }
            }
            Console.WriteLine(string.Join(" ", s));
        }
        static void Filter(string filter, int num, List<int> numbers)
        {
            switch (filter)
            {
                case "<":
                    foreach (var item in numbers)
                    {
                        if (item < num)
                        {
                            Console.Write($"{item} ");
                        }
                    }
                    Console.WriteLine(); 
                    break;
                case ">":
                    foreach (var item in numbers)
                    {
                        if (item > num)
                        {
                            Console.Write($"{item} ");
                        }
                    }
                    Console.WriteLine(); 
                    break;
                case ">=":
                    foreach (var item in numbers)
                    {
                        if (item >= num)
                        {
                            Console.Write($"{item} ");
                        }
                    }
                    Console.WriteLine(); 
                    break;
                case "<=":
                    foreach (var item in numbers)
                    {
                        if (item <= num)
                        {
                            Console.Write($"{item} ");
                        }
                    }
                    Console.WriteLine(); 
                    break;
            }
        }
    }
}
