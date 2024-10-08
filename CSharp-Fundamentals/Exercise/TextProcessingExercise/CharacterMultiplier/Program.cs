using System;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string str1 = input[0];
            string str2 = input[1];
            int result = Method1(str1, str2);
            Console.WriteLine(result);
        }
        static int Method1(string str1, string str2)
        {
            int sum = 0;
            if (str1.Length < str2.Length)
            {
                string temp = str1;
                str1 = str2;
                str2 = temp;
            }
            for (int i = 0; i < str1.Length; i++)
            {
                if (i > str2.Length - 1)
                {
                    sum += str1[i];
                }
                else
                {
                    int current = str1[i] * str2[i];
                    sum += current;
                }
            }
            return sum;
        }
    }
}
