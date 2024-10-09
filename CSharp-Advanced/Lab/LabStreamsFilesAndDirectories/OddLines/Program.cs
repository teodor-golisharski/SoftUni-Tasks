using System;
using System.IO;

namespace OddLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";
            using (StreamReader reader = new StreamReader(inputFilePath))
            {

                int count = 0;
                string s = reader.ReadLine();
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        if (count % 2 != 0)
                        {
                            writer.WriteLine(s);
                        }
                        count++;
                        s = reader.ReadLine();
                    }
                }
            }
        }
    }
}
