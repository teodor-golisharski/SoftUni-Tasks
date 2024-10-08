using System;
using System.Text;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int strength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                if (current == '>')
                {
                    strength += int.Parse(input[i + 1].ToString());
                    sb.Append(current);
                }
                else if(strength == 0)
                {
                    sb.Append(current);
                }
                else
                {
                    strength--;
                }
            }
            Console.WriteLine(sb);
        }
    }
}
