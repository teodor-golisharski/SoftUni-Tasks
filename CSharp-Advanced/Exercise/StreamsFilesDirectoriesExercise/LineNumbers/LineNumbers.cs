namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            int count = 1;
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        sb.AppendLine($"Line {count}: {line} ({LettersCount(line)})({PunctMarksCount(line)})");
                        line = reader.ReadLine();
                    }
                    writer.WriteLine(sb);
                }
            }
        }
        private static int LettersCount(string line)
        {
            int count = 0;
            foreach (char item in line)
            {
                if (char.IsLetter(item))
                {
                    count++;
                }
            }
            return count;
        }
        private static int PunctMarksCount(string line)
        {
            int count = 0;
            foreach (char item in line)
            {
                if (char.IsPunctuation(item))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
