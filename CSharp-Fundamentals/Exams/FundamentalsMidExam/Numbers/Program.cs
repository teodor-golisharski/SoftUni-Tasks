using System;
using System.Collections.Generic;
using System.Linq;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> seq = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "Finish")
            {
                string command = input[0];
                int value = int.Parse(input[1]);
                switch (command)
                {
                    case "Add": seq.Add(value); break;
                    case "Remove": seq.Remove(value); break;
                    case "Replace":
                        Replace(seq, value, int.Parse(input[2]));
                        break;

                    case "Collapse":
                        Collapse(seq, value);
                        break;
                }
                input = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", seq));
        }
        static List<int> Replace(List<int> seq, int value, int replacement)
        {
            for (int i = 0; i < seq.Count; i++)
            {
                if (seq[i] == value)
                {
                    seq[i] = replacement;
                    return seq;
                }
            }
            return seq;
        }
        static List<int> Collapse(List<int> seq, int value)
        {
            for (int i = 0; i < seq.Count; i++)
            {
                if (seq[i] < value)
                {
                    seq.RemoveAt(i);
                    i--;
                }
            }
            return seq;
        }
    }
}
