using System;
using System.Collections;
using System.Collections.Generic;

namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> chars = new Stack<char>();
            foreach(char c in input)
            {
                chars.Push(c);
            }
            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(chars.Pop());
            }
        }
    }
}
