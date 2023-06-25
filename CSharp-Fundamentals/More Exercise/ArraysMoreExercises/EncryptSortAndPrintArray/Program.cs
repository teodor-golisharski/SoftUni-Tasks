using System;
using System.Linq;
using System.Collections.Generic;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                int len = s.Length;
                int sum = 0;
                for (int j = 0; j < len; j++)
                {
                    char sym = s[j];
                    switch ((int)sym)
                    {
                        case 97:
                        case 101:
                        case 105:
                        case 111:
                        case 117:
                        case 65:
                        case 69:
                        case 73: 
                        case 79:
                        case 85: sum += (int)sym * len; break;
                        default: sum += (int)sym / len;break;
                    }
                }
                arr[i] = sum;
            }
            Array.Sort(arr);
            foreach (var elements in arr)
            {
                Console.WriteLine(elements);
            }
        }
    }
}
