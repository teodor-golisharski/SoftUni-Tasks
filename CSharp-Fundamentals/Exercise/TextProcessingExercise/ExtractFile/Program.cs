using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = { '\\', '.' };
            string[] path = Console.ReadLine().Split(separators);
            string fileName = path[path.Length - 2];
            string fileExtension = path[path.Length - 1];
            Console.WriteLine($"File name: {path[path.Length - 2]}");
            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}
