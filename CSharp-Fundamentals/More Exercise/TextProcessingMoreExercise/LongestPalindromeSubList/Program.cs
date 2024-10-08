using System;

namespace LongestPalindromeSubList
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();
            int maxLen = 0;
            // Check all single letter central points
            for (var c = 0; c < letters.Length; c++)
                maxLen = Math.Max(maxLen, PalindromeLen(letters, c, c));
            // Check all double letter central points
            for (var c = 0; c < letters.Length - 1; c++)
                maxLen = Math.Max(maxLen, PalindromeLen(letters, c, c + 1));
            Console.WriteLine(maxLen);

        }

        static int PalindromeLen(string letters, int leftIndex, int rightIndex)
        {
            while (leftIndex >= 0 && rightIndex < letters.Length
                && letters[leftIndex] == letters[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }
            return rightIndex - leftIndex - 1;
        }

    }
}
