using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SantasSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\@(?<name>[A-za-z]+)[^\@\-\!\:\>]+\!(?<behavior>[GN])\!";
            Regex regex = new Regex(pattern);
            int key = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "end")
            {
                StringBuilder decrypted = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    int curr = (int)input[i] - key;
                    decrypted.Append((char)curr);
                }
                Match match = regex.Match(decrypted.ToString());
                string name = match.Groups["name"].Value.ToString();
                string behavior = match.Groups["behavior"].Value.ToString();
                if(behavior == "G")
                {
                    Console.WriteLine(name);
                }
                input = Console.ReadLine();
            }
        }
    }
}
