using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\@\#+[A-Z][a-zA-Z0-9]{4,}[A-Z]\@\#+";
            Regex regex = new Regex(pattern);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                if(match.Success)
                {
                    string concat = "";
                    foreach (var item in input)
                    {
                        if(char.IsDigit(item))
                        {
                            concat += item;
                        }
                    }
                    if(concat == "")
                    {
                        concat += "00";
                    }
                    Console.WriteLine($"Product group: {concat}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
