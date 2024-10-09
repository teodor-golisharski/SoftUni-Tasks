namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            string line = string.Empty;
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                while (line != null)
                {
                    line = reader.ReadLine();

                    if (count % 2 == 0)
                    {
                        string replaced = ReplaceSymbols(line);
                        string reversed = ReverseWords(replaced);
                        sb.AppendLine(reversed);
                    }
                    count++;
                }
            }
            return sb.ToString().TrimEnd();
        }

        private static string ReplaceSymbols(string line)
        {
            string[] array = { "-", ",", ".", "!", "?" };
            foreach (var item in array)
            {
                line = line.Replace(item, "@");
            }
            return line;
        }

        private static string ReverseWords(string replacedSymbols)
        {
            string[] reversedWords = replacedSymbols.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            return string.Join(" ", reversedWords);
        }
    }
}
